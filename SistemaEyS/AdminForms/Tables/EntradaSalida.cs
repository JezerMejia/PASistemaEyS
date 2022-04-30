using System;
using Gtk;
using SistemaEyS.Datos;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class entradaSalidaPanel : PanelTemplate
    {
        Dt_tlb_asistencia dtus = new Dt_tlb_asistencia();
        public entradaSalidaPanel()
        {
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("User", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Dirección", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Teléfono", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.SetTreeViewColumns(treeView, storeObjects);

            this.treeView.Model = dtus.listarentradaSalida();
        }
    }
}
