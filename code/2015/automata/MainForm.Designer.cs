namespace automata
{
    partial class MainForm
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
            this.btnEditXML = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pbNFA = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNFA)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditXML
            // 
            this.btnEditXML.Location = new System.Drawing.Point(68, 37);
            this.btnEditXML.Name = "btnEditXML";
            this.btnEditXML.Size = new System.Drawing.Size(95, 23);
            this.btnEditXML.TabIndex = 0;
            this.btnEditXML.Text = "Edit XML";
            this.btnEditXML.UseVisualStyleBackColor = true;
            this.btnEditXML.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(68, 170);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(95, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load XML";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbWord
            // 
            this.tbWord.Location = new System.Drawing.Point(101, 277);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(100, 20);
            this.tbWord.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Word to check";
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(68, 303);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(95, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check word";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(68, 380);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(95, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert to DFA";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.tbWord);
            this.panel1.Controls.Add(this.btnEditXML);
            this.panel1.Controls.Add(this.btnConvert);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnCheck);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 723);
            this.panel1.TabIndex = 8;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Enabled = false;
            this.btnMinimize.Location = new System.Drawing.Point(68, 430);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(95, 23);
            this.btnMinimize.TabIndex = 7;
            this.btnMinimize.Text = "Minimize DFA";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // pbNFA
            // 
            this.pbNFA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbNFA.Location = new System.Drawing.Point(228, 0);
            this.pbNFA.Name = "pbNFA";
            this.pbNFA.Size = new System.Drawing.Size(705, 723);
            this.pbNFA.TabIndex = 9;
            this.pbNFA.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 723);
            this.Controls.Add(this.pbNFA);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNFA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEditXML;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.PictureBox pbNFA;
    }
}

