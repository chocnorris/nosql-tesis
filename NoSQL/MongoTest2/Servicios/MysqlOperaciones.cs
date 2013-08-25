using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoSQL.Modelo;
using NoSQL.Servicios;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace NoSQL.Servicios
{
    class MysqlOperaciones : IOperaciones
    {

        MySqlConnection conn;
        string dbname;

        public MysqlOperaciones(string dbname, string host, string user = "forum", string pass = "1234")
        {
            string connStr = "server=" + host + ";user=" + user + ";password=" + pass + ";";
            this.dbname = dbname;
            conn = new MySqlConnection(connStr);
            conn.Open();
            try
            {
                MySqlScript script = new MySqlScript(conn, "USE " + dbname);
                script.Execute();
            }
            catch (Exception)
            {
                Initialize(false);
            }
        }

        public bool Initialize(bool dropExistent)
        {
            if (dropExistent)
            {
                MySqlScript scriptDrop = new MySqlScript(conn, "DROP DATABASE " + dbname);
                try
                {
                    scriptDrop.Execute();
                }
                catch (Exception)
                {
                }
            }
            MySqlScript script = new MySqlScript(conn);
            script.Query = System.IO.File.ReadAllText(@"..\..\Data\script.sql");
            int result = script.Execute();
            return true;
        }

        public bool Cleanup()
        {
            return Initialize(true);
        }

        public List<Author> GetAuthors(int skip = 0, int take = 0)
        {
            var authors = new List<Author>();
            string sql = "";
            if (skip == 0 && take == 0)
                sql = "SELECT * FROM Authors";
            else
            {
                sql = "SELECT * FROM Authors LIMIT " + take + " OFFSET " + skip; // <- ni idea que estoy haciendo
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Author author = new Author()
                {
                    Id = rdr.GetInt32("id"),
                    Name = rdr.GetString("name"),
                    Photo = null
                };
                authors.Add(author);
            }
            rdr.Close();
            return authors;
        }

        public List<Comment> GetComments(int skip = 0, int take = 0)
        {
            var comments = new List<Comment>();
            string sql = "";
            if (skip == 0 && take == 0)
                sql = "SELECT Base.*, Comments.*, Authors.Name FROM Comments LEFT JOIN Base ON Comments.Id = Base.Id LEFT JOIN Authors ON Authors.id = Base.author_id";
            else
            {
                sql = "SELECT Base.*, Comments.*, Authors.Name FROM Comments LEFT JOIN Base ON Comments.Id = Base.Id LEFT JOIN Authors ON Authors.id = Base.author_id LIMIT " + take + " OFFSET " + skip; // <- ni idea que estoy haciendo
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Comment comment = new Comment()
                {
                    Id = rdr.GetInt32("id"),
                    Text = rdr.GetString("Text"),
                    Date = rdr.GetDateTime("Date"),
                    Parent_id = rdr.GetInt32("Parent_id"),
                    Thread_id = rdr.GetInt32("Thread_id"),
                    CommentCount = rdr.GetInt32("CommentCount"),
                    Author = new Author()
                    {
                        Id = rdr.GetInt32("Author_id"),
                        Name = rdr.GetString("Name")
                    }
                };
                comments.Add(comment);
            }
            rdr.Close();
            return comments;
        }

        public List<Comment> GetChildComments(object Parent_id)
        {
            var comments = new List<Comment>();
            string sql = "SELECT Base.*, Comments.*, Authors.Name FROM Comments LEFT JOIN Base ON Comments.Id = Base.Id LEFT JOIN Authors ON Authors.id = Base.author_id WHERE Comments.Parent_id = " + Parent_id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Comment comment = new Comment()
                {
                    Id = rdr.GetInt32("id"),
                    Text = rdr.GetString("Text"),
                    Date = rdr.GetDateTime("Date"),
                    Parent_id = rdr.GetInt32("Parent_id"),
                    Thread_id = rdr.GetInt32("Thread_id"),
                    CommentCount = rdr.GetInt32("CommentCount"),
                    Author = new Author()
                    {
                        Id = rdr.GetInt32("Author_id"),
                        Name = rdr.GetString("Name")
                    }
                };
                comments.Add(comment);
            }
            rdr.Close();
            return comments;
        }

        public List<Thread> GetThreads(int skip = 0, int take = 0)
        {
            var threads = new List<Thread>();
            string sql = "";
            if (skip == 0 && take == 0)
                sql = "SELECT " +
                    "Base.*, Threads.*, Authors.Name AS Name " +
                    "FROM Threads LEFT JOIN Base ON Threads.Id = Base.Id " +
                    "LEFT JOIN Authors ON Authors.id = Base.author_id  ";
            else
            {
                sql = "SELECT " +
                    "Base.*, Threads.*, Authors.Name AS Name " +
                    "FROM Threads LEFT JOIN Base ON Threads.Id = Base.Id " +
                    "LEFT JOIN Authors ON Authors.id = Base.author_id  " +
                    "LIMIT " + take + " OFFSET " + skip;
            }
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Thread thread = new Thread()
                {
                    Id = rdr.GetInt32("id"),
                    Title = rdr.GetString("Title"),
                    Date = rdr.GetDateTime("Date"),
                    Tags = null,
                    CommentCount = rdr.GetInt32("CommentCount"),
                    Author = new Author()
                    {
                        Id = rdr.GetInt32("Author_id"),
                        Name = rdr.GetString("Name")
                    }
                };
                threads.Add(thread);
            }
            rdr.Close();
            return threads;
        }

        public Thread GetThread(object id)
        {
            string sql = "SELECT Base.*, Threads.*, Authors.Name AS Name, Tags.Tag AS Tag FROM Threads LEFT JOIN Base ON Threads.Id = Base.Id LEFT JOIN Authors ON Base.author_id = Authors.id LEFT JOIN Tags ON Tags.thread_id = Base.id WHERE Threads.Id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<string> tags = new List<string>();
            Thread thread = null;
            bool primero = true;
            while (rdr.Read())
            {
                if (primero)
                {
                     thread = new Thread()
                    {
                        Id = rdr.GetInt32("id"),
                        Title = rdr.GetString("Title"),
                        Date = rdr.GetDateTime("Date"),
                        CommentCount = rdr.GetInt32("CommentCount"),
                        Author = new Author()
                        {
                            Id = rdr.GetInt32("Author_id"),
                            Name = rdr.GetString("Name")
                        }
                    };
                    primero = false;
                }
                if(!rdr.IsDBNull(rdr.GetOrdinal("Tag")))
                    tags.Add(rdr.GetString("Tag"));
            }
            rdr.Close();
            thread.Tags = tags.ToArray();
            return thread;
        }

        public Author GetAuthor(object id)
        {
            string sql = "SELECT * FROM Authors WHERE id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var rdr = cmd.ExecuteReader();
            rdr.Read();
            int fileSize = (int)rdr.GetBytes(rdr.GetOrdinal("Photo"), 0, null, 0, 0);
            byte[] rawData = new byte[fileSize];
            rdr.GetBytes(rdr.GetOrdinal("Photo"), 0, rawData, 0, fileSize);
            Author author = new Author()
            {
                Id = rdr.GetInt32("id"),
                Name = rdr.GetString("name"),
                Photo = ConvertToBitmap(rawData)
            };
            rdr.Close();
            return author;
        }

        public Comment GetComment(object id)
        {
            string sql = "SELECT Base.*, Comments.*, Authors.Name AS Name FROM Comments LEFT JOIN Base ON Comments.Id = Base.Id  LEFT JOIN Authors ON Base.author_id = Authors.id WHERE Comments.Id = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            Comment comment = new Comment()
            {
                Id = rdr.GetInt32("id"),
                Text = rdr.GetString("Text"),
                Date = rdr.GetDateTime("Date"),
                Parent_id = rdr.GetInt32("Parent_id"),
                Thread_id = rdr.GetInt32("Thread_id"),
                CommentCount = rdr.GetInt32("CommentCount"),
                Author = new Author()
                {
                    Id = rdr.GetInt32("Author_id"),
                    Name = rdr.GetString("Name")
                }
            };
            rdr.Close();
            return comment;
        }

        public Comment AddComment(Comment comentario)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Base VALUES(NULL, @Author_id, @Date, @CommentCount)";
            cmd.Parameters.AddWithValue("@Author_id", comentario.Author.Id);
            cmd.Parameters.AddWithValue("@Date", comentario.Date);
            cmd.Parameters.AddWithValue("@CommentCount", 0);
            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "INSERT INTO Comments VALUES(@Id, @Text, @Thread_id, @Parent_id)";
            cmd2.Parameters.AddWithValue("@Id", id);
            cmd2.Parameters.AddWithValue("@Text", comentario.Text);
            cmd2.Parameters.AddWithValue("@Thread_id", comentario.Thread_id);
            cmd2.Parameters.AddWithValue("@Parent_id", comentario.Parent_id);
            cmd2.ExecuteNonQuery();
            comentario.Id = id;

            MySqlCommand cmd3 = new MySqlCommand();
            cmd3.Connection = conn;
            cmd3.CommandText = "UPDATE Base SET CommentCount = CommentCount + 1 WHERE id = @Id";
            cmd3.Parameters.AddWithValue("@Id", comentario.Parent_id);
            cmd3.ExecuteNonQuery();
            return comentario;
        }

        public Author AddAuthor(Author autor)
        {
            ImageConverter converter = new ImageConverter();
            byte[] bytes = (byte[])converter.ConvertTo(autor.Photo, typeof(byte[]));
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO authors VALUES(NULL, @Name, @Photo)";
            cmd.Parameters.AddWithValue("@Name", autor.Name);
            cmd.Parameters.AddWithValue("@Photo", bytes);
            cmd.ExecuteNonQuery();
            long id = cmd.LastInsertedId;
            autor.Id = id;
            return autor;
        }

        public Thread AddThread(Thread thread)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Base VALUES(NULL, @Author_id, @Date, @CommentCount)";
            cmd.Parameters.AddWithValue("@Author_id", thread.Author.Id);
            cmd.Parameters.AddWithValue("@Date", thread.Date);
            cmd.Parameters.AddWithValue("@CommentCount", 0);
            cmd.ExecuteNonQuery();

            long id = cmd.LastInsertedId;
            MySqlCommand cmd2 = new MySqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "INSERT INTO Threads VALUES(@Id, @Title)";
            cmd2.Parameters.AddWithValue("@Id", id);
            cmd2.Parameters.AddWithValue("@Title", thread.Title);
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd3;
            for (int i = 0; i < thread.Tags.Count(); i++)
            {
                cmd3 = new MySqlCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "INSERT INTO Tags VALUES(@Thread_id, @Tag)";
                cmd3.Parameters.AddWithValue("@Thread_id", id);
                cmd3.Parameters.AddWithValue("@Tag", thread.Tags[i]);
                cmd3.ExecuteNonQuery();
            }
            thread.Id = id;
            return thread;
        }

        public long GetAuthorsCount()
        {
            string sql = "SELECT Count(*) AS cant FROM Authors";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var resu = cmd.ExecuteScalar();
            return (Int64)resu;
        }

        public long GetThreadsCount()
        {
            string sql = "SELECT Count(*) AS cant FROM Threads";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var resu = cmd.ExecuteScalar();
            return (Int64)resu;
        }

        public long GetCommentsCount()
        {
            string sql = "SELECT Count(*) AS cant FROM Comments";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var resu = cmd.ExecuteScalar();
            return (Int64)resu;
        }

        public bool RemoveAuthor(Author autor)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Authors WHERE Authors.id = @id";
            cmd.Parameters.AddWithValue("@id", autor.Id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool RemoveThread(Thread thread)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Base WHERE Base.id = @id";
            cmd.Parameters.AddWithValue("@id", thread.Id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool RemoveComment(Comment comentario)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Base WHERE Base.id = @id";
            cmd.Parameters.AddWithValue("@id", comentario.Id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public int ThreadsByAuthor(object id)
        {
            string sql = "SELECT Count(*) AS cant FROM Threads LEFT JOIN Base ON Threads.id = Base.id WHERE Author_id = "+id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var resu = cmd.ExecuteScalar();
            return (Int32)resu;
        }
        public List<Author> AuthorsByName(string name, int max)
        {
            return new List<Author>();
        }
        public bool IsDatabaseConnected()
        {
            return conn.State.Equals(System.Data.ConnectionState.Open);
        }

        public string ConnectionState()
        {
            return conn.State.ToString();
        }

        public string Identidad()
        {
            return "MySQL";
        }

        public bool Shutdown()
        {
            conn.Close();
            return true;
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

        public List<Author> AuthorsPopular(int cant)
        {
            return new List<Author>();
        }
    }
}

