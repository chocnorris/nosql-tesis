using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using System.Drawing;

namespace MongoTest2.Modelo
{
    public class Author 
    {        
        public object Id { get; set; }
        public string Name { get; set; }
        //TODO: Agregar más información para los autores/usuarios del sistema

        public Bitmap Photo { get; set; }
    }
}
