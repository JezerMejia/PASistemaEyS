using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.UserForms
{
    public partial class UserLogin : Gtk.Window
    {
        protected Window parent;
        ConnectionEyS conn = ConnectionEyS.OpenConnection();

        public UserLogin(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.lbUser.WidthChars = 10;
            this.lbPassword.WidthChars = 10;
        }

        public void Close()
        {
            this.Destroy();
            this.parent.Show();
        }

        private bool LogIn(string user, string password)
        {
            StringBuilder sb = new StringBuilder();
            IDataReader idr = null;
            bool value = false;

            sb.Clear();
            sb.Append($"SELECT idEmpleado, password FROM BDSistemaEyS.Empleado WHERE idEmpleado = {user};");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                if (!idr.Read()) throw new Exception("Empleado no encontrado");
                if (idr[1].ToString() == password)
                {
                    value = true;
                } else
                {
                    throw new Exception("Contraseña incorrecta");
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
            return value;
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnEnterOnClicked(object sender, EventArgs e)
        {
            string idEmpleado = this.entUser.Text;
            string pwdEmpleado = this.entPassword.Text;

            if (!LogIn(idEmpleado, pwdEmpleado))
            {
                return;
            }

            UserAssistanceForm assistanceForm = new UserAssistanceForm(this, idEmpleado);
            assistanceForm.Show();
            this.Hide();
            this.entPassword.Text = "";
            this.entUser.Text = "";
        }
    }
}
