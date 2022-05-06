using System;
using Gtk;
using SistemaEyS.DatosEyS;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class DelBtn : Gtk.Window
    {

        Dt_tlb_user dtus = new Dt_tlb_user();

        public DelBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            llenarcbxUser();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }


        protected void llenarcbxUser()
        {
            ListStore datos = new ListStore(typeof(String), typeof(String));
            datos = dtus.cbxEUsers();
            TreeIter iter;

            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    this.comboboxentry3.InsertText(Convert.ToInt32(datos.GetValue(iter, 0)), (String)datos.GetValue(iter, 1));

                }
                while (datos.IterNext(ref iter));

            }

            comboboxentry3.Entry.Completion = new EntryCompletion();
            comboboxentry3.Entry.Completion.Model = datos;
            comboboxentry3.Entry.Completion.TextColumn = 1;
        }


    }


}
