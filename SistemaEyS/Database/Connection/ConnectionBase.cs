using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaEyS.Database.Connection
{
    public abstract class ConnectionBase
    {
        public MySqlConnection conn { get; set; }
        static protected ConnectionBase instance = null;

        public virtual string GetConnectionString()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "",
                UserID = "root",
                Password = "1234"
            };
            return sb.ConnectionString;
        }

        public IDataReader Read(CommandType ct, string query)
        {
            MySqlCommand sqlCommand = new MySqlCommand
            {
                CommandType = ct,
                CommandText = query,
                Connection = this.conn
            };

            IDataReader IDR;
            try
            {
                IDR = sqlCommand.ExecuteReader();
            }
            catch
            {
                throw;
            }

            return IDR;
        }

        public Int32 Execute(CommandType ct, string query)
        {
            Int32 value = 0;

            MySqlCommand sqlCommand = new MySqlCommand
            {
                CommandType = ct,
                CommandText = query,
                Connection = this.conn
            };

            try
            {
                value = sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }

            return value;
        }

        protected ConnectionBase()
        {
            this.conn = new MySqlConnection();
        }
    }
}
