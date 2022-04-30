using System;
using System.Data;
using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;
using Gtk;
using MySql.Data;
using System.Text;
using System.Collections.Generic;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.Datos
{
    public class Dt_tlb_empleado
    {

        public Gtk.ListStore listStore;

        ConnectionEyS conn = ConnectionEyS.OpenConnection();
        StringBuilder sb = new StringBuilder();

        public ListStore listarUsuarios()
        {
            ListStore datos = new ListStore(typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(string), typeof(string), typeof(string));

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Empleado;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString() + " " + idr[2].ToString(), // Nombre
                        idr[3].ToString() + " " + idr[4].ToString(), // Apellido
                        idr[5].ToString(), // FechaIngreso
                        idr[6].ToString(), // CedulaEmpleado
                        idr[7].ToString(), // Cargo
                        idr[8].ToString(), // Departamento
                        idr[9].ToString(), // Horario
                        idr[10].ToString() // Grupo
                    );
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
            }
            return datos;
        }
        public Dt_tlb_empleado()
        {
        }
    }
}