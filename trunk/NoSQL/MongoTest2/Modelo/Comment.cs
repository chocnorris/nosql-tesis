using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace NoSQL.Modelo
{
    public class Comment
    {
        [JsonIgnore]
        public object Id { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public object Parent_id { get; set; }
        [JsonIgnore]
        public object Thread_id { get; set; }
        [JsonIgnore]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public long CommentCount { get; set; }
    }
}
