using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Entidades;
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
        List<Autor> GetAutores();

        /// <summary>
        /// Obtener todos los comentarios
        /// </summary>
        /// <returns></returns>
        List<Comentario> GetComentarios();

        /// <summary>
        /// Obtener todos los threads
        /// </summary>
        /// <returns></returns>
        List<Thread> GetThreads();

        /// <summary>
        /// Otener un autor
        /// </summary>
        /// <returns></returns>
        Autor GetAutor(Autor autor);

        /// <summary>
        /// Obtener un comentario
        /// </summary>
        /// <returns></returns>
        Comentario GetComentario(Comentario comentario);

        /// <summary>
        /// Agregar un comentario a la base de datos
        /// </summary>
        /// <param name="comentario"></param>
        Comentario addComentario(Comentario comentario);

        /// <summary>
        /// Agregar un autor a la base de datos
        /// </summary>
        /// <param name="autor"></param>
        Autor addAutor(Autor autor);

        /// <summary>
        /// Agregar un thread a la base de datos
        /// </summary>
        /// <param name="thread"></param>
        Thread addThread(Thread thread);

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