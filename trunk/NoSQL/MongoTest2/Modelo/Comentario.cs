using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoTest2.Modelo
{
    public class Comentario
    {
        public object id { get; set; }
        public Autor Author { get; set; }
        public string Text { get; set; }
        public object Parent_id { get; set; }
        public object Thread_id { get; set; }
        public DateTime Date { get; set; }
    }
}
