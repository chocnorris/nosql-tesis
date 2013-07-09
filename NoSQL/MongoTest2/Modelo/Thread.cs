using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoSQL.Modelo
{
    public class Thread
    {
        public object Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public DateTime Date { get; set; }
        public long CommentCount { get; set; }
        public string [] Tags { get; set; }
    }
}
