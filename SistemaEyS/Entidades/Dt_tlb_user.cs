using System;
using System.Data;
using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;
using Gtk;
using MySql.Data;
using System.Text;
using System.Collections.Generic;
using SistemadeControldeAsistencia.Entidades;
using SistemadeControldeAsistencia.datos;

namespace SistemaEyS.Datos
{
    public class Dt_tlb_user
    {

        public Gtk.ListStore listStore;

        Conexion conn = new Conexion();
        MessageDialog ms = null;
        StringBuilder sb = new StringBuilder();

        public ListStore listarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM Seguridad.VwUser;");
            try
            {
                conn.AbrirConexion();
                idr = conn.Leer(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(idr[0].ToString(), idr[1].ToString(),
                        idr[2].ToString(), idr[3].ToString(), idr[4].ToString());
                }
                return datos;
            }
            catch (Exception e)
            {
                ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                throw;
            }
            finally
            {
                idr.Close();
                conn.CerrarConexion();
            }
        }
        public Dt_tlb_user()
        {
        }
    }
}
