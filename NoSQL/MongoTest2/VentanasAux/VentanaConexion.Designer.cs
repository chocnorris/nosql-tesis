namespace NoSQL
{
    partial class VentanaConexion
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
            this.comboBoxDB = new System.Windows.Forms.ComboBox();
            this.labelDB = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.buttonConectar = new System.Windows.Forms.Button();
            this.comboBoxHost = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxDB
            // 
            this.comboBoxDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDB.FormattingEnabled = true;
            this.comboBoxDB.Location = new System.Drawing.Point(93, 14);
            this.comboBoxDB.Name = "comboBoxDB";
            this.comboBoxDB.Size = new System.Drawing.Size(203, 21);
            this.comboBoxDB.TabIndex = 0;
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Location = new System.Drawing.Point(12, 17);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(75, 13);
            this.labelDB.TabIndex = 1;
            this.labelDB.Text = "Base de datos";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(12, 45);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(29, 13);
            this.labelHost.TabIndex = 2;
            this.labelHost.Text = "Host";
            // 
            // buttonConectar
            // 
            this.buttonConectar.Location = new System.Drawing.Point(117, 68);
            this.buttonConectar.Name = "buttonConectar";
            this.buttonConectar.Size = new System.Drawing.Size(75, 23);
            this.buttonConectar.TabIndex = 4;
            this.buttonConectar.Text = "Conectar";
            this.buttonConectar.UseVisualStyleBackColor = true;
            this.buttonConectar.Click += new System.EventHandler(this.buttonConectar_Click);
            // 
            // comboBoxHost
            // 
            this.comboBoxHost.FormattingEnabled = true;
            this.comboBoxHost.Location = new System.Drawing.Point(93, 41);
            this.comboBoxHost.Name = "comboBoxHost";
            this.comboBoxHost.Size = new System.Drawing.Size(203, 21);
            this.comboBoxHost.TabIndex = 5;
            this.comboBoxHost.Text = "localhost";
            // 
            // VentanaConexion
            // 
            this.AcceptButton = this.buttonConectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 103);
            this.Controls.Add(this.comboBoxHost);
            this.Controls.Add(this.buttonConectar);
            this.Controls.Add(this.labelHost);
            this.Controls.Add(this.labelDB);
            this.Controls.Add(this.comboBoxDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaConexion";
            this.Text = "Conectar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDB;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Button buttonConectar;
        private System.Windows.Forms.ComboBox comboBoxHost;
    }
}