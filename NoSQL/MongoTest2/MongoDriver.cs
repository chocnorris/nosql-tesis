using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Modelo;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace MongoTest2
{
    public class MongoDriver : IOperaciones
    {
        MongoClient client;
        MongoServer server;
        MongoDatabase db;

        /// <summary>
        /// Identidad de la base de datos (definir en webconfig mas apropiado)
        /// </summary>
        public string Identidad ()
        {          
            return "MongoDB";            
        }

        /// <summary>
        /// Inicializar base de datos
        /// </summary>
        public MongoDriver(string host)
        {
            client = new MongoClient("mongodb://"+host);
            server = client.GetServer();
            db = server.GetDatabase("forum");            
        }

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {

            MongoCollection<Author> col = db.GetCollection<Author>("authors");
            MongoCursor<Author> autores = col.FindAll();
            if (skip != 0)
                autores = autores.SetSkip(skip);
            if (take != 0)
                autores = autores.SetLimit(take);
            return autores.SetSortOrder("Name").ToList();
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            MongoCollection<Comment> col = db.GetCollection<Comment>("comments");
            MongoCursor<Comment> comentarios = col.FindAll();
            if (skip != 0)
                comentarios = comentarios.SetSkip(skip);
            if (take != 0)
                comentarios = comentarios.SetLimit(take);
            return comentarios.ToList();
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            var query = Query.EQ("Parent_id", ObjectId.Parse(Parent_id.ToString()));
            MongoCollection<Comment> col = db.GetCollection<Comment>("comments");
            MongoCursor<Comment> comentarios = col.Find(query);
            return comentarios.ToList();
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            MongoCollection<Thread> col = db.GetCollection<Thread>("threads");
            MongoCursor<Thread> threads = col.FindAll();
            if (skip != 0)
                threads = threads.SetSkip(skip);
            if (take != 0)
                threads = threads.SetLimit(take);
            return threads.ToList();
        }

        public Comment AddComment(Comment comentario)
        {
            comentario.Id = ObjectId.GenerateNewId();
            comentario.Thread_id = ObjectId.Parse(comentario.Thread_id.ToString());
            comentario.Parent_id = ObjectId.Parse(comentario.Parent_id.ToString());
            db.GetCollection<Comment>("comments").Insert(comentario);
            return comentario;
        }

        public Author AddAuthor(Author autor)
        {
            autor.Id = ObjectId.GenerateNewId();
            db.GetCollection<Author>("authors").Insert(autor);
            return autor;
        }

        public Thread AddThread(Thread thread)
        {
            thread.Id = ObjectId.GenerateNewId();
            db.GetCollection<Thread>("threads").Insert(thread);
            return thread;
        }
        
        public Author GetAuthor(object id)
        {
            return db.GetCollection<Author>("author").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
        }

        public Thread GetThread(object id)
        {
            return db.GetCollection<Thread>("threads").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
        }

        public Comment GetComments(object id)
        {
            return db.GetCollection<Comment>("comments").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
        }

        public bool IsDatabaseConnected()
        {
            return server.State == MongoServerState.Connected; 
        }


        public Dictionary<string, string> GetShards()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var sh in server.GetDatabase("config").GetCollection("shards").FindAll())
            {                
                dictionary.Add(sh["_id"].AsString, sh["host"].AsString);

            }
            return dictionary;
        }

        public string ConnectionState()
        {
            return server.State.ToString();
        }


        public long GetAuthorsCount()
        {
            return db.GetCollection("authors").Count();
        }

        public long GetThreadsCount()
        {
            return db.GetCollection("threads").Count();
        }

        public long GetCommentsCount()
        {
            return db.GetCollection("comments").Count();
        }
    }
}
