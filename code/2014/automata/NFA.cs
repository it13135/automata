using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace automata
{
    public class NFA:FA
    {
        //Λίστα καταστάσεων
        List<State> states = new List<State>();
        
        //Επιστρέφει την αρχική κατάσταση
        private State startState { get { return states.Where(x => x.IsStart == true).FirstOrDefault(); } }

        /// <summary>
        /// Ανάγνωση NFA από αρχείο
        /// </summary>
        /// <param name="filename">Όνομα του αρχείου</param>
        /// <returns>constructor</returns>
        public static NFA Load(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            for (int i = 0; i < lines.Count(); i++)
            {
                lines[i] = lines[i].Trim();
                lines[i] = Regex.Replace(lines[i], @"\s+", " "); //Αντικατάσταση πολλών spaces με 1
            }

            NFA res = new NFA();
            string[] strings = lines[0].Split(new char[]{' '});
            foreach (string str in strings)
	        {
                string lstr = str.Trim();
                switch (lstr.Count())
	            {
                    case 0:
                        break;
                    case 1:
                        char ch = lstr[0];
                        res.addSymbol(ch);
                        break;
		            default:
                        throw new Exception("Τα σύμβολα πρέπει να είναι απλοί χαρακτήρες χωριζόμενοι με κενά");
                        break;
	            }
	        }
            int numberOfStates;
            bool parse = int.TryParse(lines[1], out numberOfStates);
            if (parse == false)
                throw new Exception("Η 2η γραμμή του αρχείου εισόδου πρέπει να περιέχει ακέραιο αριθμό, που αντιστοιχεί στο πλήθος των καταστάσεων");
            int startStateNo;
            parse = int.TryParse(lines[2], out startStateNo);
            if (parse == false)
                throw new Exception("Η 3η γραμμή του αρχείου εισόδου πρέπει να περιέχει ακέραιο αριθμό, που αντιστοιχεί στον αριθμό της αρχικής κατάστασης");
            List<int> endStates = new List<int>();
            string[] strEndStates;
            strEndStates = lines[3].Split(new char[] { ' ' });
            foreach (string str in strEndStates)
            {
                int endStateNo;
                parse = int.TryParse(str, out endStateNo);
                if (parse == false)
                    throw new Exception("Η 4η γραμμή του αρχείου εισόδου πρέπει να περιέχει ακέραιους αριθμούς, χωρισμένους με κενά, που αντιστοιχεί στους αριθμούς των τελικών καταστάσεων");
                endStates.Add(endStateNo);
            }
            

            for (int i = 1; i <= numberOfStates; i++)
            {
                State state = new State(i);
                state.IsStart = (i == startStateNo);
                if (endStates.Where(x => x == i).Count() > 0)
                    state.IsEnd = true;
                res.addState(state);
            }
            for (int i = 4; i < lines.Count(); i++)
            {
                string a = lines[i];
                if (a.Length == 0)
                    continue;
                if (a.Length < 5)
                    throw new Exception("Δεν έχουν δοθεί σωστά οι μεταβάσεις: μετάβαση " + a);
                string[] transitions = a.Split(new char[] {' '});
                Int16 sState;
                char ch;
                Int16 eState;
                parse = Int16.TryParse(transitions[0], out sState);
                if (parse == false)
                    throw new Exception();
                if (transitions[1].Length == 1)
                    ch = transitions[1][0];
                else
                    throw new Exception();
                parse = Int16.TryParse(transitions[2], out eState);
                if (parse == false)
                    throw new Exception();
                res.addNewTransition(sState, ch, eState);

            }
            return res;

        }

        /// <summary>
        ///  Προσθήκη κατάστασης στη λίστα καταστάσεων του NFA
        /// </summary>
        /// <param name="state">Κατάσταση προς προσθήκη</param>
        public void addState(State state)
        {
            states.Add(state);
        }

        /// <summary>
        /// Προσθήκη συμβόλου στη λίστα με τα σύμβολα που αναγνωρίζει το αυτόματο
        /// </summary>
        /// <param name="symbol">Το σύμβολο που προστίθεται</param>
        public void addSymbol(char symbol)
        {
            symbols.Add(symbol);
        }

        /// <summary>
        /// Προσθήκη νέας μετάβασης στη λίστα με τις μεταβάσεις του αυτόματου
        /// </summary>
        /// <param name="from">Αριθμός κατάστασης αφετηρίας της μετάβασης</param>
        /// <param name="symbol">Σύμβολο που ενεργοποιθεί την μετάβαση</param>
        /// <param name="to">Αριθμός κατάστασης προορισμού της μετάβασης</param>
        public void addNewTransition(Int16 from, char symbol, Int16 to)
        {
            transitions.Add(new Transition(from, symbol, to));
        }
        
        /// <summary>
        /// Επιστρέφει μια λίστα καταστάσεων, συμπεριλαμβανόμενης της κατάστασης που
        /// περνιέται σαν όρισμα, στις οποίες μπορούμε να καταλήξουμε μέσω e-μεταβάσεων
        /// </summary>
        /// <param name="a">Κατάσταση αφετηρίας των e-μεταβάσεων</param>
        /// <returns>Λίστα καταστάσεων</returns>
        public List<State> eClosure(State a)
        {
            List<State> notVisitedYet = new List<State>(states);
            List<State> res = new List<State>();
            notVisitedYet.Remove(a);
            res.Add(a);
            int index = 0;
            while (notVisitedYet.Count>0)
            {
                State currState = res[index];
                List<Transition> eTransitions = this.transitions.Where(x => x.startState == currState.StateNo && x.readSymbol == 'e' 
                    && notVisitedYet.Count(y=>y.StateNo==x.endState)>0).ToList();
                foreach (Transition transition in eTransitions)
                {
                    State stateTo = getStateById(transition.endState);
                    res.Add(stateTo);
                    notVisitedYet.Remove(stateTo);
                }
                index++;
                if (res.Count<=index)
                    break;
            }
            return res;
        }

        /// <summary>
        /// Εύρεση κατάστασης βάσει του αριθμού κατάστασης
        /// </summary>
        /// <param name="_stateNo">Αριθμός κατάστασης</param>
        /// <returns>Κατάσταση που αντιστοιχεί στον αριθμό</returns>
        public State getStateById(int _stateNo)
        {
            return states.Where(x=>x.StateNo==_stateNo).FirstOrDefault();
        }

        /// <summary>
        /// Ελέγχει αν η λέξη ανήκει στη γλώσσα του αυτομάτου
        /// </summary>
        /// <param name="input">Λέξη προς έλεγχο</param>
        /// <returns>Ναι εφόσον ανήκει, Όχι εφόσον δεν ανήκει</returns>
        public bool isWord(String input)
        {
            State currState = states.Where(x=>x.IsStart==true).FirstOrDefault();
            TreeNode currTree = new TreeNode(null, '-', currState);
            List<TreeNode> currNodes = new List<TreeNode>();
            currNodes.Add(currTree);
            List<TreeNode> eClosures;
            foreach (char ch in input)
            {
                eClosures = new List<TreeNode>();
                foreach (TreeNode node in currNodes)
                {
                    foreach (State state in eClosure(node.getState()))
                    {
                        TreeNode temp = new TreeNode(node, '-', state);
                        eClosures.Add(temp);
                    }
                }
                currNodes = new List<TreeNode>();
                foreach (TreeNode tempNode in eClosures)
                {
                    currState = tempNode.getState();
                    var transitionChilds = transitions.Where(x => x.startState == currState.StateNo 
                                                             && x.readSymbol == ch);
                    foreach (Transition tr in transitionChilds)
                    {
                        TreeNode nd = new TreeNode(tempNode, ch, getStateById(tr.endState));
                        currNodes.Add(nd);
                    }
                }
                if (currNodes.Count == 0)
                    return false;
            }
            State g;
            if (currNodes.Where(x => x.getState().IsEnd == true).Count() == 0)
                return false;
            return true;
        }


        /// <summary>
        /// Μετατροπή σε DFA
        /// </summary>
        /// <returns>Τo DFA που αντιστοιχεί στο NFA</returns>
        public DFA ConvertToDFA()
        {
            DFA dfa = new DFA(this.symbols);
            SuperState startSuperState = new SuperState(true);
            foreach (State state in eClosure(startState))
            {
                startSuperState.Add(state);
            }
            dfa.AddSuperState(startSuperState);
            List<SuperState> notYetVisited = new List<SuperState>();
            notYetVisited.Add(startSuperState);
            while (true)
            {
                SuperState sp = notYetVisited[0];
                foreach (char ch in symbols)
                {
                    SuperState toBeAdded = new SuperState();
                    foreach(State st in sp)
                    {
                        List<Transition> ltr = this.transitions.Where(x => x.startState == st.StateNo && x.readSymbol == ch).ToList();
                        foreach (Transition tr in ltr)
                        {
                            State acceptState = states.Where(x => x.StateNo == tr.endState).FirstOrDefault();
                            if (!toBeAdded.Contains(acceptState))
                            {
                                foreach (State ecl in eClosure(acceptState))
                                {
                                    if (!toBeAdded.Contains(ecl))
                                        toBeAdded.Add(ecl);    
                                }
                            }
                        }
                    }
                    SuperState checkSuperState = dfa.getSuperState(toBeAdded);
                    if (checkSuperState == null) //αν δεν υπάρχει ήδη, να προστεθεί
                    {
                        notYetVisited.Add(toBeAdded);
                        dfa.AddSuperState(toBeAdded);
                        checkSuperState = toBeAdded;
                    }

                    dfa.AddTransition(sp, ch, checkSuperState);
                }
                notYetVisited.Remove(sp);
                if (notYetVisited.Count == 0)
                    break;
            }
            dfa.FixEndStates(this.states.Where(x => x.IsEnd == true).ToList());
            return dfa;
        }
    }
}
