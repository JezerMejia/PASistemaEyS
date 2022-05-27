using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosSeguridad.Datos;

namespace SistemaEyS.AdminForms
{
    public partial class AdminLogin : Gtk.Window
    {
        ConnectionEyS conn = ConnectionEyS.OpenConnection();
        protected Window parent;
        protected string idAdministrador;

        public AdminLogin(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.lbUser.WidthChars = 15;
            this.lbPassword.WidthChars = 15;
            this.lbRole.WidthChars = 15;
        }


        public void Close()
        {
            this.Destroy();
            this.parent.Show();
        }

        protected void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnExitOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool LogIn(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "Ingrese un Nombre de empleado");
                ms.Run();
                ms.Destroy();
                return false;
            }
            StringBuilder sb = new StringBuilder();
            IDataReader idr = null;
            bool value = false;

            sb.Clear();
            sb.Append($"SELECT user, pwd FROM Seguridad.tbl_user WHERE user = '{user}';");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                if (!idr.Read()) throw new Exception("Empleado no encontrado");
                if (idr[1].ToString() == password)
                {
                    value = true;
                }
                else
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

        protected void btnEnterOnClicked(object sender, EventArgs e)
        {
            string idAdmin = this.entUser.Text;
            string pwdAdmin = this.entPassword.Text;

            if (!LogIn(idAdmin, pwdAdmin))
            {
                return;
            }

            AdminPanel adminPan = new AdminPanel(this, idAdmin);
            adminPan.Show();
            this.Hide();
            this.entPassword.Text = "";
            this.entUser.Text = "";

            MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Bienvenido: " + idAdmin);
            ms.Run();
            ms.Destroy();
        }


    }
}
