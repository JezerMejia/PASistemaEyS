using System;
using SistemaEyS.DatosEyS;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class solicitudVacacionesPanel : Gtk.Bin
    {
        Dt_tlb_solicitudVacaciones dtus = new Dt_tlb_solicitudVacaciones();

        public solicitudVacacionesPanel()
        {
            this.Build();
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("ID Empleado", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fecha Solicitud", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Descripción", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fin", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.tableView.SetTreeViewColumns(this.tableView.treeView, storeObjects);

            this.tableView.treeView.Model = dtus.listarSolicitudVacaciones();
        }
    }
}
