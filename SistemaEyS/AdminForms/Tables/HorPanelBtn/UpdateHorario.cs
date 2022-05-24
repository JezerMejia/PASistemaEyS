using System;
using System.Data;
using Gtk;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosEyS;

namespace SistemaEyS.AdminForms.Tables.HorPanelBtn
{
    public partial class UpdateHorario : Gtk.Window
    {
        ConnectionEyS connection = ConnectionEyS.OpenConnection();
        Dt_tlb_horario dthor = new Dt_tlb_horario();
        protected ListStore HorData;

        public UpdateHorario() :
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
            //this.HorData = dthor.listarUsuariosHor();
            //this.FillCmbxIDModel();
        }

        /*
        protected void FillCmbxIDModel()
        {
            ListStore store = (ListStore)this.lunesIni.Model;
            store.Clear();
            TreeIter iter;
            if (HorData.GetIterFirst(out iter))
            {
               
                    this.lunesIni.InsertText(
                        Convert.ToInt32(HorData.GetValue(iter, 0)),
                        (String)HorData.GetValue(iter, 1)
                        
                    );
            
            }

            this.lunesIni.Active = -1;
            this.lunesIni.Entry.Text = HorData.GetValue(iter, 1).ToString();
            this.lunesIni.Entry.Completion = new EntryCompletion();
            this.lunesIni.Entry.Completion.Model = HorData;
            this.lunesIni.Entry.Completion.TextColumn = 0;

        }

        */
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
                //ClearInput();
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


            string modifiedQuery = "";

            //Lunes
            if (!string.IsNullOrWhiteSpace(this.lunesIni.ActiveText))
            {
                modifiedQuery += $"lunesInicio = '{lunesIni.ActiveText}', ";
            }
            if (!string.IsNullOrWhiteSpace(lunesSal.ActiveText))
            {
                modifiedQuery += $"lunesSalida = '{lunesSal.ActiveText}', ";
            }

            //Martes
            if (!string.IsNullOrWhiteSpace(martesIni.ActiveText))
            {
                modifiedQuery += $"martesInicio = '{martesIni.ActiveText}', ";
            }
            if (!string.IsNullOrWhiteSpace(martesSal.ActiveText))
            {
                modifiedQuery += $"martesSalida = '{martesSal.ActiveText}', ";
            }

            //Miercoles
            if (!string.IsNullOrWhiteSpace(miercolesIni.ActiveText))
            {
                modifiedQuery += $"miercolesInicio = '{miercolesIni.ActiveText}', ";
            }
            if (!string.IsNullOrWhiteSpace(miercolesSal.ActiveText))
            {
                modifiedQuery += $"miercolesSalida = '{miercolesSal.ActiveText}', ";
            }

            //Jueves
            if (!string.IsNullOrWhiteSpace(juevesIni.ActiveText))
            {
                modifiedQuery += $"juevesInicio = '{juevesIni.ActiveText}', ";
            }
            if (!string.IsNullOrWhiteSpace(juevesSal.ActiveText))
            {
                modifiedQuery += $"juevesSalida = '{juevesSal.ActiveText}', ";
            }

            //Viernes
            if (!string.IsNullOrWhiteSpace(viernesIni.ActiveText))
            {
                modifiedQuery += $"viernesInicio = '{viernesIni.ActiveText}', ";
            }

            if (!string.IsNullOrWhiteSpace(viernesSal.ActiveText))
            {
                modifiedQuery += $"viernesSalida = '{viernesSal.ActiveText}', ";
            }

            //Sabado
            if (!string.IsNullOrWhiteSpace(sabadoIni.ActiveText))
            {
                modifiedQuery += $"sabadoInicio = '{sabadoIni.ActiveText}', ";
            }
            if (!string.IsNullOrWhiteSpace(sabadoSal.ActiveText))
            {
                modifiedQuery += $"sabadoSalida = '{sabadoSal.ActiveText}', ";
            }

            //Domingo
            if (!string.IsNullOrWhiteSpace(domingoIni.ActiveText))
            {
                modifiedQuery += $"domingoInicio = '{domingoIni.ActiveText}', ";
            }
            if (!string.IsNullOrWhiteSpace(domingoSal.ActiveText))
            {
                modifiedQuery += $"domingoSalida = '{domingoSal.ActiveText}', ";
            }

                modifiedQuery = modifiedQuery.Trim();
            if (modifiedQuery.EndsWith(","))
                modifiedQuery = modifiedQuery.Remove(modifiedQuery.Length - 1);

            string Query = $"UPDATE BDSistemaEyS.Horario SET {modifiedQuery} " +
                $"WHERE idHorario = idHorario;";
            //Console.WriteLine(Query);
            try
            {
                connection.Execute(CommandType.Text, Query);
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Guardado");
                ms.Run();
                ms.Destroy();
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

    }
}
