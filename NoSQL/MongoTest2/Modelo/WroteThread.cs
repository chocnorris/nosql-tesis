using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace NoSQL.Modelo
{
    public class WroteThread : Relationship<Payload>, IRelationshipAllowingSourceNode<Author>,
 IRelationshipAllowingTargetNode<Comment>
    {
        public static readonly string TypeKey = "WROTET";

        public string Caption { get; set; }

        public WroteThread(NodeReference targetNode, Payload payload)
            : base(targetNode, payload)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}