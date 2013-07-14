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
                string connstr = "";
                if (checkBoxReplSet.CheckState == CheckState.Checked)
                    connstr = construirReplSetConn();
                else
                {
                    connstr = comboBoxHost.Text;
                    if (!testConnection(connstr, 27017))
                        return;
                }
                MongoOperaciones md;
                if (textBoxUsuario.Text == "")
                    md = new MongoOperaciones("forum", connstr);
                else
                    md = new MongoOperaciones("forum", connstr, textBoxUsuario.Text, textBoxPass.Text);
                panelAux = new InfoMongo(md);
                db = md;
            }
            if (comboBoxDB.SelectedItem.ToString() == "Cassandra")
            {
                if (!testConnection(comboBoxHost.Text, 9160))
                    return;
                if (textBoxUsuario.Text == "")
                    db = new CassandraOperaciones("forum", comboBoxHost.Text);
                else
                    db = new CassandraOperaciones("forum", comboBoxHost.Text, textBoxUsuario.Text, textBoxPass.Text);
                db.Initialize(false);
            }
            if (comboBoxDB.SelectedItem.ToString() == "MySQL")
            {
                if (!testConnection(comboBoxHost.Text, 3306))
                    return;
                if (textBoxUsuario.Text == "")
                    db = new MysqlOperaciones("forum", comboBoxHost.Text);
                else
                    db = new MysqlOperaciones("forum", comboBoxHost.Text, textBoxUsuario.Text, textBoxPass.Text);
            }
            padre.AfterConnection(db, panelAux);
        }

        private string construirReplSetConn()
        {
            string connstr = "";
            for (int i = 0; i < dataGridViewReplSet.Rows.Count - 1; i++)
            {
                var row = dataGridViewReplSet.Rows[i];
                if (row.Cells["Port"].Value == null)
                    connstr += row.Cells["Host"].Value + ":27017";
                else
                    connstr += row.Cells["Host"].Value + ":" + row.Cells["Port"].Value;
                if (i < dataGridViewReplSet.Rows.Count - 2)
                    connstr += ",";
            }
            return connstr + "/?replicaSet="+textBoxNombreReplSet;
        }

        private void checkBoxReplSet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReplSet.CheckState.Equals(CheckState.Checked))
            {
                comboBoxHost.Enabled = false;
                dataGridViewReplSet.Enabled = true;
                textBoxNombreReplSet.Enabled = true;
            }
            else
            {
                comboBoxHost.Enabled = true;
                dataGridViewReplSet.Enabled = false;
                textBoxNombreReplSet.Enabled = false;
            }
        }

        private void comboBoxDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDB.SelectedItem.Equals("Mongo"))
                groupBoxReplSet.Visible = true;
            else
                groupBoxReplSet.Visible = false;
        }
    }
}
