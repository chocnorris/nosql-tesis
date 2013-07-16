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
    class MysqlOperaciones: IOperaciones
    {

        MySqlConnection conn;
        string dbname;

        public MysqlOperaciones(string dbname, string host, string user = "forum", string pass = "1234")
        {
            string connStr = "server="+host+";user="+user+";password="+pass+";";
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
            string sql="";
            if (skip == 0 && take == 0)
                sql = "SELECT * FROM Authors";
            else
            {
                sql = "SELECT * FROM Authors OFFSET " + skip + " LIMIT " + take; // <- ni idea que estoy haciendo
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
            string sql = "SELECT * FROM Authors WHERE id = "+id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            var rdr = cmd.ExecuteReader();
            rdr.Read();
            int fileSize = (int)rdr.GetBytes(rdr.GetOrdinal("Photo"), 0, null, 0, 0);
            byte [] rawData = new byte[fileSize];
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
            throw new NotImplementedException();
        }

        public Comment AddComment(Comment comentario)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            return 0;
        }

        public long GetCommentsCount()
        {
            return 0;
        }

        public bool RemoveAuthor(Author autor)
        {
            throw new NotImplementedException();
        }

        public bool RemoveThread(Thread thread)
        {
            throw new NotImplementedException();
        }

        public bool RemoveComment(Comment comentario)
        {
            throw new NotImplementedException();
        }

        public bool IsDatabaseConnected()
        {
            return conn.State.Equals(System.Data.ConnectionState.Open);
        }

        public Dictionary<string, string> GetShards()
        {
            throw new NotImplementedException();
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

    }
}
