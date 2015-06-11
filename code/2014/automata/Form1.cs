using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automata
{
    public partial class Form1 : Form
    {
        NFA nfa=null;
        Pda pda = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            while (nfa == null)
                loadNFA();
            bool isWord = nfa.isWord(tbInput.Text);
            if (isWord)
                MessageBox.Show("Η λέξη ανήκει στη γλώσσα του αυτομάτου");
            else
                MessageBox.Show("Η λέξη δεν ανήκει στη γλώσσα του αυτομάτου");
        }

        private void loadNFA()
        {
            openFileDialog1.Filter = "NFA files|*.nfa";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    nfa = NFA.Load(openFileDialog1.FileName);
                    tbNFA.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    tbDFA1.Text = "";
                    tbDFA2.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadNFA();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            while (nfa == null)
                loadNFA();
            DFA dfa = nfa.ConvertToDFA();
            tbDFA1.Text =  dfa.ToString();
            DrawForm df1 = new DrawForm(dfa, "DFA από αρχική μετατροπή");
            df1.Show();
            dfa.Minimize();
            tbDFA2.Text = dfa.ToString();
            DrawForm df2 = new DrawForm(dfa, "DFA μετά την ελαχιστοποίηση");
            df2.Show();
        }

        private void btnCheckPda_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDA files|*.pda";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    String test = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    pda = new Pda(test);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
