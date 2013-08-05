using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoSQL.Servicios;
using NoSQL.Paneles;

namespace NoSQL
{
    public partial class Ventana : Form
    {
        PanelConexion pc;
        IOperaciones db;
        public Ventana()
        {
            InitializeComponent();
            pc = new PanelConexion(this);
            panelInfo.Controls.Add(pc);
            pc.Dock = DockStyle.Fill;
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
            pc.Conectar();
        }

        public void AfterConnection(UserControl panel = null)
        {
            if (db.IsDatabaseConnected())
                bloquearBotones(false);
            if (panel != null)
            {
                panelInfo.Controls.Add(panel);
                panel.Dock = DockStyle.Fill;
            }
        }

        public void AfterConnection(IOperaciones db, UserControl panel = null)
        {
            this.db = db;
            if (db.IsDatabaseConnected())
            {
                bloquearBotones(false);
                panelInfo.Controls.Clear();
                if (panel != null)
                {
                    panelInfo.Controls.Add(panel);
                    panel.Dock = DockStyle.Fill;
                }
            }
        }
        private void buttonDesconectar_Click(object sender, EventArgs e)
        {
            db.Shutdown();
            db = null;
            panelInfo.Controls.Clear();
            panelInfo.Controls.Add(pc);
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

        private void panelAcciones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
