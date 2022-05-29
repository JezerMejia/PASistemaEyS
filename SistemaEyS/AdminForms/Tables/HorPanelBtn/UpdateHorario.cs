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
        protected Neg_Horario entHor = new Neg_Horario();
        //ConnectionEyS connection = ConnectionEyS.OpenConnection();
        protected Dt_tlb_horario dthor = new Dt_tlb_horario();
        protected ListStore HorData;
        string id;
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
                id = this._SelectedID.ToString();
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
            this.HorData = dthor.GetData();
            this.SetEntryTextFromID(this.SelectedID);
        }

        protected void OnButton15Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lunesIni.ActiveText) ||
                string.IsNullOrWhiteSpace(lunesSal.ActiveText) ||
                string.IsNullOrWhiteSpace(martesIni.ActiveText) ||
                string.IsNullOrWhiteSpace(martesSal.ActiveText) ||
                string.IsNullOrWhiteSpace(miercolesIni.ActiveText) ||
                string.IsNullOrWhiteSpace(miercolesSal.ActiveText) ||
                string.IsNullOrWhiteSpace(juevesIni.ActiveText) ||
                string.IsNullOrWhiteSpace(juevesSal.ActiveText) ||
                string.IsNullOrWhiteSpace(viernesIni.ActiveText) ||
                string.IsNullOrWhiteSpace(viernesSal.ActiveText) ||
                string.IsNullOrWhiteSpace(sabadoIni.ActiveText) ||
                string.IsNullOrWhiteSpace(sabadoSal.ActiveText) ||
                string.IsNullOrWhiteSpace(domingoIni.ActiveText) ||
                string.IsNullOrWhiteSpace(domingoSal.ActiveText)
                )
            {
                mensaje("No pueden haber datos vacios");
                return;
            }

            if (lunesIni.ActiveText.Equals(lunesSal.ActiveText) ||
                martesIni.ActiveText.Equals(martesSal.ActiveText) ||
                miercolesIni.ActiveText.Equals(miercolesSal.ActiveText) ||
                juevesIni.ActiveText.Equals(juevesSal.ActiveText) ||
                viernesIni.ActiveText.Equals(viernesSal.ActiveText) ||
                sabadoIni.ActiveText.Equals(sabadoSal.ActiveText) ||
                domingoIni.ActiveText.Equals(domingoSal.ActiveText))
            {

                mensaje("Entrada y salida no pueden ser iguales");
                return;
            }

            try
            {
                //dthor.UpdateSet(this.id, this.lunesIni.ActiveText, this.lunesSal.ActiveText,
                //            this.martesIni.ActiveText, this.martesSal.ActiveText,
                //            this.miercolesIni.ActiveText, this.miercolesSal.ActiveText,
                //            this.juevesIni.ActiveText, this.juevesSal.ActiveText,
                //            this.viernesIni.ActiveText, this.viernesSal.ActiveText,
                //            this.sabadoIni.ActiveText, this.sabadoSal.ActiveText,
                //            this.domingoIni.ActiveText, this.domingoSal.ActiveText);

                mensaje("Guardado");
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
                ClearInput();
            }

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
                Ent_Horario hor = this.entHor.SearchHorario(id);
                
                this.lunesIni.Active = this.GetIndexFromValue(
                    this.lunesIni, hor.lunesInicio.ToString());
                
                this.lunesSal.Active = this.GetIndexFromValue(
                    this.lunesSal, hor.lunesSalida.ToString());

                this.martesIni.Active = this.GetIndexFromValue(
                    this.martesIni, hor.martesInicio.ToString());

                /*
                this.martesSal.Active = this.GetIndexFromValue(
                    this.martesSal, hor.martesSalida.ToString());

                this.miercolesIni.Active = this.GetIndexFromValue(
                    this.miercolesIni, hor.miercolesInicio.ToString());

                this.miercolesSal.Active = this.GetIndexFromValue(
                    this.miercolesSal, hor.miercolesSalida.ToString());

                this.juevesIni.Active = this.GetIndexFromValue(
                    this.juevesIni, hor.juevesInicio.ToString());

                this.juevesSal.Active = this.GetIndexFromValue(
                    this.juevesSal, hor.juevesSalida.ToString());

                this.viernesIni.Active = this.GetIndexFromValue(
                    this.viernesIni, hor.viernesInicio.ToString());

                this.viernesSal.Active = this.GetIndexFromValue(
                    this.viernesSal, hor.viernesSalida.ToString());

                this.sabadoIni.Active = this.GetIndexFromValue(
                    this.sabadoIni, hor.sabadoInicio.ToString());

                this.sabadoSal.Active = this.GetIndexFromValue(
                    this.sabadoSal, hor.sabadoSalida.ToString());

                this.domingoIni.Active = this.GetIndexFromValue(
                    this.domingoIni, hor.domingoInicio.ToString());

                this.domingoSal.Active = this.GetIndexFromValue(
                    this.domingoSal, hor.domingoSalida.ToString());*/
            }

            catch (Exception)
            {
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
