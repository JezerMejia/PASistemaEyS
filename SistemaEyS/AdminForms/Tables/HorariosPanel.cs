using System;
using SistemaEyS.DatosEyS;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class HorariosPanel : Gtk.Bin
    {
        Dt_tlb_horario dtus = new Dt_tlb_horario();

        public HorariosPanel()
        {
            this.Build();
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Lunes - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Lunes - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Martes - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Martes - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Miércoles - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Miércoles - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Jueves - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Jueves - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Viernes - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Viernes - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Sábado - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Sábado - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Domingo - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Domingo - Fin", typeof(string), "text", new Gtk.CellRendererText()),
            };

            this.tableView.SetTreeViewColumns(this.tableView.treeView, storeObjects);

            this.tableView.treeView.Model = dtus.listarHorarios();
        }

        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            this.tableView.treeView.Model = dtus.listarHorarios();
        }
    }
}
