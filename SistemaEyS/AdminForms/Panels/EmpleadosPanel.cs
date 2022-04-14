using System;
namespace SistemaEyS.AdminForms.Panels
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class EmpleadosPanel : Gtk.Bin
    {
        public Gtk.ListStore listStore;

        public EmpleadosPanel()
        {
            this.Build();
            Type[] types = { typeof (string), typeof (string) };
            this.listStore = new Gtk.ListStore(
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string)
            );

            this.treeView.Model = this.listStore;
            this.treeView.ShowAll();

            this.treeView.AppendColumn("ID", new Gtk.CellRendererText(), "text", 0);
            this.treeView.AppendColumn("Nombre", new Gtk.CellRendererText(), "text", 1);
            this.treeView.AppendColumn("Apellido", new Gtk.CellRendererText(), "text", 2);
            this.treeView.AppendColumn("Dirección", new Gtk.CellRendererText(), "text", 3);
            this.treeView.AppendColumn("Teléfono", new Gtk.CellRendererText(), "text", 4);
            this.treeView.AppendColumn("Email", new Gtk.CellRendererText(), "text", 5);

            this.listStore.AppendValues("000031725", "Jezer", "Mejía", "", "81211855", "jezer.mejia13523@est.uca.edu.ni");
            this.listStore.AppendValues("000031231", "Juan", "Juan", "", "81921935", "juan.juan23214@est.uca.edu.ni");
        }
    }
}
