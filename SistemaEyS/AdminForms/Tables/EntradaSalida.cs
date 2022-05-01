using System;
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
                new StoreObject("ID Empleado", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fecha", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Entrada", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Salida", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.SetTreeViewColumns(treeView, storeObjects);

            this.treeView.Model = dtus.listarentradaSalida();
        }
    }
}
