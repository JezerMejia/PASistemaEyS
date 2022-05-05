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
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void OnButton4Clicked(object sender, EventArgs e)
        {
            MessageDialog mensaje = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Ha cancelado");
            mensaje.Run();
            mensaje.Destroy();
        }
    }
}
