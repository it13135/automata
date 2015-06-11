using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public class DFA:FA
    {
        //Λίστα υπερκαταστάσεων
        List<SuperState> superStates = new List<SuperState>();

        /// <summary>
        /// Μετατροπή του DFA σε κείμενο περιγραφής του
        /// </summary>
        /// <returns>Κείμενο που περιγράφει το DFA</returns>
        public override string ToString()
        {
            string res = "";
            foreach (char ch in symbols)
	        {
		        res += ch.ToString() + " ";
	        }
            res = res.Trim() + Environment.NewLine;
            res += superStates.Count.ToString() + Environment.NewLine;
            SuperState startSuperState = superStates.Where(x => x.IsStart == true).FirstOrDefault();
            res += startSuperState.ToString() + Environment.NewLine;
            List<SuperState> endSuperStates = superStates.Where(x => x.IsEnd == true).ToList();
            foreach (SuperState superState in endSuperStates)
            {
                res += superState.ToString() + " ";
            }
            res = res.Trim();
            res = res + Environment.NewLine;
            foreach (Transition transition in transitions)
            {
                res += getSuperStateByNo(transition.startState).ToString() + " ";
                res += transition.readSymbol.ToString() + " ";
                res += getSuperStateByNo(transition.endState).ToString() + Environment.NewLine;
            }
            return res;
        }

        /// <summary>
        /// Constructor, δημιουργεί του DFA, μαζί με τα σύμβολα που μπορεί να διαβάζει
        /// </summary>
        /// <param name="_symbols"></param>
        public DFA(List<char> _symbols)
        {
            foreach (char ch in _symbols)
            {
                symbols.Add(ch);    
            }
        }

        /// <summary>
        /// Ελαχιστοποίηση (Βελτιστοποίηση) του DFA
        /// </summary>
        public void Minimize()
        {
            //Αφαιρούμε όλες τις καταστάσεις που δεν είναι προσβάσιμες 
            superStates.RemoveAll(x => x.IsStart == false && this.transitions.Where(y => y.endState == x.SuperStateNo).Count() == 0);
            //Αφαιρούμε τις αντίστοιχες μεταβάσεις με αφετηρία τις καταστάσεις που μόλις αφαιρέθηκαν
            transitions.RemoveAll(x => this.superStates.Where(y => y.SuperStateNo == x.startState).Count()==0);
            
            List<EquivalentRecord> eqTable = new List<EquivalentRecord>();
            for (int i = 0; i < superStates.Count; i++)
            {
                for (int j = i; j < superStates.Count; j++)
                {
                    eqTable.Add(new EquivalentRecord(superStates[i].SuperStateNo, superStates[i].IsEnd, superStates[j].SuperStateNo, superStates[j].IsEnd));
                }
            }
            
            foreach (EquivalentRecord rec in eqTable.Where(x => x.State1 == x.State2))
            {
                rec.State = RecState.equivalent;
            }

            int dif = 0;
            foreach (EquivalentRecord rec in eqTable.Where(x => x.State1IsEnd != x.State2IsEnd))
            {
                rec.State = RecState.different;
                dif++;
            }
            while (dif > 0)
            {
                dif = 0;
                foreach (EquivalentRecord rec in eqTable.Where(x => x.State == RecState.unprocessed))
                {
                    foreach (Char _symbol in this.symbols)
                    {
                        int state1 = -1;
                        int state2 = -1;
                        int cnt = 1;
                        int endstate1 = -1;
                        int endstate2 = -1;


                        foreach (Transition _transition in transitions.Where(x => (x.startState == rec.State1
                                                                                && x.readSymbol == _symbol)
                                                                               || (x.startState == rec.State2
                                                                                && x.readSymbol == _symbol)).OrderBy(x => x.endState))
                        {
                            switch (cnt)
                            {
                                case 1:
                                    endstate1 = _transition.endState;
                                    break;
                                case 2:
                                    endstate2 = _transition.endState;
                                    break;
                                default:
                                    //Δε θα έπτρεπε να φτάσει εδώ
                                    break;
                            }
                            cnt++;
                        }
                        if (eqTable.Where(x => x.State1 == endstate1 && x.State2 == endstate2 && x.State == RecState.different).Count() > 0)
                        {
                            rec.State = RecState.different;
                            dif++;
                            continue;
                        }
                    }
                }
            }
            foreach (EquivalentRecord rec in eqTable.Where(x => x.State == RecState.unprocessed))
            {
                SuperState s1 = this.getSuperStateByNo(rec.State1);
                SuperState s2 = this.getSuperStateByNo(rec.State2);
                if ((s1==null)||(s2==null))
                        continue;
                foreach (State _state in s2.Where(x=>(s1.Where(y=>y.StateNo==x.StateNo).Count()==0)))
                {
                    s1.Add(_state);
                }
                foreach(Transition _transition in transitions.Where(x=>x.endState == s2.SuperStateNo))
                {
                    if ((transitions.Where(x=>x.endState == s1.SuperStateNo && x.startState == _transition.startState && x.readSymbol == _transition.readSymbol).Count()==0))
                        _transition.endState = s1.SuperStateNo;
                }
                transitions.RemoveAll(x => x.endState == s2.SuperStateNo);
                superStates.Remove(s2);
                transitions.RemoveAll(x => x.startState == rec.State2);
            }
        }

        /// <summary>
        /// Εύρεση της υπερκατάστασης, μέσω ενός αριθμού που την χαρακτηρίζει
        /// </summary>
        /// <param name="stateNo">Αριθμός της υπερκατάστασης</param>
        /// <returns></returns>
        public SuperState getSuperStateByNo(int stateNo)
        {
            SuperState res = superStates.Where(x => x.SuperStateNo == stateNo).FirstOrDefault();
            return res;
        }


        /// <summary>
        /// Εύρεση της υπερκατάστασης μέσα στο DFA
        /// </summary>
        /// <param name="_superState"></param>
        /// <returns></returns>
        public SuperState getSuperState(SuperState _superState)
        {
            int index = superStates.IndexOf(_superState);
            if (index == -1)
                return null;
            else
                return superStates[index];

        }

        /// <summary>
        /// Προσθήκη νέας υπερκατάστασης
        /// </summary>
        /// <param name="_superState"></param>
        public void AddSuperState(SuperState _superState)
        {
            _superState.SuperStateNo = superStates.Count()+1;
            superStates.Add(_superState);

        }

        /// <summary>
        /// Προσθήκη νέας μετάβασης
        /// </summary>
        /// <param name="_superStateFro">Υπερκατάσταση αφετηρίας</param>
        /// <param name="_symbol">Σύμβολο ενεργοποίησης της μετάβασης</param>
        /// <param name="_superStateTo">Υπερκατάσταση προορισμού</param>
        public void AddTransition(SuperState _superStateFro, char _symbol, SuperState _superStateTo)
        {
            this.transitions.Add(new Transition(_superStateFro.SuperStateNo, _symbol, _superStateTo.SuperStateNo));
        }

        /// <summary>
        /// Χαρακτηρισμός των υπερκαταστάσεων που περιέχουν καταστάσεις αποδοχής (τελικές)
        /// ως υπερκαταστάσεις αοποδοχής (τελικές)
        /// </summary>
        /// <param name="endStates"></param>
        public void FixEndStates(List<State> endStates)
        {
            foreach (SuperState superState in superStates)
                superState.Sort();
            foreach (State state in endStates)
                foreach (SuperState superState in superStates)
                    if (superState.Contains(state))
                        superState.IsEnd = true;
        }

        /// <summary>
        /// Σχεδιασμός του DFA
        /// </summary>
        /// <returns>Bitmap που περιέχει το σχέδιο του DFA</returns>
        public Bitmap  Draw()
        {
            int offset = 70;
            int radious = 30;
            int bitmapSize = 400;
            Point zeroPoint = new Point(0, 0);
            Point center = new Point(bitmapSize / 2, bitmapSize / 2);
            Point startPoint = new Point(center.X, offset);
            int points = superStates.Count();
            float angle = Convert.ToSingle(2 * Math.PI / points);
            int circumradius = (bitmapSize - 2 * offset) / 2;

            Font myFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);

            Pen arrowPen = new Pen(Color.Red);
            arrowPen.CustomEndCap = new AdjustableArrowCap(5, 5, true);

            Bitmap bmp = new Bitmap(bitmapSize, bitmapSize, PixelFormat.Format32bppArgb);
            Graphics gBmp = Graphics.FromImage(bmp);
            gBmp.SmoothingMode = SmoothingMode.AntiAlias;
            gBmp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //Σχεδιασμός των καταστάσεων
            for (int i = 0; i < points; i++)
			{
                gBmp.TranslateTransform(center.X, center.Y);
                gBmp.RotateTransform(i * 360 / points);
                gBmp.TranslateTransform(circumradius, 0);
                Point origin = gBmp.getPoint();                
                SuperState superState = superStates[i];
                superState.Center = new Point(origin.X, origin.Y);
                Pen statePen = new Pen(Color.Red, 2);
                Pen startStatePen = new Pen(Color.Blue, 2);
                if (superState.IsStart)
                    gBmp.DrawCircle(startStatePen, zeroPoint, radious);
                else
                    gBmp.DrawCircle(statePen, zeroPoint, radious);
                if (superState.IsEnd)
                    gBmp.DrawCircle(statePen, zeroPoint, radious - 4);
                gBmp.ResetTransform();
            }
            //Γράψιμο των ονομασιών των καταστάσεων
            for (int i = 0; i < points; i++)
            {
                SuperState superState = superStates[i];
                gBmp.TranslateTransform(superState.Center.X, superState.Center.Y);
                String stateString = superState.ToString();
                if (stateString.Length > 8)
                    stateString = stateString.Substring(0, stateString.Length / 2) + Environment.NewLine + stateString.Substring(stateString.Length / 2);
                gBmp.DrawString(stateString, myFont, new SolidBrush(Color.Black), 0, 0, sf);
                gBmp.TranslateTransform(-superState.Center.X, -superState.Center.Y);
            }

            //Σχεδίαση των μεταβάσεων από μια κατάσταση στον εαυτό της
            foreach (SuperState _super in this.superStates)
            {
                string selfString = "";
                foreach (Transition transition in this.transitions.Where(z => z.startState == z.endState && z.startState == _super.SuperStateNo))
                {
                    if (selfString !="")
                        selfString += ", ";
                    selfString += transition.readSymbol.ToString();
                }
                if (selfString != "")
                {
                    
                    Point selfCenter= new Point();
                    int dist = (int) _super.Center.DistanceTo(center);
                    double rotationAngle = center.Angle(_super.Center);
                    gBmp.TranslateTransform(center.X, center.Y);
                    gBmp.RotateTransform((float) rotationAngle);
                    gBmp.TranslateTransform(dist + 3 * radious / 2, 0);
                    gBmp.DrawCircle(new Pen(Color.Green), zeroPoint, radious / 2);
                    gBmp.TranslateTransform(radious / 2, 0);
                    gBmp.RotateTransform(70);
                    gBmp.DrawLine(arrowPen, -1, 0, 1, 0);
                    gBmp.RotateTransform(-70);
                    gBmp.TranslateTransform(5, 0);
                    Point origin = gBmp.getPoint();
                    gBmp.ResetTransform();
                    gBmp.TranslateTransform(origin.X, origin.Y);
                    gBmp.DrawString(selfString, myFont, new SolidBrush(Color.Black), 0, 0, sf);
                    gBmp.ResetTransform();
                }
            }
            gBmp.ResetTransform();
            //Σχεδίαση των υπολοίπων σμεταβάσεων 
            foreach (Transition transition in this.transitions.Where(z=>z.startState!=z.endState))
            {
                SuperState stateFrom = this.getSuperStateByNo(transition.startState);
                SuperState stateTo = this.getSuperStateByNo(transition.endState);


                float rotationAngle = stateFrom.Center.Angle(stateTo.Center);
                
                gBmp.TranslateTransform((stateFrom.Center.X + stateTo.Center.X) / 2, (stateFrom.Center.Y + stateTo.Center.Y) / 2);
                gBmp.RotateTransform(rotationAngle);
                double distance = Math.Sqrt(Math.Pow(stateTo.Center.Y - stateFrom.Center.Y, 2) + Math.Pow(stateTo.Center.X - stateFrom.Center.X, 2));
                int tx = (int)(distance / 2) - radious;
                gBmp.DrawLine(arrowPen, -tx, 0, tx, 0);

                gBmp.TranslateTransform(tx-10, 10);
                gBmp.RotateTransform(-rotationAngle);
                gBmp.DrawString(transition.readSymbol.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), new SolidBrush(Color.Blue), 0, 0, sf);
                gBmp.RotateTransform(rotationAngle);
                gBmp.TranslateTransform(10-tx, -10);
                gBmp.RotateTransform(-rotationAngle);
                gBmp.TranslateTransform(-(stateFrom.Center.X + stateTo.Center.X) / 2, -(stateFrom.Center.Y + stateTo.Center.Y) / 2);
            }
            return bmp;
        }
    }
}
