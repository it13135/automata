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
    public partial class MainForm : Form
    {
        Automaton a = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            managexml mxml = new managexml();
            mxml.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                a = AutomatonFactory.CreateFromFile(ofd.FileName);
                btnConvert.Enabled = (a is NFA);
                btnCheck.Enabled = true;
                Draw(a);
            }
        }

        private void Draw(Automaton auto)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(this.BackColor);
            g.DrawImage(auto.ToBmp(), 20, 20, pictureBox1.Width - 40, pictureBox1.Height - 40);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (a.isWord(tbWord.Text))
                MessageBox.Show("Η λέξη ανήκει στη γλώσσα του αυτομάτου");
            else
                MessageBox.Show("Η λέξη δεν ανήκει στη γλώσσα του αυτομάτου");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (a is NFA)
            {
                DFA dfa = ((NFA)a).toDFA();
                Draw(dfa);
            }
        }
    }
}
