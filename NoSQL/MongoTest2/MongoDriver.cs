﻿using System;
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
            MongoCollection<Autor> col = db.GetCollection<Autor>("authors");
            MongoCursor<Autor> autores = col.FindAll();
            return autores.ToList();
        }

        public List<Comentario> GetComentarios()
        {
            MongoCollection<Comentario> col = db.GetCollection<Comentario>("comments");
            MongoCursor<Comentario> comentarios = col.FindAll();
            return comentarios.ToList();
        }

        public List<Thread> GetThreads()
        {
            MongoCollection<Thread> col = db.GetCollection<Thread>("threads");
            MongoCursor<Thread> threads = col.FindAll();
            return threads.ToList();
        }

        public Comentario addComentario(Comentario comentario)
        {
            db.GetCollection<Comentario>("comments").Insert(comentario);
            return comentario;
        }

        public Autor addAutor(Autor autor)
        {
            db.GetCollection<Autor>("authors").Insert(autor);
            return autor;
        }

        public Thread addThread(Thread thread)
        {
            db.GetCollection<Thread>("threads").Insert(thread);
            return thread;
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