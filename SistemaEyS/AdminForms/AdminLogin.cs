using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.DatosSeguridad.Entidades;
using SistemaEyS.DatosSeguridad.Negocio;

namespace SistemaEyS.AdminForms
{
    public partial class AdminLogin : Gtk.Window
    {
        protected Window parent;
        protected string idAdministrador;
        protected Neg_user NegUser = new Neg_user();

        public AdminLogin(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
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

        protected void btnEnterOnClicked(object sender, EventArgs args)
        {
            Ent_user user;
            try
            {
                if (string.IsNullOrWhiteSpace(this.entUser.Text))
                    throw new ArgumentException("Escriba un nombre de usuario");

                if (string.IsNullOrWhiteSpace(this.entPassword.Text))
                    throw new ArgumentException("Escriba una contraseña");

                string userAdmin = this.entUser.Text;
                string pwdAdmin = this.entPassword.Text;

                user = this.NegUser.SearchUser(userAdmin);

                if (user.pwd != this.entPassword.Text)
                    throw new Exception("Contraseña incorrecta");

                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    $"¡Bienvenido, {user.nombres}!");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                return;
            }

            AdminPanel adminPan = new AdminPanel(this, user.id_user);
            adminPan.Show();
            this.Hide();

            this.entPassword.Text = "";
            this.entUser.Text = "";
        }
    }
}
