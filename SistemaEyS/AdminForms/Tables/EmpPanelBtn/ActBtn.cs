using System;
using Gtk;

namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class ActBtn : Gtk.Window
    {
        public ActBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }
    }
}
