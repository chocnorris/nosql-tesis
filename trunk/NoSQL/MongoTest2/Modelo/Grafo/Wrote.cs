using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace NoSQL.Modelo
{
    public class Wrote : Relationship, IRelationshipAllowingSourceNode<Author>,
 IRelationshipAllowingTargetNode<Thread>
    {
        public static readonly string TypeKey = "WROTE";

        public string Caption { get; set; }

        public Wrote(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}