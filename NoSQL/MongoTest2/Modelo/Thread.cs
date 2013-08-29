using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NoSQL.Modelo
{
    public class Thread
    {
        [JsonIgnore]
        public object Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        [JsonIgnore]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public long CommentCount { get; set; }
        [JsonIgnore]
        public string [] Tags { get; set; }
    }
}
