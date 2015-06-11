using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    class PdaSnapshot
    {
        public List<Char> stack;
        public int stateNo;
        PdaSnapshot parent;
        public PdaSnapshot(PdaSnapshot _parent)
        {
            stack = new List<char>();
            parent= _parent;
        }
    }
}
