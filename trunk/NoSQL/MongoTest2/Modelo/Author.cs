using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using System.Drawing;
using Newtonsoft.Json;

namespace NoSQL.Modelo
{
    public class Author 
    {
        [JsonIgnore]
        public object Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public Bitmap Photo { get; set; }
    }
}
