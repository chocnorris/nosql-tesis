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
            var authors = db.GetAuthors(0, 1);
            Author auth = new Author();
            if (authors.Count > 0)
                auth = authors.First();
            else
            {
                auth = new Author();
                auth.Name = "dummy author";
                auth.Photo = new Bitmap(1, 1);     
            }
            pictureBoxFoto.Image = auth.Photo;
        }
    }
}
