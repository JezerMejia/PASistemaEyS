using System;
using Gtk;
using SistemaEyS.Datos;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class solicitudVacacionesPanel : PanelTemplate
    {
        Dt_tlb_solicitudVacaciones dtus = new Dt_tlb_solicitudVacaciones();

        public solicitudVacacionesPanel()
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

            this.treeView.Model = dtus.listarsolicitudVacaciones();
        }
    }
}
