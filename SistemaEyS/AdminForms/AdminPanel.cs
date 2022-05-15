﻿using System;
using Gtk;
using SistemaEySLibrary;
using SistemaEyS.AdminForms.Seguridad;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.AdminForms
{
    public partial class AdminPanel : Gtk.Window
    {
        protected Window parent;
        protected uint timeout;

        public AdminPanel(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.SetDateTimeTimeout();
        }
        public void Close()
        {
            GLib.Source.Remove(this.timeout);
            ConnectionSeg.CloseConnection();
            this.Destroy();
            this.parent.Show();
        }

        protected void SetDateTimeTimeout()
        {
            this.UpdateDateTime();
            this.timeout = GLib.Timeout.Add(500, this.UpdateDateTime);
        }
        protected bool UpdateDateTime()
        {
            DateTime dateTime = DateTime.Now;
            string str = dateTime.ToString("yyyy-MM-dd h:mm:ss tt");
            this.lbDateTime.Markup = $"<span weight=\"bold\">{str}</span>";
            this.lbDateTime.UseMarkup = true;
            this.clockwidget1.QueueDraw();
            return true;
        }
        public void AddTab(Notebook notebook, Widget widget, string label)
        {
            TabviewLabel tabviewLabel = new TabviewLabel(label);
            notebook.AppendPage(widget, tabviewLabel);
            tabviewLabel.CloseClicked += delegate (object obj, EventArgs args)
            {
                this.ntTabview.RemovePage(notebook.PageNum(widget));
            };
            widget.Show();
            tabviewLabel.Show();
        }

        protected void actCloseOnActivated(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void TablasEmpleadosActionOnActivated(object sender, EventArgs e)
        {
            Tables.EmpleadosView empleadosPanel = new Tables.EmpleadosView();
            this.AddTab(this.ntTabview, empleadosPanel, "Empleados");
        }

        protected void TablasHorariosActionOnActivated(object sender, EventArgs e)
        {
            Tables.HorarioView horariosPanel = new Tables.HorarioView();
            this.AddTab(this.ntTabview, horariosPanel, "Horarios");
        }

        protected void TablasEntradasSalidasActionOnActivated(object sender, EventArgs e)
        {
            Tables.EntradaSalidaView EntradaSalidaPanel = new Tables.EntradaSalidaView();
            this.AddTab(this.ntTabview, EntradaSalidaPanel, "Entrada/Salida");
        }

        protected void TablasSolicitudVacacionesActionOnActivated(object sender, EventArgs e)
        {
            Tables.SolVacacionesView SolicitudVacaciones = new Tables.SolVacacionesView();
            this.AddTab(this.ntTabview, SolicitudVacaciones, "Solicitudes de vacaciones");
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            Application.Quit();
            args.RetVal = true;
        }

        protected void SeguridadRolesOnActivated(object sender, EventArgs e)
        {
            AdminForms.Seguridad.RolSeguridad rolSeguridad = new RolSeguridad();
            rolSeguridad.Show();
        }

        protected void AjustesCargosOnActivated(object sender, EventArgs e)
        {
            AdminForms.Settings.CargosSettings cargosSettings = new Settings.CargosSettings();
            cargosSettings.Show();
        }

        protected void SeguridadUsuariosOnActivated(object sender, EventArgs e)
        {
            UserSeguridad userSeguridad = new UserSeguridad();
            userSeguridad.Show();
        }

        protected void AjustesDepartamentosOnActivated(object sender, EventArgs e)
        {
            AdminForms.Settings.DepartamentoSettings departamentoSettings = new Settings.DepartamentoSettings();
            departamentoSettings.Show();
        }
    }
}