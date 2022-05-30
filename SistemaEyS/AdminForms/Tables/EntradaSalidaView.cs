using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.HorPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class EntradaSalidaView : Gtk.Bin
    {
        Dt_tlb_asistencia DtAssis = new Dt_tlb_asistencia();

        public EntradaSalidaView()
        {
            this.Build();
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("ID Empleado", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Empleado", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fecha", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Entrada", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Salida", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.viewTable.Model = DtAssis.GetDataView();
        }

        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            this.viewTable.Model = DtAssis.GetDataView();
        }
    }
}
