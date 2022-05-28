using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Negocio;
using SistemaEyS.DatosEyS.Entidades;

namespace SistemaEyS.AdminForms.Tables.HorPanelBtn
{
    public partial class AddDialogHor : Gtk.Window
    {
        //Dt_tlb_horario DtHor = new Dt_tlb_horario();
        protected Neg_Horario NegHor = new Neg_Horario();
        public int SelectedID = -1;

        public AddDialogHor() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void OnButton15Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.TxtName.Text))
                    throw new ArgumentException("Ingrese un nombre para el Horario");

                Ent_Horario hor = new Ent_Horario()
                {
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

                this.NegHor.AddHorario(hor);

                mensaje("Guardado");
                this.ClearInput();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        protected void OnButton13Clicked(object sender, EventArgs e)
        {
            this.ClearInput();
            this.Hide();
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

        public void mensaje(String mensaje)
        {
            MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, mensaje);
            ms.Run();
            ms.Destroy();
        }
    }
}
