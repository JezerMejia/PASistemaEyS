using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS
{
    public class Dt_tlb_solicitudVacaciones
    {

        public Gtk.ListStore listStore;

        ConnectionEyS conn = ConnectionEyS.OpenConnection();
        StringBuilder sb = new StringBuilder();

        public ListStore listarSolicitudVacaciones()
        {
            ListStore datos = new ListStore(
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string)
            );

            Console.WriteLine("UWU");

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.SolVacaciones;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(), // ID
                        idr[3].ToString(), // ID Empleado
                        idr[1].ToString(), // Fecha de Solicitud
                        idr[2].ToString(), // Descripción
                        idr[4].ToString(), // Inicio
                        idr[5].ToString() // Fin
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
        public Dt_tlb_solicitudVacaciones()
        {
        }
    }
}
