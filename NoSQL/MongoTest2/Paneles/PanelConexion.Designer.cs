namespace NoSQL.Paneles
{
    partial class PanelConexion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxHost = new System.Windows.Forms.ComboBox();
            this.labelHost = new System.Windows.Forms.Label();
            this.labelDB = new System.Windows.Forms.Label();
            this.comboBoxDB = new System.Windows.Forms.ComboBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelExtra = new System.Windows.Forms.Panel();
            this.groupBoxReplSet = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewReplSet = new System.Windows.Forms.DataGridView();
            this.Host = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelNombreReplSet = new System.Windows.Forms.Label();
            this.textBoxNombreReplSet = new System.Windows.Forms.TextBox();
            this.checkBoxReplSet = new System.Windows.Forms.CheckBox();
            this.groupBoxExtra = new System.Windows.Forms.GroupBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.panelPrincipal.SuspendLayout();
            this.panelExtra.SuspendLayout();
            this.groupBoxReplSet.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReplSet)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBoxExtra.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxHost
            // 
            this.comboBoxHost.FormattingEnabled = true;
            this.comboBoxHost.Location = new System.Drawing.Point(98, 41);
            this.comboBoxHost.Name = "comboBoxHost";
            this.comboBoxHost.Size = new System.Drawing.Size(203, 21);
            this.comboBoxHost.TabIndex = 10;
            this.comboBoxHost.Text = "localhost";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(17, 45);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(29, 13);
            this.labelHost.TabIndex = 8;
            this.labelHost.Text = "Host";
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Location = new System.Drawing.Point(17, 17);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(75, 13);
            this.labelDB.TabIndex = 7;
            this.labelDB.Text = "Base de datos";
            // 
            // comboBoxDB
            // 
            this.comboBoxDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDB.FormattingEnabled = true;
            this.comboBoxDB.Location = new System.Drawing.Point(98, 14);
            this.comboBoxDB.Name = "comboBoxDB";
            this.comboBoxDB.Size = new System.Drawing.Size(203, 21);
            this.comboBoxDB.TabIndex = 6;
            this.comboBoxDB.SelectedIndexChanged += new System.EventHandler(this.comboBoxDB_SelectedIndexChanged);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.labelDB);
            this.panelPrincipal.Controls.Add(this.comboBoxHost);
            this.panelPrincipal.Controls.Add(this.comboBoxDB);
            this.panelPrincipal.Controls.Add(this.labelHost);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(399, 74);
            this.panelPrincipal.TabIndex = 11;
            // 
            // panelExtra
            // 
            this.panelExtra.Controls.Add(this.groupBoxReplSet);
            this.panelExtra.Controls.Add(this.groupBoxExtra);
            this.panelExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExtra.Location = new System.Drawing.Point(0, 74);
            this.panelExtra.Name = "panelExtra";
            this.panelExtra.Size = new System.Drawing.Size(399, 387);
            this.panelExtra.TabIndex = 12;
            // 
            // groupBoxReplSet
            // 
            this.groupBoxReplSet.Controls.Add(this.panel1);
            this.groupBoxReplSet.Controls.Add(this.panel2);
            this.groupBoxReplSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxReplSet.Location = new System.Drawing.Point(0, 89);
            this.groupBoxReplSet.Name = "groupBoxReplSet";
            this.groupBoxReplSet.Size = new System.Drawing.Size(399, 298);
            this.groupBoxReplSet.TabIndex = 12;
            this.groupBoxReplSet.TabStop = false;
            this.groupBoxReplSet.Text = "Múltiples Hosts";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewReplSet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 226);
            this.panel1.TabIndex = 2;
            // 
            // dataGridViewReplSet
            // 
            this.dataGridViewReplSet.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewReplSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewReplSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReplSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Host,
            this.Port});
            this.dataGridViewReplSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReplSet.Enabled = false;
            this.dataGridViewReplSet.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReplSet.Name = "dataGridViewReplSet";
            this.dataGridViewReplSet.Size = new System.Drawing.Size(333, 226);
            this.dataGridViewReplSet.TabIndex = 1;
            // 
            // Host
            // 
            this.Host.HeaderText = "Host";
            this.Host.Name = "Host";
            this.Host.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Host.Width = 170;
            // 
            // Port
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.Port.DefaultCellStyle = dataGridViewCellStyle1;
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelNombreReplSet);
            this.panel2.Controls.Add(this.textBoxNombreReplSet);
            this.panel2.Controls.Add(this.checkBoxReplSet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 53);
            this.panel2.TabIndex = 3;
            // 
            // labelNombreReplSet
            // 
            this.labelNombreReplSet.AutoSize = true;
            this.labelNombreReplSet.Location = new System.Drawing.Point(13, 27);
            this.labelNombreReplSet.Name = "labelNombreReplSet";
            this.labelNombreReplSet.Size = new System.Drawing.Size(44, 13);
            this.labelNombreReplSet.TabIndex = 11;
            this.labelNombreReplSet.Text = "Nombre";
            // 
            // textBoxNombreReplSet
            // 
            this.textBoxNombreReplSet.Enabled = false;
            this.textBoxNombreReplSet.Location = new System.Drawing.Point(94, 24);
            this.textBoxNombreReplSet.Name = "textBoxNombreReplSet";
            this.textBoxNombreReplSet.Size = new System.Drawing.Size(203, 20);
            this.textBoxNombreReplSet.TabIndex = 10;
            this.textBoxNombreReplSet.Text = "rs0";
            // 
            // checkBoxReplSet
            // 
            this.checkBoxReplSet.AutoSize = true;
            this.checkBoxReplSet.Location = new System.Drawing.Point(3, 4);
            this.checkBoxReplSet.Name = "checkBoxReplSet";
            this.checkBoxReplSet.Size = new System.Drawing.Size(149, 17);
            this.checkBoxReplSet.TabIndex = 0;
            this.checkBoxReplSet.Text = "Conectar a múltiples hosts";
            this.checkBoxReplSet.UseVisualStyleBackColor = true;
            this.checkBoxReplSet.CheckedChanged += new System.EventHandler(this.checkBoxReplSet_CheckedChanged);
            // 
            // groupBoxExtra
            // 
            this.groupBoxExtra.Controls.Add(this.labelPass);
            this.groupBoxExtra.Controls.Add(this.labelUsuario);
            this.groupBoxExtra.Controls.Add(this.textBoxUsuario);
            this.groupBoxExtra.Controls.Add(this.textBoxPass);
            this.groupBoxExtra.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxExtra.Location = new System.Drawing.Point(0, 0);
            this.groupBoxExtra.Name = "groupBoxExtra";
            this.groupBoxExtra.Size = new System.Drawing.Size(399, 89);
            this.groupBoxExtra.TabIndex = 11;
            this.groupBoxExtra.TabStop = false;
            this.groupBoxExtra.Text = "Opciones";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(16, 56);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(61, 13);
            this.labelPass.TabIndex = 10;
            this.labelPass.Text = "Contraseña";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Location = new System.Drawing.Point(16, 30);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(43, 13);
            this.labelUsuario.TabIndex = 9;
            this.labelUsuario.Text = "Usuario";
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(97, 27);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(203, 20);
            this.textBoxUsuario.TabIndex = 0;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(97, 53);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(203, 20);
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.UseSystemPasswordChar = true;
            // 
            // PanelConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelExtra);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "PanelConexion";
            this.Size = new System.Drawing.Size(399, 461);
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.panelExtra.ResumeLayout(false);
            this.groupBoxReplSet.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReplSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxExtra.ResumeLayout(false);
            this.groupBoxExtra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHost;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.ComboBox comboBoxDB;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelExtra;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.GroupBox groupBoxExtra;
        private System.Windows.Forms.GroupBox groupBoxReplSet;
        private System.Windows.Forms.DataGridView dataGridViewReplSet;
        private System.Windows.Forms.CheckBox checkBoxReplSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNombreReplSet;
        private System.Windows.Forms.TextBox textBoxNombreReplSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Host;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
    }
}
