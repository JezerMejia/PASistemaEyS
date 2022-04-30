using System;
using Gtk;
using SistemaEyS.Datos;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class EmpleadosPanel :PanelTemplate
    {
        public EmpleadosPanel()
        {
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Ingreso", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cédula", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cargo", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Departamento", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Horario", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Grupo", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.SetTreeViewColumns(treeView, storeObjects);

            Dt_tlb_empleado dtus = new Dt_tlb_empleado();
            this.treeView.Model = dtus.listarUsuarios();
        }
    }
}
