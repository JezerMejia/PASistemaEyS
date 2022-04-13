using System;
using Gtk;
namespace SistemaEyS.UserForms
{
    public partial class UserAssistanceForm : Gtk.Window
    {
        protected Window parent;
        public UserAssistanceForm(Window parent) :
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

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnExitOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
