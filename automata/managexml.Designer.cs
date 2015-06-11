namespace automata
{
    partial class managexml
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(managexml));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuParent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChild = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChild = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteChild = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new automata.DropDownTreeView();
            this.menuParent.SuspendLayout();
            this.menuChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Αποθήκευση ως";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Αποθήκευση";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Άνοιγμα";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuParent
            // 
            this.menuParent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.menuParent.Name = "contextMenuStrip1";
            this.menuParent.Size = new System.Drawing.Size(132, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.addToolStripMenuItem.Text = "Προσθήκη";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // menuChild
            // 
            this.menuChild.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChild,
            this.deleteChild});
            this.menuChild.Name = "contextMenuStrip1";
            this.menuChild.Size = new System.Drawing.Size(132, 48);
            // 
            // addChild
            // 
            this.addChild.Name = "addChild";
            this.addChild.Size = new System.Drawing.Size(131, 22);
            this.addChild.Text = "Προσθήκη";
            this.addChild.Click += new System.EventHandler(this.addChild_Click);
            // 
            // deleteChild
            // 
            this.deleteChild.Name = "deleteChild";
            this.deleteChild.Size = new System.Drawing.Size(131, 22);
            this.deleteChild.Text = "Διαγραφή";
            this.deleteChild.Click += new System.EventHandler(this.deleteChild_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "empty.gif");
            this.imageList1.Images.SetKeyName(1, "none.gif");
            this.imageList1.Images.SetKeyName(2, "initial.gif");
            this.imageList1.Images.SetKeyName(3, "final.gif");
            this.imageList1.Images.SetKeyName(4, "initialandfinal.gif");
            // 
            // treeView1
            // 
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.LabelEdit = true;
            this.treeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(379, 301);
            this.treeView1.TabIndex = 3;
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // managexml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 427);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "managexml";
            this.Text = "managexml";
            this.Load += new System.EventHandler(this.managexml_Load);
            this.menuParent.ResumeLayout(false);
            this.menuChild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DropDownTreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip menuParent;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuChild;
        private System.Windows.Forms.ToolStripMenuItem addChild;
        private System.Windows.Forms.ToolStripMenuItem deleteChild;
        private System.Windows.Forms.ImageList imageList1;
    }
}