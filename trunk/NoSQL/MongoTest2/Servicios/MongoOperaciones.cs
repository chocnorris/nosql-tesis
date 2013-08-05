using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoSQL.Servicios;
using NoSQL.Modelo;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using NoSQL.Helpers;

namespace NoSQL.Servicios
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
        public MongoOperaciones(string dbname, string host, string user = "", string pass = "")
        {
            client = new MongoClient("mongodb://"+host);
            server = client.GetServer();
            db = server.GetDatabase(dbname);            
        }

        public MongoOperaciones(string dbname, string[] hosts,string replSetName, string user = "", string pass = "")
        {
            client = new MongoClient("mongodb://" + construirReplSetConn(hosts, replSetName));
            server = client.GetServer();
            db = server.GetDatabase(dbname);
        }

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {

            MongoCollection<Author> col = db.GetCollection<Author>("authors");
            MongoCursor<Author> autores = col.FindAll();
            //OJO! optimización, no trae la foto cuando pedís muchos autores
            autores.SetFields("_id", "Name");
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
            comentario.CommentCount = 0;
            db.GetCollection<Comment>("comments").Insert(comentario);
            string colPadre = "";
            if (comentario.Thread_id.Equals(comentario.Parent_id))
                colPadre = "threads";
            else
                colPadre = "comments";
            db.GetCollection(colPadre).Update(Query.EQ("_id", new ObjectId(comentario.Parent_id.ToString())), Update.Inc("CommentCount", 1));
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
            thread.CommentCount = 0;
            db.GetCollection<Thread>("threads").Insert(thread);
            return thread;
        }
        
        public Author GetAuthor(object id)
        {
            Author author = db.GetCollection<Author>("authors").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
            return author;
        }

        public Thread GetThread(object id)
        {
            Thread thread = db.GetCollection<Thread>("threads").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
            return thread;
        }

        public Comment GetComment(object id)
        {
            Comment comment = db.GetCollection<Comment>("comments").FindOne(Query.EQ("_id", new ObjectId(id.ToString())));
            return comment;
        }

        public bool IsDatabaseConnected()
        {
            return server.State == MongoServerState.Connected || server.State == MongoServerState.ConnectedToSubset; 
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
            var coms = db.GetCollection<Comment>("comments").Find(Query.EQ("author._id", new ObjectId(autor.Id.ToString())));
            foreach (Comment c in coms)
                RemoveComment(c);
            var ths = db.GetCollection<Thread>("threads").Find(Query.EQ("author._id", new ObjectId(autor.Id.ToString())));
            foreach (Thread t in ths)
                RemoveThread(t);
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
            string colPadre = "";
            if (comentario.Thread_id.Equals(comentario.Parent_id))
                colPadre = "threads";
            else
            {
                colPadre = "comments";
            }
            db.GetCollection(colPadre).Update(Query.EQ("_id", new ObjectId(comentario.Parent_id.ToString())), Update.Inc("CommentCount", -1));
            var res = db.GetCollection<Comment>("comments").Remove(Query.EQ("_id", new ObjectId(comentario.Id.ToString())));
            return true;
        }


        public bool Initialize(bool drop)
        {
            //Nota: Mongo no requiere inicialización, salvo para el sharding
            //TODO: Ver índices para las colecciones
            if (drop)
                db.Drop();
            ShardDB();
            //Éste es uno necesario por las fotos
            db.GetCollection("authors").EnsureIndex(new IndexKeysBuilder().Ascending("Name"), IndexOptions.SetUnique(false));
            return true;
        }
        //TODO: Ver cómo parametrizar (o no) el sharding de la db
        private bool ShardDB()
        {
            if (server.Instance.InstanceType != MongoServerInstanceType.ShardRouter)
            {
                return true;
            }
            MongoDatabase db = server.GetDatabase("admin");

            /** Código a ejecutar por consola
            sh.enableSharding("forum")
            sh.shardCollection("forum.comments",{"thread_id":1, "_id":1})
            sh.shardCollection("forum.threads",{"_id":1})
            sh.shardCollection("forum.authors",{"_id":1})
            */

            CommandDocument comandoShard = new CommandDocument();
            comandoShard.Add("enableSharding", "forum");
            CommandResult res = db.RunCommand(comandoShard);

            comandoShard = new CommandDocument();
            comandoShard.Add("shardCollection", "forum.comments");
            BsonDocument doc = new BsonDocument();
            doc.Add("thread_id", 1);
            doc.Add("_id", 1);
            comandoShard.Add("key", doc);
            res = db.RunCommand(comandoShard);

            comandoShard = new CommandDocument();
            comandoShard.Add("shardCollection", "forum.threads");
            doc = new BsonDocument();
            doc.Add("_id", 1);
            comandoShard.Add("key", doc);
            res = db.RunCommand(comandoShard);

            comandoShard = new CommandDocument();
            comandoShard.Add("shardCollection", "forum.authors");
            doc = new BsonDocument();
            doc.Add("_id", 1);
            comandoShard.Add("key", doc);
            res = db.RunCommand(comandoShard);

            return true;
        }

        public bool Cleanup()
        {
            return Initialize(true);
        }


        public bool Shutdown()
        {
            return true;
        }

        private string construirReplSetConn(string [] hosts, string replSetName)
        {
            string connstr = "";
            for (int i = 0; i < hosts.Count(); i++)
            {
                var row = hosts[i];
                if (!hosts[i].Contains(":"))
                    connstr += hosts[i] + ":27017";
                else
                    connstr += hosts[i];
                if (i < hosts.Count() - 1)
                    connstr += ",";
            }
            return connstr + "/?replicaSet=" + replSetName;
        }
    }
}
