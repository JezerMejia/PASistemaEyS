using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;

namespace SistemaEyS.Database.Connection
{
    public class ConnectionEyS
    {
        public MySqlConnection conn { get; set; }
        static private ConnectionEyS instance = null;

        public String CadenaConexion()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "BDSistemaEyS",
                UserID = "root",
                Password = "Usuario123."
            };
            return sb.ConnectionString;
        }

        static public ConnectionEyS OpenConnection()
        {
            if (ConnectionEyS.instance != null) return ConnectionEyS.instance;
            ConnectionEyS conexion = new ConnectionEyS();
            conexion.conn.ConnectionString = conexion.CadenaConexion();

            MessageDialog ms;
            try
            {
                conexion.conn.Open();
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se abrió la conexión a la BD SistemaEyS");
                ms.SetPosition(WindowPosition.Center);
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Error al conectar a la Base de Datos de SistemaEyS: " + e.Message);
                ms.SetPosition(WindowPosition.Center);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error al conectar a la Base de Datos: " + e);
            }

            ConnectionEyS.instance = conexion;
            return conexion;
        }

        static public void CloseConnection()
        {
            if (ConnectionEyS.instance == null) {
                return;
            }
            if (ConnectionEyS.instance.conn.State == ConnectionState.Closed)
            {
                return;
            }
            else
            {
                ConnectionEyS.instance.conn.Close();
                ConnectionEyS.instance = null;
            }
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
        private ConnectionEyS()
        {
            this.conn = new MySqlConnection();
        }
    }
}
