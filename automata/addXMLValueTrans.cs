using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automata
{
    public partial class addXMLValueTrans : AddForm
    {
        public addXMLValueTrans()
        {
            InitializeComponent();
        }
        public addXMLValueTrans(String title)
            : this()
        {
            setTitle(title);
        }

        private void addXMLValue_Load(object sender, EventArgs e)
        {

        }
        
        public override TreeNode getNode()
        {
            String initial = tbInitial.Text;
            String final = tbFinal.Text;
            String symbol = tbSymbol.Text;
            String stackOut = tbStackOut.Text;
            String stackIn = tbStackIn.Text;
            String nodeLabel = String.Format("Μετάωαση {0} {1} {2} {3} {3}", initial, symbol, final, stackOut, stackIn);
            TreeNode node = new TreeNode(nodeLabel);
            node.Tag = "transition";
            
            TreeNode nodeInitial = new TreeNode("Αρχική κατάσταση");
            nodeInitial.Tag = "attr, stateFrom";
            nodeInitial.Nodes.Add(new TreeNode(initial));
            node.Nodes.Add(nodeInitial);
            
            TreeNode nodeSymbol = new TreeNode("Σύμβολο");
            nodeSymbol.Tag = "attr, symbol";
            nodeSymbol.Nodes.Add(new TreeNode(symbol));
            node.Nodes.Add(nodeSymbol);
            
            TreeNode nodeFinal = new TreeNode("Τελική κατάσταση");
            nodeFinal.Tag = "attr, stateTo";
            nodeFinal.Nodes.Add(new TreeNode(final));
            node.Nodes.Add(nodeFinal);

            TreeNode nodeStackOut = new TreeNode("Έξοδος από στοίβα");
            nodeStackOut.Tag = "attr, stackOut";
            nodeStackOut.Nodes.Add(new TreeNode(stackOut));
            node.Nodes.Add(nodeStackOut);

            TreeNode nodeStackIn = new TreeNode("Είσοδος στη στοίβα");
            nodeStackIn.Tag = "attr, stackIn";
            nodeStackIn.Nodes.Add(new TreeNode(stackIn));
            node.Nodes.Add(nodeStackIn);
            return node;
        }
        
    }
}
