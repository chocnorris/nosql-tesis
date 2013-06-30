﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoTest2.Paneles;
using System.Net.Sockets;

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
            comboBoxDB.Items.Add("MySQL");
            comboBoxDB.SelectedIndex = 0;
            comboBoxHost.Items.Add("localhost");
            comboBoxHost.Items.Add("127.0.0.1");
            comboBoxHost.Items.Add("192.168.56.201");
            comboBoxHost.Items.Add("192.168.56.202");
            comboBoxHost.Items.Add("192.168.56.203");

        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            if (comboBoxDB.SelectedItem.ToString() == "Mongo")
            {
                if (!testPort(comboBoxHost.Text, 27017))
                    return;
                MongoOperaciones md = new MongoOperaciones("forum", comboBoxHost.Text);
                InfoMongo panel = new InfoMongo(md);
                padre.SetDB(md);
                padre.SetPanelInfo(panel);
            }
            if (comboBoxDB.SelectedItem.ToString() == "Cassandra")
            {
                CassandraOperaciones cassandra = new CassandraOperaciones("forum", comboBoxHost.Text);
                cassandra.Initialize(false);
                padre.SetDB(cassandra);
                //padre.SetPanelInfo(panel);
                //panel.serverState();                
            }
            if (comboBoxDB.SelectedItem.ToString() == "MySQL")
            {
                MysqlOperaciones mysql = new MysqlOperaciones("forum", comboBoxHost.Text);
                //mysql.Initialize(false);
                padre.SetDB(mysql);
                //padre.SetPanelInfo(panel);
                //panel.serverState;
            }
            padre.AfterConnection();
            this.Close();
        }

        private bool testPort(string host, int port)
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Connect(host, port);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.ConnectionRefused)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
