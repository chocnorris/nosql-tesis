namespace MongoTest2
{
    partial class Ventana
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
            this.buttonActualizarMonitor = new System.Windows.Forms.Button();
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonAgregarDatos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelChunks = new System.Windows.Forms.Label();
            this.comboBoxShardList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.labelTam = new System.Windows.Forms.Label();
            this.panelAcciones.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonActualizarMonitor
            // 
            this.buttonActualizarMonitor.AutoSize = true;
            this.buttonActualizarMonitor.Location = new System.Drawing.Point(12, 12);
            this.buttonActualizarMonitor.Name = "buttonActualizarMonitor";
            this.buttonActualizarMonitor.Size = new System.Drawing.Size(134, 23);
            this.buttonActualizarMonitor.TabIndex = 16;
            this.buttonActualizarMonitor.Text = "Actualizar";
            this.buttonActualizarMonitor.UseVisualStyleBackColor = true;
            this.buttonActualizarMonitor.Click += new System.EventHandler(this.buttonActualizarMonitor_Click);
            // 
            // panelAcciones
            // 
            this.panelAcciones.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelAcciones.Controls.Add(this.buttonRandom);
            this.panelAcciones.Controls.Add(this.buttonAgregarDatos);
            this.panelAcciones.Controls.Add(this.buttonActualizarMonitor);
            this.panelAcciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAcciones.Location = new System.Drawing.Point(0, 0);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(160, 420);
            this.panelAcciones.TabIndex = 1;
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(12, 70);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(134, 23);
            this.buttonRandom.TabIndex = 18;
            this.buttonRandom.Text = "Agregar Datos Aleatorios";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonAgregarDatos
            // 
            this.buttonAgregarDatos.Location = new System.Drawing.Point(12, 41);
            this.buttonAgregarDatos.Name = "buttonAgregarDatos";
            this.buttonAgregarDatos.Size = new System.Drawing.Size(134, 23);
            this.buttonAgregarDatos.TabIndex = 17;
            this.buttonAgregarDatos.Text = "Agregar Datos Manual";
            this.buttonAgregarDatos.UseVisualStyleBackColor = true;
            this.buttonAgregarDatos.Click += new System.EventHandler(this.buttonAgregarDatos_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.comboBoxShardList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxCant);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxEstado);
            this.panel1.Controls.Add(this.labelEstado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(160, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 420);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTam);
            this.groupBox1.Controls.Add(this.labelChunks);
            this.groupBox1.Location = new System.Drawing.Point(9, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 193);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // labelChunks
            // 
            this.labelChunks.AutoSize = true;
            this.labelChunks.Location = new System.Drawing.Point(7, 20);
            this.labelChunks.Name = "labelChunks";
            this.labelChunks.Size = new System.Drawing.Size(43, 13);
            this.labelChunks.TabIndex = 0;
            this.labelChunks.Text = "Chunks";
            // 
            // comboBoxShardList
            // 
            this.comboBoxShardList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShardList.FormattingEnabled = true;
            this.comboBoxShardList.Location = new System.Drawing.Point(66, 73);
            this.comboBoxShardList.Name = "comboBoxShardList";
            this.comboBoxShardList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxShardList.Sorted = true;
            this.comboBoxShardList.TabIndex = 28;
            this.comboBoxShardList.SelectedIndexChanged += new System.EventHandler(this.comboBoxShardList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Detalles";
            // 
            // textBoxCant
            // 
            this.textBoxCant.Location = new System.Drawing.Point(67, 38);
            this.textBoxCant.Name = "textBoxCant";
            this.textBoxCant.ReadOnly = true;
            this.textBoxCant.Size = new System.Drawing.Size(120, 20);
            this.textBoxCant.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Cantidad";
            // 
            // textBoxEstado
            // 
            this.textBoxEstado.Location = new System.Drawing.Point(67, 6);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.ReadOnly = true;
            this.textBoxEstado.Size = new System.Drawing.Size(120, 20);
            this.textBoxEstado.TabIndex = 24;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(6, 9);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 23;
            this.labelEstado.Text = "Estado";
            // 
            // labelTam
            // 
            this.labelTam.AutoSize = true;
            this.labelTam.Location = new System.Drawing.Point(7, 37);
            this.labelTam.Name = "labelTam";
            this.labelTam.Size = new System.Drawing.Size(46, 13);
            this.labelTam.TabIndex = 1;
            this.labelTam.Text = "Tamaño";
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAcciones);
            this.Name = "Ventana";
            this.Text = "Ventana";
            this.panelAcciones.ResumeLayout(false);
            this.panelAcciones.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonActualizarMonitor;
        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxShardList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEstado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelChunks;
        private System.Windows.Forms.Button buttonAgregarDatos;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Label labelTam;


    }
}