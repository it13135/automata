using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace automata
{
    public class NFA : Automaton
    {
        public DFA convertToDFA()
        {
            throw new System.NotImplementedException();
        }
        public NFA(List<State> _states)
            : base(_states)
        {
            ;
        }

        public override bool isWord(string word)
        {
            bool res = false;
            List<State> currentStates = new List<State>();
            currentStates.Add(InitialState);
            foreach (char chr in word)
            {
                List<State> nextStates = new List<State>();
                foreach (State currentState in currentStates)
                {
                    nextStates = nextStates.Union(currentState.getNextStates(chr)).Distinct().ToList();
                }
                currentStates = new List<State>().Union(nextStates).ToList();
            }
            int a = (from b in currentStates where b.isEndState select b).Count();
            return a > 0;
        }

        public DFA toDFA()
        {
            List<State> currentState = new List<State>();
            currentState.Add(this.InitialState);
            List<State> res = new List<State>();
            DFA dfa = new DFA(res);
            return dfa;
        }
    }
}
