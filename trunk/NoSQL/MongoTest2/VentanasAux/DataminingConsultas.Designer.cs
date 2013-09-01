namespace NoSQL.VentanasAux
{
    partial class DataminingConsultas
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
            this.button1 = new System.Windows.Forms.Button();
            this.labelValorThread = new System.Windows.Forms.Label();
            this.comboBoxThread = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Valorar Thread";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelValorThread
            // 
            this.labelValorThread.AutoSize = true;
            this.labelValorThread.Location = new System.Drawing.Point(344, 33);
            this.labelValorThread.Name = "labelValorThread";
            this.labelValorThread.Size = new System.Drawing.Size(0, 13);
            this.labelValorThread.TabIndex = 1;
            // 
            // comboBoxThread
            // 
            this.comboBoxThread.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThread.FormattingEnabled = true;
            this.comboBoxThread.Location = new System.Drawing.Point(22, 33);
            this.comboBoxThread.Name = "comboBoxThread";
            this.comboBoxThread.Size = new System.Drawing.Size(152, 21);
            this.comboBoxThread.TabIndex = 2;
            this.comboBoxThread.SelectedIndexChanged += new System.EventHandler(this.comboBoxAutorThread_SelectedIndexChanged);
            // 
            // DataminingConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 99);
            this.Controls.Add(this.comboBoxThread);
            this.Controls.Add(this.labelValorThread);
            this.Controls.Add(this.button1);
            this.Name = "DataminingConsultas";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.DataminingConsultas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelValorThread;
        private System.Windows.Forms.ComboBox comboBoxThread;
    }
}