using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Entidades;
using MongoTest2.Modelo;

namespace MongoTest2
{
    public class MongoOperaciones : IOperaciones
    {
        /// <summary>
        /// Inicializar base de datos
        /// </summary>
        public MongoOperaciones()
        {

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
    }
}
