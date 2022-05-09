using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;
using SistemaEyS.Database.Connection;
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
            comboboxentry2.Entry.Completion.TextColumn = 0;
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
                        this.name.Text = (string)datos.GetValue(iter, 1);
                        this.secondName.Text = (string)datos.GetValue(iter, 2);
                        this.surname.Text = (string)datos.GetValue(iter, 3);
                        this.secondSurname.Text = (string)datos.GetValue(iter, 4);
                        this.dIngress.Text = (string)datos.GetValue(iter, 5);
                        this.Icard.Text = (string)datos.GetValue(iter, 6);
                        this.password.Text = (string)datos.GetValue(iter, 7);
                        this.idCar.Text = (string)datos.GetValue(iter, 8);
                        this.idDep.Text = (string)datos.GetValue(iter, 9);
                        this.idHor.Text = (string)datos.GetValue(iter, 10);
                        this.idGroup.Text = (string)datos.GetValue(iter, 11);
                        return;
                    }
                }
                while (datos.IterNext(ref iter));
            }
        }

        protected void OnButton5Clicked(object sender, EventArgs e)
        {

            ConnectionEyS connection = ConnectionEyS.OpenConnection();

            string idEmpleado = this.comboboxentry2.ActiveText;

            if (string.IsNullOrWhiteSpace(idEmpleado))
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                        ButtonsType.Ok, "Seleccione un ID de empleado");
                ms.Run();
                ms.Destroy();
            }

            string modifiedQuery = "";

            if (!string.IsNullOrWhiteSpace(this.newId.Text))
            {
                modifiedQuery += $"idEmpleado = {this.newId.Text}, ";
            }
            if (!string.IsNullOrWhiteSpace(this.name.Text))
            {
                modifiedQuery += $"primerNombre = '{this.name.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.secondName.Text))
            {
                modifiedQuery += $"segundoNombre = '{this.secondName.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.surname.Text))
            {
                modifiedQuery += $"primerApellido = '{this.surname.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.secondSurname.Text))
            {
                modifiedQuery += $"segundoApellido = '{this.secondSurname.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.Icard.Text))
            {
                modifiedQuery += $"cedulaEmpleado = '{this.Icard.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.password.Text))
            {
                modifiedQuery += $"password = '{this.password.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.idCar.Text))
            {
                modifiedQuery += $"idCargo = '{this.idCar.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.idDep.Text))
            {
                modifiedQuery += $"idDepartamento = '{this.idDep.Text}', ";
            }
            if (!string.IsNullOrWhiteSpace(this.idHor.Text))
            {
                modifiedQuery += $"idHorario = {this.idHor.Text}, ";
            }
            if (!string.IsNullOrWhiteSpace(this.idGroup.Text))
            {
                modifiedQuery += $"idGrupo = {this.idGroup.Text}, ";
            }

            modifiedQuery = modifiedQuery.Trim();
            if (modifiedQuery.EndsWith(","))
                modifiedQuery = modifiedQuery.Remove(modifiedQuery.Length - 1);

            string Query = $"UPDATE BDSistemaEyS.Empleado SET {modifiedQuery} " +
                $"WHERE idEmpleado = {idEmpleado};";
            try
            {
                connection.Execute(CommandType.Text, Query);
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Guardado");
                ms.Run();
                ms.Destroy();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        public void ClearInput()
        {
            this.comboboxentry2.Active = -1;
            this.comboboxentry2.Entry.Text = "";
            this.newId.Text = "";
            this.name.Text = "";
            this.secondName.Text = "";
            this.surname.Text = "";
            this.secondSurname.Text = "";
            this.dIngress.Text = "";
            this.Icard.Text = "";
            this.password.Text = "";
            this.idCar.Text = "";
        }

        public void SetIDRandom()
        {
            Random r = new Random();
            this.newId.Text = Convert.ToString(r.Next(10000, 100000));
        }

        protected void OnButton4Clicked(object sender, EventArgs e)
        {
            this.ClearInput();
            this.Hide();
        }
    }
}
