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
            foreach(Author a in db.AuthorsPopular(10))
                listBoxPop.Items.Add(a.Name);
            cargarAutores();
        }


        private void cargarDatosAutor(object id)
        {
            Author auth = db.GetAuthor(id);
            pictureBoxFoto.Image = auth.Photo;
        }

        private void comboBoxAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosAutor(((ComboItem)comboBoxAutor.SelectedItem).Value);
            textBoxThreads.Text = "Número de threads: " + db.ThreadsByAuthor(((ComboItem) comboBoxAutor.SelectedItem).Value);
        }

        private void textBoxAutor_TextChanged(object sender, EventArgs e)
        {
            cargarAutores();
        }
        private void cargarAutores()
        {
            comboBoxAutor.Items.Clear();
            string name = textBoxAutor.Text;
            var Autores = db.AuthorsByName(name, 30);
            foreach (var autor in Autores)
            {
                comboBoxAutor.Items.Add(new ComboItem { Text = autor.Name, Value = autor.Id });
            }
            if (Autores.Count > 0)
            {
                comboBoxAutor.SelectedIndex = 0;
            }
        }
    }
}
