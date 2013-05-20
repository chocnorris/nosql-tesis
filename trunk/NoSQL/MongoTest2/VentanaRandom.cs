using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace MongoTest2
{
    public partial class VentanaRandom : Form
    {
        MongoDatabase db;

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

        public VentanaRandom(MongoDatabase mdb)
        {
            db = mdb;
            InitializeComponent();
        }

        private void buttonAutores_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            progressBar.Visible = true;
            worker.RunWorkerAsync(AU);
        }

        private void buttonThreads_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            progressBar.Visible = true;
            worker.RunWorkerAsync(TH);
        }

        private void buttonCom_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
                return;
            progressBar.Visible = true;
            worker.RunWorkerAsync(CO);
        }

        private const int CO = 1;
        private const int TH = 2;
        private const int AU = 3;

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int opc = (int)e.Argument;
            switch (opc)
            {
                case 1: 
                    cargarComments((int)numericUpDownCom.Value);
                    break;
                case 2:
                    cargarThreads((int)numericUpDownThreads.Value);
                    break;
                default:
                    cargarAutores((int)numericUpDownAutores.Value);
                    break;
            }
        }

        private void cargarAutores(int n)
        {
            Random rand = new Random();
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(2000);
                db.GetCollection("authors").Insert(new { name = names[num] + num2 });
                worker.ReportProgress((i / n) * 100);
            }
        }

        private void cargarThreads(int n)
        {
            Random rand = new Random();
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(50);
                int nAut = (int)db.GetCollection("authors").Count();
                int num3 = rand.Next(nAut);
                BsonDocument auth = db.GetCollection("authors").FindAll().Skip(num3).First();
                db.GetCollection("threads").Insert(new
                {
                    title = names[num] + names[num2],
                    author = auth,
                    date = DateTime.Now
                });
                worker.ReportProgress((i / n) * 100);
            }
        }

        private void cargarComments(int n)
        {
            Random rand = new Random();
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(50);
                int nAut = (int)db.GetCollection("authors").Count();
                int num3 = rand.Next(nAut);
                BsonDocument auth = db.GetCollection("authors").FindAll().SetSkip(num3).SetLimit(1).First();
                BsonValue parentId = null;
                BsonValue threadId = null;
                int num4 = rand.Next(10);
                int num5 = 0;
                int nCom = (int)db.GetCollection("comments").Count();
                if (num4 <= 3 || nCom == 0)
                {
                    int nTh = (int)db.GetCollection("threads").Count();
                    num5 = rand.Next(nTh);
                    BsonDocument thread = db.GetCollection("threads").FindAll().SetSkip(num5).SetLimit(1).First();
                    parentId = thread["_id"];
                    threadId = parentId;
                }
                else
                {
                    num5 = rand.Next(nCom);
                    BsonDocument com = db.GetCollection("comments").FindAll().SetSkip(num5).SetLimit(1).First();
                    parentId = com["_id"];
                    threadId = com["thread_id"];
                }

                db.GetCollection("comments").Insert(new
                {
                    text = lorem,
                    thread_id = threadId,
                    author = auth,
                    date = DateTime.Now,
                    parent_id = parentId
                });

                worker.ReportProgress((i*100)/n);
            }

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Visible = false;
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
