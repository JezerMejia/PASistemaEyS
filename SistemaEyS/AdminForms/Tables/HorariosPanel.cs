using System;
using SistemaEyS.Datos;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]
    public class HorariosPanel : PanelTemplate
    {
        Dt_tlb_horario dtus = new Dt_tlb_horario();

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

            this.treeView.Model = dtus.listarHorarios();
        }
    }
}
