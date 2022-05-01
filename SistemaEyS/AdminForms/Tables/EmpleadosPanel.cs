using System;
using Gtk;
using SistemaEyS.Datos;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class EmpleadosPanel : Gtk.Bin
    {
        Dt_tlb_empleado dtus = new Dt_tlb_empleado();
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
    }
}
