using System;
using System.Data;
using Gtk;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosEyS;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class UpdateDialog : Gtk.Window
    {
        protected Dt_tlb_empleado dtus = new Dt_tlb_empleado();
        protected Dt_tbl_cargo dtcarg = new Dt_tbl_cargo();
        protected Dt_tlb_departamento dtdep = new Dt_tlb_departamento();
        protected ListStore EmpData;
        protected ListStore CargoData;
        protected ListStore DepData;

        protected EmpleadosView parent;

        public UpdateDialog(EmpleadosView parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            //this.CmbxEntry = SistemaEySLibrary.ComboBoxNumericEntry.NewText();
            this.CmbxID.Entry.WidthChars = 16;
            this.Hide();
            this.UpdateData();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        public void UpdateData()
        {
            this.EmpData = dtus.listarUsuarios();
            this.CargoData = dtcarg.GetDataCmbx();
            this.DepData = dtdep.ListarDepartamentosCmbx();
            this.FillCmbxIDModel();
            this.FillCmbCargoModel();
            this.FillCmbDepModel();
        }

        protected void FillCmbxIDModel()
        {
            ListStore store = (ListStore)this.CmbxID.Model;
            store.Clear();
            TreeIter iter;
            if (EmpData.GetIterFirst(out iter))
            {
                do
                {
                    this.CmbxID.InsertText(
                        Convert.ToInt32(EmpData.GetValue(iter, 0)),
                        (String)EmpData.GetValue(iter, 0)
                    );
                }
                while (EmpData.IterNext(ref iter));
            }

            this.CmbxID.Entry.Completion = new EntryCompletion();
            this.CmbxID.Entry.Completion.Model = EmpData;
            this.CmbxID.Entry.Completion.TextColumn = 0;
        }
        protected void FillCmbCargoModel()
        {
            ListStore store = (ListStore)this.CmbCargo.Model;
            store.Clear();
            this.CargoData.InsertWithValues(0, "Ninguno", "0", "");
            this.CmbCargo.Model = this.CargoData;
            this.CmbCargo.Active = -1;
        }
        
        protected void FillCmbDepModel()
        {
            ListStore model = (ListStore) this.CmbDep.Model;
            model.Clear();
            this.DepData.InsertWithValues(0, "Ninguno", "0", "");
            this.CmbDep.Model = this.DepData;
            this.CmbDep.Active = -1;
        }

        protected int GetIndexFromValue(ComboBox comboBox, string value)
        {
            int index = -1;
            TreeModel model = comboBox.Model;
            TreeIter iter;

            if (value == "")
            {
                return 0;
            }

            int i = 0;
            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (value == (string) model.GetValue(iter, 1))
                    {
                        index = i;
                        break;
                    }
                    i++;
                } while (model.IterNext(ref iter));
            }

            return index;
        }

        protected void ComboBoxOnChanged(object sender, EventArgs e)
        {
            string id = this.CmbxID.ActiveText;

            TreeIter iter;
            if (EmpData.GetIterFirst(out iter))
            {
                do
                {
                    if (id == (string)EmpData.GetValue(iter, 0))
                    {
                        this.newId.Text = id;
                        this.name.Text = (string)EmpData.GetValue(iter, 1);
                        this.secondName.Text = (string)EmpData.GetValue(iter, 2);
                        this.surname.Text = (string)EmpData.GetValue(iter, 3);
                        this.secondSurname.Text = (string)EmpData.GetValue(iter, 4);
                        this.dIngress.Text = (string)EmpData.GetValue(iter, 5);
                        this.Icard.Text = (string)EmpData.GetValue(iter, 6);
                        this.password.Text = (string)EmpData.GetValue(iter, 7);
                        this.CmbCargo.Active = this.GetIndexFromValue(
                            this.CmbCargo, (string) EmpData.GetValue(iter, 8));
                        this.CmbDep.Active = this.GetIndexFromValue(
                            this.CmbDep, (string)EmpData.GetValue(iter, 9));
                        this.idHor.Text = (string)EmpData.GetValue(iter, 10);
                        this.idGroup.Text = (string)EmpData.GetValue(iter, 11);
                        return;
                    } else
                    {
                        this.newId.Text = "";
                        this.name.Text = "";
                        this.secondName.Text = "";
                        this.surname.Text = "";
                        this.secondSurname.Text = "";
                        this.dIngress.Text = "";
                        this.Icard.Text = "";
                        this.password.Text = "";
                        this.CmbCargo.Active = -1;
                        this.CmbCargo.Active = -1;
                        this.idHor.Text = "";
                        this.idGroup.Text = "";
                    }
                }
                while (EmpData.IterNext(ref iter));
            }
        }

        protected string GetActiveID(ComboBox comboBox)
        {
            string id = "'NULL'";
            TreeModel model = comboBox.Model;
            TreeIter iter;
            if (comboBox.GetActiveIter(out iter))
            {
                Console.WriteLine($"ID: {id}");
                id = (string)model.GetValue(iter, 1);
                if (string.IsNullOrWhiteSpace(id))
                {
                    return "NULL";
                }
                id = $"'{id}'";
            }
            return id;
        }

        protected void BtnAcceptOnClicked(object sender, EventArgs e)
        {
            ConnectionEyS connection = ConnectionEyS.OpenConnection();

            string idEmpleado = this.CmbxID.ActiveText;

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
            if (!string.IsNullOrWhiteSpace(this.CmbCargo.ActiveText))
            {
                string idCargo = this.GetActiveID(this.CmbCargo);
                modifiedQuery += $"idCargo = {idCargo}, ";
            }
            if (!string.IsNullOrWhiteSpace(this.CmbDep.ActiveText))
            {
                string idDep = this.GetActiveID(this.CmbDep);
                modifiedQuery += $"idDepartamento = {idDep}, ";
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
            //Console.WriteLine(Query);
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

            this.parent.UpdateData();
        }

        public void ClearInput()
        {
            this.CmbxID.Active = -1;
            this.CmbxID.Entry.Text = "";
            this.newId.Text = "";
            this.name.Text = "";
            this.secondName.Text = "";
            this.surname.Text = "";
            this.secondSurname.Text = "";
            this.dIngress.Text = "";
            this.Icard.Text = "";
            this.password.Text = "";
            this.CmbCargo.Active = -1;
            this.CmbDep.Active = -1;
        }

        public void SetIDRandom()
        {
            Random r = new Random();
            this.newId.Text = Convert.ToString(r.Next(10000, 100000));
        }

        protected void BtnCancelOnClicked(object sender, EventArgs e)
        {
            this.ClearInput();
            this.Hide();
        }

        protected void BtnNewIDUpdateOnClicked(object sender, EventArgs e)
        {
            this.SetIDRandom();
        }
    }
}
