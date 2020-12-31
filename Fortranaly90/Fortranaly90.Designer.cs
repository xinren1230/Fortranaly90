namespace Fortranaly90
{
    partial class Fortranaly90
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fortranaly90));
            this.btn_Browse = new System.Windows.Forms.Button();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.Tree = new System.Windows.Forms.Button();
            this.Head_label = new System.Windows.Forms.Label();
            this.btn_author = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(206, 36);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 0;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(12, 39);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(182, 20);
            this.textBox_address.TabIndex = 1;
            // 
            // Tree
            // 
            this.Tree.Location = new System.Drawing.Point(108, 74);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(75, 23);
            this.Tree.TabIndex = 2;
            this.Tree.Text = "Tree";
            this.Tree.UseVisualStyleBackColor = true;
            this.Tree.Click += new System.EventHandler(this.Tree_Click);
            // 
            // Head_label
            // 
            this.Head_label.AutoSize = true;
            this.Head_label.Location = new System.Drawing.Point(13, 13);
            this.Head_label.Name = "Head_label";
            this.Head_label.Size = new System.Drawing.Size(73, 13);
            this.Head_label.TabIndex = 3;
            this.Head_label.Text = "F90 files path:";
            // 
            // btn_author
            // 
            this.btn_author.Location = new System.Drawing.Point(232, 83);
            this.btn_author.Name = "btn_author";
            this.btn_author.Size = new System.Drawing.Size(49, 23);
            this.btn_author.TabIndex = 4;
            this.btn_author.Text = "Author";
            this.btn_author.UseVisualStyleBackColor = true;
            this.btn_author.Click += new System.EventHandler(this.btn_author_Click);
            // 
            // Fortranaly90
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 119);
            this.Controls.Add(this.btn_author);
            this.Controls.Add(this.Head_label);
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.btn_Browse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fortranaly90";
            this.ShowIcon = false;
            this.Text = "Fortranaly90";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fortranaly90_FormClosing);
            this.Load += new System.EventHandler(this.Fortranaly90_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Button Tree;
        private System.Windows.Forms.Label Head_label;
        private System.Windows.Forms.Button btn_author;
    }
}

