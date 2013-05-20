namespace MongoTest2
{
    partial class VentanaRandom
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
            this.buttonAutores = new System.Windows.Forms.Button();
            this.buttonThreads = new System.Windows.Forms.Button();
            this.buttonCom = new System.Windows.Forms.Button();
            this.numericUpDownAutores = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCom = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCom)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAutores
            // 
            this.buttonAutores.Location = new System.Drawing.Point(12, 12);
            this.buttonAutores.Name = "buttonAutores";
            this.buttonAutores.Size = new System.Drawing.Size(119, 23);
            this.buttonAutores.TabIndex = 0;
            this.buttonAutores.Text = "Autores";
            this.buttonAutores.UseVisualStyleBackColor = true;
            this.buttonAutores.Click += new System.EventHandler(this.buttonAutores_Click);
            // 
            // buttonThreads
            // 
            this.buttonThreads.Location = new System.Drawing.Point(12, 42);
            this.buttonThreads.Name = "buttonThreads";
            this.buttonThreads.Size = new System.Drawing.Size(119, 23);
            this.buttonThreads.TabIndex = 1;
            this.buttonThreads.Text = "Threads";
            this.buttonThreads.UseVisualStyleBackColor = true;
            this.buttonThreads.Click += new System.EventHandler(this.buttonThreads_Click);
            // 
            // buttonCom
            // 
            this.buttonCom.Location = new System.Drawing.Point(13, 72);
            this.buttonCom.Name = "buttonCom";
            this.buttonCom.Size = new System.Drawing.Size(118, 23);
            this.buttonCom.TabIndex = 2;
            this.buttonCom.Text = "Comentarios";
            this.buttonCom.UseVisualStyleBackColor = true;
            this.buttonCom.Click += new System.EventHandler(this.buttonCom_Click);
            // 
            // numericUpDownAutores
            // 
            this.numericUpDownAutores.Location = new System.Drawing.Point(138, 14);
            this.numericUpDownAutores.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAutores.Name = "numericUpDownAutores";
            this.numericUpDownAutores.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAutores.TabIndex = 3;
            // 
            // numericUpDownThreads
            // 
            this.numericUpDownThreads.Location = new System.Drawing.Point(137, 42);
            this.numericUpDownThreads.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownThreads.Name = "numericUpDownThreads";
            this.numericUpDownThreads.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownThreads.TabIndex = 3;
            // 
            // numericUpDownCom
            // 
            this.numericUpDownCom.Location = new System.Drawing.Point(137, 72);
            this.numericUpDownCom.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownCom.Name = "numericUpDownCom";
            this.numericUpDownCom.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCom.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(141, 113);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(118, 23);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // VentanaRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 148);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.numericUpDownCom);
            this.Controls.Add(this.numericUpDownThreads);
            this.Controls.Add(this.numericUpDownAutores);
            this.Controls.Add(this.buttonCom);
            this.Controls.Add(this.buttonThreads);
            this.Controls.Add(this.buttonAutores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VentanaRandom";
            this.Text = "VentanaRandom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentanaRandom_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAutores;
        private System.Windows.Forms.Button buttonThreads;
        private System.Windows.Forms.Button buttonCom;
        private System.Windows.Forms.NumericUpDown numericUpDownAutores;
        private System.Windows.Forms.NumericUpDown numericUpDownThreads;
        private System.Windows.Forms.NumericUpDown numericUpDownCom;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker worker;
    }
}