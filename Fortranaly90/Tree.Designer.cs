namespace Fortranaly90
{
    partial class Tree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tree));
            this.textBox_USE_Modules = new System.Windows.Forms.TextBox();
            this.label_main = new System.Windows.Forms.Label();
            this.label_module = new System.Windows.Forms.Label();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_module = new System.Windows.Forms.Panel();
            this.label_Usemodules = new System.Windows.Forms.Label();
            this.GraphvizLink = new System.Windows.Forms.LinkLabel();
            this.textBox_Graphvizcode = new System.Windows.Forms.TextBox();
            this.pictureBox_Graphviz = new System.Windows.Forms.PictureBox();
            this.label_Graphviz = new System.Windows.Forms.Label();
            this.label_photo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_findvar = new System.Windows.Forms.Button();
            this.textBox_findvar = new System.Windows.Forms.TextBox();
            this.label_var = new System.Windows.Forms.Label();
            this.btn_find_function_query = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_find = new System.Windows.Forms.TextBox();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Network = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graphviz)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_USE_Modules
            // 
            this.textBox_USE_Modules.Location = new System.Drawing.Point(685, 127);
            this.textBox_USE_Modules.Multiline = true;
            this.textBox_USE_Modules.Name = "textBox_USE_Modules";
            this.textBox_USE_Modules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_USE_Modules.Size = new System.Drawing.Size(289, 263);
            this.textBox_USE_Modules.TabIndex = 3;
            // 
            // label_main
            // 
            this.label_main.AutoSize = true;
            this.label_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_main.Location = new System.Drawing.Point(42, 13);
            this.label_main.Name = "label_main";
            this.label_main.Size = new System.Drawing.Size(70, 26);
            this.label_main.TabIndex = 4;
            this.label_main.Text = "label1";
            // 
            // label_module
            // 
            this.label_module.AutoSize = true;
            this.label_module.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_module.Location = new System.Drawing.Point(42, 88);
            this.label_module.Name = "label_module";
            this.label_module.Size = new System.Drawing.Size(70, 26);
            this.label_module.TabIndex = 5;
            this.label_module.Text = "label2";
            // 
            // panel_main
            // 
            this.panel_main.Location = new System.Drawing.Point(45, 53);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(304, 38);
            this.panel_main.TabIndex = 7;
            // 
            // panel_module
            // 
            this.panel_module.Location = new System.Drawing.Point(45, 127);
            this.panel_module.Name = "panel_module";
            this.panel_module.Size = new System.Drawing.Size(634, 686);
            this.panel_module.TabIndex = 8;
            // 
            // label_Usemodules
            // 
            this.label_Usemodules.AutoSize = true;
            this.label_Usemodules.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Usemodules.Location = new System.Drawing.Point(676, 85);
            this.label_Usemodules.Name = "label_Usemodules";
            this.label_Usemodules.Size = new System.Drawing.Size(152, 26);
            this.label_Usemodules.TabIndex = 9;
            this.label_Usemodules.Text = "Used modules";
            // 
            // GraphvizLink
            // 
            this.GraphvizLink.AutoSize = true;
            this.GraphvizLink.Location = new System.Drawing.Point(1239, 393);
            this.GraphvizLink.Name = "GraphvizLink";
            this.GraphvizLink.Size = new System.Drawing.Size(153, 13);
            this.GraphvizLink.TabIndex = 10;
            this.GraphvizLink.TabStop = true;
            this.GraphvizLink.Text = "http://www.webgraphviz.com/";
            this.GraphvizLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GraphvizLink_LinkClicked);
            // 
            // textBox_Graphvizcode
            // 
            this.textBox_Graphvizcode.Location = new System.Drawing.Point(991, 127);
            this.textBox_Graphvizcode.Multiline = true;
            this.textBox_Graphvizcode.Name = "textBox_Graphvizcode";
            this.textBox_Graphvizcode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Graphvizcode.Size = new System.Drawing.Size(401, 263);
            this.textBox_Graphvizcode.TabIndex = 12;
            // 
            // pictureBox_Graphviz
            // 
            this.pictureBox_Graphviz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Graphviz.Location = new System.Drawing.Point(685, 450);
            this.pictureBox_Graphviz.Name = "pictureBox_Graphviz";
            this.pictureBox_Graphviz.Size = new System.Drawing.Size(707, 333);
            this.pictureBox_Graphviz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Graphviz.TabIndex = 13;
            this.pictureBox_Graphviz.TabStop = false;
            this.pictureBox_Graphviz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox_Graphviz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox_Graphviz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox_Graphviz.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // label_Graphviz
            // 
            this.label_Graphviz.AutoSize = true;
            this.label_Graphviz.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Graphviz.Location = new System.Drawing.Point(982, 85);
            this.label_Graphviz.Name = "label_Graphviz";
            this.label_Graphviz.Size = new System.Drawing.Size(157, 26);
            this.label_Graphviz.TabIndex = 14;
            this.label_Graphviz.Text = "Graphviz Code";
            // 
            // label_photo
            // 
            this.label_photo.AutoSize = true;
            this.label_photo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_photo.Location = new System.Drawing.Point(676, 408);
            this.label_photo.Name = "label_photo";
            this.label_photo.Size = new System.Drawing.Size(155, 26);
            this.label_photo.TabIndex = 15;
            this.label_photo.Text = "Network Photo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_findvar);
            this.panel1.Controls.Add(this.textBox_findvar);
            this.panel1.Controls.Add(this.label_var);
            this.panel1.Controls.Add(this.btn_find_function_query);
            this.panel1.Controls.Add(this.label_photo);
            this.panel1.Controls.Add(this.label_Graphviz);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_find);
            this.panel1.Controls.Add(this.btn_Copy);
            this.panel1.Controls.Add(this.label_Usemodules);
            this.panel1.Controls.Add(this.btn_Network);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1418, 834);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // btn_findvar
            // 
            this.btn_findvar.Location = new System.Drawing.Point(1313, 47);
            this.btn_findvar.Name = "btn_findvar";
            this.btn_findvar.Size = new System.Drawing.Size(75, 23);
            this.btn_findvar.TabIndex = 18;
            this.btn_findvar.Text = "Query";
            this.btn_findvar.UseVisualStyleBackColor = true;
            this.btn_findvar.Click += new System.EventHandler(this.btn_findvar_Click);
            // 
            // textBox_findvar
            // 
            this.textBox_findvar.Location = new System.Drawing.Point(1091, 50);
            this.textBox_findvar.Name = "textBox_findvar";
            this.textBox_findvar.Size = new System.Drawing.Size(206, 20);
            this.textBox_findvar.TabIndex = 17;
            // 
            // label_var
            // 
            this.label_var.AutoSize = true;
            this.label_var.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_var.Location = new System.Drawing.Point(1086, 11);
            this.label_var.Name = "label_var";
            this.label_var.Size = new System.Drawing.Size(157, 25);
            this.label_var.TabIndex = 16;
            this.label_var.Text = "Find variable：";
            // 
            // btn_find_function_query
            // 
            this.btn_find_function_query.Location = new System.Drawing.Point(987, 48);
            this.btn_find_function_query.Name = "btn_find_function_query";
            this.btn_find_function_query.Size = new System.Drawing.Size(75, 23);
            this.btn_find_function_query.TabIndex = 4;
            this.btn_find_function_query.Text = "Query";
            this.btn_find_function_query.UseVisualStyleBackColor = true;
            this.btn_find_function_query.Click += new System.EventHandler(this.btn_find_function_query_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(676, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Find function or subroutine:";
            // 
            // textBox_find
            // 
            this.textBox_find.Location = new System.Drawing.Point(681, 50);
            this.textBox_find.Name = "textBox_find";
            this.textBox_find.Size = new System.Drawing.Size(289, 20);
            this.textBox_find.TabIndex = 2;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(1313, 88);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 23);
            this.btn_Copy.TabIndex = 1;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Network
            // 
            this.btn_Network.Location = new System.Drawing.Point(928, 787);
            this.btn_Network.Name = "btn_Network";
            this.btn_Network.Size = new System.Drawing.Size(212, 23);
            this.btn_Network.TabIndex = 0;
            this.btn_Network.Text = "General Network";
            this.btn_Network.UseVisualStyleBackColor = true;
            this.btn_Network.Click += new System.EventHandler(this.btn_Network_Click);
            // 
            // Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 836);
            this.Controls.Add(this.pictureBox_Graphviz);
            this.Controls.Add(this.textBox_Graphvizcode);
            this.Controls.Add(this.GraphvizLink);
            this.Controls.Add(this.panel_module);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.label_module);
            this.Controls.Add(this.label_main);
            this.Controls.Add(this.textBox_USE_Modules);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tree";
            this.ShowIcon = false;
            this.Text = "Tree";
            this.Load += new System.EventHandler(this.Tree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graphviz)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_USE_Modules;
        private System.Windows.Forms.Label label_main;
        private System.Windows.Forms.Label label_module;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_module;
        private System.Windows.Forms.Label label_Usemodules;
        private System.Windows.Forms.LinkLabel GraphvizLink;
        private System.Windows.Forms.TextBox textBox_Graphvizcode;
        private System.Windows.Forms.PictureBox pictureBox_Graphviz;
        private System.Windows.Forms.Label label_Graphviz;
        private System.Windows.Forms.Label label_photo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Network;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_find_function_query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_find;
        private System.Windows.Forms.Label label_var;
        private System.Windows.Forms.Button btn_findvar;
        private System.Windows.Forms.TextBox textBox_findvar;


    }
}