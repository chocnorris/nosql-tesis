namespace MongoTest2
{
    partial class VentanaTags
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
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.textBoxNuevo = new System.Windows.Forms.TextBox();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonQuitar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTags
            // 
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.Location = new System.Drawing.Point(12, 12);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.Size = new System.Drawing.Size(133, 173);
            this.listBoxTags.TabIndex = 0;
            // 
            // textBoxNuevo
            // 
            this.textBoxNuevo.Location = new System.Drawing.Point(152, 13);
            this.textBoxNuevo.Name = "textBoxNuevo";
            this.textBoxNuevo.Size = new System.Drawing.Size(120, 20);
            this.textBoxNuevo.TabIndex = 1;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(152, 39);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 2;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(65, 201);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 3;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(147, 201);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonQuitar
            // 
            this.buttonQuitar.Location = new System.Drawing.Point(152, 68);
            this.buttonQuitar.Name = "buttonQuitar";
            this.buttonQuitar.Size = new System.Drawing.Size(75, 23);
            this.buttonQuitar.TabIndex = 5;
            this.buttonQuitar.Text = "Quitar";
            this.buttonQuitar.UseVisualStyleBackColor = true;
            this.buttonQuitar.Click += new System.EventHandler(this.buttonQuitar_Click);
            // 
            // VentanaTags
            // 
            this.AcceptButton = this.buttonAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelar;
            this.ClientSize = new System.Drawing.Size(284, 236);
            this.Controls.Add(this.buttonQuitar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.textBoxNuevo);
            this.Controls.Add(this.listBoxTags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaTags";
            this.Text = "Tags";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTags;
        private System.Windows.Forms.TextBox textBoxNuevo;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonQuitar;
    }
}