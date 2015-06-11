using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automata
{
    public class TreeNode
    {
        TreeNode parent;
        char symbol;
        State state;
        public TreeNode(TreeNode _parent, char sym, State _state)
        {
            symbol = sym;
            state = _state;
            parent = _parent;
        }
        public State getState()
        {
            return this.state;
        }
    }
}
