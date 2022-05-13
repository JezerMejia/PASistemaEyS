using System;
using Gtk;
using SistemaEyS.Database.Connection;
using MySql.Data.MySqlClient;
using System.Data;
using SistemaEySLibrary;

namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class AddDialog : Gtk.Window
    {
        protected EmpleadosView parent;
        public AddDialog(EmpleadosView parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            SetIDRandom();
            this.Hide();

            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            ConnectionEyS connection = ConnectionEyS.OpenConnection();

            if (string.IsNullOrWhiteSpace(TxtID.Text) ||
                string.IsNullOrWhiteSpace(TxtName.Text) ||
                string.IsNullOrWhiteSpace(TxtPIN.Text)
                )
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "No puede haber datos vacíos");
                ms.Run();
                ms.Destroy();
                ClearInput();
                return;
            }

            string Query = "INSERT INTO BDSistemaEyS.Empleado (" +
                    "idEmpleado, primerNombre, segundoNombre, " +
                    "primerApellido, segundoApellido, password) " +
                    "VALUES (" +
                    $"{TxtID.Text}, '{TxtName.Text}', '{TxtSecondName.Text}'," +
                    $"'{TxtLastName.Text}', '{TxtSecondLastName.Text}', '{TxtPIN.Text}');";

            try
            {
                connection.Execute(CommandType.Text, Query);
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Agregado");
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
            this.parent.UpdateData();
        }

        protected void BtnCancelOnClicked(object sender, EventArgs e)
        {
            this.ClearInput();
            this.Hide();
        }

        // Clear all Entry
        public void ClearInput()
        {
            this.TxtID.Text = "";
            this.TxtName.Text = "";
            this.TxtSecondName.Text = "";
            this.TxtLastName.Text = "";
            this.TxtSecondLastName.Text = "";
            this.TxtPIN.Text = "";
        }

        // Set the ID as a random number
        public void SetIDRandom()
        {
            Random r = new Random();
            this.TxtID.Text = Convert.ToString(r.Next(10000, 100000));
        }

        protected void BtnNewIDUpdateOnClicked(object sender, EventArgs e)
        {
            this.SetIDRandom();
        }
    }
}
