using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace MongoTest2.Modelo
{
    public class Author 
    {        
        public object Id { get; set; }
        public string Name { get; set; }
    }
}
