using System;
using System.Data;
using MySql.Data.MySqlClient;
using Gtk;

namespace SistemadeControldeAsistencia.datos
{
    public class Conexion
    {
        #region atributes
        private MySqlConnection conn { get; set; }
        private MySqlCommand sqlCommand { get; set; }
        private IDataReader idr { get; set; }
        static private Conexion instance = null;
        #endregion

        #region metodos
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
        }//fin del metodo

        static public Conexion OpenConnection()
        {
            if (Conexion.instance != null) return Conexion.instance;
            Conexion conexion = new Conexion();

            MessageDialog ms = null;

            conexion.conn.ConnectionString = conexion.CadenaConexion();
            try
            {
                conexion.conn.Open();
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Se abrió la conexión a la BD Seguridad");
                ms.Run();
                ms.Destroy();
            } catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                Console.WriteLine("Error al conectar a la Base de Datos: " + e);
            }

            Conexion.instance = conexion;
            return conexion;
        }


        public void CloseConnection()
        {
            if (this.conn.State == ConnectionState.Closed)
            {
                return;
            } else
            {
                this.conn.Close();
                Conexion.instance = null;
            }
        }//fin del metodo


        public IDataReader Leer(CommandType ct, string consulta)
        {
            this.idr = null;
            this.sqlCommand.Connection = conn;
            this.sqlCommand.CommandType = ct;
            this.sqlCommand.CommandText = consulta;

            try
            {
                this.idr = this.sqlCommand.ExecuteReader();
            }
            catch
            {
                throw;
            }
            return idr;
        }//fin del metodo


        public Int32 Ejecutar(CommandType ct, string consulta)
        {
            int retorno = 0;
            this.sqlCommand.Connection = conn;
            this.sqlCommand.CommandType = ct;
            this.sqlCommand.CommandText = consulta;

            try
            {
                retorno = this.sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }//fin try-catch
            return retorno;
        }//fin del metodo
        #endregion


        #region constructor 
        private Conexion()
        {
            conn = new MySqlConnection();
            sqlCommand = new MySqlCommand();
        }
        #endregion




    }

}
