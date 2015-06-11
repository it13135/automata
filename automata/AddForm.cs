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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        protected void setTitle(String title)
        {
            this.Text = title;
        }
        public virtual TreeNode getNode()
        {
            return null;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
