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
            this.components = new System.ComponentModel.Container();
            this.groupBoxAutores = new System.Windows.Forms.GroupBox();
            this.buttonAgregarAutor = new System.Windows.Forms.Button();
            this.textBoxNombreAutor = new System.Windows.Forms.TextBox();
            this.labelNombreAutor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxComments = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxContCom = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeViewCom = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxCom = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAgregarCom = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxAutorCom = new System.Windows.Forms.ComboBox();
            this.labelThreadsTree = new System.Windows.Forms.Label();
            this.labelAutorCom = new System.Windows.Forms.Label();
            this.groupBoxThreads = new System.Windows.Forms.GroupBox();
            this.buttonAgregarThread = new System.Windows.Forms.Button();
            this.textBoxNombreThread = new System.Windows.Forms.TextBox();
            this.labelNombreThread = new System.Windows.Forms.Label();
            this.comboBoxAutorThread = new System.Windows.Forms.ComboBox();
            this.labelAutorThread = new System.Windows.Forms.Label();
            this.contextMenuStripNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new System.Windows.Forms.Panel();
            this.numericUpDownInicio = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCant = new System.Windows.Forms.NumericUpDown();
            this.labelInicio = new System.Windows.Forms.Label();
            this.labelCant = new System.Windows.Forms.Label();
            this.labelPaginación = new System.Windows.Forms.Label();
            this.groupBoxAutores.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxThreads.SuspendLayout();
            this.contextMenuStripNode.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCant)).BeginInit();
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
            this.groupBoxComments.Controls.Add(this.splitContainer1);
            this.groupBoxComments.Controls.Add(this.panel2);
            this.groupBoxComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxComments.Location = new System.Drawing.Point(0, 95);
            this.groupBoxComments.Name = "groupBoxComments";
            this.groupBoxComments.Size = new System.Drawing.Size(598, 296);
            this.groupBoxComments.TabIndex = 1;
            this.groupBoxComments.TabStop = false;
            this.groupBoxComments.Text = "Comentarios";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 68);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxContCom);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(592, 225);
            this.splitContainer1.SplitterDistance = 123;
            this.splitContainer1.TabIndex = 12;
            // 
            // textBoxContCom
            // 
            this.textBoxContCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxContCom.Location = new System.Drawing.Point(257, 0);
            this.textBoxContCom.Multiline = true;
            this.textBoxContCom.Name = "textBoxContCom";
            this.textBoxContCom.ReadOnly = true;
            this.textBoxContCom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxContCom.Size = new System.Drawing.Size(335, 123);
            this.textBoxContCom.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeViewCom);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 123);
            this.panel3.TabIndex = 10;
            // 
            // treeViewCom
            // 
            this.treeViewCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCom.Location = new System.Drawing.Point(0, 0);
            this.treeViewCom.Name = "treeViewCom";
            this.treeViewCom.Size = new System.Drawing.Size(257, 123);
            this.treeViewCom.TabIndex = 6;
            this.treeViewCom.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCom_AfterSelect);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBoxCom);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(507, 98);
            this.panel5.TabIndex = 10;
            // 
            // textBoxCom
            // 
            this.textBoxCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCom.Location = new System.Drawing.Point(0, 0);
            this.textBoxCom.Multiline = true;
            this.textBoxCom.Name = "textBoxCom";
            this.textBoxCom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCom.Size = new System.Drawing.Size(507, 98);
            this.textBoxCom.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonAgregarCom);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(507, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel4.Size = new System.Drawing.Size(85, 98);
            this.panel4.TabIndex = 9;
            // 
            // buttonAgregarCom
            // 
            this.buttonAgregarCom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAgregarCom.Location = new System.Drawing.Point(0, 65);
            this.buttonAgregarCom.Name = "buttonAgregarCom";
            this.buttonAgregarCom.Size = new System.Drawing.Size(85, 23);
            this.buttonAgregarCom.TabIndex = 8;
            this.buttonAgregarCom.Text = "Comentar";
            this.buttonAgregarCom.UseVisualStyleBackColor = true;
            this.buttonAgregarCom.Click += new System.EventHandler(this.buttonAgregarCom_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.comboBoxAutorCom);
            this.panel2.Controls.Add(this.labelThreadsTree);
            this.panel2.Controls.Add(this.labelAutorCom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 52);
            this.panel2.TabIndex = 11;
            // 
            // comboBoxAutorCom
            // 
            this.comboBoxAutorCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutorCom.FormattingEnabled = true;
            this.comboBoxAutorCom.Location = new System.Drawing.Point(41, 5);
            this.comboBoxAutorCom.Name = "comboBoxAutorCom";
            this.comboBoxAutorCom.Size = new System.Drawing.Size(152, 21);
            this.comboBoxAutorCom.TabIndex = 3;
            // 
            // labelThreadsTree
            // 
            this.labelThreadsTree.AutoSize = true;
            this.labelThreadsTree.Location = new System.Drawing.Point(4, 36);
            this.labelThreadsTree.Name = "labelThreadsTree";
            this.labelThreadsTree.Size = new System.Drawing.Size(46, 13);
            this.labelThreadsTree.TabIndex = 10;
            this.labelThreadsTree.Text = "Threads";
            // 
            // labelAutorCom
            // 
            this.labelAutorCom.AutoSize = true;
            this.labelAutorCom.Location = new System.Drawing.Point(3, 8);
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
            // contextMenuStripNode
            // 
            this.contextMenuStripNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarToolStripMenuItem});
            this.contextMenuStripNode.Name = "contextMenuStripNode";
            this.contextMenuStripNode.Size = new System.Drawing.Size(118, 26);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.labelPaginación);
            this.panel6.Controls.Add(this.labelCant);
            this.panel6.Controls.Add(this.labelInicio);
            this.panel6.Controls.Add(this.numericUpDownCant);
            this.panel6.Controls.Add(this.numericUpDownInicio);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(323, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(269, 52);
            this.panel6.TabIndex = 11;
            // 
            // numericUpDownInicio
            // 
            this.numericUpDownInicio.Location = new System.Drawing.Point(59, 21);
            this.numericUpDownInicio.Name = "numericUpDownInicio";
            this.numericUpDownInicio.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownInicio.TabIndex = 0;
            this.numericUpDownInicio.ValueChanged += new System.EventHandler(this.numericUpDownDesde_ValueChanged);
            // 
            // numericUpDownCant
            // 
            this.numericUpDownCant.Location = new System.Drawing.Point(195, 21);
            this.numericUpDownCant.Name = "numericUpDownCant";
            this.numericUpDownCant.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownCant.TabIndex = 1;
            this.numericUpDownCant.ValueChanged += new System.EventHandler(this.numericUpDownHasta_ValueChanged);
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Location = new System.Drawing.Point(21, 23);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(32, 13);
            this.labelInicio.TabIndex = 2;
            this.labelInicio.Text = "Inicio";
            // 
            // labelCant
            // 
            this.labelCant.AutoSize = true;
            this.labelCant.Location = new System.Drawing.Point(140, 23);
            this.labelCant.Name = "labelCant";
            this.labelCant.Size = new System.Drawing.Size(49, 13);
            this.labelCant.TabIndex = 3;
            this.labelCant.Text = "Cantidad";
            // 
            // labelPaginación
            // 
            this.labelPaginación.AutoSize = true;
            this.labelPaginación.Location = new System.Drawing.Point(3, 5);
            this.labelPaginación.Name = "labelPaginación";
            this.labelPaginación.Size = new System.Drawing.Size(60, 13);
            this.labelPaginación.TabIndex = 4;
            this.labelPaginación.Text = "Paginación";
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxThreads.ResumeLayout(false);
            this.groupBoxThreads.PerformLayout();
            this.contextMenuStripNode.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCant)).EndInit();
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNode;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelPaginación;
        private System.Windows.Forms.Label labelCant;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.NumericUpDown numericUpDownCant;
        private System.Windows.Forms.NumericUpDown numericUpDownInicio;
    }
}