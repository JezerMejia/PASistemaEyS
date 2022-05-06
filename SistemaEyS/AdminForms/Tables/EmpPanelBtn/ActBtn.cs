using System;
using Gtk;
using SistemaEyS.DatosEyS;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class ActBtn : Gtk.Window
    {
        Dt_tlb_empleado dtus = new Dt_tlb_empleado();
        ListStore datos;

        public ActBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            this.datos = dtus.listarUsuarios();
            llenarcbxUser();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void llenarcbxUser()
        {
            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    this.comboboxentry2.InsertText(
                        Convert.ToInt32(datos.GetValue(iter, 0)),
                        (String)datos.GetValue(iter, 0)
                    );
                }
                while (datos.IterNext(ref iter));
            }

            comboboxentry2.Entry.Completion = new EntryCompletion();
            comboboxentry2.Entry.Completion.Model = datos;
            comboboxentry2.Entry.Completion.TextColumn = 1;
        }

        protected void ComboBoxOnChanged(object sender, EventArgs e)
        {
            string id = this.comboboxentry2.ActiveText;

            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    if (id == (string)datos.GetValue(iter, 0))
                    {
                        this.entry5.Text = (string)datos.GetValue(iter, 1);
                        this.entry6.Text = (string)datos.GetValue(iter, 2);
                        this.entry7.Text = (string)datos.GetValue(iter, 5);
                        return;
                    }
                }
                while (datos.IterNext(ref iter));
            }
        }
    }
}
