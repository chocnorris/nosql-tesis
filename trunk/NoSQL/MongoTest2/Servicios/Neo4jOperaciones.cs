using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neo4jClient;
using NoSQL.Modelo;
using Neo4jClient.Cypher;

namespace NoSQL.Servicios
{
    public class Neo4jOperaciones : IOperaciones
    {
        GraphClient client;

        public Neo4jOperaciones(string dbname, string host, string user = "", string pass = "")
        {
            string uriString = "http://" + host + ":7474/db/data";
            if(user!="")
                uriString = "http://" + user + ":" + pass + "@" + host + ":7474/db/data";
            client = new GraphClient(new Uri(uriString));
            client.Connect();
            CreateNodesRelationshipsIndexes();
        }
        public bool Initialize(bool dropExistent)
        {
            bool ret = true;
            if (dropExistent)
            {
                client.Cypher
                    .Start(new { n = All.Nodes })
                    .Delete("n")
                    .ExecuteWithoutResults();
            }
            CreateNodesRelationshipsIndexes();
            return ret;
        }

        private void CreateNodesRelationshipsIndexes()
        {
            client.CreateIndex("Author", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.exact }, IndexFor.Node); // full text node index
            client.CreateIndex("Thread", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.fulltext }, IndexFor.Node); // full text node index
            client.CreateIndex("Comment", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.fulltext }, IndexFor.Node); // full text node index
        }

        public bool Cleanup()
        {
            return Initialize(true);
        }

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {
            var res = client
                .Cypher 
                .Start(new { n = Node.ByIndexQuery("Author", "*:*") })
                .Return<Node<Author>>("n");
            List<Node<Author>> lista = res.Results.ToList();
            List<Author> ret = new List<Author>();
            Author aut;
            foreach (Node<Author> node in lista)
            {
                aut = node.Data;
                aut.Id = node.Reference.Id;
                ret.Add(aut);
            }
            return ret;
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            var res = client
                .Cypher
                .Start(new { n = Node.ByIndexQuery("Comment", "*:*") })
                .Return<Node<Comment>>("n");
            List<Node<Comment>> lista = res.Results.ToList();
            List<Comment> ret = new List<Comment>();
            Comment com;
            foreach (Node<Comment> node in lista)
            {
                com = node.Data;
                com.Id = node.Reference.Id;
                var aut = client
                    .Cypher
                    .Start(new { comment = new NodeReference((long)com.Id) })
                    .Match("(comment)<-[:WROTEC]-(author)")
                    .Return<Node<Author>>("author");
                com.Author = new Author()
                {
                    Id = aut.Results.FirstOrDefault().Reference.Id,
                    Name = aut.Results.FirstOrDefault().Data.Name
                };
                ret.Add(com);
            }
            return ret;
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            if (Parent_id.GetType().Equals(typeof(string)))
                Parent_id = long.Parse((string)Parent_id);
            var lista = client
            .Cypher
            .Start(new { parent = new NodeReference((long)Parent_id) })
            .Match("(parent)<-[:PARENT]-(comment)")
            .Return<Node<Comment>>("comment").Results.ToList();
            List<Comment> ret = new List<Comment>();
            Comment com;
            foreach (Node<Comment> node in lista)
            {
                com = node.Data;
                com.Id = node.Reference.Id;
                var aut = client
                    .Cypher
                    .Start(new { comment = new NodeReference((long)com.Id) })
                    .Match("(comment)<-[:WROTEC]-(author)")
                    .Return<Node<Author>>("author");
                com.Author = new Author()
                {
                    Id = aut.Results.FirstOrDefault().Reference.Id,
                    Name = aut.Results.FirstOrDefault().Data.Name
                };
                ret.Add(com);
            }
            return ret;
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            var res = client
                .Cypher
                .Start(new { n = Node.ByIndexQuery("Thread", "*:*") })
                .Return<Node<Thread>>("n");
            List<Node<Thread>> lista = res.Results.ToList();
            List<Thread> ret = new List<Thread>();
            Thread thr;
            foreach (Node<Thread> node in lista)
            {
                thr = node.Data;
                thr.Id = node.Reference.Id;
                var aut = client
                    .Cypher
                    .Start(new { thread = new NodeReference((long)thr.Id)})
                    .Match("(thread)<-[:WROTET]-(author)")
                    .Return<Node<Author>>("author");
                thr.Author = new Author()
                {
                    Id = aut.Results.FirstOrDefault().Reference.Id,
                    Name = aut.Results.FirstOrDefault().Data.Name
                };
                ret.Add(thr);
            }
            return ret;
        }

        public Thread GetThread(object id)
        {
            if (id.GetType().Equals(typeof(string)))
                id = long.Parse((string)id);
            var node = client.Get<Thread>(new NodeReference((long)id));
            Thread thr = node.Data;
            thr.Id = node.Reference.Id;
            var aut = client
                .Cypher
                .Start(new { thread = new NodeReference((long)thr.Id) })
                .Match("(thread)<-[:WROTET]-(author)")
                .Return<Node<Author>>("author");
            thr.Author = new Author()
            {
                Id = aut.Results.FirstOrDefault().Reference.Id,
                Name = aut.Results.FirstOrDefault().Data.Name,
            };
            return thr;
        }

        public Author GetAuthor(object id)
        {
            if (id.GetType().Equals(typeof(string)))
                id = long.Parse((string)id);
            var node = client.Get<Author>(new NodeReference((long)id));
            Author aut = node.Data;
            aut.Id = node.Reference.Id;
            return aut;
        }

        public Comment GetComment(object id)
        {
            if (id.GetType().Equals(typeof(string)))
                id = long.Parse((string)id);
            var node = client.Get<Comment>(new NodeReference((long)id));
            Comment com = node.Data;
            com.Id = node.Reference.Id;
            var aut = client
                .Cypher
                .Start(new { comment = new NodeReference((long)com.Id) })
                .Match("(comment)<-[:WROTEC]-(author)")
                .Return<Node<Author>>("author");
            com.Author = new Author()
            {
                Id = aut.Results.FirstOrDefault().Reference.Id,
                Name = aut.Results.FirstOrDefault().Data.Name,
            };
            return com;
        }

        public Comment AddComment(Comment comentario)
        {
            var auth = client.Get<Author>(new NodeReference((long)comentario.Author.Id));
            NodeReference<Comment> theComment = client.Create(comentario,
                new IRelationshipAllowingParticipantNode<Comment>[0],
                new[]
                    {
                        new IndexEntry("Comment")
                    {
                        { "Text", comentario.Text},
                    }
                    });
            client.CreateRelationship(auth.Reference, new WroteComment(theComment, new Payload() { Date = comentario.Date }));

            NodeReference<Thread> thr = null;
            if (comentario.Thread_id.GetType().Equals(typeof(string)))
                thr = new NodeReference<Thread>(long.Parse((string)comentario.Thread_id));
            else
                thr = new NodeReference<Thread>((long)comentario.Thread_id);
            client.CreateRelationship(theComment, new CommentThread(thr, null));

            if (comentario.Thread_id.Equals(comentario.Parent_id))
            {
                NodeReference<Thread> par = null;
                if (comentario.Parent_id.GetType().Equals(typeof(string)))
                    par = new NodeReference<Thread>(long.Parse((string)comentario.Parent_id));
                else
                    par = new NodeReference<Thread>((long)comentario.Parent_id);
                client.CreateRelationship(theComment, new ParentCommentT(par, null));
            }
            else
            {
                NodeReference<Comment> par2 = null;
                if (comentario.Parent_id.GetType().Equals(typeof(string)))
                    par2 = new NodeReference<Comment>(long.Parse((string)comentario.Parent_id));
                else
                    par2 = new NodeReference<Comment>((long)comentario.Parent_id);
                client.CreateRelationship(theComment, new ParentCommentC(par2, null));

            }
            return comentario;
        }

        public Author AddAuthor(Author autor)
        {
            var theauthor = client.Create(autor,
                new IRelationshipAllowingParticipantNode<Author>[0],
                new[]
                {
                    new IndexEntry("Author")
                    {
                        { "Name", autor.Name },
                    }
                });
            autor.Id = theauthor.Id;
            return autor;
        }

        public Thread AddThread(Thread thread)
        {
            var auth = client.Get<Author>(new NodeReference((long)thread.Author.Id));
            var theThread = client.Create(thread,
                    new IRelationshipAllowingParticipantNode<Thread>[0],
                    new[]
                    {
                        new IndexEntry("Thread")
                        {
                            { "Title", thread.Title }
                        }
                    });
            client.CreateRelationship(auth.Reference, new WroteThread(theThread, new Payload() { Date = thread.Date }));
            return thread;
        }

        public long GetAuthorsCount()
        {
            return GetAuthors().Count;
        }

        public long GetThreadsCount()
        {
            return GetThreads().Count;
        }

        public long GetCommentsCount()
        {
            return GetComments().Count;
        }

        public bool RemoveAuthor(Author autor)
        {
            throw new NotImplementedException();
        }

        public bool RemoveThread(Thread thread)
        {
            throw new NotImplementedException();
        }

        public bool RemoveComment(Comment comentario)
        {
            throw new NotImplementedException();
        }

        public int ThradsByAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public List<Author> AuthorsByName(string name, int max)
        {
            throw new NotImplementedException();
        }

        public bool IsDatabaseConnected()
        {
            return true;
        }

        public string ConnectionState()
        {
            throw new NotImplementedException();
        }

        public string Identidad()
        {
            return "Neo4j";
        }

        public bool Shutdown()
        {
            throw new NotImplementedException();
        }


        public int ThreadsByAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public List<Author> AuthorsPopular(int cant)
        {
            throw new NotImplementedException();
        }
    }
}
