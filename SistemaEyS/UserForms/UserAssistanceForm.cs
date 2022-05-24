using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;

namespace SistemaEyS.UserForms
{
    public partial class UserAssistanceForm : Gtk.Window
    {
        protected Window parent;
        protected uint timeout;
        protected string idEmpleado;

        protected Dt_tlb_asistencia DtAssis = new Dt_tlb_asistencia();
        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();
        protected ListStore EmpModel;

        public UserAssistanceForm(Window parent, string idEmpleado) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.idEmpleado = idEmpleado;
            this.Build();
            this.UpdateData();
            this.SetDateTimeTimeout();
        }

        public void UpdateData()
        {
            this.EmpModel = this.DtEmp.GetDataView();
            this.lbWelcome.Text = $"¡Bienvenido, {this.GetEmpleadoName()}!";
        }

        protected string GetEmpleadoName()
        {
            TreeIter iter;
            if (this.EmpModel.GetIterFirst(out iter))
            {
                do
                {
                    if (this.idEmpleado == this.EmpModel.GetValue(iter, 0).ToString())
                    {
                        return this.EmpModel.GetValue(iter, 1).ToString();
                    }
                }
                while (this.EmpModel.IterNext(ref iter));
            }
            return "";
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
            this.lbDateTime.Text = str;
            this.clockwidget1.QueueDraw();
            return true;
        }

        private void MarkAssitanceEnter()
        {
            DateTime now = DateTime.Now;

            try
            {
                this.DtAssis.InsertEnterAssistance(
                    this.idEmpleado,
                    now.ToString("yyyy-MM-dd"),
                    now.ToString("H:mm:ss")
                );
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Marcado de entrada exitoso");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok,
                    "Error al marcar la entrada: " + e.Message);
                ms.Run();
                ms.Destroy();
            }
        }
        private void MarkAssitanceExit()
        {
            DateTime now = DateTime.Now;

            try
            {
                this.DtAssis.InsertExitAssistance(
                    this.idEmpleado,
                    now.ToString("yyyy-MM-dd"),
                    now.ToString("H:mm:ss")
                );
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Marcado de salida exitoso");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok,
                    "Error al marcar la salida: " + e.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        public void Close()
        {
            GLib.Source.Remove(this.timeout);
            this.Destroy();
            this.parent.Show();
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnExitOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void btnMarkEntryOnClicked(object sender, EventArgs e)
        {
            this.MarkAssitanceEnter();
        }

        protected void btnMarkExitOnClicked(object sender, EventArgs e)
        {
            this.MarkAssitanceExit();
        }
    }
}
