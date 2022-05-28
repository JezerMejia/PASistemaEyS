using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.Calendar;

namespace SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn
{
    public partial class AddDialogSolVac : Gtk.Window
    {
        protected EmpleadosView parent;

        protected Dt_tlb_SolVacaciones DtSolVac = new Dt_tlb_SolVacaciones();
        protected Dt_tlb_empleado dtEmp = new Dt_tlb_empleado();

        protected ListStore DataUser;
        protected calendar Cal = new calendar();

        public int SelectedID = -1;
        public int SelectedUser = -1;

        public AddDialogSolVac() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();

            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.DataUser = dtEmp.GetDataView();
            this.CmbxIDEmp.Model = this.DataUser;
            this.FillCmbxUsuarioModel();
        }
        protected void FillCmbxUsuarioModel()
        {
            this.CmbxIDEmp.Model = this.DataUser;
            this.CmbxIDEmp.Active = -1;

            this.CmbxIDEmp.Entry.Completion = new EntryCompletion();
            this.CmbxIDEmp.Entry.Completion.Model = this.DataUser;
            this.CmbxIDEmp.Entry.Completion.TextColumn = 0;
        }

        public void SetFechaSol(DateTime fechaEntrada)
        {
            try
            {
                this.TxtFechaSol.Text = fechaEntrada.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void SetFechaIni(DateTime fechaEntrada)
        {
            try
            {
                this.TxtFechaIni.Text = fechaEntrada.ToString("yyyy-MM-dd hh:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void SetFechaFin(DateTime fechaEntrada)
        {
            try
            {
                this.TxtFechaFin.Text = fechaEntrada.ToString("yyyy-MM-dd hh:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        protected void OnButton8Clicked(object sender, EventArgs e)
        {
            this.Cal.fecha = new calendar.selectFecha(this.SetFechaSol);
            this.Cal.Show();
        }

        protected void OnButton9Clicked(object sender, EventArgs e)
        {
            this.Cal.fecha = new calendar.selectFecha(this.SetFechaIni);
            this.Cal.Show();
        }

        protected void OnButton10Clicked(object sender, EventArgs e)
        {
            this.Cal.fecha = new calendar.selectFecha(this.SetFechaFin);
            this.Cal.Show();
        }

        public void mensaje(String mensaje)
        {
            MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    mensaje);
            ms.Run();
            ms.Destroy();
        }

        protected void OnExitBtnClicked(object sender, EventArgs e)
        {
            this.Hide();
            this.ClearInput();
        }

        public void ClearInput()
        {
            this.TxtFechaSol.Text = "";
            this.CmbxIDEmp.Active = -1;
            this.CmbxIDEmp.Entry.Text = "";
            this.justTxt.Buffer.Text = "";
            this.TxtFechaIni.Text = "";
            this.TxtFechaFin.Text = "";
        }

        protected void TxtFechaIniOnChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TxtFechaIni.Text))
            {
                this.TxtFechaFin.Sensitive = false;
                this.TxtFechaFin.IsEditable = false;
                return;
            };
            this.TxtFechaFin.Sensitive = true;
            this.TxtFechaFin.IsEditable = true;
        }

        protected void OnSaveBtnClicked(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.TxtFechaSol.Text) ||
                    string.IsNullOrWhiteSpace(this.CmbxIDEmp.ActiveText) ||
                    string.IsNullOrWhiteSpace(this.justTxt.Buffer.Text) ||
                    string.IsNullOrWhiteSpace(this.TxtFechaIni.Text) ||
                    string.IsNullOrWhiteSpace(this.TxtFechaFin.Text)
                    )
                {
                    throw new ArgumentException("No puede haber datos vacíos");
                }

                DateTime now = DateTime.Now.Date;
                DateTime fechaSol = Convert.ToDateTime(this.TxtFechaSol.Text);
                DateTime fechaIni = Convert.ToDateTime(this.TxtFechaIni.Text);
                DateTime fechaFin = Convert.ToDateTime(this.TxtFechaFin.Text);

                if (fechaIni < now || fechaFin < now)
                {
                    throw new ArgumentException(
                        "Una de las fechas de solicitud es menor a la fecha actual, " +
                        "ingrese una fecha mayor a la actual"
                        );
                }

                if (fechaIni == fechaFin)
                {
                    throw new ArgumentException(
                        "Las fechas de las solicitudes no deben ser iguales"
                        );
                }
                if (fechaIni > fechaFin)
                {
                    throw new ArgumentException(
                        "La fecha de inicio no puede ser mayor a la de salida"
                        );
                }

                this.DtSolVac.InsertInto(
                    this.TxtFechaSol.Text, this.justTxt.Buffer.Text,
                    this.CmbxIDEmp.ActiveText, this.TxtFechaIni.Text,
                    this.TxtFechaFin.Text
                );
                this.mensaje("Guardado");
                this.ClearInput();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                    ex.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }
    }
}
