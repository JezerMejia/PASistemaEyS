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
        protected Dt_tlb_horario DtHor = new Dt_tlb_horario();

        protected Neg_Empleado NegEmp = new Neg_Empleado();
        protected Neg_Asistencia NegAsis = new Neg_Asistencia();
        protected Neg_Horario NegHor = new Neg_Horario();

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

        public void SetSensitiveData()
        {
            if (this.Empleado.idHorario == null)
            {
                this.lbInfo.Text =
                    "Aún no tienes asignado un horario\n" +
                    "Comuníquese con RRHH";
                this.btnMarkEntry.Sensitive = false;
                this.btnMarkExit.Sensitive = false;
                return;
            }
            Ent_Horario hor = this.NegHor.SearchHorario((int)this.Empleado.idHorario);
            DateTime? todayInicio = hor.GetTodayInicio();
            DateTime? todaySalida = hor.GetTodaySalida();

            if (todayInicio == null || todaySalida == null)
            {
                this.lbInfo.Text =
                    "Hoy no tienes que trabajar\n" +
                    "¡Pase un buen día!";
                this.btnMarkEntry.Sensitive = false;
                this.btnMarkExit.Sensitive = false;
                return;
            }

            this.btnMarkEntry.Sensitive = true;
            this.btnMarkExit.Sensitive = true;

            bool entradaExists =
                this.DtAssis.DoesExist(
                    "AND",
                    new DataTableParameter("idEmpleado", $"'{this.Empleado.idEmpleado}'"),
                    new DataTableParameter("fechaAsistencia", $"'{DateTime.Now.ToString("yyyy-MM-dd")}'"),
                    new DataTableParameter("horaEntrada", $"NULL", "IS NOT")
                    );
            bool salidaExists =
                this.DtAssis.DoesExist(
                    "AND",
                    new DataTableParameter("idEmpleado", $"'{this.Empleado.idEmpleado}'"),
                    new DataTableParameter("fechaAsistencia", $"'{DateTime.Now.ToString("yyyy-MM-dd")}'"),
                    new DataTableParameter("horaSalida", $"NULL", "IS NOT")
                    );

            if (entradaExists)
            {
                this.btnMarkEntry.Sensitive = false;
                this.lbInfo.Text =
                    "¡Te esperamos al final del día!\n" +
		            $"Tu jornada termina a las {todaySalida?.ToString("hh:mm:ss tt")}.";
            }
            else
            {
                this.btnMarkExit.Sensitive = false;
                this.lbInfo.Text =
                    "¡Es hora de marcar tu asistencia!\n" +
		            $"Tu jornada inicia a las {todayInicio?.ToString("hh:mm:ss tt")}.";
            }

            if (salidaExists)
            {
                this.btnMarkExit.Sensitive = false;
                this.lbInfo.Text =
                    "Has completado tu jornada de hoy.\n¡Que tengas un buen día!";
            }
        }

        public void UpdateData()
        {
            this.Empleado = this.NegEmp.SearchEmpleado(this.idEmpleado);

            this.lbWelcome.Text = $"¡Bienvenido, {this.Empleado.GetFullName()}!";

            this.SetSensitiveData();
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
                this.UpdateData();
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
                this.UpdateData();
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
