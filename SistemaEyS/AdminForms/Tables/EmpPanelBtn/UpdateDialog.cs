using System;
using System.Text.RegularExpressions;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.DatosEyS.Negocio;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class UpdateDialog : Gtk.Window
    {
        protected Neg_Empleado NegEmp = new Neg_Empleado();

        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();
        protected Dt_tbl_cargo DtCargo = new Dt_tbl_cargo();
        protected Dt_tbl_departamento DtDep = new Dt_tbl_departamento();
        protected ListStore EmpData;
        protected ListStore CargoData;
        protected ListStore DepData;

        protected int _SelectedID = -1;
        public int SelectedID
        {
            get
            {
                return this._SelectedID;
            }
            set
            {
                this._SelectedID = value;
                this.TxtID.Text = this._SelectedID.ToString();
            }
        }

        protected EmpleadosView parent;

        public UpdateDialog(EmpleadosView parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.Hide();
            this.UpdateData();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        public void UpdateData()
        {
            this.EmpData = DtEmp.GetData();
            this.CargoData = DtCargo.GetDataCmbx();
            this.DepData = DtDep.GetDataCmbx();
            this.FillCmbCargoModel();
            this.FillCmbDepModel();

            this.SetEntryTextFromID(this.SelectedID);
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
            ListStore model = (ListStore)this.CmbDep.Model;
            model.Clear();
            this.DepData.InsertWithValues(0, "Ninguno", "0", "");
            this.CmbDep.Model = this.DepData;
            this.CmbDep.Active = -1;
        }

        protected int GetIndexFromValue(ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            int index = 0;
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
                    if (value == (string)model.GetValue(iter, 1))
                    {
                        index = i;
                        break;
                    }
                    i++;
                } while (model.IterNext(ref iter));
            }

            return index;
        }

        protected void TxtIDOnChanged(object sender, EventArgs e)
        {
            this.SetEntryTextFromID(this.SelectedID);
        }

        protected void SetEntryTextFromID(int idEmpleado)
        {
            Console.WriteLine(idEmpleado);
            try
            {
                Ent_Empleado emp = this.NegEmp.SearchEmpleado(idEmpleado);

                this.name.Text = emp.primerNombre;
                this.secondName.Text = emp.segundoNombre;
                this.surname.Text = emp.primerApellido;
                this.secondSurname.Text = emp.segundoApellido;
                this.dIngress.Text = emp.fechaIngreso?.ToString("yyyy-MM-dd") ?? "";
                this.Icard.Text = emp.cedulaEmpleado;
                this.password.Text = emp.pinEmpleado;
                this.password.Text = emp.pinEmpleado;
                this.CmbCargo.Active = this.GetIndexFromValue(
                    this.CmbCargo, emp.idCargo?.ToString());
                this.CmbDep.Active = this.GetIndexFromValue(
                    this.CmbDep, emp.idDepartamento?.ToString());
                this.idHor.Text = emp.idHorario?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                this.name.Text = "";
                this.secondName.Text = "";
                this.surname.Text = "";
                this.secondSurname.Text = "";
                this.dIngress.Text = "";
                this.Icard.Text = "";
                this.password.Text = "";
                this.password.Text = "";
                this.CmbCargo.Active = -1;
                this.CmbDep.Active = -1;
                this.idHor.Text = "";
            }
        }

        protected int? GetActiveID(ComboBox comboBox)
        {
            int? id = null;
            TreeModel model = comboBox.Model;
            TreeIter iter;
            if (comboBox.GetActiveIter(out iter))
            {
                //Console.WriteLine($"ID: {id}");
                string v = (string)model.GetValue(iter, 1);
                if (string.IsNullOrWhiteSpace(v) || v == "0") return null;
                id = Int32.Parse(v);
            }
            return id;
        }

        protected void BtnAcceptOnClicked(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaIngreso = null;
                if (!string.IsNullOrWhiteSpace(this.dIngress.Text))
                {
                    if (!Regex.IsMatch(this.dIngress.Text,
                        @"^([0-9]{4})-(1[0-2]|0[1-9])-(3[01]|0[1-9]|[12][0-9])$")
                    )
                        throw new FormatException("Fecha de ingreso inválida");
                    fechaIngreso = DateTime.Parse(this.dIngress.Text);
                }
                int? idHor = null;
                if (!string.IsNullOrWhiteSpace(this.idHor.Text))
                {
                    idHor = Int32.Parse(this.idHor.Text);
                }
                Ent_Empleado emp = new Ent_Empleado()
                {
                    idEmpleado = this.SelectedID,
                    primerNombre = this.name.Text,
                    segundoNombre = this.secondName.Text,
                    primerApellido = this.surname.Text,
                    segundoApellido = this.secondSurname.Text,
                    pinEmpleado = this.password.Text,
                    cedulaEmpleado = this.Icard.Text,
                    fechaIngreso = fechaIngreso,
                    idCargo = this.GetActiveID(this.CmbCargo),
                    idDepartamento = this.GetActiveID(this.CmbDep),
                    idHorario = idHor,
                };
                this.NegEmp.EditEmpleado(emp);
                //this.DtEmp.UpdateSet(
                //    idEmpleado,
                //    this.name.Text,
                //    this.secondName.Text,
                //    this.surname.Text,
                //    this.secondSurname.Text,
                //    this.password.Text,
                //    this.Icard.Text,
                //    this.dIngress.Text,
                //    this.GetActiveID(this.CmbCargo),
                //    this.GetActiveID(this.CmbDep),
                //    this.idHor.Text
                //    );
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Guardado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                    ex.Message);
                ms.Run();
                ms.Destroy();
            }

            this.parent.UpdateData();
        }

        public void ClearInput()
        {
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

        protected void BtnCancelOnClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
