using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace automata
{
    public class DFA : Automaton
    {
        public DFA minimized()
        {
            throw new System.NotImplementedException();
        }

        public DFA(List<State> _states)
            : base(_states)
        {
            ;
        }

        public override bool isWord(string word)
        {
            bool res = false;
            State currentState = InitialState;
            foreach (char chr in word)
            {
                currentState = currentState.NextState(chr);
                if (currentState == null)
                    return false;
            }
            return FinalStates.Contains(currentState);
        }

    }
}
