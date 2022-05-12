using System;
using SistemaEyS.DatosEyS;
using SistemaEyS.AdminForms.Tables.HorPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class HorarioView : Gtk.Bin
    {
        Dt_tlb_horario dtus = new Dt_tlb_horario();
        AddDialogHor adh = new AddDialogHor();

        public HorarioView()
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

            this.viewTable.SetTreeViewColumns(storeObjects);

            this.viewTable.Model = dtus.listarHorarios();
        }

        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            this.viewTable.Model = dtus.listarHorarios();
        }

        protected void OnBtnAddClicked(object sender, EventArgs e)
        {
            adh.Show();
            adh.Present();
        }
    }
}
