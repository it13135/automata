using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public class PdaTransition:Transition
    {
        public char outSymbol;
        public char inSymbol;
        public PdaTransition(int _startState, 
                             char _readSymbol, 
                             char _outSymbol, 
                             char _inSymbol, 
                             int _endState)
            :base(_startState, _readSymbol, _endState)
        {
            outSymbol = _outSymbol;
            inSymbol = _inSymbol;
        }

    }
}
