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
    public partial class addXMLValue : AddForm
    {
        public addXMLValue()
        {
            InitializeComponent();
        }

        public addXMLValue(String title): this()
        {
            String formTitle = "";
            switch (title)
            {
                case "symbol":
                    formTitle = "Προσθήκη συμβόλοϋ";
                    lbl.Text = "Σύμβολο";
                    break;
                case "finalState":
                    formTitle = "Προσθήκη τελικής κατάστασης";
                    lbl.Text = "Τελική κατάσταση";
                    break;
            }
            setTitle(formTitle);
        }
        private void addXMLValue_Load(object sender, EventArgs e)
        {

        }

        public override TreeNode getNode()
        {
            TreeNode node = new TreeNode();
            node.Text = tbValue.Text;
            return node;
        }
        
    }
}
