using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoSQL.Modelo;
using MongoDB.Driver;

namespace NoSQL.Servicios
{
    /// <summary>
    /// Interfaz para ser utilizada por las diferentes implementaciones de base de datos.
    /// </summary>
    public interface IOperaciones
    {
        #region Configuración
        /// <summary>
        /// Inicializar la base de datos.
        /// </summary>
        /// <param name="dropExistent">true para descartar la base de datos existente</param>
        /// <returns>resultado del proceso</returns>
        bool Initialize(bool dropExistent);

        /// <summary>
        /// Vaciar la base de datos.
        /// </summary>
        /// <returns>resultado del proceso</returns>
        bool Cleanup();
        #endregion

        #region operaciones CRUD
        /// <summary>
        /// Obtener todos los autores o por paginación
        /// </summary>
        /// <returns></returns>
        List<Author> GetAuthors(int skip = 0, int take = 0);

        /// <summary>
        /// Obtener todos los comentarios o por paginación
        /// </summary>
        /// <returns></returns>
        List<Comment> GetComments(int skip = 0, int take = 0);

        /// <summary>
        /// Obtener todos los comentarios hijos de un comentario o thread
        /// </summary>
        /// <param name="Parent_id">Id de comentario para el cual se quieren obtener sus hijos</param>
        /// <returns></returns>
        List<Comment> GetChildComments(object Parent_id);
        
        /// <summary>
        /// Obtener todos los threads o por paginación
        /// </summary>
        /// <returns></returns>
        List<Thread> GetThreads(int skip = 0, int take = 0);

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
        Comment GetComment(object id);

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

        /// <summary>
        /// Retorna el número de autores en la colección
        /// </summary>
        /// <returns></returns>
        
        long GetAuthorsCount();
        /// <summary>
        /// Retorna el número de threads en la colección
        /// </summary>
        /// <returns></returns>
        long GetThreadsCount();

        /// <summary>
        /// Retorna el número de comentarios en la colección
        /// </summary>
        /// <returns></returns>
        long GetCommentsCount();

        /// <summary>
        /// Elimina un autor de la base de datos y todo otro dato asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveAuthor(Author autor);

        /// <summary>
        /// Elimina un thread de la base de datos y todo otro dato asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveThread(Thread thread);

        /// <summary>
        /// Elimina un comentario de la base de datos y todo otro dato asociado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveComment(Comment comentario);
        #endregion

        #region Otras
        /// <summary>
        /// Determinar el si se está conectado a la base de datos
        /// </summary>
        /// <returns></returns>
        bool IsDatabaseConnected();

        /// <summary>
        /// Retorna el estado de la conexión 
        /// </summary>
        /// <returns></returns>
        string ConnectionState();

        /// <summary>
        /// Obtener el tipo de la base de datos
        /// </summary>
        /// <returns></returns>
        string Identidad();

        /// <summary>
        /// Desconceta la base de datos
        /// </summary>
        /// <returns></returns>
        bool Shutdown();

        #endregion
    }
}