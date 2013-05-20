namespace MongoTest2
{
    partial class VentanaDatos
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
            this.groupBoxAutores = new System.Windows.Forms.GroupBox();
            this.buttonAgregarAutor = new System.Windows.Forms.Button();
            this.textBoxNombreAutor = new System.Windows.Forms.TextBox();
            this.labelNombreAutor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxComments = new System.Windows.Forms.GroupBox();
            this.textBoxCom = new System.Windows.Forms.TextBox();
            this.treeViewCom = new System.Windows.Forms.TreeView();
            this.comboBoxAutorCom = new System.Windows.Forms.ComboBox();
            this.labelAutorCom = new System.Windows.Forms.Label();
            this.groupBoxThreads = new System.Windows.Forms.GroupBox();
            this.buttonAgregarThread = new System.Windows.Forms.Button();
            this.textBoxNombreThread = new System.Windows.Forms.TextBox();
            this.labelNombreThread = new System.Windows.Forms.Label();
            this.comboBoxAutorThread = new System.Windows.Forms.ComboBox();
            this.labelAutorThread = new System.Windows.Forms.Label();
            this.buttonAgregarCom = new System.Windows.Forms.Button();
            this.textBoxContCom = new System.Windows.Forms.TextBox();
            this.labelThreadsTree = new System.Windows.Forms.Label();
            this.groupBoxAutores.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxComments.SuspendLayout();
            this.groupBoxThreads.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAutores
            // 
            this.groupBoxAutores.Controls.Add(this.buttonAgregarAutor);
            this.groupBoxAutores.Controls.Add(this.textBoxNombreAutor);
            this.groupBoxAutores.Controls.Add(this.labelNombreAutor);
            this.groupBoxAutores.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxAutores.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAutores.Name = "groupBoxAutores";
            this.groupBoxAutores.Size = new System.Drawing.Size(598, 57);
            this.groupBoxAutores.TabIndex = 0;
            this.groupBoxAutores.TabStop = false;
            this.groupBoxAutores.Text = "Autores";
            // 
            // buttonAgregarAutor
            // 
            this.buttonAgregarAutor.Location = new System.Drawing.Point(215, 19);
            this.buttonAgregarAutor.Name = "buttonAgregarAutor";
            this.buttonAgregarAutor.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarAutor.TabIndex = 2;
            this.buttonAgregarAutor.Text = "Agregar";
            this.buttonAgregarAutor.UseVisualStyleBackColor = true;
            this.buttonAgregarAutor.Click += new System.EventHandler(this.buttonAgregarAutor_Click);
            // 
            // textBoxNombreAutor
            // 
            this.textBoxNombreAutor.Location = new System.Drawing.Point(57, 21);
            this.textBoxNombreAutor.Name = "textBoxNombreAutor";
            this.textBoxNombreAutor.Size = new System.Drawing.Size(152, 20);
            this.textBoxNombreAutor.TabIndex = 1;
            // 
            // labelNombreAutor
            // 
            this.labelNombreAutor.AutoSize = true;
            this.labelNombreAutor.Location = new System.Drawing.Point(7, 24);
            this.labelNombreAutor.Name = "labelNombreAutor";
            this.labelNombreAutor.Size = new System.Drawing.Size(44, 13);
            this.labelNombreAutor.TabIndex = 0;
            this.labelNombreAutor.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxComments);
            this.panel1.Controls.Add(this.groupBoxThreads);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 60);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel1.Size = new System.Drawing.Size(598, 391);
            this.panel1.TabIndex = 1;
            // 
            // groupBoxComments
            // 
            this.groupBoxComments.Controls.Add(this.labelThreadsTree);
            this.groupBoxComments.Controls.Add(this.textBoxContCom);
            this.groupBoxComments.Controls.Add(this.buttonAgregarCom);
            this.groupBoxComments.Controls.Add(this.textBoxCom);
            this.groupBoxComments.Controls.Add(this.treeViewCom);
            this.groupBoxComments.Controls.Add(this.comboBoxAutorCom);
            this.groupBoxComments.Controls.Add(this.labelAutorCom);
            this.groupBoxComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComments.Location = new System.Drawing.Point(0, 95);
            this.groupBoxComments.Name = "groupBoxComments";
            this.groupBoxComments.Size = new System.Drawing.Size(598, 296);
            this.groupBoxComments.TabIndex = 1;
            this.groupBoxComments.TabStop = false;
            this.groupBoxComments.Text = "Comentarios";
            // 
            // textBoxCom
            // 
            this.textBoxCom.Location = new System.Drawing.Point(3, 182);
            this.textBoxCom.Multiline = true;
            this.textBoxCom.Name = "textBoxCom";
            this.textBoxCom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCom.Size = new System.Drawing.Size(508, 108);
            this.textBoxCom.TabIndex = 7;
            // 
            // treeViewCom
            // 
            this.treeViewCom.Location = new System.Drawing.Point(3, 69);
            this.treeViewCom.Name = "treeViewCom";
            this.treeViewCom.Size = new System.Drawing.Size(235, 107);
            this.treeViewCom.TabIndex = 6;
            this.treeViewCom.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCom_AfterSelect);
            // 
            // comboBoxAutorCom
            // 
            this.comboBoxAutorCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutorCom.FormattingEnabled = true;
            this.comboBoxAutorCom.Location = new System.Drawing.Point(57, 22);
            this.comboBoxAutorCom.Name = "comboBoxAutorCom";
            this.comboBoxAutorCom.Size = new System.Drawing.Size(152, 21);
            this.comboBoxAutorCom.TabIndex = 3;
            // 
            // labelAutorCom
            // 
            this.labelAutorCom.AutoSize = true;
            this.labelAutorCom.Location = new System.Drawing.Point(10, 25);
            this.labelAutorCom.Name = "labelAutorCom";
            this.labelAutorCom.Size = new System.Drawing.Size(32, 13);
            this.labelAutorCom.TabIndex = 2;
            this.labelAutorCom.Text = "Autor";
            // 
            // groupBoxThreads
            // 
            this.groupBoxThreads.Controls.Add(this.buttonAgregarThread);
            this.groupBoxThreads.Controls.Add(this.textBoxNombreThread);
            this.groupBoxThreads.Controls.Add(this.labelNombreThread);
            this.groupBoxThreads.Controls.Add(this.comboBoxAutorThread);
            this.groupBoxThreads.Controls.Add(this.labelAutorThread);
            this.groupBoxThreads.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxThreads.Location = new System.Drawing.Point(0, 2);
            this.groupBoxThreads.Name = "groupBoxThreads";
            this.groupBoxThreads.Size = new System.Drawing.Size(598, 93);
            this.groupBoxThreads.TabIndex = 0;
            this.groupBoxThreads.TabStop = false;
            this.groupBoxThreads.Text = "Threads";
            // 
            // buttonAgregarThread
            // 
            this.buttonAgregarThread.Location = new System.Drawing.Point(338, 61);
            this.buttonAgregarThread.Name = "buttonAgregarThread";
            this.buttonAgregarThread.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarThread.TabIndex = 4;
            this.buttonAgregarThread.Text = "Agregar";
            this.buttonAgregarThread.UseVisualStyleBackColor = true;
            this.buttonAgregarThread.Click += new System.EventHandler(this.buttonAgregarThread_Click);
            // 
            // textBoxNombreThread
            // 
            this.textBoxNombreThread.Location = new System.Drawing.Point(57, 63);
            this.textBoxNombreThread.Name = "textBoxNombreThread";
            this.textBoxNombreThread.Size = new System.Drawing.Size(275, 20);
            this.textBoxNombreThread.TabIndex = 3;
            // 
            // labelNombreThread
            // 
            this.labelNombreThread.AutoSize = true;
            this.labelNombreThread.Location = new System.Drawing.Point(10, 66);
            this.labelNombreThread.Name = "labelNombreThread";
            this.labelNombreThread.Size = new System.Drawing.Size(35, 13);
            this.labelNombreThread.TabIndex = 2;
            this.labelNombreThread.Text = "Título";
            // 
            // comboBoxAutorThread
            // 
            this.comboBoxAutorThread.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutorThread.FormattingEnabled = true;
            this.comboBoxAutorThread.Location = new System.Drawing.Point(57, 30);
            this.comboBoxAutorThread.Name = "comboBoxAutorThread";
            this.comboBoxAutorThread.Size = new System.Drawing.Size(152, 21);
            this.comboBoxAutorThread.TabIndex = 1;
            // 
            // labelAutorThread
            // 
            this.labelAutorThread.AutoSize = true;
            this.labelAutorThread.Location = new System.Drawing.Point(10, 33);
            this.labelAutorThread.Name = "labelAutorThread";
            this.labelAutorThread.Size = new System.Drawing.Size(32, 13);
            this.labelAutorThread.TabIndex = 0;
            this.labelAutorThread.Text = "Autor";
            // 
            // buttonAgregarCom
            // 
            this.buttonAgregarCom.Location = new System.Drawing.Point(517, 267);
            this.buttonAgregarCom.Name = "buttonAgregarCom";
            this.buttonAgregarCom.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarCom.TabIndex = 8;
            this.buttonAgregarCom.Text = "Comentar";
            this.buttonAgregarCom.UseVisualStyleBackColor = true;
            this.buttonAgregarCom.Click += new System.EventHandler(this.buttonAgregarCom_Click);
            // 
            // textBoxContCom
            // 
            this.textBoxContCom.Location = new System.Drawing.Point(245, 69);
            this.textBoxContCom.Multiline = true;
            this.textBoxContCom.Name = "textBoxContCom";
            this.textBoxContCom.ReadOnly = true;
            this.textBoxContCom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxContCom.Size = new System.Drawing.Size(347, 107);
            this.textBoxContCom.TabIndex = 9;
            // 
            // labelThreadsTree
            // 
            this.labelThreadsTree.AutoSize = true;
            this.labelThreadsTree.Location = new System.Drawing.Point(10, 53);
            this.labelThreadsTree.Name = "labelThreadsTree";
            this.labelThreadsTree.Size = new System.Drawing.Size(46, 13);
            this.labelThreadsTree.TabIndex = 10;
            this.labelThreadsTree.Text = "Threads";
            // 
            // VentanaDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 454);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxAutores);
            this.Name = "VentanaDatos";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Agregar Datos";
            this.Load += new System.EventHandler(this.VentanaDatos_Load);
            this.groupBoxAutores.ResumeLayout(false);
            this.groupBoxAutores.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBoxComments.ResumeLayout(false);
            this.groupBoxComments.PerformLayout();
            this.groupBoxThreads.ResumeLayout(false);
            this.groupBoxThreads.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAutores;
        private System.Windows.Forms.Button buttonAgregarAutor;
        private System.Windows.Forms.TextBox textBoxNombreAutor;
        private System.Windows.Forms.Label labelNombreAutor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxThreads;
        private System.Windows.Forms.Button buttonAgregarThread;
        private System.Windows.Forms.TextBox textBoxNombreThread;
        private System.Windows.Forms.Label labelNombreThread;
        private System.Windows.Forms.ComboBox comboBoxAutorThread;
        private System.Windows.Forms.Label labelAutorThread;
        private System.Windows.Forms.GroupBox groupBoxComments;
        private System.Windows.Forms.ComboBox comboBoxAutorCom;
        private System.Windows.Forms.Label labelAutorCom;
        private System.Windows.Forms.TreeView treeViewCom;
        private System.Windows.Forms.TextBox textBoxCom;
        private System.Windows.Forms.Button buttonAgregarCom;
        private System.Windows.Forms.TextBox textBoxContCom;
        private System.Windows.Forms.Label labelThreadsTree;
    }
}