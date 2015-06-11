using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automata
{
    public class PDATransition : Transition
    {
        private char stakOutSymbol;
        private char stakInSymbol;
        public PDATransition(String _stackOut, String _stackIn)
        {
            stakOutSymbol = _stackOut[0];
            stakInSymbol = _stackIn[0];
        }
    }
}
