using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Entidades;
using MongoTest2.Modelo;
using MongoDB.Driver;
using MongoDB.Bson;

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
        public MongoDriver()
        {
            client = new MongoClient("mongodb://localhost");
            server = client.GetServer();
            db = server.GetDatabase("forum");            
        }

        // temporal
        public MongoDriver(MongoClient cl, MongoServer sv)
        {
            client = cl;
            server = sv;
            db = server.GetDatabase("forum");            
        }


        public List<Autor> GetAutores()
        {
            var autores =  new List<Autor>();            
            MongoCursor<BsonDocument> autoresBson = db.GetCollection("authors").FindAll().SetSortOrder("name");
            bool tieneAutores = autoresBson.Count() > 0;
            foreach (var auth in autoresBson)
            {
                BsonId id = new BsonId();
                id.Value = auth["_id"].AsBsonValue;
                autores.Add( new Autor () { 
                    Nombre = auth["Nombre"].AsString, 
                    AutorId = id} );                                
            }
            return autores;
        }

        public List<Comentario> GetComentarios()
        {
            var Comentarios = new List<Comentario>();
            return Comentarios;
        }

        public List<Thread> GetThreads()
        {
            List<Thread> Threads = new List<Thread>();
            MongoCursor<BsonDocument> threads = db.GetCollection("threads").FindAll();            
            foreach (var th in threads)
            {
                BsonId Id = new BsonId();
                Id.Value = th["_id"];
                Threads.Add(new Thread()
                {
                    Id = Id,
                    Titulo = th["title"].AsString
                });
            }
            return Threads;
        }

        public Comentario addComentario(Comentario comentario)
        {
            throw new NotImplementedException();            
        }

        public Autor addAutor(Autor autor)
        {
            var entity = db.GetCollection<Autor>("authors").Insert(autor);
            return autor;
            /*
            if (entity != null)
            {
                BsonId Id = new BsonId();
                Id.Value = entity.ToBsonDocument()["_id"];
                return new Author()
                {
                    AutorId = Id,
                    Nombre = entity.ToBsonDocument()["name"].AsString
                };
            }
            else return null;           
             */
        }

        public Thread addThread(Thread thread)
        {
            throw new NotImplementedException();
        }
        
        public Autor GetAutor(Autor autor)
        {
            throw new NotImplementedException();
        }

        public Comentario GetComentario(Comentario comentario)
        {
            throw new NotImplementedException();
        }

        public bool Conectado()
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

        public string GetEstadoConexion()
        {
            return server.State.ToString();
        }

        public MongoDatabase GetDB()
        {
            return db;
        }

    }
}
