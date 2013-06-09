using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Modelo;

namespace MongoTest2
{
    public class CassandraOperaciones : IOperaciones
    {
        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            throw new NotImplementedException();
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public Thread GetThread(object id)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public Comment GetComment(object id)
        {
            throw new NotImplementedException();
        }

        public Comment AddComment(Comment comentario)
        {
            throw new NotImplementedException();
        }

        public Author AddAuthor(Author autor)
        {
            throw new NotImplementedException();
        }

        public Thread AddThread(Thread thread)
        {
            throw new NotImplementedException();
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

        public bool IsDatabaseConnected()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetShards()
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
    }
}
