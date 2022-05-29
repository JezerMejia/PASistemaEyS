using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Negocio;
using SistemaEyS.DatosEyS.Entidades;

namespace SistemaEyS.UserForms
{
    public partial class UserAssistanceForm : Gtk.Window
    {
        protected Window parent;
        protected uint timeout;
        protected int idEmpleado;

        protected Dt_tlb_asistencia DtAssis = new Dt_tlb_asistencia();
        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();

        protected Neg_Empleado NegEmp = new Neg_Empleado();
        protected Neg_Asistencia NegAsis = new Neg_Asistencia();

        protected ListStore EmpModel;

        protected Ent_Empleado Empleado;

        public UserAssistanceForm(Window parent, int idEmpleado) :
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
            this.Empleado = this.NegEmp.SearchEmpleado(this.idEmpleado);

            this.lbWelcome.Text = $"¡Bienvenido, {this.Empleado.GetFullName()}!";
        }

        protected void SetDateTimeTimeout()
        {
            this.UpdateDateTime();
            this.timeout = GLib.Timeout.Add(500, this.UpdateDateTime);
        }
        protected bool UpdateDateTime()
        {
            DateTime dateTime = DateTime.Now;
            string str = dateTime.ToString("yyyy-MM-dd hh:mm:ss tt");
            this.lbDateTime.Text = str;
            this.clockwidget1.QueueDraw();
            return true;
        }

        private void MarkAssitanceEnter()
        {
            DateTime now = DateTime.Now;

            try
            {
                Ent_Asistencia asis = new Ent_Asistencia()
                {
                    idEmpleado = this.Empleado.idEmpleado,
                    fechaAsistencia = now.Date,
                    horaEntrada = now
                };
                this.NegAsis.MarkAssistance(asis);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Marcado de entrada exitoso");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
                Ent_Asistencia asis = new Ent_Asistencia()
                {
                    idEmpleado = this.Empleado.idEmpleado,
                    fechaAsistencia = now.Date,
                    horaSalida = now
                };
                this.NegAsis.MarkAssistance(asis);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Marcado de salida exitoso");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
