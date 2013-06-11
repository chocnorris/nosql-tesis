using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace MongoTest2
{
    public class ComboItem
    {
        public object Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
