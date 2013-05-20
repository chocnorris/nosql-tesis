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
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            int n = (int)numericUpDownAutores.Value;
            progressBar.Maximum = n;
            progressBar.Step = 1;
            Random rand = new Random();
            for(int i = 1; i<=n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(2000);
                db.GetCollection("authors").Insert(new { name = names[num] + num2 });
                progressBar.PerformStep();
            }
            progressBar.Visible = false;
        }

        private void buttonThreads_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            int n = (int)numericUpDownThreads.Value;
            progressBar.Maximum = n;
            progressBar.Step = 1;
            Random rand = new Random();
            for (int i = 1; i <= n; i++)
            {
                int num = rand.Next(50);
                int num2 = rand.Next(50);
                int nAut = (int) db.GetCollection("authors").Count();
                int num3 = rand.Next(nAut);
                BsonDocument auth = db.GetCollection("authors").FindAll().Skip(num3).First();
                db.GetCollection("threads").Insert(new { 
                    title = names[num]+names[num2],
                    author = auth,
                    date = DateTime.Now
                });
                progressBar.PerformStep();
            }
            progressBar.Visible = false;
        }

        private void buttonCom_Click(object sender, EventArgs e)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            int n = (int)numericUpDownCom.Value;
            progressBar.Maximum = n;
            progressBar.Step = 1;
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
                if (num4 <= 3 || nCom==0)
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
                progressBar.PerformStep();
            }
            progressBar.Visible = false;
        }
    }
}
