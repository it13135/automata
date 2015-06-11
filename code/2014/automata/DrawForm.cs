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
    public partial class DrawForm : Form
    {
        Graphics g;
        Bitmap bmp;
        public DrawForm()
        {
            InitializeComponent();
        }
        public DrawForm(DFA dfa, String _title ="DFA")
            : this()
        {
            bmp = dfa.Draw();
            this.Text = _title;
            //g.DrawImage(bmp, 20, 20, bmp.Width, bmp.Height);            
        }

        private void DrawForm_Paint(object sender, PaintEventArgs e)
        {
            g = this.CreateGraphics();
            g.DrawImage(bmp, 20, 20, this.ClientRectangle.Width - 40, this.ClientRectangle.Height - 40);
        }

    }
}
