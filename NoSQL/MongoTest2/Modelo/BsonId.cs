using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace MongoTest2.Modelo
{
    public class BsonId : GenericId
    {       
       public BsonValue Value { get; set; }
    }
}
