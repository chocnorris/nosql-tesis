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
                .Return<Node<Author>>("n")
                .Skip(skip);
            if (take != 0)
                res = res.Limit(take);
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
                .Return<Node<Comment>>("n").Skip(skip);
            if (take != 0)
                res = res.Limit(take);
            List<Node<Comment>> lista = res.Results.ToList();
            List<Comment> ret = new List<Comment>();
            foreach (Node<Comment> node in lista)
            {
                ret.Add(singleComment(node));
            }
            return ret;
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            Parent_id = long.Parse(Parent_id.ToString());
            var lista = client
            .Cypher
            .Start(new { parent = new NodeReference((long)Parent_id) })
            .Match("(parent)<-[:PARENT]-(comment)")
            .Return<Node<Comment>>("comment").Results.ToList();
            List<Comment> ret = new List<Comment>();
            foreach (Node<Comment> node in lista)
            {
                ret.Add(singleComment(node));
            }
            return ret;
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            var res = client
                .Cypher
                .Start(new { n = Node.ByIndexQuery("Thread", "*:*") })
                .Return<Node<Thread>>("n")
                .Skip(skip);
            if (take != 0)
                res = res.Limit(take);
            List<Node<Thread>> lista = res.Results.ToList();
            List<Thread> ret = new List<Thread>();
            foreach (Node<Thread> node in lista)
            {
                ret.Add(singleThread(node));
            }
            return ret;
        }

        public Thread GetThread(object id)
        {
            id = long.Parse(id.ToString());
            var node = client.Get<Thread>(new NodeReference((long)id));
            return singleThread(node);
        }


        public Author GetAuthor(object id)
        {
            id = long.Parse(id.ToString());
            var node = client.Get<Author>(new NodeReference((long)id));
            Author aut = node.Data;
            aut.Id = node.Reference.Id;
            return aut;
        }

        public Comment GetComment(object id)
        {
            id = long.Parse(id.ToString());
            var node = client.Get<Comment>(new NodeReference((long)id));
            return singleComment(node);
        }

        private Thread singleThread(Node<Thread> node)
        {
            Thread thr = node.Data;
            thr.Id = node.Reference.Id;
            var aut = client
                .Cypher
                .Start(new { thread = new NodeReference((long)thr.Id) })
                .Match("(thread)<-[:WROTE]-(author)")
                .Return<Node<Author>>("author");
            Node<Author>nodo = aut.Results.First();
            thr.Author = new Author()
            {
                Id = aut.Results.FirstOrDefault().Reference.Id,
                Name = aut.Results.FirstOrDefault().Data.Name,
            };

            long respuestas = client
                .Cypher
                .Start(new { thread = new NodeReference((long)thr.Id) })
                .Match("(thread)<-[:PARENT]-(comment)")
                .Return(() => All.Count()).Results.FirstOrDefault();

            thr.CommentCount = respuestas;
            return thr;
        }
        private Comment singleComment(Node<Comment> node)
        {
            Comment com = node.Data;
            com.Id = node.Reference.Id;
            var aut = client
                .Cypher
                .Start(new { comment = new NodeReference((long)com.Id) })
                .Match("(comment)<-[:WROTE]-(author)")
                .Return<Node<Author>>("author");
            com.Author = new Author()
            {
                Id = aut.Results.FirstOrDefault().Reference.Id,
                Name = aut.Results.FirstOrDefault().Data.Name,
            };
            var par = client
                .Cypher
                .Start(new { comment = new NodeReference((long)com.Id) })
                .Match("(parent)<-[:PARENT]-(comment)")
                .Return<Node<Comment>>("parent").Results.FirstOrDefault();
            com.Parent_id = par.Reference.Id;
            var thr = client
                .Cypher
                .Start(new { comment = new NodeReference((long)com.Id) })
                .Match("(thread)<-[:COMMTH]-(comment)")
                .Return<Node<Comment>>("thread").Results.FirstOrDefault();
            com.Thread_id = thr.Reference.Id;

            long respuestas = client
            .Cypher
            .Start(new { parent = new NodeReference((long)com.Id) })
            .Match("(parent)<-[:PARENT]-(comment)")
            .Return(() => All.Count()).Results.FirstOrDefault();

            com.CommentCount = respuestas;
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
                        { "Text", comentario.Text}
                    }
                    });
            client.CreateRelationship(auth.Reference, new Wrote(theComment));

            NodeReference<Thread> thr = long.Parse(comentario.Thread_id.ToString());
            client.CreateRelationship(theComment, new CommentThread(thr));
            NodeReference par = new NodeReference<Comment>(long.Parse(comentario.Parent_id.ToString()));
            client.CreateRelationship(theComment, new Parent(par));

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
            client.CreateRelationship(auth.Reference, new Wrote(theThread));
            return thread;
        }

        public long GetAuthorsCount()
        {
            var res = client
            .Cypher
            .Start(new { n = Node.ByIndexQuery("Author", "*:*") })
            .Return(() => All.Count());
            return res.Results.First();
        }

        public long GetThreadsCount()
        {
            var res = client
            .Cypher
            .Start(new { n = Node.ByIndexQuery("Thread", "*:*") })
            .Return(() => All.Count());
            return res.Results.First();
        }

        public long GetCommentsCount()
        {
            var res = client
            .Cypher
            .Start(new { n = Node.ByIndexQuery("Comment", "*:*") })
            .Return(() => All.Count());
            return res.Results.First();
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
            return true;
        }


        public int ThreadsByAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public List<Author> AuthorsPopular(int cant)
        {
            List<Author> lista = GetAuthors();
            return lista;
        }

    }
}
