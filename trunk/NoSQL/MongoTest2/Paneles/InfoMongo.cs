using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoSQL.Paneles
{
    public partial class InfoMongo : UserControl
    {

        private MongoOperaciones db;
        private Dictionary<string, string> shards;

        public InfoMongo(MongoOperaciones md)
        {
            db = md;
            InitializeComponent();
            serverState();
        }

        private void serverState()
        {
            comboBoxShardList.Items.Clear();
            //comboBoxShardList.Items.Add("Global");
            shards = db.GetShards();
            shards.Add("Global", "");
            foreach (var keyvalue in shards)
            {
                comboBoxShardList.Items.Add(new ComboItem { Text = keyvalue.Key, Value = keyvalue.Value }); ;
            }
            comboBoxShardList.SelectedIndex = 0;
            textBoxEstado.Text = db.ConnectionState();
            detalles("Global", "");
        }
        private void detalles(string key, string value)
        {
            textBoxInfo.Text = db.ServerInfo(key , value);
        }

        private void comboBoxShardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            detalles(comboBoxShardList.SelectedItem.ToString(), ((ComboItem)comboBoxShardList.SelectedItem).Value.ToString());
        }

        private void buttonActualizarMonitor_Click(object sender, EventArgs e)
        {
            serverState();
        }


    }
}
