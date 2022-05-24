using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Negocio;
using SistemaEyS.DatosEyS.Entidades;

namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class AddDialog : Gtk.Window
    {
        protected EmpleadosView parent;
        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();
        protected Neg_Empleado NegEmp = new Neg_Empleado();

        public AddDialog(EmpleadosView parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.SetIDRandom();
            this.Hide();

            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtID.Text) ||
                    string.IsNullOrWhiteSpace(TxtName.Text) ||
                    string.IsNullOrWhiteSpace(TxtPIN.Text) ||
                    string.IsNullOrWhiteSpace(TxtCedula.Text)
                    )
                {
                    throw new ArgumentException(
                        "No puede haber datos vacíos"
                        );
                }

                Ent_Empleado emp = new Ent_Empleado()
                {
                    idEmpleado = Int32.Parse(this.TxtID.Text),
                    primerNombre = this.TxtName.Text,
                    segundoNombre = this.TxtSecondName.Text,
                    primerApellido = this.TxtLastName.Text,
                    segundoApellido = this.TxtSecondLastName.Text,
                    pinEmpleado = this.TxtPIN.Text,
                    cedulaEmpleado = this.TxtCedula.Text
                };
                this.NegEmp.AddEmpleado(emp);

                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Agregado");
                ms.Run();
                ms.Destroy();
                ClearInput();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                    e.Message);
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
            this.TxtCedula.Text = "";
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
