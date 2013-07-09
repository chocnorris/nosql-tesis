using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoSQL
{
    public partial class VentanaTags : Form
    {
        VentanaDatos padre;
        public VentanaTags(VentanaDatos padre, string [] init)
        {
            this.padre = padre;
            InitializeComponent();
            for (int i = 0; i < init.Length; i++)
                listBoxTags.Items.Add(init[i]);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (textBoxNuevo.Text == "")
                return;
            listBoxTags.Items.Add(textBoxNuevo.Text);
            textBoxNuevo.Text = "";
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            string[] tags = new string[listBoxTags.Items.Count];
            int i = 0;
            foreach (string t in listBoxTags.Items)
                tags[i++] = t;
            padre.SetTags(tags);
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            if(listBoxTags.SelectedIndex != -1)
                listBoxTags.Items.RemoveAt(listBoxTags.SelectedIndex);
        }
    }
}
