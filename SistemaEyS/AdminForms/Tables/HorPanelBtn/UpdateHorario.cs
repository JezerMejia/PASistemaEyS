using System;
using System.Data;
using Gtk;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.DatosEyS.Negocio;

namespace SistemaEyS.AdminForms.Tables.HorPanelBtn
{
    public partial class UpdateHorario : Gtk.Window
    {
        protected Neg_Horario NegHor = new Neg_Horario();
        protected Dt_tlb_horario DtHor = new Dt_tlb_horario();
        protected ListStore HorData;
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

        public UpdateHorario() :
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
            this.HorData = DtHor.GetData();
            this.SetEntryTextFromID(this.SelectedID);
        }

        protected void BtnSaveOnClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.TxtName.Text))
                    throw new ArgumentException("Ingrese un nombre para el Horario");

                Ent_Horario hor = new Ent_Horario()
                {
                    idHorario = this.SelectedID,
                    nombreHorario = this.TxtName.Text,
                    lunesInicio = this.NegHor.StringToDateTime(
                            this.lunesIni.ActiveText
                            ),
                    lunesSalida = this.NegHor.StringToDateTime(
                            this.lunesSal.ActiveText
                            ),
                    martesInicio = this.NegHor.StringToDateTime(
                            this.martesIni.ActiveText
                            ),
                    martesSalida = this.NegHor.StringToDateTime(
                            this.martesSal.ActiveText
                            ),
                    miercolesInicio = this.NegHor.StringToDateTime(
                            this.miercolesIni.ActiveText
                            ),
                    miercolesSalida = this.NegHor.StringToDateTime(
                            this.miercolesSal.ActiveText
                            ),
                    juevesInicio = this.NegHor.StringToDateTime(
                            this.juevesIni.ActiveText
                            ),
                    juevesSalida = this.NegHor.StringToDateTime(
                            this.juevesSal.ActiveText
                            ),
                    viernesInicio = this.NegHor.StringToDateTime(
                            this.viernesIni.ActiveText
                            ),
                    viernesSalida = this.NegHor.StringToDateTime(
                            this.viernesSal.ActiveText
                            ),
                    sabadoInicio = this.NegHor.StringToDateTime(
                            this.sabadoIni.ActiveText
                            ),
                    sabadoSalida = this.NegHor.StringToDateTime(
                            this.sabadoSal.ActiveText
                            ),
                    domingoInicio = this.NegHor.StringToDateTime(
                            this.domingoIni.ActiveText
                            ),
                    domingoSalida = this.NegHor.StringToDateTime(
                            this.domingoSal.ActiveText
                            ),
                };

                this.NegHor.EditEmpleado(hor);

                this.mensaje("Guardado");
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this,
		            DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        public void mensaje(String mensaje)
        {
            MessageDialog ms = new MessageDialog(this,
		        DialogFlags.Modal, MessageType.Info,
                ButtonsType.Ok, mensaje);
            ms.Run();
            ms.Destroy();
        }

        public void ClearInput()
        {
            this.TxtName.Text = "";
            // Lunes
            this.lunesIni.Active = -1;
            this.lunesIni.Entry.Text = "";
            this.lunesSal.Active = -1;
            this.lunesSal.Entry.Text = "";

            //Martes
            this.martesIni.Active = -1;
            this.martesIni.Entry.Text = "";
            this.martesSal.Active = -1;
            this.martesSal.Entry.Text = "";

            //Miercoles
            this.miercolesIni.Active = -1;
            this.miercolesIni.Entry.Text = "";
            this.miercolesSal.Active = -1;
            this.miercolesSal.Entry.Text = "";

            //Jueves
            this.juevesIni.Active = -1;
            this.juevesIni.Entry.Text = "";
            this.juevesSal.Active = -1;
            this.juevesSal.Entry.Text = "";

            //Viernes
            this.viernesIni.Active = -1;
            this.viernesIni.Entry.Text = "";
            this.viernesSal.Active = -1;
            this.viernesSal.Entry.Text = "";

            //Sabado
            this.sabadoIni.Active = -1;
            this.sabadoIni.Entry.Text = "";
            this.sabadoSal.Active = -1;
            this.sabadoSal.Entry.Text = "";

            //Domingo
            this.domingoIni.Active = -1;
            this.domingoIni.Entry.Text = "";
            this.domingoSal.Active = -1;
            this.domingoSal.Entry.Text = "";
        }

        protected void SetEntryTextFromID(int id)
        {
            try
            {
                Ent_Horario hor = this.NegHor.SearchHorario(id);

                this.TxtName.Text = hor.nombreHorario;

                this.lunesIni.Entry.Text = hor.lunesInicio?.ToString("HH:mm") ?? "";

                this.lunesSal.Entry.Text = hor.lunesSalida?.ToString("HH:mm") ?? "";

                this.martesIni.Entry.Text = hor.martesInicio?.ToString("HH:mm") ?? "";

                this.martesSal.Entry.Text = hor.martesSalida?.ToString("HH:mm") ?? "";

                this.miercolesIni.Entry.Text = hor.miercolesInicio?.ToString("HH:mm") ?? "";

                this.miercolesSal.Entry.Text = hor.miercolesSalida?.ToString("HH:mm") ?? "";

                this.juevesIni.Entry.Text = hor.juevesInicio?.ToString("HH:mm") ?? "";

                this.juevesSal.Entry.Text = hor.juevesSalida?.ToString("HH:mm") ?? "";

                this.viernesIni.Entry.Text = hor.viernesInicio?.ToString("HH:mm") ?? "";

                this.viernesSal.Entry.Text = hor.viernesSalida?.ToString("HH:mm") ?? "";

                this.sabadoIni.Entry.Text = hor.sabadoInicio?.ToString("HH:mm") ?? "";

                this.sabadoSal.Entry.Text = hor.sabadoSalida?.ToString("HH:mm") ?? "";

                this.domingoIni.Entry.Text = hor.domingoInicio?.ToString("HH:mm") ?? "";

                this.domingoSal.Entry.Text = hor.domingoSalida?.ToString("HH:mm") ?? "";
            }
            catch (Exception)
            {
                this.ClearInput();
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

        protected void BtnCancelOnClicked(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
