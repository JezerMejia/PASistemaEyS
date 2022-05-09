using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosEyS;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class DelBtn : Gtk.Window
    {

        Dt_tlb_empleado dtus = new Dt_tlb_empleado();
        ListStore datos;

        public DelBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.CmbxEntry.Entry.WidthChars = 22;
            this.Hide();
            this.UpdateData();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        public void UpdateData()
        {
            this.datos = dtus.listarUsuariosVista();
            this.FillComboboxModel();
        }

        protected void FillComboboxModel()
        {
            ListStore store = (ListStore) this.CmbxEntry.Model;
            store.Clear();
            TreeIter iter;
            if (this.datos.GetIterFirst(out iter))
            {
                do
                {
                    this.CmbxEntry.InsertText(
                        Convert.ToInt32(this.datos.GetValue(iter, 0)),
                        (String) this.datos.GetValue(iter, 0)
                    );
                }
                while (this.datos.IterNext(ref iter));
            }

            this.CmbxEntry.Entry.Completion = new EntryCompletion();
            this.CmbxEntry.Entry.Completion.Model = this.datos;
            this.CmbxEntry.Entry.Completion.TextColumn = 0;
        }

        protected void ComboBoxOnChanged(object sender, EventArgs e)
        {
            string id = this.CmbxEntry.ActiveText;

            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    if (id == (string) datos.GetValue(iter, 0))
                    {
                        this.TxtName.Text = (string) datos.GetValue(iter, 1);
                        this.TxtLastName.Text = (string)datos.GetValue(iter, 2);
                        return;
                    } else
                    {
                        this.TxtName.Text = "";
                        this.TxtLastName.Text = "";
                    }
                }
                while (datos.IterNext(ref iter));
            }
        }

        protected void BtnAcceptOnClicked(object sender, EventArgs args)
        {
            ConnectionEyS connection = ConnectionEyS.OpenConnection();
            string idEmpleado = this.CmbxEntry.ActiveText;

            if (string.IsNullOrWhiteSpace(idEmpleado))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Ingrese un ID válido");
                ms.Run();
                ms.Destroy();
                return;
            }

            String Query = "DELETE FROM BDSistemaEyS.Empleado WHERE idEmpleado = " +
                $"{idEmpleado};";

            try
            {
                connection.Execute(CommandType.Text, Query);
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Eliminado");
                ms.Run();
                ms.Destroy();
                ClearInput();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        protected void BtnCancelOnClicked(object sender, EventArgs e)
        {
            this.ClearInput();
            this.Hide();
        }

        // Clear all Entry
        public void ClearInput()
        {
            this.CmbxEntry.Active = -1;
            this.CmbxEntry.Entry.Text = "";
            this.TxtName.Text = "";
            this.TxtLastName.Text = "";
        }

    }
}
