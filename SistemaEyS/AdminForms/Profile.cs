using System;
using SistemaEyS.DatosSeguridad.Entidades;
using SistemaEyS.DatosSeguridad.Negocio;
using Gtk;

namespace SistemaEyS.AdminForms
{
    public partial class Profile : Gtk.Window
    {
        protected Neg_user NegUser = new Neg_user();
        public Window parent;
        public int UserID;

        public Profile(Window parent, int userID) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.parent = parent;
            this.UserID = userID;

            this.parent.Sensitive = false;

            this.UpdateData();
        }

        public void UpdateData()
        {
            try
            {
                Ent_user user = this.NegUser.SearchUser(this.UserID);

                this.TxtUser.Text = user.user;
                this.TxtName.Text = user.nombres;
                this.TxtSurname.Text = user.apellidos;
                this.TxtEmail.Text = user.email;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        protected void BtnExitOnClicked(object sender, EventArgs e)
        {
            this.parent.Sensitive = true;
            this.Destroy();
        }
    }
}
