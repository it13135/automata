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
        DFA dfa = null;
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
            ofd.Filter = "All Files (*.nfa, *.dfa, *.pda)|*.nfa;*.dfa;*.pda|NFA Files (*.nfa) |*.nfa|DFA Files (*.dfa) | *.dfa|PDA Files (*.pda)|*.pda ";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                a = AutomatonFactory.CreateFromFile(ofd.FileName);
                btnConvert.Enabled = (a is NFA);
                btnCheck.Enabled = true;
                Draw(pbNFA, a);
            }
        }

        private void Draw(PictureBox pb, Automaton auto)
        {
            pb.Refresh();
            Graphics g = pb.CreateGraphics();
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawImage(auto.ToBmp(), 20, 20, pb.Width - 40, pb.Height - 40);
            g.Dispose();
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
                dfa = ((NFA)a).convertToDFA();
                Draw(pbNFA, dfa);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if ((a != null) && (a is NFA))
            {
                Draw(pbNFA, a);
                if (dfa != null)
                    Draw(pbNFA, dfa);
            }
        }

        private void tabFA_Selected(object sender, TabControlEventArgs e)
        {
            this.Invalidate();
        }
    }
}
