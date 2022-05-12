using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS
{
    public class Dt_tlb_cargo
    {

        public Gtk.ListStore listStore;

        ConnectionEyS conn = ConnectionEyS.OpenConnection();
        StringBuilder sb = new StringBuilder();

        public ListStore listarCargos()
        {
            ListStore datos = new ListStore(
                typeof(string), typeof(string),
                typeof(string)
            );

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Cargo;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[1].ToString(), // Nombre
                        idr[0].ToString(), // ID
                        idr[2].ToString()  // Descripción
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
        public Dt_tlb_cargo()
        {
        }
    }
}
