namespace NoSQL
{
    partial class VentanaConsultas
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
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.panelFoto = new System.Windows.Forms.Panel();
            this.comboBoxAutor = new System.Windows.Forms.ComboBox();
            this.labelAutor = new System.Windows.Forms.Label();
            this.textBoxThreads = new System.Windows.Forms.TextBox();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.listBoxPop = new System.Windows.Forms.ListBox();
            this.labelPop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.panelFoto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxFoto.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(120, 117);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFoto.TabIndex = 0;
            this.pictureBoxFoto.TabStop = false;
            // 
            // panelFoto
            // 
            this.panelFoto.Controls.Add(this.pictureBoxFoto);
            this.panelFoto.Location = new System.Drawing.Point(212, 12);
            this.panelFoto.Name = "panelFoto";
            this.panelFoto.Size = new System.Drawing.Size(120, 117);
            this.panelFoto.TabIndex = 1;
            // 
            // comboBoxAutor
            // 
            this.comboBoxAutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAutor.FormattingEnabled = true;
            this.comboBoxAutor.Location = new System.Drawing.Point(12, 59);
            this.comboBoxAutor.Name = "comboBoxAutor";
            this.comboBoxAutor.Size = new System.Drawing.Size(152, 21);
            this.comboBoxAutor.TabIndex = 2;
            this.comboBoxAutor.SelectedIndexChanged += new System.EventHandler(this.comboBoxAutor_SelectedIndexChanged);
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Location = new System.Drawing.Point(12, 17);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(32, 13);
            this.labelAutor.TabIndex = 3;
            this.labelAutor.Text = "Autor";
            // 
            // textBoxThreads
            // 
            this.textBoxThreads.Location = new System.Drawing.Point(12, 109);
            this.textBoxThreads.Name = "textBoxThreads";
            this.textBoxThreads.ReadOnly = true;
            this.textBoxThreads.Size = new System.Drawing.Size(152, 20);
            this.textBoxThreads.TabIndex = 5;
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.Location = new System.Drawing.Point(12, 33);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(152, 20);
            this.textBoxAutor.TabIndex = 6;
            this.textBoxAutor.TextChanged += new System.EventHandler(this.textBoxAutor_TextChanged);
            // 
            // listBoxPop
            // 
            this.listBoxPop.FormattingEnabled = true;
            this.listBoxPop.Location = new System.Drawing.Point(12, 186);
            this.listBoxPop.Name = "listBoxPop";
            this.listBoxPop.Size = new System.Drawing.Size(152, 134);
            this.listBoxPop.TabIndex = 7;
            // 
            // labelPop
            // 
            this.labelPop.AutoSize = true;
            this.labelPop.Location = new System.Drawing.Point(13, 167);
            this.labelPop.Name = "labelPop";
            this.labelPop.Size = new System.Drawing.Size(136, 13);
            this.labelPop.TabIndex = 8;
            this.labelPop.Text = "Top 10 - Autores Populares";
            // 
            // VentanaConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 338);
            this.Controls.Add(this.labelPop);
            this.Controls.Add(this.listBoxPop);
            this.Controls.Add(this.textBoxAutor);
            this.Controls.Add(this.textBoxThreads);
            this.Controls.Add(this.labelAutor);
            this.Controls.Add(this.comboBoxAutor);
            this.Controls.Add(this.panelFoto);
            this.Name = "VentanaConsultas";
            this.Text = "VentanaConsultas";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.panelFoto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Panel panelFoto;
        private System.Windows.Forms.ComboBox comboBoxAutor;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.TextBox textBoxThreads;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.ListBox listBoxPop;
        private System.Windows.Forms.Label labelPop;
    }
}