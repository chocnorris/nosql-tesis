using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace NoSQL.Modelo
{
    public class Parent : Relationship<Payload>, IRelationshipAllowingSourceNode<Comment>,
 IRelationshipAllowingTargetNode<object>
    {
        public static readonly string TypeKey = "PARENT";

        public string Caption { get; set; }

        public Parent(NodeReference targetNode, Payload payload)
            : base(targetNode, null)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
