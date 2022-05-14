using System;
using System.Data;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.AdminForms.Tables.HorPanelBtn
{
    public partial class AddDialogHor : Gtk.Window
    {
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

            ConnectionEyS connection = ConnectionEyS.OpenConnection();

            compararMayor();
          
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
                ClearInput();
                return;
            }

            String Query = "INSERT INTO BDSistemaEyS.Horario (" +
                    "lunesInicio, lunesSalida, " +
                    "martesInicio, martesSalida, " +
                    "miercolesInicio, miercolesSalida," +
                    "juevesInicio, juevesSalida," +
                    "viernesInicio, viernesSalida," +
                    "sabadoInicio, sabadoSalida," +
                    "domingoInicio, domingoSalida) " +
                    "VALUES (" +
                    $"'{lunesIni.ActiveText}', '{lunesSal.ActiveText}'," +
                    $"'{martesIni.ActiveText}', '{martesSal.ActiveText}', " +
                    $"'{miercolesIni.ActiveText}','{miercolesSal.ActiveText}', " +
                    $"'{juevesIni.ActiveText}', '{juevesSal.ActiveText}', " +
                    $"'{viernesIni.ActiveText}', '{viernesSal.ActiveText}'," +
                    $"'{sabadoIni.ActiveText}', '{sabadoSal.ActiveText}', " +
                    $"'{domingoIni.ActiveText}', '{domingoSal.ActiveText}');";

            try
            {
                connection.Execute(CommandType.Text, Query);
                mensaje("Guardado");
                ClearInput();
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

        public void comprobarIgual()
        {

        }

        public void compararMayor()
        {

            DateTime dtLunesI = DateTime.ParseExact(lunesIni.ActiveText, "H:mm", null);
            DateTime dtLuness = DateTime.ParseExact(lunesSal.ActiveText, "H:mm", null);
            DateTime dtmartesI = DateTime.ParseExact(martesIni.ActiveText, "H:mm", null);
            DateTime dtmartess = DateTime.ParseExact(martesSal.ActiveText, "H:mm", null);
            int result = DateTime.Compare(dtLunesI, dtLuness);
            int resultm = DateTime.Compare(dtmartesI, dtmartess);

            if (result > 0 || resultm > 0)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Fechas distintas");
                ms.Run();
                ms.Destroy();
                return;
            }

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
