using System;
using Gtk;
namespace SistemaEyS.UserForms
{
    public partial class UserLogin : Gtk.Window
    {
        protected Window parent;
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

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnEnterOnClicked(object sender, EventArgs e)
        {
            UserAssistanceForm assistanceForm = new UserAssistanceForm(this);
            assistanceForm.Show();
            this.Hide();
        }
    }
}
