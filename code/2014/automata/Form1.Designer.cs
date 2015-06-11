namespace automata
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCheckPda = new System.Windows.Forms.Button();
            this.tbNFA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDFA1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDFA2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(83, 35);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(100, 20);
            this.tbInput.TabIndex = 0;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(60, 19);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check word";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(83, 70);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load NFA";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Location = new System.Drawing.Point(23, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 49);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Εργασία 1η";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input word:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Location = new System.Drawing.Point(23, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 49);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Εργασία 2η";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(60, 19);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(100, 23);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert to DFA";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCheckPda);
            this.groupBox3.Location = new System.Drawing.Point(23, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 49);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Εργασία 3η";
            // 
            // btnCheckPda
            // 
            this.btnCheckPda.Location = new System.Drawing.Point(60, 19);
            this.btnCheckPda.Name = "btnCheckPda";
            this.btnCheckPda.Size = new System.Drawing.Size(100, 23);
            this.btnCheckPda.TabIndex = 7;
            this.btnCheckPda.Text = "Load PDA";
            this.btnCheckPda.UseVisualStyleBackColor = true;
            this.btnCheckPda.Click += new System.EventHandler(this.btnCheckPda_Click);
            // 
            // tbNFA
            // 
            this.tbNFA.Location = new System.Drawing.Point(220, 47);
            this.tbNFA.Multiline = true;
            this.tbNFA.Name = "tbNFA";
            this.tbNFA.ReadOnly = true;
            this.tbNFA.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbNFA.Size = new System.Drawing.Size(185, 467);
            this.tbNFA.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "NFA";
            // 
            // tbDFA1
            // 
            this.tbDFA1.Location = new System.Drawing.Point(433, 47);
            this.tbDFA1.Multiline = true;
            this.tbDFA1.Name = "tbDFA1";
            this.tbDFA1.ReadOnly = true;
            this.tbDFA1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDFA1.Size = new System.Drawing.Size(230, 467);
            this.tbDFA1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DFA";
            // 
            // tbDFA2
            // 
            this.tbDFA2.Location = new System.Drawing.Point(697, 47);
            this.tbDFA2.Multiline = true;
            this.tbDFA2.Name = "tbDFA2";
            this.tbDFA2.ReadOnly = true;
            this.tbDFA2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDFA2.Size = new System.Drawing.Size(228, 467);
            this.tbDFA2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "DFA minimized";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 562);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDFA2);
            this.Controls.Add(this.tbDFA1);
            this.Controls.Add(this.tbNFA);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbInput);
            this.Name = "Form1";
            this.Text = "Εργασίες 1η και 2η (3η ημιτελής)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCheckPda;
        private System.Windows.Forms.TextBox tbNFA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDFA1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDFA2;
        private System.Windows.Forms.Label label4;
    }
}

