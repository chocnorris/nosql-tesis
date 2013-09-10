using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;

namespace NoSQL.Modelo
{
    public class CommentThread : Relationship, IRelationshipAllowingSourceNode<Comment>,
 IRelationshipAllowingTargetNode<Thread>
    {
        public static readonly string TypeKey = "COMMTH";

        public string Caption { get; set; }

        public CommentThread(NodeReference targetNode)
            : base(targetNode)
        { }

        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
