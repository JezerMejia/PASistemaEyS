using System;
namespace SistemaEyS.AdminForms.Help
{
    public partial class AboutEyS : Gtk.Window
    {
        public AboutEyS() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        public void Close()
        {
            this.Hide();
            this.Destroy();
        }

        protected void BtnExitOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
