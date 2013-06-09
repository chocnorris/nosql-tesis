using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MongoTest2.Paneles
{
    public partial class InfoMongo : UserControl
    {

        private MongoDriver db;

        public InfoMongo(MongoDriver md)
        {
            db = md;
            InitializeComponent();
        }

        public void serverState()
        {
            comboBoxShardList.Items.Clear();
            comboBoxShardList.Items.Add("Global");

            foreach (var keyvalue in db.GetShards())
            {
                comboBoxShardList.Items.Add(new ComboItem { Text = keyvalue.Key, Value = keyvalue.Value }); ;
            }
            comboBoxShardList.SelectedIndex = 0;
            textBoxEstado.Text = db.ConnectionState();
            detalles("Global");
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

        private void buttonActualizarMonitor_MouseClick(object sender, MouseEventArgs e)
        {
            serverState();
        }
    }
}
