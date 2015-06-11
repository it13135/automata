using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public class Transition
    {

        public char readSymbol;
        public int startState;
        public int endState;

        public Transition(int sFrom, char sym, int sTo)
        {
            startState = sFrom;
            readSymbol = sym;
            endState = sTo;
        }
    }
}
