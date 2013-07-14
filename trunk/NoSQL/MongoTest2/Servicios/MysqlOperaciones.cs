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

        public MysqlOperaciones(string dbname, string host, string user = "forum", string pass = "1234")
        {
            string connStr = "server="+host+";user="+user+";database="+dbname+";password="+pass+";";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        public bool Initialize(bool dropExistent)
        {
            throw new NotImplementedException();
        }

        public bool Cleanup()
        {
            throw new NotImplementedException();
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
                Author author = new Author();
                author.Id = rdr.GetInt32(0);
                author.Name = rdr.GetString(1);
                author.Photo = new Bitmap(1, 1);
                
            }
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
            ImageConverter converter = new ImageConverter();
            byte[] bytes = (byte[])converter.ConvertTo(autor.Photo, typeof(byte[]));

            string insertstmt = getInsertStatementFor("Author", "NoSQL.Modelo");            
            string addStmt = string.Format(insertstmt,
            "null",
            "'"+autor.Name+"'",
            "'"+BitConverter.ToString(bytes).Replace("-", ""))+"'";
            MySqlCommand cmd = new MySqlCommand(addStmt, conn);                                   
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
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return rdr.GetInt64("cant");
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

       /// <summary>
        /// Devuelve un statement parametrizado para agregar a un column family
       /// </summary>
       /// <param name="entityName"></param>
       /// <param name="modelNamespacePath"></param>
       /// <returns></returns>
        protected string getInsertStatementFor(string entityName, string modelNamespacePath)
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == modelNamespacePath && t.Name == entityName
                    select t;
            string stmt = @"INSERT INTO " + entityName + @"s (";
            var properties = q.First().GetProperties().OrderBy(p => p.Name.ToUpper());
            int j = 0;
            foreach (PropertyInfo property in properties)
            {
                stmt = stmt + " "+property.Name;
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


    }
}
