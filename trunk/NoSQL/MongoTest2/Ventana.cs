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
            bloquearBotones(true);
        }       

        private void buttonAgregarDatos_Click(object sender, EventArgs e)
        {
            if (db != null && db.IsDatabaseConnected())
            {
                Form vd = new VentanaDatos(db);
                vd.ShowDialog();
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            if (db != null && db.IsDatabaseConnected())
            {
                Form vr = new VentanaRandom(db);
                vr.Show();
            }
        }

        
        private void buttonConectar_Click(object sender, EventArgs e)
        {
            Form vc = new VentanaConexion(this);
            vc.ShowDialog();
        }

        public void SetPanelInfo(UserControl panel)
        {
            panelInfo.Controls.Add(panel);
            panel.Dock = DockStyle.Fill;
        }

        public void SetDB(IOperaciones db)
        {
            this.db = db;
        }

        public void AfterConnection()
        {
            if (db.IsDatabaseConnected())
                bloquearBotones(false);
        }

        private void buttonDesconectar_Click_1(object sender, EventArgs e)
        {
            db.Shutdown();
            db = null;
            panelInfo.Controls.Clear();
            bloquearBotones(true);
        }

        private void buttonDrop_Click(object sender, EventArgs e)
        {
            if (db != null && db.IsDatabaseConnected())
            {
                if (MessageBox.Show("Se borrarán todos los datos" + Environment.NewLine + "¿Desea continuar?", "Confirmar borrado", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.Cleanup();
                }
            }
        }

        private void bloquearBotones(bool bloqueo)
        {
            bloqueo = !bloqueo;
            buttonAgregarDatos.Enabled = bloqueo;
            buttonConectar.Enabled = !bloqueo;
            buttonDesconectar.Enabled = bloqueo;
            buttonRandom.Enabled = bloqueo;
            buttonConsultas.Enabled = bloqueo;
            buttonDrop.Enabled = bloqueo;
        }

        private void buttonConsultas_Click(object sender, EventArgs e)
        {
            Form vc = new VentanaConsultas(db);
            vc.ShowDialog();
        }

        private void VentanaRandom_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Shutdown();
        }
    }
}
