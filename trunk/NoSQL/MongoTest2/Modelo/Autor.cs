using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Modelo;

namespace MongoTest2.Entidades
{
    public class Autor 
    {        
        public GenericId AutorId { get; set; }
        public string Nombre { get; set; }
    }
}
