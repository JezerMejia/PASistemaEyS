using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class UpdateDialog : Gtk.Window
    {
        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();
        protected Dt_tbl_cargo DtCargo = new Dt_tbl_cargo();
        protected Dt_tbl_departamento DtDep = new Dt_tbl_departamento();
        protected ListStore EmpData;
        protected ListStore CargoData;
        protected ListStore DepData;

        protected int _SelectedID;
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

            this.SetEntryTextFromID(this.TxtID.Text);
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

        protected void TxtIDOnChanged(object sender, EventArgs e)
        {
            string id = this.TxtID.Text;
            this.SetEntryTextFromID(id);
        }

        protected void SetEntryTextFromID(string idEmpleado)
        {
            TreeIter iter;
            if (EmpData.GetIterFirst(out iter))
            {
                do
                {
                    if (idEmpleado == (string)EmpData.GetValue(iter, 0))
                    {
                        this.name.Text = (string)EmpData.GetValue(iter, 1);
                        this.secondName.Text = (string)EmpData.GetValue(iter, 2);
                        this.surname.Text = (string)EmpData.GetValue(iter, 3);
                        this.secondSurname.Text = (string)EmpData.GetValue(iter, 4);
                        this.dIngress.Text = (string)EmpData.GetValue(iter, 5);
                        this.Icard.Text = (string)EmpData.GetValue(iter, 6);
                        this.password.Text = (string)EmpData.GetValue(iter, 7);
                        this.CmbCargo.Active = this.GetIndexFromValue(
                            this.CmbCargo, (string)EmpData.GetValue(iter, 8));
                        this.CmbDep.Active = this.GetIndexFromValue(
                            this.CmbDep, (string)EmpData.GetValue(iter, 9));
                        this.idHor.Text = (string)EmpData.GetValue(iter, 10);
                        return;
                    }
                    else
                    {
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
            string idEmpleado = this.TxtID.Text;

            if (string.IsNullOrWhiteSpace(idEmpleado))
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Seleccione un ID de empleado");
                ms.Run();
                ms.Destroy();
                return;
            }

            try
            {
                this.DtEmp.UpdateSet(
                    idEmpleado,
                    this.name.Text,
                    this.secondName.Text,
                    this.surname.Text,
                    this.secondSurname.Text,
                    this.password.Text,
                    this.Icard.Text,
                    this.dIngress.Text,
                    this.GetActiveID(this.CmbCargo),
                    this.GetActiveID(this.CmbDep),
                    this.idHor.Text
                    );
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Guardado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception ex)
            {
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
