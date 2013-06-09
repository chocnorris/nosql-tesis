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
        /// Devolver una lista de sentencias para ejecutar sobre Cassandra donde cada una crea un column family (tabla)
        /// tomando el modelo de clases como referencia 
        /// </summary>
        /// <param name="modelNamespacePath"></param>
        /// <returns></returns>
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
        /// Devolver el tipo correspodiente a Cassandra dado un tipo de C#
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
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
        /// Crear column families (tablas) en base al Modelo
        /// </summary>
        protected void createColumnFamilies()
        {
            var statements = getCassandraCreateStatementsBasedOnModel("MongoTest2.Modelo");
            foreach (string statement in statements)
                db.ExecuteNonQuery(statement);
        }

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            throw new NotImplementedException();
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            throw new NotImplementedException();
        }

        public Thread GetThread(object id)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(object id)
        {
            throw new NotImplementedException();
        }

        public Comment GetComment(object id)
        {
            throw new NotImplementedException();
        }

        public Comment AddComment(Comment comentario)
        {
            throw new NotImplementedException();
        }

        public Author AddAuthor(Author autor)
        {
            throw new NotImplementedException();
        }

        public Thread AddThread(Thread thread)
        {
            throw new NotImplementedException();
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
    }
}
