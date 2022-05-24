﻿using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class SolVacacionesView : Gtk.Bin
    {
        Dt_tlb_solicitudVacaciones dtus = new Dt_tlb_solicitudVacaciones();
        AddDialogSolVac solVac = new AddDialogSolVac();

        public SolVacacionesView()
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
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.viewTable.Model = dtus.listarSolicitudVacaciones();
        }

        protected void OnBtnAddSVClicked(object sender, EventArgs e)
        {

            solVac.Show();

        }
    }
}
