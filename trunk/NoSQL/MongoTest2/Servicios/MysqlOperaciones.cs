using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoTest2.Modelo;
using MongoTest2.Servicios;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MongoTest2
{
    class MysqlOperaciones: IOperaciones
    {

        MySqlConnection conn;

        public MysqlOperaciones(string dbname, string host)
        {
            string connStr = "server="+host+";user=root;database="+dbname+";password=2010;";
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
            string sql = "SELECT Count(*) AS cant FROM Authors";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return rdr.GetInt64("cant");
        }

        public long GetThreadsCount()
        {
            throw new NotImplementedException();
        }

        public long GetCommentsCount()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string Identidad()
        {
            throw new NotImplementedException();
        }
    }
}
