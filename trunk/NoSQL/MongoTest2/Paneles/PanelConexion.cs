using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoSQL.Servicios;
using System.Net.Sockets;

namespace NoSQL.Paneles
{
    public partial class PanelConexion : UserControl
    {
        Ventana padre;
        public PanelConexion(Ventana padre)
        {
            this.padre = padre;
            InitializeComponent();
            comboBoxDB.Items.Add("Mongo");
            comboBoxDB.Items.Add("Cassandra");
            comboBoxDB.Items.Add("MySQL");
            comboBoxDB.SelectedIndex = 0;
            comboBoxHost.Items.Add("localhost");
            comboBoxHost.Items.Add("127.0.0.1");
            comboBoxHost.Items.Add("192.168.56.201");
            comboBoxHost.Items.Add("192.168.56.202");
            comboBoxHost.Items.Add("192.168.56.203");
            comboBoxHost.Items.Add("mongo201:27017,mongo202:27017,mongo203:27017/?replicaSet=rs0");

        }

        private bool testConnection(string host, int defport)
        {
            if (!Uri.IsWellFormedUriString(host, UriKind.RelativeOrAbsolute) || host.Equals(""))
            {
                MessageBox.Show("Host no válido", "Error");
                return false;
            }
            if(!host.Contains("//"))
                host = "mongodb://"+host;
            int port = defport;
            Uri uri = null;
            try
            {
                uri = new Uri(host, UriKind.RelativeOrAbsolute);
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede conectar", "Error");
                return false;
            }
            if(uri.Port != -1)
                port = uri.Port;
            host = uri.Host;

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Connect(host, port);
                    socket.Close();
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("No se puede conectar"+Environment.NewLine+ex.Message, "Error");
                    return false;
                }
            }
            return true;
        }

        public void Conectar()
        {
            UserControl panelAux = null;
            IOperaciones db = null;
            if (comboBoxDB.SelectedItem.ToString() == "Mongo")
            {
                if (!testConnection(comboBoxHost.Text, 27017))
                    return;
                MongoOperaciones md = new MongoOperaciones("forum", comboBoxHost.Text);
                panelAux = new InfoMongo(md);
                db = md;
            }
            if (comboBoxDB.SelectedItem.ToString() == "Cassandra")
            {
                if (!testConnection(comboBoxHost.Text, 9160))
                    return;
                db = new CassandraOperaciones("forum", comboBoxHost.Text);
                db.Initialize(false);
            }
            if (comboBoxDB.SelectedItem.ToString() == "MySQL")
            {
                if (!testConnection(comboBoxHost.Text, 3306))
                    return;
                db = new MysqlOperaciones("forum", comboBoxHost.Text);
            }
            padre.AfterConnection(db, panelAux);
        }
    }
}
