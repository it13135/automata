using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    class Pda
    {
        int numberOfStates;
        List<State> States;
        List<PdaTransition> transitions;
        List<Char> Stack;
        PdaSnapshot initialSnapshot;
        List<PdaSnapshot> currentSnapshot;
        public Pda(String _fileContent)
        {
            Stack = new List<Char>();
            States = new List<State>();
            transitions = new List<PdaTransition>();
            initialSnapshot = new PdaSnapshot(null);
            currentSnapshot = new List<PdaSnapshot>();
            using (StringReader reader = new StringReader(_fileContent))
            {
                Int32 _counter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    switch (_counter)
                    {
                        case 0:
                            if (Int32.TryParse(line.Trim(), out numberOfStates) == false)
                                throw new Exception("H πρώτη γραμμή του αρχείου δεν έχει την αναμενόμενη μορφή");
                            break;
                        case 1:
                            int _startState;
                            if (Int32.TryParse(line.Trim(), out _startState) == false)
                                throw new Exception("H δεύτερη γραμμή του αρχείου δεν έχει την αναμενόμενη μορφή");
                            State init = new State(_startState, true);
                            States.Add(init);
                            initialSnapshot.stateNo = init.StateNo;
                            currentSnapshot.Add(initialSnapshot);
                            break;
                        case 2:
                            List<string> _finalStates = line.Trim().Split(new char[] { ' ' }).ToList();
                            foreach (string _finalState in _finalStates)
                            {
                                int _fs;
                                if (Int32.TryParse(_finalState, out _fs) == false)
                                    throw new Exception("H τρίτη γραμμή του αρχείου δεν έχει την αναμενόμενη μορφή");
                                State s = States.Where(x => x.StateNo == _fs).FirstOrDefault();
                                if (s == null)
                                    States.Add(new State(_fs, false, true));
                                else
                                    s.IsEnd = true;
                            }
                            break;
                        default:
                            string _transition = line.Trim();
                            if (_transition == "")
                                break;
                            List<string> _transitionStrings = _transition.Split(new char[] { ' ' }).ToList();
                            int startState;
                            if (Int32.TryParse(_transitionStrings[0], out startState) == false)
                                throw new Exception("H γραμμή " + (_counter +1).ToString() + " του αρχείου δεν έχει την αναμενόμενη μορφή");
                            int endState;
                            if (Int32.TryParse(_transitionStrings[4], out endState) == false)
                                throw new Exception("H γραμμή " + (_counter + 1).ToString() + " του αρχείου δεν έχει την αναμενόμενη μορφή");
                            PdaTransition _tsn = new PdaTransition(startState, _transitionStrings[1][0], _transitionStrings[2][0], _transitionStrings[3][0], endState);
                            transitions.Add(_tsn);
                            break;
                    }
                    _counter++;
                }
                for (int i = 1; i <= numberOfStates; i++)
                {
                    if (States.Where(x=>x.StateNo == i).Count() == 0)
                        States.Add(new State(i));
                }
            }

        }
        public State getState(Int32 _state)
        {
            State state = new State(_state);
            return state;
        }
        public State getState(String _state)
        {
            Int32 _istate;
            if (Int32.TryParse(_state, out _istate) == false)
                throw new Exception();
            State state = new State(_istate);
            return state;
        }

        public bool isWord(String _word)
        {
            bool res = true;
            return res;
        }

        public List<PdaSnapshot> eclosure()
        {
            List<PdaSnapshot> res = new List<PdaSnapshot>();
            foreach (PdaSnapshot _snap in currentSnapshot)
            {
                foreach (PdaSnapshot _clos in eclosure(_snap))
                {
                    res.Add(_clos);
                }
            }
            return res;
        }

        public List<PdaSnapshot> eclosure(PdaSnapshot _snap)
        {
            List<PdaSnapshot> res = new List<PdaSnapshot>();
            foreach (PdaTransition _transition in transitions.Where(x=>x.readSymbol=='e' && x.startState == _snap.stateNo))
            {
                PdaSnapshot addSnap = new PdaSnapshot(_snap);
                addSnap.stateNo = _transition.endState;
                List<char> addStack = new List<char>(_snap.stack);
                if (!(_transition.outSymbol == 'e'))
                    addStack.RemoveAt(addStack.Count - 1);
                if (!(_transition.inSymbol == 'e'))
                    addStack.Add(_transition.inSymbol);
                addSnap.stack = addStack;
                res.Add(addSnap);
            }
            return res;
        }

        public void readSymbol(char _symbol)
        {
            foreach (PdaSnapshot _snap in eclosure())
            {
                foreach (PdaTransition _tran in transitions.Where(x=>x.readSymbol == _symbol))
                {
                    if (!(_tran.outSymbol == 'e'))
                    {
                        if (_snap.stack.LastOrDefault() == _tran.outSymbol)
                            ;
                    }

                }
            }
        }

    }
}
