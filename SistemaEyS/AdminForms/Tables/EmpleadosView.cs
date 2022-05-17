using System;
using Gtk;
using SistemaEyS.DatosEyS;
using SistemaEyS.AdminForms.Tables.EmpPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class EmpleadosView : Gtk.Bin
    {
        Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();
        AddDialog addBtn;
        UpdateDialog actBtn;
        DeleteDialog delBtn;

        public EmpleadosView()
        {
            this.Build();

            this.addBtn = new AddDialog(this);
            this.actBtn = new UpdateDialog(this);
            this.delBtn = new DeleteDialog(this);

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Ingreso", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cédula", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Contraseña", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cargo", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Departamento", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("ID Horario", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Grupo", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.viewTable.Model = DtEmp.GetDataView();
            this.actBtn.UpdateData();
            this.delBtn.UpdateData();
        }

        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }


        protected void btnAddOnClicked(object sender, EventArgs e)
        {
            //AddBtn
            addBtn.Show();
            addBtn.Present();
            addBtn.SetIDRandom();
        }

        protected void OnButton3Clicked(object sender, EventArgs e)
        {
            //ActBtn
            actBtn.UpdateData();
            actBtn.Show();
            actBtn.Present();
            actBtn.SetIDRandom();
        }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            //DelBtn
            delBtn.UpdateData();
            delBtn.Show();
            delBtn.Present();
        }
    }
}
