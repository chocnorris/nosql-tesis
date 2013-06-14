using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Modelo;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoTest2.Helpers;

namespace MongoTest2
{
    public class MongoOperaciones : IOperaciones
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
        public MongoOperaciones(string host)
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
            Thread thread = db.GetCollection<Thread>("threads").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
            if(thread != null)
                thread.CommentCount = db.GetCollection<Comment>("comments").Find(Query.EQ("Parent_id", (ObjectId)thread.Id)).Count();
            return thread;
        }

        public Comment GetComment(object id)
        {
            Comment comment = db.GetCollection<Comment>("comments").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
            if(comment != null)
                comment.CommentCount = db.GetCollection<Comment>("comments").Find(Query.EQ("Parent_id", (ObjectId)comment.Id)).Count();
            return comment;
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

        public bool RemoveAuthor(Author autor)
        {
            //Eliminación recursiva!!!
            throw new NotImplementedException();
        }

        public bool RemoveThread(Thread thread)
        {
            db.GetCollection<Comment>("comments").Remove(Query.EQ("thread_id", new ObjectId(thread.Id.ToString())));
            var res = db.GetCollection<Thread>("threads").Remove(Query.EQ("_id", new ObjectId(thread.Id.ToString())));
            return true;
        }

        public bool RemoveComment(Comment comentario)
        {
            //Eliminación recursiva
            var hijos = db.GetCollection<Comment>("comments").Find(Query.EQ("parent_id", new ObjectId(comentario.Id.ToString())));
            foreach (Comment c in hijos)
                RemoveComment(c);
            var res = db.GetCollection<Comment>("comments").Remove(Query.EQ("_id", new ObjectId(comentario.Id.ToString())));
            return true;
        }

        public string ServerInfo(string key, string value)
        {
            CommandDocument comandoStats = new CommandDocument();
            comandoStats.Add("dbstats", 1);
            comandoStats.Add("scale", 1024); //Kb!!
            CommandResult stats = db.RunCommand(comandoStats);

            MongoCollection<BsonDocument> chunks = server.GetDatabase("config").GetCollection("chunks");
            string res = "";
            if (key == "Global")
            {
                res += "Chunks: " +chunks.Count();
                res += Environment.NewLine;
                res += "Tamaño: " + stats.Response["dataSize"] + " Kb";
                res += Environment.NewLine;
                res += Environment.NewLine;
                res += "Autores: " + GetAuthorsCount();
                res += Environment.NewLine;
                res += "Threads: " + GetThreadsCount();
                res += Environment.NewLine;
                res += "Comentarios: " + GetCommentsCount();
                /*
                res += Environment.NewLine;
                res += Environment.NewLine;
                res += stats.Response.ToString();
                 * */
            }
            else
            {
                res += "Chunks: " +
                    chunks.Find(new QueryDocument("shard", key)).Count();
                res += Environment.NewLine;
                res += "Tamaño: " +
                    stats.Response["raw"][value]["dataSize"] + " Kb";
            }
            CommandDocument comandoStatus = new CommandDocument();
            comandoStatus.Add("serverStatus", 1);
            CommandResult status = db.RunCommand(comandoStatus);
            res += Environment.NewLine;
            res += Environment.NewLine;
            res += "Uptime: " + (int)(status.Response["uptime"].AsDouble/60) + " minutos";
            res += Environment.NewLine;
            res += "Metrics: " + JsonHelper.FormatJson(status.Response.ToString());
            return res;
        }

        public bool Initialize(bool drop)
        {
            throw new NotImplementedException();
        }

        public bool Cleanup()
        {
            throw new NotImplementedException();
        }
    }
}
