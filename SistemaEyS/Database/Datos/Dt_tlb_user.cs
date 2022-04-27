using System;
using System.Data;
using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;
using Gtk;
using MySql.Data;
using System.Text;
using System.Collections.Generic;
using SistemadeControldeAsistencia.datos;
using SistemaEyS.Datos;

namespace SistemaEyS.Datos
{
    public class Dt_tlb_user
    {

        public Gtk.ListStore listStore;

        Conexion conn = Conexion.OpenConnection();
        StringBuilder sb = new StringBuilder();

        public ListStore listarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM Seguridad.tbl_user;");
            try
            {
                idr = conn.Leer(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                        idr[2].ToString(), idr[3].ToString(), idr[4].ToString(), idr[5].ToString());
                }
                return datos;
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
            finally
            {
                if (idr != null && !idr.IsClosed)
                {
                    idr.Close();
                }
                conn.CloseConnection();
            }
            return datos;
        }
        public Dt_tlb_user()
        {
        }
    }
}
