using System;
using Gtk;

namespace SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.Calendar
{
    public partial class calendar : Gtk.Window
    {
        public calendar() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }


        public delegate void selectFecha(DateTime valor);
        public selectFecha fecha;

        protected void OnCalendar1DaySelectedDoubleClick(object sender, EventArgs e)
        {
            fecha(calendar1.GetDate());
            this.Hide();
        }
    }
}
