using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public class SuperState: List<State>, IEquatable<SuperState>
    {
        public bool IsStart { get; set; }
        public bool IsEnd { get; set; }
        public Point Center { get; set; }
        public int SuperStateNo { get; set; }
        public override string ToString()
        {
            string res = "";
            if (this.Count == 0)
                res = "Ø";
            else
            {
                res = "{";
                foreach (State state in this)
                    res += state.StateNo.ToString() + ",";
                res = res.Substring(0, res.Length - 1);
                res += "}";
            }
            return res;
        }
        public SuperState(bool _isStart = false, bool _isEnd = false)
        {
            IsStart = _isStart;
            IsEnd = _isEnd;
        }


        bool IEquatable<SuperState>.Equals(SuperState other)
        {
            if (this.Count() != other.Count())
                return false;
            else
            {
                foreach (State state in this)
                {
                    if (!other.Contains(state))
                        return false;
                }
            }

            return true;
        }
    }
}
