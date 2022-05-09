using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS
{
    public class Dt_tlb_empleado
    {

        public Gtk.ListStore listStore;

        ConnectionEyS conn = ConnectionEyS.OpenConnection();
        StringBuilder sb = new StringBuilder();

        public ListStore listarUsuariosVista()
        {
            ListStore datos = new ListStore(
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string)
            );

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.vwEmpleado;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), // Nombre
                        idr[2].ToString(), // Apellido
                        idr[3].ToString(), // FechaIngreso
                        idr[4].ToString(), // CedulaEmpleado
                        idr[5].ToString(), // Contraseña
                        idr[6].ToString(), // Cargo
                        idr[7].ToString(), // Departamento
                        idr[8].ToString(), // ID Horario
                        idr[9].ToString()  // Grupo
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


        // ListStore table empleado

        public ListStore listarUsuarios()
        {
            ListStore datos = new ListStore(
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string)
            );

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
                        idr[1].ToString(), // primerNombre
                        idr[2].ToString(), // segundoNombre
                        idr[3].ToString(), // primerApellido
                        idr[4].ToString(), // segundoApellido
                        idr[5].ToString(), // fechaIngreso
                        idr[6].ToString(), // cedulaEmpleado
                        idr[7].ToString(), // Contraseña
                        idr[8].ToString(), // idcargo
                        idr[9].ToString(),  // idDepartamento
                        idr[10].ToString(), // idHorario
                        idr[11].ToString()  // idGrupo
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
