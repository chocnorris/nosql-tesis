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

        public Neo4jOperaciones()
        {
        }
        public bool Initialize(bool dropExistent)
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"));
            client.Connect();
            CreateNodesRelationshipsIndexes();
            return true;
        }

        private void CreateNodesRelationshipsIndexes()
        {
            client.CreateIndex("Author", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.exact }, IndexFor.Node); // full text node index
            client.CreateIndex("Comment", new IndexConfiguration() { Provider = IndexProvider.lucene, Type = IndexType.fulltext }, IndexFor.Node); // full text node index
        }

        public bool Cleanup()
        {
            client.Cypher.Start(new { n = Neo4jClient.Cypher.All.Nodes }).Delete(" ").ExecuteWithoutResults();
            return true;    
        }

        public List<Modelo.Author> GetAuthors(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Modelo.Comment> GetComments(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Modelo.Comment> GetChildComments(object Parent_id)
        {
            throw new NotImplementedException();
        }

        public List<Modelo.Thread> GetThreads(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public Modelo.Thread GetThread(object id)
        {
            throw new NotImplementedException();
        }

        public Modelo.Author GetAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public Modelo.Comment GetComment(object id)
        {
            throw new NotImplementedException();
        }

        public Comment AddComment(Comment comentario)
        {
            var newComment = new GraphComment() { Id = comentario.Id, Text = comentario.Text };

            NodeReference<GraphComment> theComment = client.Create(newComment,
        new IRelationshipAllowingParticipantNode<GraphComment>[0],
        new[]
                    {
                        new IndexEntry("Comment")
                    {
                        { "Text", newComment.Text},
                        { "Id", newComment.Id }
                    }
                    });
            //NodeReference node;

            string authorName = "'" + comentario.Author.Name + "'";
            //var result = client.Cypher.Start(new { n = Neo4jClient.Cypher.All.Nodes }).Where<Author>(n => n.Name == authorName).Return<Node<Author>>("n").Results.FirstOrDefault();
            var result = client.Cypher.Start(new { n = Neo4jClient.Cypher.All.Nodes }).Return<Node<Author>>("n").
                Results.Where<Node<Author>>(aut=>aut.Data.Name==comentario.Author.Name).FirstOrDefault();
            client.CreateRelationship(result.Reference, new Wrote(theComment, new Payload() { Date = comentario.Date }));
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
                        { "Id", autor.Id.ToString() }
                    }
                });
            return autor;
        }

        public Thread AddThread(Thread thread)
        {
            var theThread = client.Create(thread,
                    new IRelationshipAllowingParticipantNode<Thread>[0],
                    new[]
                    {
                        new IndexEntry("Thread")
                    {
                        { "Title", thread.Title }
                    }
                    });
            return thread;
        }

        public long GetAuthorsCount()
        {
            throw new NotImplementedException();
        }

        public long GetThreadsCount()
        {
            throw new NotImplementedException();
        }

        public long GetCommentsCount()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAuthor(Modelo.Author autor)
        {
            throw new NotImplementedException();
        }

        public bool RemoveThread(Modelo.Thread thread)
        {
            throw new NotImplementedException();
        }

        public bool RemoveComment(Modelo.Comment comentario)
        {
            throw new NotImplementedException();
        }

        public int ThradsByAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public List<Modelo.Author> AuthorsByName(string name, int max)
        {
            throw new NotImplementedException();
        }

        public bool IsDatabaseConnected()
        {
            throw new NotImplementedException();
        }

        public string ConnectionState()
        {
            throw new NotImplementedException();
        }

        public string Identidad()
        {
            throw new NotImplementedException();
        }

        public bool Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}
