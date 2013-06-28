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
            this.panelAcciones = new System.Windows.Forms.Panel();
            this.buttonConsultas = new System.Windows.Forms.Button();
            this.buttonDrop = new System.Windows.Forms.Button();
            this.buttonDesconectar = new System.Windows.Forms.Button();
            this.buttonConectar = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonAgregarDatos = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAcciones
            // 
            this.panelAcciones.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelAcciones.Controls.Add(this.buttonConsultas);
            this.panelAcciones.Controls.Add(this.buttonDrop);
            this.panelAcciones.Controls.Add(this.buttonDesconectar);
            this.panelAcciones.Controls.Add(this.buttonConectar);
            this.panelAcciones.Controls.Add(this.buttonRandom);
            this.panelAcciones.Controls.Add(this.buttonAgregarDatos);
            this.panelAcciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelAcciones.Location = new System.Drawing.Point(0, 0);
            this.panelAcciones.Name = "panelAcciones";
            this.panelAcciones.Size = new System.Drawing.Size(160, 420);
            this.panelAcciones.TabIndex = 0;
            // 
            // buttonConsultas
            // 
            this.buttonConsultas.Location = new System.Drawing.Point(14, 149);
            this.buttonConsultas.Name = "buttonConsultas";
            this.buttonConsultas.Size = new System.Drawing.Size(132, 23);
            this.buttonConsultas.TabIndex = 5;
            this.buttonConsultas.Text = "Consultas";
            this.buttonConsultas.UseVisualStyleBackColor = true;
            this.buttonConsultas.Click += new System.EventHandler(this.buttonConsultas_Click);
            // 
            // buttonDrop
            // 
            this.buttonDrop.Location = new System.Drawing.Point(14, 211);
            this.buttonDrop.Name = "buttonDrop";
            this.buttonDrop.Size = new System.Drawing.Size(132, 23);
            this.buttonDrop.TabIndex = 4;
            this.buttonDrop.Text = "Borrar BD";
            this.buttonDrop.UseVisualStyleBackColor = true;
            this.buttonDrop.Click += new System.EventHandler(this.buttonDrop_Click);
            // 
            // buttonDesconectar
            // 
            this.buttonDesconectar.Location = new System.Drawing.Point(14, 42);
            this.buttonDesconectar.Name = "buttonDesconectar";
            this.buttonDesconectar.Size = new System.Drawing.Size(132, 23);
            this.buttonDesconectar.TabIndex = 0;
            this.buttonDesconectar.Text = "Desconectar";
            this.buttonDesconectar.UseVisualStyleBackColor = true;
            this.buttonDesconectar.Click += new System.EventHandler(this.buttonDesconectar_Click_1);
            // 
            // buttonConectar
            // 
            this.buttonConectar.Location = new System.Drawing.Point(14, 13);
            this.buttonConectar.Name = "buttonConectar";
            this.buttonConectar.Size = new System.Drawing.Size(132, 23);
            this.buttonConectar.TabIndex = 0;
            this.buttonConectar.Text = "Conectar";
            this.buttonConectar.UseVisualStyleBackColor = true;
            this.buttonConectar.Click += new System.EventHandler(this.buttonConectar_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(14, 120);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(132, 23);
            this.buttonRandom.TabIndex = 3;
            this.buttonRandom.Text = "Agregar Datos Aleatorios";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonAgregarDatos
            // 
            this.buttonAgregarDatos.Location = new System.Drawing.Point(14, 91);
            this.buttonAgregarDatos.Name = "buttonAgregarDatos";
            this.buttonAgregarDatos.Size = new System.Drawing.Size(132, 23);
            this.buttonAgregarDatos.TabIndex = 2;
            this.buttonAgregarDatos.Text = "Agregar Datos Manual";
            this.buttonAgregarDatos.UseVisualStyleBackColor = true;
            this.buttonAgregarDatos.Click += new System.EventHandler(this.buttonAgregarDatos_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(160, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(416, 420);
            this.panelInfo.TabIndex = 1;
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 420);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelAcciones);
            this.Name = "Ventana";
            this.Text = "Ventana";
            this.panelAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAcciones;
        private System.Windows.Forms.Button buttonAgregarDatos;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonConectar;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Button buttonDesconectar;
        private System.Windows.Forms.Button buttonDrop;
        private System.Windows.Forms.Button buttonConsultas;


    }
}