using System;
using Gtk;
using SistemaEyS.DatosEyS;
using SistemaEyS.AdminForms.Tables.EmpPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class EmpleadosPanel : Gtk.Bin
    {
        Dt_tlb_empleado dtus = new Dt_tlb_empleado();
        AddBtn ab = new AddBtn();
        ActBtn acb = new ActBtn();
        DelBtn delb = new DelBtn();

        public EmpleadosPanel()
        {
            this.Build();

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
            this.viewTable.SetTreeViewColumns(this.viewTable.treeView, storeObjects);

            this.viewTable.treeView.Model = dtus.listarUsuarios();
        }

        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            this.viewTable.treeView.Model = dtus.listarUsuarios();
        }


        protected void btnAddOnClicked(object sender, EventArgs e)
        {
            //AddBtn ab = new AddBtn();
            ab.Show();
            ab.Present();
        }

        protected void OnButton3Clicked(object sender, EventArgs e)
        {
            //ActBtn acb = new ActBtn();
            acb.Show();
            acb.Present();
        }

        protected void OnButton1Clicked(object sender, EventArgs e)
        {
            //DelBtn delb = new DelBtn();
            delb.Show();
            delb.Present();
        }

    }
}
