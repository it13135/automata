using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Xml;

namespace automata
{
    public abstract class Automaton
    {
        public List<State> States { get; set; }
        public State InitialState
        {
            get
            {
                State initState = (from a in States where a.isStartState select a).FirstOrDefault();
                return initState;
            }
        }

        private List<Transition> transitions
        {
            get
            {
                List<Transition> res = new List<Transition>();
                foreach (State state in States)
                {
                    res.AddRange(state.Transitions);   
                }
                return res;
            }
        }

        public List<char> Symbols
        {
            get
            {
                List<char> res = new List<char>();
                foreach (State state in this.States )
                {
                   res = res.Union(state.getSymbols().Where(x=>x != 'ε')).Distinct().ToList();
                } 
                return res;
            }
        }

        public List<State> FinalStates
        {
            get
            {
                List<State> finalState = (from a in States where a.isEndState select a).ToList();
                return finalState;
            }
        }

        public int NumberOfStates
        {
            get
            {
                return States.Count();
            }
        }

        public virtual bool isWord(string word)
        {
            throw new System.NotImplementedException();
        }

        public Bitmap Draw()
        {
            throw new System.NotImplementedException();
        }

        public Automaton()
        {
        }
        public Automaton(List<State> _states)
        {
            States = _states;
            foreach (State state in States)
            {
                state.SetAutomaton(this);
            }
        }

        public Bitmap ToBmp()
        {
            int offset = 70;
            int radious = 30;
            int bitmapSize = 400;
            Point zeroPoint = new Point(0, 0);
            Point center = new Point(bitmapSize / 2, bitmapSize / 2);
            Point startPoint = new Point(center.X, offset);
            int points = NumberOfStates;
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
                State state = States[i];
                state.Center = new Point(origin.X, origin.Y);
                Pen statePen = new Pen(Color.Red, 2);
                Pen startStatePen = new Pen(Color.Blue, 2);
                if (state.isStartState)
                    gBmp.DrawCircle(startStatePen, zeroPoint, radious);
                else
                    gBmp.DrawCircle(statePen, zeroPoint, radious);
                if (state.isEndState)
                    gBmp.DrawCircle(statePen, zeroPoint, radious - 4);
                gBmp.ResetTransform();
            }
            //Γράψιμο των ονομασιών των καταστάσεων
            for (int i = 0; i < points; i++)
            {
                State state = States[i];
                gBmp.TranslateTransform(state.Center.X, state.Center.Y);
                String stateString = state.ToString();
                if (stateString.Length > 8)
                    stateString = stateString.Substring(0, stateString.Length / 2) + Environment.NewLine + stateString.Substring(stateString.Length / 2);
                gBmp.DrawString(stateString, myFont, new SolidBrush(Color.Black), 0, 0, sf);
                gBmp.TranslateTransform(-state.Center.X, -state.Center.Y);
            }

            //Σχεδίαση των μεταβάσεων από μια κατάσταση στον εαυτό της
            foreach (State _state in this.States)
            {
                string selfString = "";
                foreach (Transition transition in _state.Transitions.Where(z => z.NextState == _state))
                {
                    if (selfString != "")
                        selfString += ", ";
                    selfString += transition.Symbol.ToString();
                }
                if (selfString != "")
                {

                    Point selfCenter = new Point();
                    int dist = (int)_state.Center.DistanceTo(center);
                    double rotationAngle = center.Angle(_state.Center);
                    gBmp.TranslateTransform(center.X, center.Y);
                    gBmp.RotateTransform((float)rotationAngle);
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

                //Σχεδίαση των υπολοίπων σμεταβάσεων                 
                foreach (Transition transition in _state.Transitions.Where(z => z.NextState != _state))
                {
                    State stateTo = transition.NextState;


                    float rotationAngle = _state.Center.Angle(stateTo.Center);

                    gBmp.TranslateTransform((_state.Center.X + stateTo.Center.X) / 2, (_state.Center.Y + stateTo.Center.Y) / 2);
                    gBmp.RotateTransform(rotationAngle);
                    double distance = Math.Sqrt(Math.Pow(stateTo.Center.Y - _state.Center.Y, 2) + Math.Pow(stateTo.Center.X - _state.Center.X, 2));
                    int tx = (int)(distance / 2) - radious;
                    gBmp.DrawLine(arrowPen, -tx, 0, tx, 0);

                    gBmp.TranslateTransform(tx - 10, 10);
                    gBmp.RotateTransform(-rotationAngle);
                    gBmp.DrawString(transition.Symbol.ToString(), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), new SolidBrush(Color.Blue), 0, 0, sf);
                    gBmp.RotateTransform(rotationAngle);
                    gBmp.TranslateTransform(10 - tx, -10);
                    gBmp.RotateTransform(-rotationAngle);
                    gBmp.TranslateTransform(-(_state.Center.X + stateTo.Center.X) / 2, -(_state.Center.Y + stateTo.Center.Y) / 2);

                }
                gBmp.ResetTransform();
            }
            return bmp;
        }
    }
}
