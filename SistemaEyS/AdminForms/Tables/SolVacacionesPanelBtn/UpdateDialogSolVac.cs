using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.Calendar;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.DatosEyS.Negocio;

namespace SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn
{
    public partial class UpdateDialogSolVac : Gtk.Window
    {
        protected Neg_SolicitudVacaciones NegSolVac = new Neg_SolicitudVacaciones();

        protected Dt_tlb_SolVacaciones DtSolVac = new Dt_tlb_SolVacaciones();
        protected Dt_tlb_empleado dtEmp = new Dt_tlb_empleado();

        protected ListStore DataUser;
        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;

        protected EmpleadosView parent;
        protected calendar calendar = new calendar();

        protected int _SelectedID = -1;

        public int SelectedID
        {
            get
            {
                return this._SelectedID;
            }
            set
            {
                this._SelectedID = value;
            }
        }

        public UpdateDialogSolVac() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            this.UpdateData();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        public void UpdateData()
        {
            this.DataUser = dtEmp.GetDataView();
            this.idEmp.Model = this.DataUser;
            this.FillCmbxUsuarioModel();
            this.SetEntryTextFromID(this.SelectedID);
        }

        protected void FillCmbxUsuarioModel()
        {
            this.idEmp.Model = this.DataUser;
            this.idEmp.Active = -1;

            this.idEmp.Entry.Completion = new EntryCompletion();
            this.idEmp.Entry.Completion.Model = this.DataUser;
            this.idEmp.Entry.Completion.TextColumn = 0;
        }

        public void setFecha(DateTime fechaEntrada)
        {
            try
            {
                this.fechaTxt.Text = fechaEntrada.ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void setFechaIni(DateTime fechaEntrada)
        {
            try
            {
                this.fecIni.Text = fechaEntrada.ToString("yyyy/MM/dd hh:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void setFechaSal(DateTime fechaEntrada)
        {
            try
            {
                this.fecSal.Text = fechaEntrada.ToString("yyyy/MM/dd hh:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        protected void OnButton8Clicked(object sender, EventArgs e)
        {
            this.calendar.fecha = new calendar.selectFecha(this.setFecha);
            this.calendar.Show();
        }

        protected void OnButton9Clicked(object sender, EventArgs e)
        {
            this.calendar.fecha = new calendar.selectFecha(this.setFechaIni);
            this.calendar.Show();
        }

        protected void OnButton10Clicked(object sender, EventArgs e)
        {
            this.calendar.fecha = new calendar.selectFecha(this.setFechaSal);
            this.calendar.Show();
        }

        protected void OnSaveBtnClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fechaTxt.Text) ||
                   string.IsNullOrWhiteSpace(idEmp.ActiveText) ||
                   string.IsNullOrWhiteSpace(justTxt.Buffer.Text) ||
                   string.IsNullOrWhiteSpace(fecIni.Text) ||
                   string.IsNullOrWhiteSpace(fecSal.Text)
                   )
                {
                    throw new ArgumentException("No peude haber datos vacíos");
                }

                DateTime actFech = DateTime.Now.Date;
                DateTime inFech = Convert.ToDateTime(fechaTxt.Text);
                DateTime inicioFech = Convert.ToDateTime(fecIni.Text);
                DateTime finFech = Convert.ToDateTime(fecSal.Text);

                Ent_SolicitudVacaciones entSolVac = new Ent_SolicitudVacaciones()
                {
                    idSolVacaciones = this.SelectedID,
                    descripcionSol = this.justTxt.Buffer.Text,
                    fechaSol = DateTime.Parse(this.fechaTxt.Text),
                    fechaHoraInicio = DateTime.Parse(this.fecIni.Text),
                    fechaHoraFin = DateTime.Parse(this.fecSal.Text),
                    idEmpleado = Int32.Parse(this.idEmp.ActiveText),
                };
                this.NegSolVac.EditSolicitudVacaciones(entSolVac);

                MessageDialog ms = new MessageDialog(this,
		                DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
			            "La solicitud fue editada");
                ms.Run();
                ms.Destroy();
                this.ClearInput();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void OnExitBtnClicked(object sender, EventArgs e)
        {
            this.Hide();
            this.ClearInput();
        }

        public void ClearInput()
        {
            this.fechaTxt.Text = "";
            this.idEmp.Active = -1;
            this.idEmp.Entry.Text = "";
            this.justTxt.Buffer.Text = "";
            this.fecIni.Text = "";
            this.fecSal.Text = "";
        }

        protected void OnFecIniTextInserted(object o, TextInsertedArgs args)
        {
            if (string.IsNullOrWhiteSpace(this.fecIni.Text))
            {
                this.fecSal.Sensitive = false;
                this.fecSal.IsEditable = false;
            };
            this.fecSal.Sensitive = true;
            this.fecSal.IsEditable = true;
        }

        protected void SetEntryTextFromID(int id)
        {
            try
            {
                Ent_SolicitudVacaciones solVac = this.NegSolVac.SearchVacaciones(id);

                this.fechaTxt.Text = solVac.fechaSol.ToString("yyyy-MM-dd") ?? "";
                this.idEmp.Active = this.GetIndexFromValue(
                    this.idEmp, solVac.idEmpleado.ToString());
                this.fecIni.Text = solVac.fechaHoraInicio.ToString("yyyy-MM-dd") ?? "";
                this.fecSal.Text = solVac.fechaHoraFin.ToString("yyyy-MM-dd") ?? "";
                this.justTxt.Buffer.Text = solVac.descripcionSol;
            }
            catch (Exception)
            {
                this.fechaTxt.Text = "";
                this.idEmp.Active = -1;
                this.fecIni.Text = "";
                this.fecSal.Text = "";
                this.justTxt.Buffer.Text = "";
            }
        }


        protected int GetIndexFromValue(ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            int index = 0;
            TreeModel model = comboBox.Model;
            TreeIter iter;

            if (value == "") return 0;

            int i = 0;
            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (value == (string)model.GetValue(iter, 1))
                    {
                        index = i;
                        break;
                    }
                    i++;
                } while (model.IterNext(ref iter));
            }

            return index;
        }
    }
}
