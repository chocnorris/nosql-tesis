using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Entidades;
using MongoTest2.Modelo;
using MongoDB.Driver;

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
        public string Identidad {
            get
            {
                return "MongoDB";
            }
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
        public List<Autor> GetAutores()
        {
            throw new NotImplementedException();
        }

        public List<Comentario> GetComentarios()
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

    }
}
