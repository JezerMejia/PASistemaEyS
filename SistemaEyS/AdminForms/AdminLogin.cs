using System;
using Gtk;
namespace SistemaEyS.AdminForms
{
    public partial class AdminLogin : Gtk.Window
    {
        protected Window parent;
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
    }
}
