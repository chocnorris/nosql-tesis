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
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonActualizarMonitor = new System.Windows.Forms.Button();
            this.comboBoxShardList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.panelInfo.Controls.Add(this.panel2);
            this.panelInfo.Controls.Add(this.panel1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(405, 340);
            this.panelInfo.TabIndex = 2;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(0, 0);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(405, 245);
            this.textBoxInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonActualizarMonitor);
            this.panel1.Controls.Add(this.comboBoxShardList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxEstado);
            this.panel1.Controls.Add(this.labelEstado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 95);
            this.panel1.TabIndex = 6;
            // 
            // buttonActualizarMonitor
            // 
            this.buttonActualizarMonitor.AutoSize = true;
            this.buttonActualizarMonitor.Location = new System.Drawing.Point(13, 63);
            this.buttonActualizarMonitor.Name = "buttonActualizarMonitor";
            this.buttonActualizarMonitor.Size = new System.Drawing.Size(178, 23);
            this.buttonActualizarMonitor.TabIndex = 10;
            this.buttonActualizarMonitor.Text = "Actualizar";
            this.buttonActualizarMonitor.UseVisualStyleBackColor = true;
            // 
            // comboBoxShardList
            // 
            this.comboBoxShardList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShardList.FormattingEnabled = true;
            this.comboBoxShardList.Location = new System.Drawing.Point(71, 36);
            this.comboBoxShardList.Name = "comboBoxShardList";
            this.comboBoxShardList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxShardList.Sorted = true;
            this.comboBoxShardList.TabIndex = 9;
            this.comboBoxShardList.SelectedIndexChanged += new System.EventHandler(this.comboBoxShardList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Detalles";
            // 
            // textBoxEstado
            // 
            this.textBoxEstado.Location = new System.Drawing.Point(71, 10);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.ReadOnly = true;
            this.textBoxEstado.Size = new System.Drawing.Size(120, 20);
            this.textBoxEstado.TabIndex = 8;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(10, 13);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(40, 13);
            this.labelEstado.TabIndex = 6;
            this.labelEstado.Text = "Estado";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 245);
            this.panel2.TabIndex = 7;
            // 
            // InfoMongo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelInfo);
            this.Name = "InfoMongo";
            this.Size = new System.Drawing.Size(405, 340);
            this.panelInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonActualizarMonitor;
        private System.Windows.Forms.ComboBox comboBoxShardList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEstado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Panel panel2;
    }
}
