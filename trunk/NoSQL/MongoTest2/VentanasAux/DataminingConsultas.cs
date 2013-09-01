using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoSQL.Servicios;

namespace NoSQL.VentanasAux
{
    public partial class DataminingConsultas : Form
    {
        public Neo4jOperaciones db;
        public DataminingConsultas(Neo4jOperaciones db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelValorThread.Text = db.GetThreadRelevance(((ComboItem)comboBoxThread.Items[comboBoxThread.SelectedIndex]).Value).ToString();
        }

        private void DataminingConsultas_Load(object sender, EventArgs e)
        {
            CargarThreads();
        }
        protected void CargarThreads()
        {
            var threads = db.GetThreads();

            foreach (var thread in threads)
            {
                comboBoxThread.Items.Add(new ComboItem() { Text = thread.Title, Value = thread.Id });
            }
        }


        private void comboBoxAutorThread_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
