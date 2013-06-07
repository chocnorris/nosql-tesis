using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Entidades;
using MongoTest2.Modelo;

namespace MongoTest2.Servicios
{
    /// <summary>
    /// Interfaz para ser utilizada por las diferentes implementaciones de base de datos.
    /// </summary>
    public interface IOperaciones
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Autor> GetAutores();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Comentario> GetComentarios();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Autor GetAutor();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Comentario GetComentario();

        }
}
