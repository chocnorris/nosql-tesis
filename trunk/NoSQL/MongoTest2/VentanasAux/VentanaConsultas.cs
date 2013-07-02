using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoTest2.Modelo;
using MongoTest2.Servicios;

namespace MongoTest2
{
    public partial class VentanaConsultas : Form
    {
        IOperaciones db;
        public VentanaConsultas(IOperaciones db)
        {
            this.db = db;
            InitializeComponent();
            Author auth = db.GetAuthors(0, 1).First();
            auth = db.GetAuthor(auth.Id);
            pictureBoxFoto.Image = auth.Photo;
        }
    }
}
