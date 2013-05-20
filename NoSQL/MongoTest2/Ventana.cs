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
    public partial class Ventana : Form
    {
        MongoClient client;
        MongoServer server;
        MongoDatabase db;
        public Ventana()
        {
            client = new MongoClient("mongodb://localhost");
            server = client.GetServer();
            db = server.GetDatabase("forum");
            InitializeComponent();
            serverState();
        }

        private void serverState()
        {
            textBoxCant.Text = db.GetCollection("comments").Count() + "";

            comboBoxShardList.Items.Clear();
            comboBoxShardList.Items.Add("Global");
            foreach (var sh in server.GetDatabase("config").GetCollection("shards").FindAll())
            {
                comboBoxShardList.Items.Add(sh["_id"] + "");
            }
            comboBoxShardList.SelectedIndex = 0;
            textBoxEstado.Text = server.State.ToString();
            detalles("Global");
        }

        private void buttonActualizarMonitor_Click(object sender, EventArgs e)
        {
            serverState();
        }

        private void detalles(string referencia)
        {
            if (referencia == "Global")
            {
                labelChunks.Text = "Chunks: " + 
                    server.GetDatabase("config").GetCollection("chunks").Count() ;
                return;
            }

            labelChunks.Text = "Chunks: " +
                    server.GetDatabase("config").GetCollection("chunks").Find(new QueryDocument("shard", referencia)).Count();
        }

        private void comboBoxShardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            detalles(comboBoxShardList.SelectedItem.ToString());
        }

        private void buttonAgregarDatos_Click(object sender, EventArgs e)
        {
            Form vd = new VentanaDatos(db);
            vd.ShowDialog();
            /*
            string text = System.IO.File.ReadAllText(@"C:\Users\Juan Cruz\Documents\Visual Studio 2010\Projects\MongoTest\MongoTest2\1mb.txt");
            for (int i = 0; i < 100; i++)
            {
                BsonDocument t = new BsonDocument();
                t["author"] = "hola"+i;
                t["title"]=text;
                db.GetCollection("threads").Save(t);
            }
             * */
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Form vr = new VentanaRandom(db);
            vr.ShowDialog();
        }
    }
}
