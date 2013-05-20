using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace MongoTest2
{
    public class ComboItem
    {
        public BsonValue Text { get; set; }
        public BsonValue Value { get; set; }
        public override string ToString()
        {
            return Text + "";
        }
    }
}
