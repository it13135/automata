using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace automata
{
    public static class TransitionFactory
    {
        public static Transition Create(string _type, XAttribute stackOut, XAttribute stackIn)
        {
            Transition res = null;
            switch (_type)
            {
                case "NFA":
                case "DFA":
                    res = new Transition();
                    break;
                case "PDA":
                    res = new PDATransition(stackOut.Value, stackIn.Value);
                    break;
            }
            return res;
        }
    }
}
