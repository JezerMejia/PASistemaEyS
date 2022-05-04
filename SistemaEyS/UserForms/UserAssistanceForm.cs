using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.UserForms
{
    public partial class UserAssistanceForm : Gtk.Window
    {
        protected Window parent;
        protected uint timeout;
        protected string idEmpleado;
        ConnectionEyS conn = ConnectionEyS.OpenConnection();

        public UserAssistanceForm(Window parent, string idEmpleado) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.idEmpleado = idEmpleado;
            this.Build();
            this.SetDateTimeTimeout();

            this.lbWelcome.Text = $"¡Bienvenido, {this.GetNameEmpleado()}!";
        }

        protected string GetNameEmpleado()
        {
            StringBuilder sb = new StringBuilder();
            string value = "";
            IDataReader idr = null;

            sb.Clear();
            sb.Append($"SELECT Nombre FROM BDSistemaEyS.vwEmpleado " +
                    $"WHERE ID = {this.idEmpleado};"
                    );
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                if (!idr.Read()) throw new Exception("Empleado no encontrado");
                value = idr[0].ToString();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Error al obtener el nombre del empleado: " + e.Message);
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
            return value;
        }

        protected void SetDateTimeTimeout()
        {
            this.UpdateDateTime();
            this.timeout = GLib.Timeout.Add(500, this.UpdateDateTime);
        }
        protected bool UpdateDateTime()
        {
            DateTime dateTime = DateTime.Now;
            string str = dateTime.ToString("yyyy-MM-dd h:mm:ss tt");
            this.lbDateTime.Text = str;
            this.clockwidget1.QueueDraw();
            return true;
        }

        private bool MarkAssitanceEnter()
        {
            StringBuilder sb = new StringBuilder();
            bool value = false;

            DateTime now = DateTime.Now;

            sb.Clear();
            sb.Append($"INSERT INTO BDSistemaEyS.Asistencia (fechaAsistencia, horaEntrada, idEmpleado) " +
                    $"VALUES ('{now.ToString("yyyy-MM-dd")}', '{now.ToString("H:mm:ss")}', {this.idEmpleado}) " +
                    $"ON DUPLICATE KEY UPDATE horaEntrada='{now.ToString("H:mm:ss")}';"
                    );
            try
            {
                value = conn.Execute(CommandType.Text, sb.ToString()) != 0;
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Marcado de entrada exitoso");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Error al marcar la entrada: " + e.Message);
                ms.Run();
                ms.Destroy();
            }
            return value;
        }
        private bool MarkAssitanceExit()
        {
            StringBuilder sb = new StringBuilder();
            bool value = false;

            DateTime now = DateTime.Now;

            sb.Clear();
            sb.Append($"INSERT INTO BDSistemaEyS.Asistencia (fechaAsistencia, horaSalida, idEmpleado) " +
                    $"VALUES ('{now.ToString("yyyy-MM-dd")}', '{now.ToString("H:mm:ss")}', {this.idEmpleado}) " +
                    $"ON DUPLICATE KEY UPDATE horaSalida='{now.ToString("H:mm:ss")}';"
                    );
            try
            {
                value = conn.Execute(CommandType.Text, sb.ToString()) != 0;
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Marcado de salida exitoso");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Error al marcar la salida: " + e.Message);
                ms.Run();
                ms.Destroy();
            }
            return value;
        }

        public void Close()
        {
            GLib.Source.Remove(this.timeout);
            this.Destroy();
            this.parent.Show();
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnExitOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void btnMarkEntryOnClicked(object sender, EventArgs e)
        {
            this.MarkAssitanceEnter();
        }

        protected void btnMarkExitOnClicked(object sender, EventArgs e)
        {
            this.MarkAssitanceExit();
        }
    }
}
