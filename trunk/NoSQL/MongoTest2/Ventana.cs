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
using MongoTest2.Servicios;

namespace MongoTest2
{
    public partial class Ventana : Form
    {        
        MongoClient client;
        MongoServer server;
        MongoDatabase dbmongo;                

        IOperaciones db;
        public Ventana()
        {
            InitializeComponent();
        }

        private void serverState()
        {
            comboBoxShardList.Items.Clear();
            comboBoxShardList.Items.Add("Global");            

            foreach (var keyvalue in db.GetShards())
            {
                comboBoxShardList.Items.Add(new ComboItem { Text = keyvalue.Key, Value = keyvalue.Value }); ;
            }
            comboBoxShardList.SelectedIndex = 0;
            textBoxEstado.Text = db.GetEstadoConexion();
            detalles("Global");
        }

        private void buttonActualizarMonitor_Click(object sender, EventArgs e)
        {
            serverState();
        }

        private void detalles(string referencia)
        {
            /* Hay que ver esto de los detalles (estandarizar la que informacion se saca)
            CommandDocument comandoStats = new CommandDocument();
            comandoStats.Add("dbstats", 1);
            comandoStats.Add("scale", 1024*1024); //Mb!!
            CommandResult stats = db.RunCommand(comandoStats);

            MongoCollection<BsonDocument> chunks = server.GetDatabase("config").GetCollection("chunks");
            if (referencia == "Global")
            {
                labelChunks.Text = "Chunks: " +
                    chunks.Count();
                labelTam.Text = "Tamaño: " +
                    stats.Response["dataSize"]+" Mb";
            }
            else
            {
                labelChunks.Text = "Chunks: " +
                    chunks.Find(new QueryDocument("shard", referencia)).Count();
                labelTam.Text = "Tamaño: " +
                    stats.Response["raw"][((ComboItem)comboBoxShardList.SelectedItem).Value.AsString]["dataSize"] + " Mb";
            }
             */
        }

        private void comboBoxShardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            detalles(comboBoxShardList.SelectedItem.ToString());
        }

        private void buttonAgregarDatos_Click(object sender, EventArgs e)
        {
            Form vd = new VentanaDatos(db);
            vd.ShowDialog();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Form vr = new VentanaRandom(dbmongo);
            vr.Show();
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            // sacar luego
            client = new MongoClient("mongodb://localhost");
            server = client.GetServer();          
            db = new MongoDriver(client,server);
            dbmongo = db.GetDB();
            serverState();
            if ( db.Conectado() )
                buttonConectar.Enabled = false;            
        }
    }
}
