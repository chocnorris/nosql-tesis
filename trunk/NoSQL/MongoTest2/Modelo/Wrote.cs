using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace NoSQL.Modelo
{
    public class Wrote : Relationship<Payload>, IRelationshipAllowingSourceNode<Author>,
 IRelationshipAllowingTargetNode<Comment>
    {
        public static readonly string TypeKey = "WROTE";

        public string Caption { get; set; }

        public Wrote(NodeReference targetNode, Payload payload)
            : base(targetNode, payload)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
