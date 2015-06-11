namespace automata
{
    partial class addXMLValueTrans
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
            this.tbInitial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFinal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStackOut = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStackIn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbInitial
            // 
            this.tbInitial.Location = new System.Drawing.Point(161, 26);
            this.tbInitial.Name = "tbInitial";
            this.tbInitial.Size = new System.Drawing.Size(100, 20);
            this.tbInitial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Αρχική κατάσταση:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Σύμβολο:";
            // 
            // tbSymbol
            // 
            this.tbSymbol.Location = new System.Drawing.Point(161, 58);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(100, 20);
            this.tbSymbol.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Τελική κατάσταση:";
            // 
            // tbFinal
            // 
            this.tbFinal.Location = new System.Drawing.Point(161, 90);
            this.tbFinal.Name = "tbFinal";
            this.tbFinal.Size = new System.Drawing.Size(100, 20);
            this.tbFinal.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Εξαγωγή από στοίβα:";
            // 
            // tbStackOut
            // 
            this.tbStackOut.Location = new System.Drawing.Point(161, 122);
            this.tbStackOut.Name = "tbStackOut";
            this.tbStackOut.Size = new System.Drawing.Size(100, 20);
            this.tbStackOut.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Εισαγωγή σε στοίβα:";
            // 
            // tbStackIn
            // 
            this.tbStackIn.Location = new System.Drawing.Point(161, 154);
            this.tbStackIn.Name = "tbStackIn";
            this.tbStackIn.Size = new System.Drawing.Size(100, 20);
            this.tbStackIn.TabIndex = 9;
            // 
            // addXMLValueTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbStackIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStackOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSymbol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInitial);
            this.Name = "addXMLValueTrans";
            this.Text = "Προσθήκη μετάβασης";
            this.Load += new System.EventHandler(this.addXMLValue_Load);
            this.Controls.SetChildIndex(this.tbInitial, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbSymbol, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbFinal, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbStackOut, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbStackIn, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInitial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStackOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStackIn;
    }
}