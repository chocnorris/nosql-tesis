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
        List<Autor> GetAutores();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Comentario> GetComentarios();

        /// <summary>
        /// (ver tema de ids)
        /// </summary>
        /// <returns></returns>
        Autor GetAutor(Autor autor);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Comentario GetComentario(Comentario comentario);

        }
}
