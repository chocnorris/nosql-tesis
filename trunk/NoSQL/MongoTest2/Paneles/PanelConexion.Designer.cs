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
            this.comboBoxHost = new System.Windows.Forms.ComboBox();
            this.labelHost = new System.Windows.Forms.Label();
            this.labelDB = new System.Windows.Forms.Label();
            this.comboBoxDB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxHost
            // 
            this.comboBoxHost.FormattingEnabled = true;
            this.comboBoxHost.Location = new System.Drawing.Point(93, 44);
            this.comboBoxHost.Name = "comboBoxHost";
            this.comboBoxHost.Size = new System.Drawing.Size(203, 21);
            this.comboBoxHost.TabIndex = 10;
            this.comboBoxHost.Text = "localhost";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(12, 48);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(29, 13);
            this.labelHost.TabIndex = 8;
            this.labelHost.Text = "Host";
            // 
            // labelDB
            // 
            this.labelDB.AutoSize = true;
            this.labelDB.Location = new System.Drawing.Point(12, 20);
            this.labelDB.Name = "labelDB";
            this.labelDB.Size = new System.Drawing.Size(75, 13);
            this.labelDB.TabIndex = 7;
            this.labelDB.Text = "Base de datos";
            // 
            // comboBoxDB
            // 
            this.comboBoxDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDB.FormattingEnabled = true;
            this.comboBoxDB.Location = new System.Drawing.Point(93, 17);
            this.comboBoxDB.Name = "comboBoxDB";
            this.comboBoxDB.Size = new System.Drawing.Size(203, 21);
            this.comboBoxDB.TabIndex = 6;
            // 
            // PanelConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxHost);
            this.Controls.Add(this.labelHost);
            this.Controls.Add(this.labelDB);
            this.Controls.Add(this.comboBoxDB);
            this.Name = "PanelConexion";
            this.Size = new System.Drawing.Size(331, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHost;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.Label labelDB;
        private System.Windows.Forms.ComboBox comboBoxDB;
    }
}
