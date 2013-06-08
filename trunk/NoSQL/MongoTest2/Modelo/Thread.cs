using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoTest2.Modelo
{
    public class Thread
    {
        public object Id { get; set; }
        public string Title { get; set; }
        public Autor Author { get; set; }
        public DateTime Date { get; set; }
    }
}
