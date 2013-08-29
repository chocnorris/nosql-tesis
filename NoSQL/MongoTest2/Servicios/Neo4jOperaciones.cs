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
                aut.Id = node.Reference;
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
                com.Id = node.Reference;
                ret.Add(com);
            }
            return ret;
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            throw new NotImplementedException();
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
                thr.Id = node.Reference;
                ret.Add(thr);
            }
            return ret;
        }

        public Thread GetThread(object id)
        {
            var node = client.Get<Thread>((NodeReference)id);
            Thread th = node.Data;
            th.Id = node.Reference;
            return th;
        }

        public Author GetAuthor(object id)
        {
            var node = client.Get<Author>((NodeReference)id);
            Author aut = node.Data;
            aut.Id = node.Reference;
            return aut;
        }

        public Comment GetComment(object id)
        {
            var node = client.Get<Comment>((NodeReference)id);
            Comment com = node.Data;
            com.Id = node.Reference;
            return com;
        }

        public Comment AddComment(Comment comentario)
        {

            NodeReference<Comment> theComment = client.Create(comentario,
                new IRelationshipAllowingParticipantNode<Comment>[0],
                new[]
                    {
                        new IndexEntry("Comment")
                    {
                        { "Text", comentario.Text},
                    }
                    });
            client.CreateRelationship((NodeReference<Author>)comentario.Author.Id, new WroteComment(theComment, new Payload() { Date = comentario.Date }));
            client.CreateRelationship(theComment, new CommentThread((NodeReference<Thread>)comentario.Thread_id, null));
            var obj = GetThread(comentario.Parent_id);
            if(obj != null)
                client.CreateRelationship(theComment, new ParentCommentT((NodeReference<Thread>)comentario.Thread_id, null));
            else
                client.CreateRelationship(theComment, new ParentCommentC((NodeReference<Comment>)comentario.Thread_id, null));
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
            var auth = client.Get<Author>((NodeReference)thread.Author.Id);
            var theThread = client.Create(thread,
                    new IRelationshipAllowingParticipantNode<Thread>[0],
                    new[]
                    {
                        new IndexEntry("Thread")
                        {
                            { "Title", thread.Title }
                        }
                    });
            client.CreateRelationship((NodeReference<Author>)thread.Author.Id, new WroteThread(theThread, new Payload() { Date = thread.Date }));
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
