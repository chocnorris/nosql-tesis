using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

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
        [BsonIgnore]
        public int ParentVote { get; set; }
    }
}
