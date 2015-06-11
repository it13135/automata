using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    enum RecState { unprocessed, equivalent, different };
    class EquivalentRecord
    {
        public int State1 { get; set; }
        public int State2 { get; set; }
        public bool State1IsEnd { get; set; }
        public bool State2IsEnd { get; set; }
        public RecState State { get; set; }
        public EquivalentRecord(int _state1, bool _state1IsEnd, int _state2, bool _state2IsEnd)
        {
            State1 = _state1;
            State2 = _state2;
            State1IsEnd = _state1IsEnd;
            State2IsEnd = _state2IsEnd;
        }
    }
}
