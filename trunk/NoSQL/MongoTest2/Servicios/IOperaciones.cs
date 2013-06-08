using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Modelo;
using MongoDB.Driver;

namespace MongoTest2.Servicios
{
    /// <summary>
    /// Interfaz para ser utilizada por las diferentes implementaciones de base de datos.
    /// </summary>
    public interface IOperaciones
    {

        #region operaciones CRUD
        /// <summary>
        /// Obtener todos los autores
        /// </summary>
        /// <returns></returns>
        List<Author> GetAutores();

        /// <summary>
        /// Obtener todos los comentarios
        /// </summary>
        /// <returns></returns>
        List<Comment> GetComentarios();

        /// <summary>
        /// Obtener todos los comentarios hijos de un comentario o thread
        /// </summary>
        /// <param name="Parent_id"></param>
        /// <returns></returns>
        List<Comment> GetComentariosHijos(object Parent_id);
        
        /// <summary>
        /// Obtener todos los threads
        /// </summary>
        /// <returns></returns>
        List<Thread> GetThreads();

        /// <summary>
        /// Obtener un thread
        /// </summary>
        /// <returns></returns>
        Thread GetThread(object id);

        /// <summary>
        /// Otener un autor
        /// </summary>
        /// <returns></returns>
        Author GetAutor(object id);

        /// <summary>
        /// Obtener un comentario
        /// </summary>
        /// <returns></returns>
        Comment GetComentario(object id);

        /// <summary>
        /// Agregar un comentario a la base de datos
        /// </summary>
        /// <param name="comentario"></param>
        Comment AddComentario(Comment comentario);

        /// <summary>
        /// Agregar un autor a la base de datos
        /// </summary>
        /// <param name="autor"></param>
        Author AddAutor(Author autor);

        /// <summary>
        /// Agregar un thread a la base de datos
        /// </summary>
        /// <param name="thread"></param>
        Thread AddThread(Thread thread);

        #endregion

        #region Otras
        /// <summary>
        /// Determinar el si se está conectado a la base de datos
        /// </summary>
        /// <returns></returns>
        bool Conectado();

        /// <summary>
        /// Obtener un diccionario conteniendo todos los shards (REVISAR PUEDE HACERSE UNA ENTIDAD PARA SHARd)
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetShards();

        /// <summary>
        /// Retorna el estado de la conexión 
        /// </summary>
        /// <returns></returns>
        string GetEstadoConexion();

        /// <summary>
        /// Temporal
        /// </summary>
        /// <returns></returns>
        MongoDatabase GetDB();

        /// <summary>
        /// Obtener el tipo de la base de datos
        /// </summary>
        /// <returns></returns>
        string Identidad();

        #endregion
    }
}