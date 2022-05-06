using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS
{
    public class Dt_tlb_user
    {

        public Gtk.ListStore listStore;

        ConnectionSeg conn = ConnectionSeg.OpenConnection();
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
                idr = conn.Read(CommandType.Text, sb.ToString());
                    

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
            }
            return datos;
        }

        //POINT 


        public ListStore cbxEUsers()
        {
            ListStore datos = new ListStore(
                    typeof(string),
                    typeof(string)
                );
            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT id_user, user FROM Seguridad.tbl_user WHERE estado<>3;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(),
                        idr[1].ToString()
                        );
                }
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

        public Dt_tlb_user()
        {
        }
    }
}
