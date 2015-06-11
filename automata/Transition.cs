using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automata
{
    public class Transition
    {
        public State NextState { get; set; }
        public char Symbol { get; set; }
        public Transition()
        {
        }
    }
}
