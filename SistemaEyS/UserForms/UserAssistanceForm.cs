using System;
using Gtk;
namespace SistemaEyS.UserForms
{
    public partial class UserAssistanceForm : Gtk.Window
    {
        protected Window parent;
        protected uint timeout;

        public UserAssistanceForm(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.SetDateTimeTimeout();
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
    }
}
