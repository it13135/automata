using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public class State: IEquatable<State>, IComparable<State>
    {
        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }
        public int StateNo { get; set;}
        public State(int _stateNo, bool _start = false, bool _end = false)
        {
            StateNo = _stateNo;
            IsStart = _start;
            IsEnd = _end;
        }

        bool IEquatable<State>.Equals(State other)
        {
            return (this.StateNo == other.StateNo);
        }

        int IComparable<State>.CompareTo(State other)
        {
            if (this.StateNo > other.StateNo)
                return 1;
            if (this.StateNo < other.StateNo)
                return -1;
            return 0;
        }
    }
}
