using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace automata
{
    public class PDA : Automaton
    {
        public PDA(List<State> _states)
            : base(_states)
        {
            ;
        }

        public override bool isWord(string word)
        {
            bool res = false;
            return res;
        }

    }
}
