using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NoSQL.Modelo;
using NoSQL.Servicios;

namespace NoSQL
{
    public partial class VentanaConsultas : Form
    {
        IOperaciones db;
        public VentanaConsultas(IOperaciones db)
        {
            this.db = db;
            InitializeComponent();
        }


        private void cargarDatosAutor(object id)
        {
            Author auth = db.GetAuthor(id);
            pictureBoxFoto.Image = auth.Photo;
        }

        private void comboBoxAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosAutor(((ComboItem)comboBoxAutor.SelectedItem).Value);
            textBoxThreads.Text = db.ThradsByAuthor(((ComboItem)comboBoxAutor.SelectedItem).Value) + "";
        }

        private void buttonAutor_Click(object sender, EventArgs e)
        {
            comboBoxAutor.Items.Clear();
            var Autores = ((MongoOperaciones)db).AuthorsByName(textBoxAutor.Text, 30);
            foreach (var autor in Autores)
            {    // sacado if de "identidad", no hace la diferencia                            
                comboBoxAutor.Items.Add(new ComboItem { Text = autor.Name, Value = autor.Id });
            }
            if (Autores.Count > 0)
            {
                comboBoxAutor.SelectedIndex = 0;
            }
        }

        private void textBoxAutor_TextChanged(object sender, EventArgs e)
        {
            comboBoxAutor.Items.Clear();
            var Autores = ((MongoOperaciones)db).AuthorsByName(textBoxAutor.Text, 5);
            foreach (var autor in Autores)
            {    // sacado if de "identidad", no hace la diferencia                            
                comboBoxAutor.Items.Add(new ComboItem { Text = autor.Name, Value = autor.Id });
            }
            if (Autores.Count > 0)
            {
                comboBoxAutor.SelectedIndex = 0;
            }
        }

    }
}
