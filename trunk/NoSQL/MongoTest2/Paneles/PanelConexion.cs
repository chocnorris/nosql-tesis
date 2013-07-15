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

            dataGridViewReplSet.Rows.Add("mongo201", "27017");
            dataGridViewReplSet.Rows.Add("mongo202", "27017");
            dataGridViewReplSet.Rows.Add("mongo203", "27017");

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
            MongoOperaciones md;
            if (comboBoxDB.SelectedItem.ToString() == "Mongo")
            {
                string connstr = "";
                if (checkBoxReplSet.CheckState == CheckState.Checked)
                {
                    string [] hosts = getHostsDataGrid();
                    if (textBoxUsuario.Text == "")
                        md = new MongoOperaciones("forum", hosts, textBoxNombreReplSet.Text);
                    else
                        md = new MongoOperaciones("forum", hosts, textBoxNombreReplSet.Text, textBoxUsuario.Text, textBoxPass.Text);
                }
                else
                {
                    connstr = comboBoxHost.Text;
                    if (textBoxUsuario.Text == "")
                        md = new MongoOperaciones("forum", connstr);
                    else
                        md = new MongoOperaciones("forum", connstr, textBoxUsuario.Text, textBoxPass.Text);
                    if (!testConnection(connstr, 27017))
                        return;
                }
                panelAux = new InfoMongo(md);
                db = md;
            }
            if (comboBoxDB.SelectedItem.ToString() == "Cassandra")
            {
                if (!testConnection(comboBoxHost.Text, 9160))
                    return;
                if (textBoxUsuario.Text == "")
                    if (checkBoxReplSet.CheckState == CheckState.Checked)
                        db = new CassandraOperaciones("forum", getHostsDataGrid());
                    else
                        db = new CassandraOperaciones("forum", comboBoxHost.Text);
                else
                    if (checkBoxReplSet.CheckState == CheckState.Checked)
                        db = new CassandraOperaciones("forum", getHostsDataGrid(), textBoxUsuario.Text, textBoxPass.Text);
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

        private string[] getHostsDataGrid()
        {
            string [] hosts = new string [dataGridViewReplSet.Rows.Count-1];
            int i = 0;
            foreach(DataGridViewRow row in dataGridViewReplSet.Rows)
            {
                if (row.Cells["Host"].Value != null)
                {
                    if (row.Cells["Port"].Value != null && !row.Cells["Port"].Value.Equals(""))
                        hosts[i] = row.Cells["Host"].Value + ":" + row.Cells["Port"].Value;
                    else
                        hosts[i] = row.Cells["Host"].Value + "";
                    i++;
                }
            }
            return hosts;
        }

        private void checkBoxReplSet_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReplSet.CheckState.Equals(CheckState.Checked))
            {
                comboBoxHost.Enabled = false;
                dataGridViewReplSet.Enabled = true;
                if (comboBoxDB.SelectedItem.Equals("Mongo"))
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
            checkBoxReplSet.CheckState = CheckState.Unchecked;
            if (comboBoxDB.SelectedItem.Equals("Mongo") || comboBoxDB.SelectedItem.Equals("Cassandra"))
            {
                groupBoxReplSet.Visible = true;
            }
            else
                groupBoxReplSet.Visible = false;

        }
    }
}
