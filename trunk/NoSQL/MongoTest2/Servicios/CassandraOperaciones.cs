using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Servicios;
using MongoTest2.Modelo;
using FluentCassandra;
using System.Reflection;
using FluentCassandra.Types;
using System.Drawing;

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
        }

        #region Implementaciones de interfaz

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {                
            var Authors =
                from u in db.GetColumnFamily("Authors").AsObjectQueryable<Author>()                
                select u;

            return Authors.ToList();
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            try
            {
                var commentRows = db.ExecuteQuery(@"SELECT * FROM ""Comments""").ToList();
                var comments = new List<Comment>();
                foreach (FluentCqlRow row in commentRows)
                {
                    var comment = new Comment();
                    foreach (FluentColumn column in row)
                    {
                        var propertyValueInfo = comment.GetType().GetProperty(column.ColumnName.GetValue<string>());
                        if (column.ColumnName == "Author")
                        {
                            comment.Author = this.GetAuthor(column.ColumnValue.GetValue());
                        }
                        else
                        {
                            if (column.ColumnValue != null)
                            {
                                if (column.ColumnValue.GetType() == typeof(DateType))
                                    comment.Date = column.ColumnValue;
                                else
                                    propertyValueInfo.SetValue(comment, column.ColumnValue.GetValue(), null);
                            }
                        }
                    }
                    comments.Add(comment);
                }
                return comments.ToList().Skip(skip).ToList();
            }
            catch (Exception e)
            {
                return new List<Comment>();
            }            
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            try
            {
                var commentRows = db.ExecuteQuery(@"SELECT * FROM ""Comments"" WHERE ""Parent_id""=" + Parent_id).ToList();
                var comments = new List<Comment>();
                foreach (FluentCqlRow row in commentRows)
                {
                    var comment = new Comment();
                    foreach (FluentColumn column in row)
                    {
                        var propertyValueInfo = comment.GetType().GetProperty(column.ColumnName.GetValue<string>());
                        if (column.ColumnName == "Author")
                        {
                            comment.Author = this.GetAuthor(column.ColumnValue.GetValue());
                        }
                        else
                        {
                            if (column.ColumnValue != null)
                            {
                                if (column.ColumnValue.GetType() == typeof(DateType))
                                    comment.Date = column.ColumnValue;
                                else
                                    propertyValueInfo.SetValue(comment, column.ColumnValue.GetValue(), null);
                            }
                        }
                    }
                    comments.Add(comment);
                }
                return comments.ToList();
            }
            catch (Exception e)
            {
                return new List<Comment>();
            }            
        }                     

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            var threadRows = db.ExecuteQuery(@"SELECT * FROM ""Threads""").ToList();            
            var threads = new List<Thread>();
            foreach (FluentCqlRow row in threadRows)
            {
                var thread = new Thread();
                foreach (FluentColumn column in row)
                {
                    var propertyValueInfo = thread.GetType().GetProperty(column.ColumnName.GetValue<string>());
                    if (column.ColumnName == "Author")
                    {
                        thread.Author = this.GetAuthor(column.ColumnValue.GetValue());                       
                    }
                    else
                    {                        
                        if (column.ColumnValue != null)
                        {
                            if (column.ColumnValue.GetType() == typeof(DateType))
                                thread.Date = column.ColumnValue;
                            else
                                propertyValueInfo.SetValue(thread, column.ColumnValue.GetValue(), null);
                        }
                    }
                }
                threads.Add(thread);
            }
            return threads.Skip(skip).ToList();
        }

        public Thread GetThread(object id)
        {
            try
            {
                var threadRows = db.ExecuteQuery(@"SELECT * FROM ""Threads"" WHERE ""Id""=" + id);
                var thread = new Thread();
                foreach (FluentColumn column in threadRows.First().Columns)
                {
                    var propertyValueInfo = thread.GetType().GetProperty(column.ColumnName.GetValue<string>());
                    if (column.ColumnName == "Author")
                    {
                        thread.Author = this.GetAuthor(column.ColumnValue.GetValue());
                    }
                    else
                    {
                        if (column.ColumnValue != null)
                        {                            
                            if (column.ColumnValue.GetType() == typeof(DateType))
                                thread.Date = column.ColumnValue;
                            else                             
                                propertyValueInfo.SetValue(thread, column.ColumnValue.GetValue(), null);
                        }
                    }
                }
                return thread;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Author GetAuthor(object id)
        {
            var result = db.ExecuteQuery(@"SELECT * FROM ""Authors"" WHERE ""Id""=" + id);
            var author = new Author();
            if (result.Count()>0)
            {                
                foreach (FluentColumn column in result.First().Columns)
                {
                    var propertyValueInfo = author.GetType().GetProperty(column.ColumnName.GetValue<string>());
                    propertyValueInfo.SetValue(author, column.ColumnValue.GetValue(), null);
                }
            }
            return author;                                
        }

        public Comment GetComment(object id)
        {
            var commentRows = db.ExecuteQuery(@"SELECT * FROM ""Comments"" WHERE ""Id""=" + id);
            var comment = new Comment();
            foreach (FluentColumn column in commentRows.First().Columns)
            {
                var propertyValueInfo = comment.GetType().GetProperty(column.ColumnName.GetValue<string>());
                if (column.ColumnName == "Author")
                {
                    comment.Author = this.GetAuthor(column.ColumnValue.GetValue());
                }
                else
                {
                    if (column.ColumnValue != null)
                    {
                        if (column.ColumnValue.GetType() == typeof(DateType))
                            comment.Date = column.ColumnValue;
                        else
                            propertyValueInfo.SetValue(comment, column.ColumnValue.GetValue(), null);
                    }
                }
            }
            return comment;
        }
       
        public Comment AddComment(Comment comentario)
        {                        
            // Generar nuevo Id
            Guid id = Guid.NewGuid();

            // Resolver Author Id            
            UUIDType Autoruuid = (UUIDType)comentario.Author.Id;
            string AuthorId = Autoruuid.GetValue().ToString();
             
            string addStmt = string.Format(getInsertStatementFor("Comment", "MongoTest2.Modelo"),                
                AuthorId,
                0,
                getDateInMilliseconds(),                
                id,
                comentario.Parent_id,
                asCassandraString(comentario.Text),
                comentario.Thread_id
                );
            db.ExecuteNonQuery(addStmt);
            //TODO: Actualizar el contador de comentarios del padre!!
            comentario.Id = id;
            return comentario;            
        }

        public Author AddAuthor(Author autor)
        {                        
            ImageConverter converter = new ImageConverter();
            byte[] bytes = (byte[])converter.ConvertTo(autor.Photo, typeof(byte[]));                        
            Guid id = Guid.NewGuid();                                               
            string addStmt = string.Format(getInsertStatementFor("Author", "MongoTest2.Modelo"),
                id,
                asCassandraString(autor.Name),
                asCassandraString(BitConverter.ToString(bytes).Replace("-","")));           
            db.ExecuteNonQuery(addStmt);
            autor.Id = id;            
            return autor;
        }

        public Thread AddThread(Thread thread)
        {           

            Guid id = Guid.NewGuid();            
            UUIDType uuid = (UUIDType)thread.Author.Id;
            string AuthorId = uuid.GetValue().ToString();
            string addStmt = string.Format(getInsertStatementFor("Thread", "MongoTest2.Modelo"),
                AuthorId,
                thread.CommentCount,
                getDateInMilliseconds(),
                id,
                asCassandraString(thread.Title)
                );
            db.ExecuteNonQuery(addStmt);
            thread.Id = id;

            string tagsQuery = @"UPDATE ""Threads"" SET tags = tags +";
            foreach (string tag in thread.Tags)
            {
                tagsQuery = tag + "{'" + tag + "'}";
            }
            db.ExecuteNonQuery(tagsQuery);
            return thread;
        }

        public long GetAuthorsCount()
        {
            var resu = db.ExecuteQuery(@"SELECT Count(*) FROM ""Authors""");
            var cant = resu.First().Columns.First().ColumnValue;
            return cant;
        }

        public long GetThreadsCount()
        {
            var resu = db.ExecuteQuery(@"SELECT Count(*) FROM ""Threads""");
            var cant = resu.First().Columns.First().ColumnValue;
            return cant;
        }

        public long GetCommentsCount()
        {
            var resu = db.ExecuteQuery(@"SELECT Count(*) FROM ""Comments""");
            var cant = resu.First().Columns.First().ColumnValue;
            return cant;
        }

        public bool RemoveAuthor(Author autor)
        {
            try
            {
            db.ExecuteNonQuery(@"DELETE FROM ""Authors"" WHERE Id = "+autor.Id);                
            return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool RemoveThread(Thread thread)
        {
            try
            {
            db.ExecuteNonQuery(@"DELETE FROM ""Threads"" WHERE ""Id"" = "+thread.Id);                
            return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool RemoveComment(Comment comentario)
        {
            try
            {
            db.ExecuteNonQuery(@"DELETE FROM ""Comments"" WHERE ""Id"" = "+comentario.Id);
                //TODO: Actualizar el contador de comentarios del padre
            return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool IsDatabaseConnected()
        {
            return true;
        }

        public Dictionary<string, string> GetShards()
        {
            var dc = new Dictionary<string, string>();
            dc.Add("1", "localhost");
            return dc;
        }

        public string ConnectionState()
        {
            return "Conectado (mentira)";
        }

        public string Identidad()
        {
            return "Cassandra";
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Convertir String hexadecimal a byte
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        /// <summary>
        /// Obtener la fecha actual en milisegundos
        /// </summary>
        /// <returns></returns>
        protected long getDateInMilliseconds()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            return (long)t.TotalMilliseconds;
        }

        /// <summary>
        /// Crear keyspace de nombre keyspacename
        /// </summary>
        protected void createKeyspace()
        {          
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
            
            // Coleccion de tags
            db.ExecuteNonQuery(@"ALTER TABLE ""Threads"" ADD tags set<text>");

            // Crear index
            db.ExecuteNonQuery(@"create index comments_parent_id on ""Comments"" (""Parent_id"")");

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
                    createStatement = createStatement + @""""+pi.Name + @""" " + typeMapping(pi.PropertyType);
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
            if (type == typeof(Bitmap))
                return "blob";
            if (type == typeof(char) || type == typeof(string))
                return "text";            
            if (type == typeof(Int64) || type==typeof(long))
                return "bigint";
            if (type == typeof(int))
                return "int";
            if (type == typeof(float))
                return "float";                            
            if (type == typeof(double))
                return "double";
            if (type == typeof(bool))
                return "boolean";
            if (type == typeof(DateTime))
                return "timestamp";
            if (type == typeof(object) || !(type == typeof(ValueType)))
                return "uuid";

            // por defecto:
            return "text";
        }

        /// <summary>
        /// Devuelve un statement parametrizado para agregar a un column family
        /// </summary>
        /// <param name="columnFamilyName"></param>
        /// <param name="modelNamespacePath"></param>
        /// <returns></returns>
        protected string getInsertStatementFor(string entityName, string modelNamespacePath)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == modelNamespacePath && t.Name == entityName
                    select t;
            string stmt = @"INSERT INTO """ + entityName + @"s"" (";
            var properties = q.First().GetProperties().OrderBy(p=>p.Name.ToUpper());
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

        /// <summary>
        /// Dado un string, devolver entre ''
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        protected string asCassandraString(string str)
        {
            return "'" + str + "'";
        }
        #endregion

        public bool Initialize(bool dropExistent)
        {
            try
            {
                if (db.KeyspaceExists(KeyspaceName) && dropExistent)
                {
                    db.DropKeyspace(KeyspaceName);
                    createKeyspace();
                    createColumnFamilies();
                }
                else
                {
                    Keyspace = new CassandraKeyspace(new CassandraKeyspaceSchema
                    {
                        Name = KeyspaceName
                    }, db);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Cleanup()
        {
            try
            {
                db.DropKeyspace(KeyspaceName);
                createKeyspace();
                createColumnFamilies();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
