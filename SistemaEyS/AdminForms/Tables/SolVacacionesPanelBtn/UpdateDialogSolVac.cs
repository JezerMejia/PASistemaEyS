using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.Calendar;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.Database.DatosEyS.Negocio;

namespace SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn
{
    public partial class UpdateDialogSolVac : Gtk.Window
    {
        protected EmpleadosView parent;
        protected Dt_tlb_SolVacaciones DtSolVac = new Dt_tlb_SolVacaciones();
        protected Dt_tlb_empleado dtEmp = new Dt_tlb_empleado();
        protected ListStore DataUser;
        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        protected calendar ca = new calendar();
        protected Neg_SolicitudVacaciones NegSolVac = new Neg_SolicitudVacaciones();

        //Variables
        protected int _SelectedID = -1;
        protected string idSol;
        protected DateTime dt;
        protected DateTime dtIni;
        protected DateTime dtSal;
        protected DateTime actFech;
        protected DateTime inFech;
        protected DateTime inicioFech;
        protected DateTime finFech;

        public int SelectedID
        {
            get
            {
                return this._SelectedID;
            }
            set
            {
                this._SelectedID = value;
                idSol = this._SelectedID.ToString();
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
                dt = fechaEntrada;
                this.fechaTxt.Text = fechaEntrada.ToString("yyyy/MM/dd");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                Console.WriteLine("Error" + ex.StackTrace);
                throw;
            }
        }

        public void setFechaIni(DateTime fechaEntrada)
        {
            try
            {
                dtIni = fechaEntrada;
                this.fecIni.Text = fechaEntrada.ToString("yyyy/MM/dd hh:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                Console.WriteLine("Error" + ex.StackTrace);
                throw;
            }
        }

        public void setFechaSal(DateTime fechaEntrada)
        {
            try
            {
                dtSal = fechaEntrada;
                this.fecSal.Text = fechaEntrada.ToString("yyyy/MM/dd hh:mm:ss");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                Console.WriteLine("Error" + ex.StackTrace);
                throw;
            }
        }

    
        protected void OnButton8Clicked(object sender, EventArgs e)
        {
            ca.fecha = new calendar.selectFecha(this.setFecha);
            ca.Show();
        }

        protected void OnButton9Clicked(object sender, EventArgs e)
        {
            ca.fecha = new calendar.selectFecha(this.setFechaIni);
            ca.Show();
        }

        protected void OnButton10Clicked(object sender, EventArgs e)
        {
            ca.fecha = new calendar.selectFecha(this.setFechaSal);
            ca.Show();
        }

        protected void OnSaveBtnClicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(fechaTxt.Text) ||
               string.IsNullOrWhiteSpace(idEmp.ActiveText) ||
               string.IsNullOrWhiteSpace(justTxt.Buffer.Text) ||
               string.IsNullOrWhiteSpace(fecIni.Text) ||
               string.IsNullOrWhiteSpace(fecSal.Text)

               )
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "No puede haber datos vacíos");
                ms.Run();
                ms.Destroy();
                //ClearInput();
                return;
            }

            actFech = DateTime.Now.Date;
            inFech = Convert.ToDateTime(fechaTxt.Text);
            inicioFech = Convert.ToDateTime(fecIni.Text);
            finFech = Convert.ToDateTime(fecSal.Text);


            if (inFech < actFech)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "La solicitud no puede hacerse desde el pasado, ingrese la fecha actual o mayor a esa");
                ms.Run();
                ms.Destroy();
                return;
            }

            if (inicioFech < actFech || finFech < actFech)
            {
                mensaje("Una de las fecha de solicitud es menor a la fecha actual, ingrese una fecha mayor la actual");
                return;
            }

            if (inicioFech == finFech)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Las fechas de las solicitudes no deben ser iguales");
                ms.Run();
                ms.Destroy();
                return;
            }

            if (inicioFech > finFech)
            {
                mensaje("La fecha de inicio no puede ser menor a la de salida");
            }



            try
            {
                DtSolVac.UpdateSet(this.idSol, this.fechaTxt.Text, this.justTxt.Buffer.Text, this.idEmp.ActiveText, this.fecIni.Text, this.fecSal.Text);
                mensaje("Guardado");
                //ClearInput();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }

            UpdateData();
            ClearInput();

        }

        protected void OnExitBtnClicked(object sender, EventArgs e)
        {
            this.Hide();
            ClearInput();
        }

        public void mensaje(String mensaje)
        {
            MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, mensaje);
            ms.Run();
            ms.Destroy();

        }

        public void ClearInput()
        {

            fechaTxt.Text = "";
            idEmp.Active = -1;
            idEmp.Entry.Text = "";
            justTxt.Buffer.Text = "";
            fecIni.Text = "";
            fecSal.Text = "";

        }

        protected void OnFecIniTextInserted(object o, TextInsertedArgs args)
        {
            fecSal.Sensitive = true;
            fecSal.IsEditable = true;
        }

        protected void OnFecIniTextDeleted(object o, TextDeletedArgs args)
        {
            fecSal.Sensitive = false;
            fecSal.IsEditable = false;
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
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
        }


        protected int GetIndexFromValue(ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            int index = 0;
            TreeModel model = comboBox.Model;
            TreeIter iter;

            if (value == "")
            {
                return 0;
            }

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
