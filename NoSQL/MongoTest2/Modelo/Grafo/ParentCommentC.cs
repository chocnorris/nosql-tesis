using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace NoSQL.Modelo
{
    public class ParentCommentC : Relationship<Payload>, IRelationshipAllowingSourceNode<Comment>,
 IRelationshipAllowingTargetNode<Thread>
    {
        public static readonly string TypeKey = "PARENT";

        public string Caption { get; set; }
        public ParentCommentC(NodeReference targetNode, Payload payload)
            : base(targetNode, null)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
