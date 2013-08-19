namespace NoSQL
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonAutores = new System.Windows.Forms.Button();
            this.buttonThreads = new System.Windows.Forms.Button();
            this.buttonCom = new System.Windows.Forms.Button();
            this.numericUpDownAutores = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCom = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.buttonCom1MB = new System.Windows.Forms.Button();
            this.numericUpDownCom1MB = new System.Windows.Forms.NumericUpDown();
            this.labelEstado = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCom1MB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            this.numericUpDownThreads.Location = new System.Drawing.Point(137, 46);
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
            this.numericUpDownCom.Location = new System.Drawing.Point(137, 75);
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
            this.progressBar.Location = new System.Drawing.Point(13, 130);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(246, 23);
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
            // buttonCom1MB
            // 
            this.buttonCom1MB.Location = new System.Drawing.Point(13, 101);
            this.buttonCom1MB.Name = "buttonCom1MB";
            this.buttonCom1MB.Size = new System.Drawing.Size(118, 23);
            this.buttonCom1MB.TabIndex = 5;
            this.buttonCom1MB.Text = "Comentarios 1MB";
            this.buttonCom1MB.UseVisualStyleBackColor = true;
            this.buttonCom1MB.Click += new System.EventHandler(this.buttonCom1MB_Click);
            // 
            // numericUpDownCom1MB
            // 
            this.numericUpDownCom1MB.Location = new System.Drawing.Point(137, 104);
            this.numericUpDownCom1MB.Name = "numericUpDownCom1MB";
            this.numericUpDownCom1MB.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCom1MB.TabIndex = 6;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(12, 138);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(0, 13);
            this.labelEstado.TabIndex = 7;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(296, 14);
            this.chart1.Margin = new System.Windows.Forms.Padding(1);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(501, 208);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // VentanaRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 253);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.numericUpDownCom1MB);
            this.Controls.Add(this.buttonCom1MB);
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
            this.Text = "Datos aleatorios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentanaRandom_FormClosing);
            this.Load += new System.EventHandler(this.VentanaRandom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCom1MB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button buttonCom1MB;
        private System.Windows.Forms.NumericUpDown numericUpDownCom1MB;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}