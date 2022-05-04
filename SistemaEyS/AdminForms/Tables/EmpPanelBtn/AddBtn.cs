using System;
using Gtk;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class AddBtn : Gtk.Window
    {
        public AddBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

        protected void OnButton4Clicked(object sender, EventArgs e)
        {
            MessageDialog mensaje = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Ha cancelado");
            mensaje.Run();
            mensaje.Destroy();
            this.Hide();

        }
    }
}
