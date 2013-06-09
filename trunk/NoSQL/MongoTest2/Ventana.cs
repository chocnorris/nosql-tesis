using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoTest2.Servicios;
using MongoTest2.Paneles;

namespace MongoTest2
{
    public partial class Ventana : Form
    {        
           
        IOperaciones db;
        public Ventana()
        {
            InitializeComponent();
        }       

        private void buttonAgregarDatos_Click(object sender, EventArgs e)
        {
            Form vd = new VentanaDatos(db);
            vd.ShowDialog();
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            Form vr = new VentanaRandom(db);
            vr.Show();
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {      
            MongoDriver md = new MongoDriver("localhost");
            InfoMongo panel = new InfoMongo(md);
            db = md;
            panelInfo.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
            panel.serverState();
            if (db.IsDatabaseConnected())
                buttonConectar.Enabled = false;            
        }
    }
}
