namespace automata
{
    partial class addXMLValue
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
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(161, 117);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(100, 20);
            this.tbValue.TabIndex = 0;
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(17, 117);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(110, 13);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Προσθήκη";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // addXMLValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.tbValue);
            this.Name = "addXMLValue";
            this.Text = "Προσθήκη";
            this.Load += new System.EventHandler(this.addXMLValue_Load);
            this.Controls.SetChildIndex(this.tbValue, 0);
            this.Controls.SetChildIndex(this.lbl, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lbl;
    }
}