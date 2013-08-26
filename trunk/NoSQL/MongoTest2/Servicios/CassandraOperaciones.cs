using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoSQL.Servicios;
using NoSQL.Modelo;
using System.Reflection;
using System.Drawing;
using Cassandra;
using Cassandra.Data;
using System.IO;

namespace NoSQL.Servicios
{
    public class CassandraOperaciones : IOperaciones
    {

        protected Cluster cluster;
        protected Session session;
        protected string keySpaceName;

        public CassandraOperaciones(string dbname, string host, string user = "", string pass = "")
        {
            cluster = Cluster.Builder().AddContactPoint(host).Build();
            //session = cluster.Connect(dbname);
            session = cluster.Connect();
            keySpaceName = dbname;
        }
        public CassandraOperaciones(string dbname, string [] hosts, string user = "", string pass = "")
        {
            Builder builder = Cluster.Builder();
            for (int i = 0; i < hosts.Count(); i++)
                builder.AddContactPoint(hosts[i]);
            cluster = builder.Build();
            //session = cluster.Connect(dbname);
            session = cluster.Connect();
            keySpaceName = dbname;
        }
        #region Implementaciones de interfaz

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {
            var authors = new List<Author>();
            var authorRows = session.Execute(@"SELECT ""Id"" FROM ""Authors""");                        
            var rows = authorRows.GetRows().ToArray();                                       
            if (rows.Count() == 0)                            
                return authors;

            if (skip == 0 && take == 0)
            {
                skip = 0;
                take = rows.Count();
            }
            take += skip;
            while (skip < take)
            {
                var author = new Author();
                author.Id = rows[skip].GetValue<Guid>(0);
                author = this.GetAuthorLight(author.Id);
                authors.Add(author);
                skip++;
            }
            return authors;                        
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            var commentRows = session.Execute(@"SELECT * FROM ""Comments""").GetRows();
            var commentCount = commentRows.Count();

            commentRows = session.Execute(@"SELECT * FROM ""Comments""").GetRows();

            DateTime time1 = DateTime.Now;
            var comments = new List<Comment>();            
            if (commentCount > 0 && commentCount > skip)
            {
                var limit = skip + take;
                while (skip < commentCount && skip < limit)
                {
                    var row = commentRows.ElementAt(skip);
                    var comment = new Comment()
                    {
                        Author = new Author() { Name = row.GetValue<string>("AuthorName"), Id = row.GetValue<Guid>("AuthorId") },
                        CommentCount = 0,
                        Date = row.GetValue<DateTime>("Date"),
                        Id = row.GetValue<Guid>(0),
                        Parent_id = row.GetValue<Guid>("Parent_id"),
                        Thread_id = row.GetValue<Guid>("Thread_id"),
                        Text = row.GetValue<string>("Text"),
                    };
                    comment.CommentCount = GetChildCommentCounts(comment.Id);
                    comments.Add(comment);
                    skip++;
                }
            }
            DateTime time2 = DateTime.Now;
            return comments.ToList();
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            var commentRows = session.Execute(@"SELECT * FROM ""Comments"" WHERE ""Parent_id""=" + Parent_id);
            var comments = new List<Comment>();

            foreach (Row row in commentRows.GetRows())
            {
                var comment = new Comment()
                {
                    Author = new Author() { Name = row.GetValue<string>("AuthorName"), Id = row.GetValue<Guid>("AuthorId") },
                    CommentCount = 0,
                    Date = row.GetValue<DateTime>("Date"),
                    Id = row.GetValue<Guid>(0),
                    Parent_id = row.GetValue<Guid>("Parent_id"),
                    Thread_id = row.GetValue<Guid>("Thread_id"),
                    Text = row.GetValue<string>("Text")
                };
                comment.CommentCount = GetChildCommentCounts(comment.Id);
                comments.Add(comment);
            }
            return comments.ToList();            
        }

        /*
        public List<Thread> GetThreads2(int skip = 0, int take = 0)
        {
            var threadRows = session.Execute(@"SELECT * FROM ""Threads""").GetRows();
            var threadCount = threadRows.Count();
            threadRows = session.Execute(@"SELECT * FROM ""Threads""").GetRows();
            var threads = new List<Thread>();
            if (threadCount > 0 && threadCount > skip)
            {
                var limit = skip + take;
                while (skip < threadCount && skip < limit)
                {
                    var row = threadRows.ElementAt(skip);
                    var thread = new Thread();
                    thread.Author = this.GetAuthor(row.GetValue<Guid>("Author"));
                    thread.Date = row.GetValue<DateTime>("Date");
                    thread.Id = row.GetValue<Guid>(0);
                    thread.CommentCount = GetChildCommentCounts(thread.Id);
                    threads.Add(thread);
                    skip++;
                }
            }
            return threads.ToList();
        }
        */

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            var threadRows = session.Execute(@"SELECT * FROM ""Threads"" LIMIT "+take+1);                   
            var threads = new List<Thread>();
            foreach (Row row in threadRows.GetRows())
            {
                var thread = new Thread()
                {
                    Author = new Author ()
                    { Name = row.GetValue<string>("AuthorName"), Id = row.GetValue<Guid>("AuthorId") },
                    Date = row.GetValue<DateTime>("Date"),
                    Id = row.GetValue<Guid>(0),
                    Title = row.GetValue<string>("Title"),                    
                };
                if (row.GetValue<List<string>>("Tags") != null)
                    thread.Tags = row.GetValue<List<string>>("Tags").ToArray();
                thread.CommentCount = GetChildCommentCounts(thread.Id);
                threads.Add(thread);
            }
            return threads.Skip(skip).ToList();
        }

        public Thread GetThread(object id)
        {            
                var threadRows = session.Execute(@"SELECT * FROM ""Threads"" WHERE ""Id""=" + id).GetRows();
                Row row = threadRows.First();
                var thread = new Thread()
                {
                    Author = new Author() { Name = row.GetValue<string>("AuthorName"), Id = row.GetValue<Guid>("AuthorId") },
                    Date = row.GetValue<DateTime>("Date"),
                    Id = row.GetValue<Guid>(0),
                    Title = row.GetValue<string>("Title"),
                };
                if (row.GetValue<List<string>>("Tags") != null)
                    thread.Tags = row.GetValue<List<string>>("Tags").ToArray();
                thread.CommentCount = GetChildCommentCounts(id);
                return thread;               
        }

        public Author GetAuthor(object id)
        {
            var result = session.Execute(@"SELECT * FROM ""Authors"" WHERE ""Id""="+id).GetRows();

            var author = new Author();
            Row row = result.First();
            author = new Author();
            author.Id = row.GetValue<Guid>(0);
            author.Name = row.GetValue<string>("Name");
            author.Photo = ConvertToBitmap(row.GetValue<byte[]>("Photo"));
            return author;
        }

        public Author GetAuthorLight(object id)
        {
            var result = session.Execute(@"SELECT ""Id"", ""Name"" FROM ""Authors"" WHERE ""Id""=" + id).GetRows();

            var author = new Author();
            Row row = result.First();
            author = new Author();
            author.Id = row.GetValue<Guid>(0);
            author.Name = row.GetValue<string>("Name");
            return author;
        }

        public Comment GetComment(object id)
        {
            var commentRows = session.Execute(@"SELECT * FROM ""Comments"" WHERE ""Id""=" + id).GetRows();
            Row row = commentRows.First();
            var comment = new Comment()
                {
                    Author = new Author() { Name = row.GetValue<string>("AuthorName"), Id = row.GetValue<Guid>("AuthorId") },
                    CommentCount = 0,
                    Date = row.GetValue<DateTime>("Date"),
                    Id = row.GetValue<Guid>(0),
                    Parent_id = row.GetValue<Guid>("Parent_id"),
                    Thread_id = row.GetValue<Guid>("Thread_id"),
                    Text = row.GetValue<string>("Text")
                };
            comment.CommentCount = GetChildCommentCounts(comment.Id);
            return comment;
        }

        public Comment AddComment(Comment comentario)
        {
            // Generar nuevo Id
            Guid id = Guid.NewGuid();

            // Resolver Author Id            
            PreparedStatement statement = session.Prepare(@"insert into ""Comments""(""Id"", ""AuthorId"", ""AuthorName"", ""Text"", ""Parent_id"", ""Thread_id"", ""Date"")
                values (?,?,?,?,?,?,?)");
            BoundStatement boundStatement = new BoundStatement(statement);
            Guid parentid = new Guid((string)comentario.Parent_id);
            Guid threadid = new Guid((string)comentario.Thread_id);
            session.Execute(boundStatement.Bind(id, comentario.Author.Id, comentario.Author.Name, comentario.Text, parentid, threadid, DateTime.Now));
            comentario.Id = id;
            IncrCounterParent(comentario.Parent_id);
            return comentario;
        }

        public Author AddAuthor(Author autor)
        {
            ImageConverter converter = new ImageConverter();
            byte[] bytes = (byte[])converter.ConvertTo(autor.Photo, typeof(byte[]));
            Guid id = Guid.NewGuid();
            PreparedStatement statement = session.Prepare(@"insert into ""Authors""(""Id"", ""Name"", ""Photo"")
                values (?,?,?)");
            BoundStatement boundStatement = new BoundStatement(statement);
            session.Execute(boundStatement.Bind(id, autor.Name, bytes));

            autor.Id = id;
            return autor;
        }

        public Thread AddThread(Thread thread)
        {
            Guid id = Guid.NewGuid();
            string AuthorId = thread.Author.Id.ToString();
            string tags = "";
            foreach (string tag in thread.Tags)
            {
                tags = tags + "'" + tag + "',";
            }
            if (thread.Tags.Count() > 0)
                tags = tags.Remove(tags.Length - 1);
            tags = "[" + tags + "]";

            thread.CommentCount = GetChildCommentCounts(id);
          
            PreparedStatement statement = session.Prepare(@"insert into ""Threads"" (""Id"", ""Title"", ""AuthorId"", ""AuthorName"", ""Date"", ""Tags"")
                values (?,?,?,?,?,?)");            
            BoundStatement boundStatement = new BoundStatement(statement);
            session.Execute(boundStatement.Bind(id, thread.Title, thread.Author.Id, thread.Author.Name, DateTime.Now, thread.Tags));           
            thread.Id = id;
            return thread;
        }

        public long GetAuthorsCount()
        {
            var resu = session.Execute(@"SELECT Count(*) FROM ""Authors""").GetRows();
            long num = resu.First().GetValue<long>(0);
            return num;
        }

        public long GetThreadsCount()
        {
            var resu = session.Execute(@"SELECT Count(*) FROM ""Threads""").GetRows();
            long num = resu.First().GetValue<long>(0);
            return num;
        }

        public long GetCommentsCount()
        {
            var resu = session.Execute(@"SELECT Count(*) FROM ""Comments""").GetRows();
            long num = resu.First().GetValue<long>(0);
            return num;
        }

        public bool RemoveAuthor(Author autor)
        {            
                session.Execute(@"DELETE FROM ""Authors"" WHERE Id = " + autor.Id);
                return true;
        }                    

        public bool RemoveThread(Thread thread)
        {
           
                session.Execute(@"DELETE FROM ""Threads"" WHERE ""Id"" = " + thread.Id);
                return true;            
        }

        public bool RemoveComment(Comment comentario)
        {            
                session.Execute(@"DELETE FROM ""Comments"" WHERE ""Id"" = " + comentario.Id);
                //TODO: Actualizar el contador de comentarios del padre hmm
                return true;            
        }

        public int ThreadsByAuthor(object id)
        {
            return 0;
        }
        public List<Author> AuthorsByName(string name, int max)
        {
            return GetAuthors();
        }
        public List<Author> AuthorsPopular(int cant)
        {
            return new List<Author>();
        }
        public bool IsDatabaseConnected()
        {
            try
            {
                cluster.Metadata.GetKeyspace(keySpaceName);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string ConnectionState()
        {
            if (this.IsDatabaseConnected())
                return "Conectado";
            else
                return "Desconectado";
        }

        public string Identidad()
        {
            return "Cassandra";
        }
        #endregion

        #region Helpers


        /// <summary>
        /// Obtener la cantidad de respuestas de un comentario
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        protected long GetChildCommentCounts(object ParentId)
        {
            var results = session.Execute(@"select * from ""CommentCounts"" where ""Id""=" + ParentId).GetRows().ToList();
            if (results.Count() > 0)
                return results.First().GetValue<long>("count");
            return 0;
        }

        protected void IncrCounterParent(object parentId)
        {
            session.Execute(@"update ""CommentCounts"" set ""count""=""count""+1 where ""Id""=" + parentId);
        }

        /// <summary>
        /// Obtener un bitmap en base a un array de bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        protected Bitmap ConvertToBitmap(byte[] bytes)
        {
            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(bytes);
            return new Bitmap(img);
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
            //session.CreateKeyspace(keySpaceName);
            session.Execute(@"create keyspace "+keySpaceName+@" with REPLICATION = { 'class': 'SimpleStrategy', 'replication_factor': 2 }");
        }

        /// <summary>
        /// Crear column families (tablas) en base al Modelo
        /// </summary>
        protected void createColumnFamilies()
        {

            // Crear cf exceptuadas de la creacion programatica            
            session.Execute(@"create columnfamily ""Authors"" (""Id"" uuid PRIMARY KEY,""Name"" text,""Photo"" blob);");
            
            session.Execute(@"create columnfamily ""Comments"" (""Id"" uuid primary key, ""AuthorId"" uuid, ""AuthorName"" text,
                    ""Text"" text,""Parent_id"" uuid, ""Thread_id"" uuid, ""Date"" timestamp)");


            session.Execute(@"create columnfamily ""Threads"" (""Id"" uuid primary key, ""Title"" text, ""AuthorId"" uuid, ""AuthorName"" text, 
                    ""Date"" timestamp, ""Tags"" list<text>)");

            // Coleccion de tags
            //            db.ExecuteNonQuery(@"ALTER TABLE ""Threads"" ADD tags set<text>");

            // Crear indexes
            session.Execute(@"create index comments_parent_id on ""Comments"" (""Parent_id"")");

            session.Execute(@"create columnfamily ""CommentCounts""(""Id"" uuid primary key, ""count"" counter)");            
        }

        #endregion

        protected bool existsDatabase()
        {
            try
            {
                session.Execute("use " + keySpaceName);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }

        public bool Initialize(bool dropExistent)
        {
            session.Execute("use system");
            if (dropExistent)
                session.DeleteKeyspace(keySpaceName);
            if (!existsDatabase())
            {
                createKeyspace();
                session.Execute("use " + keySpaceName);
                createColumnFamilies();
            }
            cluster.Connect(keySpaceName);
            return true;
        }

        public bool Cleanup()
        {            
                Initialize(true); // JUJUJUJU
                return true;                        
        }


        public bool Shutdown()
        {            
                cluster.Shutdown();
                return true;                        
        }

    }
}
