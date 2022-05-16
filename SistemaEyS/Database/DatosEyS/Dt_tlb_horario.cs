using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS
{
    public class Dt_tlb_horario
    {

        public Gtk.ListStore listStore;

        ConnectionEyS conn = ConnectionEyS.OpenConnection();
        StringBuilder sb = new StringBuilder();
        public ListStore Model;

        public void UpdateModel()
        {
            ListStore datos = new ListStore(
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string)
                );

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Horario;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), idr[2].ToString(), // Lunes
                        idr[3].ToString(), idr[4].ToString(), // Martes
                        idr[5].ToString(), idr[6].ToString(), // Miércoles
                        idr[7].ToString(), idr[8].ToString(), // Jueves
                        idr[9].ToString(), idr[10].ToString(), // Viernes
                        idr[11].ToString(), idr[12].ToString(), // Sábado
                        idr[13].ToString(), idr[14].ToString() // Domingo
                    );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.SetPosition(WindowPosition.Mouse);
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
            this.Model = datos;
        }


        //
        public ListStore listarUsuariosHor()
        {
            ListStore datos = new ListStore(
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string), typeof(string)
            );

            IDataReader idr = null;
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Horario;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), idr[2].ToString(), // Lunes
                        idr[3].ToString(), idr[4].ToString(), // Martes
                        idr[5].ToString(), idr[6].ToString(), // Miércoles
                        idr[7].ToString(), idr[8].ToString(), // Jueves
                        idr[9].ToString(), idr[10].ToString(), // Viernes
                        idr[11].ToString(), idr[12].ToString(), // Sábado
                        idr[13].ToString(), idr[14].ToString() // Domingo
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
        //

        public ListStore GetData()
        {
            this.UpdateModel();
            return this.Model;
        }

        public Dt_tlb_horario()
        {
        }
    }
}