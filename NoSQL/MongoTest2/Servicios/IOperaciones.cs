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
        List<Author> GetAuthors();

        /// <summary>
        /// Obtener todos los comentarios
        /// </summary>
        /// <returns></returns>
        List<Comment> GetComments();

        /// <summary>
        /// Obtener todos los comentarios hijos de un comentario o thread
        /// </summary>
        /// <param name="Parent_id">Id de comentario para el cual se quieren obtener sus hijos</param>
        /// <returns></returns>
        List<Comment> GetChildComments(object Parent_id);
        
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
        Author GetAuthor(object id);

        /// <summary>
        /// Obtener un comentario
        /// </summary>
        /// <returns></returns>
        Comment GetComments(object id);

        /// <summary>
        /// Agregar un comentario a la base de datos
        /// </summary>
        /// <param name="comentario"></param>
        Comment AddComment(Comment comentario);

        /// <summary>
        /// Agregar un autor a la base de datos
        /// </summary>
        /// <param name="autor"></param>
        Author AddAuthor(Author autor);

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
        bool IsDatabaseConnected();

        /// <summary>
        /// Obtener un diccionario conteniendo todos los shards (REVISAR PUEDE HACERSE UNA ENTIDAD PARA SHARd)
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetShards();

        /// <summary>
        /// Retorna el estado de la conexión 
        /// </summary>
        /// <returns></returns>
        string ConnectionState();

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