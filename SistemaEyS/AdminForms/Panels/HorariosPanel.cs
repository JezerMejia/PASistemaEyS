using System;
namespace SistemaEyS.AdminForms.Panels
{
    [System.ComponentModel.ToolboxItem(true)]
    public class HorariosPanel : PanelTemplate
    {
        public HorariosPanel()
        {
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Dirección", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Teléfono", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email", typeof(string), "text", new Gtk.CellRendererText()),
            };

            this.SetTreeViewColumns(this.treeView, storeObjects);

            this.listStore = (Gtk.ListStore)this.treeView.Model;

            this.listStore.AppendValues("000031725", "Jezer", "Mejía", "", "81211855", "jezer.mejia13523@est.uca.edu.ni");
            this.listStore.AppendValues("000031231", "Juan", "Juan", "", "81921935", "juan.juan23214@est.uca.edu.ni");
        }
    }
}
