using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Modelo;
using FluentCassandra;
using System.Reflection;

namespace MongoTest2
{
    public class CassandraOperaciones : IOperaciones
    {

        protected CassandraContext db;        
        protected CassandraKeyspace Keyspace;
        protected string KeyspaceName;

        /// <summary>
        /// Crear una instancia de base de datos para Cassandra
        /// </summary>
        /// <param name="dbname">Base de datos/ keyspace</param>
        /// <param name="host">Host</param>
        public CassandraOperaciones(string dbname, string host)
        {
            KeyspaceName = dbname;
            db = new CassandraContext(dbname, host);
            createKeyspace();
            createColumnFamilies();
        }

        #region Implementaciones de interfaz

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {                
            var Authors =
                from u in db.GetColumnFamily("Authors").AsObjectQueryable<Author>()                                
                select u;
            return Authors.Skip(skip).Take(take).ToList();
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            var Comments =
                from c in db.GetColumnFamily("Comments").AsObjectQueryable<Comment>()                
                select c;
            return Comments.Skip(skip).Take(take).ToList();
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            var Comments =
                from c in db.GetColumnFamily("Comments").AsObjectQueryable<Comment>()
                where c.Parent_id == Parent_id
                select c;
            return Comments.ToList();
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            var Threads =
                from t in db.GetColumnFamily("Threads").AsObjectQueryable<Thread>()
                select t;
            return Threads.Skip(skip).Take(0).ToList();
        }

        public Thread GetThread(object id)
        {
            var q = from t in db.GetColumnFamily("Threads").AsObjectQueryable<Thread>()
               where t.Id == id
               select t;
            return q.First();
        }

        public Author GetAuthor(object id)
        {
            var q = from a in db.GetColumnFamily("Authors").AsObjectQueryable<Author>()
                where a.Id == id
                select a;
            return q.First();
        }

        public Comment GetComment(object id)
        {
            var q = from c in db.GetColumnFamily("Comments").AsObjectQueryable<Comment>()
                    where c.Id == id
                    select c;
            return q.First();
        }
       
        public Comment AddComment(Comment comentario)
        {
            string addStmt = string.Format(getInsertStatementFor("Comments", "MongoTest2.Modelo"),
                comentario.Author,
                comentario.CommentCount,
                comentario.Date,
                comentario.Id,
                comentario.Parent_id,
                comentario.Text,
                comentario.Thread_id);
            db.ExecuteNonQuery(addStmt);
            return comentario;            
        }

        public Author AddAuthor(Author autor)
        {
            string addStmt = string.Format(getInsertStatementFor("Authors", "MongoTest2.Modelo"),
                autor.Name, autor.Id);
            return autor;            
        }

        public Thread AddThread(Thread thread)
        {
            string addStmt = string.Format(getInsertStatementFor("Threads", "MongoTest2.Modelo"),
                thread.Author,
                thread.CommentCount,
                thread.Date,
                thread.Id,
                thread.Title);
            return thread;
        }

        public long GetAuthorsCount()
        {
            throw new NotImplementedException();
        }

        public long GetThreadsCount()
        {
            throw new NotImplementedException();
        }

        public long GetCommentsCount()
        {
            throw new NotImplementedException();
        }

        public bool IsDatabaseConnected()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetShards()
        {
            var dc = new Dictionary<string, string>();
            dc.Add("1", "localhost");
            return dc;
        }

        public string ConnectionState()
        {
            return "juju";
        }

        public string Identidad()
        {
            return "Cassandra";
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Crear keyspace de nombre keyspacename
        /// </summary>
        protected void createKeyspace()
        {
            if (db.KeyspaceExists(KeyspaceName))
                db.DropKeyspace(KeyspaceName);

            Keyspace = new CassandraKeyspace(new CassandraKeyspaceSchema
            {
                Name = KeyspaceName
            }, db);

            Keyspace.TryCreateSelf();
        }

        /// <summary>
        /// Crear column families (tablas) en base al Modelo
        /// </summary>
        protected void createColumnFamilies()
        {
            var statements = getCassandraCreateStatementsBasedOnModel("MongoTest2.Modelo");
            foreach (string statement in statements)
                db.ExecuteNonQuery(statement);
        }

        /// <summary>
        /// Devolver una lista de sentencias para ejecutar sobre Cassandra donde cada una crea un column family (tabla)
        /// tomando el modelo de clases como referencia 
        /// </summary>
        /// <param name="modelNamespacePath"></param>
        /// <returns>lista de sentencias ejecutables que crean column family</returns>
        protected List<string> getCassandraCreateStatementsBasedOnModel(string modelNamespacePath)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == modelNamespacePath
                    select t;

            List<string> createStatements = new List<string>();
            foreach (Type str in q.ToList())
            {
                string columnFamilyName = str.Name + "s";
                string createStatement = @"create columnfamily """ + columnFamilyName + @""" (";
                int i = 0;
                var properties = str.GetProperties();
                var propertyTypes = new List<string>();
                foreach (PropertyInfo pi in properties)
                {
                    createStatement = createStatement + pi.Name + " " + typeMapping(pi.PropertyType);
                    if (pi.Name.ToLower() == "id")
                        createStatement = createStatement + " PRIMARY KEY";
                    i++;
                    if (i < properties.Count())
                        createStatement = createStatement + ",";
                    else
                        createStatement = createStatement + ");";
                }
                createStatements.Add(createStatement);
            }
            return createStatements;
        }

        /// <summary>
        /// Resolver el tipo correspodiente a Cassandra dado un tipo de C#
        /// </summary>
        /// <param name="type"></param>
        /// <returns>un tipo cassandra</returns>
        protected string typeMapping(Type type)
        {
            if (type == typeof(char) || type == typeof(string))
                return "text";
            if (type == typeof(Int64))
                return "bigint";
            if (type == typeof(int))
                return "int";
            if (type == typeof(float))
                return "float";
            if (type == typeof(Guid) || type == typeof(object))
                return "uuid";
            if (type == typeof(double))
                return "double";
            if (type == typeof(bool))
                return "boolean";
            if (type == typeof(DateTime))
                return "timestamp";

            // por defecto:
            return "text";
        }

        /// <summary>
        /// Devuelve un statement parametrizado para agregar a un column family
        /// </summary>
        /// <param name="columnFamilyName"></param>
        /// <param name="modelNamespacePath"></param>
        /// <returns></returns>
        protected string getInsertStatementFor(string columnFamilyName, string modelNamespacePath)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == modelNamespacePath && t.Name == columnFamilyName
                    select t;
            string stmt = @"INSERT INTO """ + columnFamilyName + @""" (";
            var properties = q.First().GetProperties().OrderBy(p=>p.Name);
            int j = 0;
            foreach (PropertyInfo property in properties)
            {
                stmt = stmt + @"""" + property.Name + @"""";
                j++;
                if (j < properties.Count())
                    stmt = stmt + ",";
                else
                    stmt = stmt + ")";
            }
            stmt = stmt + " VALUES (";
            for (int i = 1; i <= properties.Count(); i++)
            {
                stmt = stmt + "{" + (i - 1) + "}";
                if (i < properties.Count())
                    stmt = stmt + ",";
                else
                    stmt = stmt + ");";
            }
            return stmt;
        }

        #endregion
    }
}
