using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;

namespace SistemaEyS.Database.Connection
{
    public class ConnectionSeg
    {
        private MySqlConnection conn { get; set; }
        static private ConnectionSeg instance = null;

        public String CadenaConexion()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "Seguridad",
                UserID = "root",
                Password = "Usuario123."
            };
            return sb.ConnectionString;
        }

        static public ConnectionSeg OpenConnection()
        {
            if (ConnectionSeg.instance != null) return ConnectionSeg.instance;
            ConnectionSeg conexion = new ConnectionSeg();
            conexion.conn.ConnectionString = conexion.CadenaConexion();

            MessageDialog ms;
            try
            {
                conexion.conn.Open();
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se abrió la conexión a la BD Seguridad");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Error al conectar a la Base de Datos de Seguridad: " + e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error al conectar a la Base de Datos: " + e);
            }

            ConnectionSeg.instance = conexion;
            return conexion;
        }


        static public void CloseConnection()
        {
            if (ConnectionSeg.instance == null) {
                return;
            }
            if (ConnectionSeg.instance.conn.State == ConnectionState.Closed)
            {
                return;
            } else
            {
                ConnectionSeg.instance.conn.Close();
                ConnectionSeg.instance = null;
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

        private ConnectionSeg()
        {
            conn = new MySqlConnection();
        }
    }

}
