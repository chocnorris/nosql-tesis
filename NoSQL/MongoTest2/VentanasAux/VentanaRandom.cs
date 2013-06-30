using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoTest2.Servicios;
using MongoTest2.Modelo;

namespace MongoTest2
{
    public partial class VentanaRandom : Form
    {
        IOperaciones db;

        string[] names = new string[50]
        {
            "Shirlee","Shiela","Kathline","Domitila","Adina","Lizzie","Eugenio",
            "Violette","Roselle","Kortney","Charline","Refugio","Lissa","Santa",
            "Sandra","Robyn","Margy","Gaylene","Shea","Ronni","Zachery","Laraine",
            "Maureen","Lan","Jacqueline","Roselia","Rodolfo","Daniela","Maple",
            "Bok","Jerome","Stepanie","Adolph","Khadijah","Lelia","Lincoln","Pearline",
            "Greg","Lanell","Arden","Alex","Kali","Ebonie","Kelli","Farah","Lucy",
            "Rene","Lilliana","Hanna","Darcie",
        };

        string lorem = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, "+
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. "+
            "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris "+
            "nisi ut aliquip ex ea commodo consequat.";

        public VentanaRandom(IOperaciones db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void buttonAutores_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            labelEstado.Text = "";
            progressBar.Visible = true;
            worker.RunWorkerAsync(AU);
        }

        private void buttonThreads_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            labelEstado.Text = "";
            progressBar.Visible = true;
            worker.RunWorkerAsync(TH);
        }

        private void buttonCom_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            labelEstado.Text = "";
            progressBar.Visible = true;
            worker.RunWorkerAsync(CO);
        }

        private void buttonCom1MB_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            labelEstado.Text = "";
            progressBar.Visible = true;
            worker.RunWorkerAsync(CO1MB);
        }

        private const int CO = 1;
        private const int TH = 2;
        private const int AU = 3;
        private const int CO1MB = 4;

        private int elapsed;

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int opc = (int)e.Argument;
            var start = DateTime.Now;
            switch (opc)
            {
                case CO:
                    cargarComments((int)numericUpDownCom.Value, false);
                    break;
                case TH:
                    cargarThreads((int)numericUpDownThreads.Value);
                    break;
                case AU:                    
                    cargarAutores((int)numericUpDownAutores.Value);
                    break;
                case CO1MB:
                    cargarComments((int)numericUpDownCom1MB.Value, true);
                    break;
            }
            var finish = DateTime.Now;
            elapsed = (int)finish.Subtract(start).TotalSeconds;
        }

        private void cargarAutores(int n)
        {
            Random rand = new Random();            
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(2000);
                db.AddAuthor(new Author() { Name = names[num] + num2 });
                //db.GetCollection("authors").Insert(new { name = names[num] + num2 });
                worker.ReportProgress((i * 100) / n);
            }            
        }

        private void cargarThreads(int n)
        {
            Random rand = new Random();
            int nAut = (int)db.GetAuthorsCount();
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(50);
                int num3 = rand.Next(nAut);
                Author auth = db.GetAuthors(num3,1).First();
                db.AddThread(new Thread()
                {
                    Title = names[num] + names[num2],
                    Author = auth,
                    Date = DateTime.Now,
                    Tags = new string [0]
                });
                worker.ReportProgress((i*100)/n);
            }
        }

        private void cargarComments(int n,bool mb)
        {
            Random rand = new Random();
            int nTh = (int)db.GetThreads().Count();
            int nCom = (int)db.GetCommentsCount();
            int cargaNCom = n / 10;
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(50);
                int nAut = (int)db.GetAuthorsCount();
                int num3 = rand.Next(nAut);
                Author auth = db.GetAuthors(num3,1).First();
                string parentId = null;
                string threadId = null;
                int num4 = rand.Next(10);
                int num5 = 0;
                if (num4 <= 3 || nCom == 0)
                {
                    num5 = rand.Next(nTh);
                    Thread thread = db.GetThreads(num5,1).First();
                    parentId = thread.Id.ToString();
                    threadId = parentId;
                }
                else
                {
                    //Calucla el núemero de comentarios a lo sumo 10 veces
                    if (i > cargaNCom)
                    {
                        nCom = (int)db.GetCommentsCount();
                        cargaNCom += n / 10;
                    }
                    num5 = rand.Next(nCom);
                    Comment com = db.GetComments(num5,1).First();
                    parentId = com.Id.ToString();
                    threadId = com.Thread_id.ToString();
                }
                if (!mb)
                    db.AddComment(new Comment()
                    {
                        Text = lorem,
                        Thread_id = threadId,
                        Author = auth,
                        Date = DateTime.Now,
                        Parent_id = parentId
                    });
                else
                    db.AddComment(new Comment()
                    {
                        Text = System.IO.File.ReadAllText(@"..\..\Data\1mb.txt"),
                        Thread_id = threadId,
                        Author = auth,
                        Date = DateTime.Now,
                        Parent_id = parentId
                    });

                worker.ReportProgress((i * 100) / n);
            }

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Visible = false;
            labelEstado.Text = "La operación tardó " + elapsed + " segundos";
            //MessageBox.Show("La operación tardó " + elapsed + " segundos", "Operación", MessageBoxButtons.OK);            
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void VentanaRandom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
                e.Cancel = true;
        }

    }
}
