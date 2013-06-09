namespace MongoTest2.Paneles
{
    partial class InfoMongo
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
            this.panelInfo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTam = new System.Windows.Forms.Label();
            this.labelChunks = new System.Windows.Forms.Label();
            this.comboBoxShardList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.buttonActualizarMonitor = new System.Windows.Forms.Button();
            this.panelInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Controls.Add(this.buttonActualizarMonitor);
            this.panelInfo.Controls.Add(this.groupBox1);
            this.panelInfo.Controls.Add(this.comboBoxShardList);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.textBoxEstado);
            this.panelInfo.Controls.Add(this.labelEstado);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(405, 340);
            this.panelInfo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTam);
            this.groupBox1.Controls.Add(this.labelChunks);
            this.groupBox1.Location = new System.Drawing.Point(10, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
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
            this.comboBoxShardList.Location = new System.Drawing.Point(67, 32);
            this.comboBoxShardList.Name = "comboBoxShardList";
            this.comboBoxShardList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxShardList.Sorted = true;
            this.comboBoxShardList.TabIndex = 4;
            this.comboBoxShardList.SelectedIndexChanged += new System.EventHandler(this.comboBoxShardList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detalles";
            // 
            // textBoxEstado
            // 
            this.textBoxEstado.Location = new System.Drawing.Point(67, 6);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.ReadOnly = true;
            this.textBoxEstado.Size = new System.Drawing.Size(120, 20);
            this.textBoxEstado.TabIndex = 3;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(6, 9);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 0;
            this.labelEstado.Text = "Estado";
            // 
            // buttonActualizarMonitor
            // 
            this.buttonActualizarMonitor.AutoSize = true;
            this.buttonActualizarMonitor.Location = new System.Drawing.Point(268, 6);
            this.buttonActualizarMonitor.Name = "buttonActualizarMonitor";
            this.buttonActualizarMonitor.Size = new System.Drawing.Size(134, 23);
            this.buttonActualizarMonitor.TabIndex = 5;
            this.buttonActualizarMonitor.Text = "Actualizar";
            this.buttonActualizarMonitor.UseVisualStyleBackColor = true;
            // 
            // InfoMongo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInfo);
            this.Name = "InfoMongo";
            this.Size = new System.Drawing.Size(405, 340);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTam;
        private System.Windows.Forms.Label labelChunks;
        private System.Windows.Forms.ComboBox comboBoxShardList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEstado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Button buttonActualizarMonitor;
    }
}
