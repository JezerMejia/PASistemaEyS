using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;

namespace SistemaEyS.Database.Connection
{
    public class ConnectionSeg : ConnectionBase
    {
        protected static new ConnectionSeg instance;
        public override string GetConnectionString()
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

        static public ConnectionSeg OpenConnection()
        {
            if (ConnectionSeg.instance != null) return ConnectionSeg.instance;
            ConnectionSeg conexion = new ConnectionSeg();
            conexion.conn.ConnectionString = conexion.GetConnectionString();

            MessageDialog ms;
            try
            {
                conexion.conn.Open();
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, "Error al conectar al apartado de Seguridad: " + e.Message);
                ms.SetPosition(WindowPosition.Center);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error al conectar a la Base de Datos: " + e);
            }

            ConnectionSeg.instance = conexion;
            return conexion;
        }


        static public void CloseConnection()
        {
            if (ConnectionSeg.instance == null)
            {
                return;
            }
            if (ConnectionSeg.instance.conn.State == ConnectionState.Closed)
            {
                return;
            }
            else
            {
                ConnectionSeg.instance.conn.Close();
                ConnectionSeg.instance = null;
            }
        }
    }
}
