using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoTest2.Paneles;

namespace MongoTest2
{
    public partial class VentanaConexion : Form
    {
        Ventana padre;
        public VentanaConexion(Ventana padre)
        {
            this.padre = padre;
            InitializeComponent();
            comboBoxDB.Items.Add("Mongo");
            comboBoxDB.Items.Add("Cassandra");
            comboBoxDB.SelectedIndex = 0;
            comboBoxHost.Items.Add("localhost");
            comboBoxHost.Items.Add("127.0.0.1");
            comboBoxHost.Items.Add("192.168.56.201");

        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            if (comboBoxDB.SelectedItem.ToString() == "Mongo")
            {
                MongoDriver md = new MongoDriver(comboBoxHost.Text);
                InfoMongo panel = new InfoMongo(md);
                padre.SetDB(md);
                padre.SetPanelInfo(panel);
                panel.serverState();
            }
            if (comboBoxDB.SelectedItem.ToString() == "Cassandra")
            {
                CassandraOperaciones cassandra = new CassandraOperaciones("forum", "localhost");
                padre.SetDB(cassandra);
                //padre.SetPanelInfo(panel);
                //panel.serverState();
            }
            padre.AfterConnection();
            this.Close();
        }
    }
}
