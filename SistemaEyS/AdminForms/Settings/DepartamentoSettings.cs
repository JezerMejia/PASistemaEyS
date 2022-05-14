using System;
namespace SistemaEyS.AdminForms.Settings
{
    public partial class DepartamentoSettings : Gtk.Window
    {
        public DepartamentoSettings() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.CmbxID.Entry.WidthChars = 16;
            this.CmbxID.Entry.IsEditable = false;
        }

        protected void BtnNewOnClicked(object sender, EventArgs e)
        {
            this.CmbxID.Active = -1;
            this.TxtName.Text = "";
            this.TxtExt.Text = "";
            this.TxtDescription.Buffer.Text = "";
        }

        protected void BtnAddOnClicked(object sender, EventArgs e)
        {
        }

        protected void BtnEditOnClicked(object sender, EventArgs e)
        {
        }

        protected void BtnRemoveOnClicked(object sender, EventArgs e)
        {
        }
    }
}
