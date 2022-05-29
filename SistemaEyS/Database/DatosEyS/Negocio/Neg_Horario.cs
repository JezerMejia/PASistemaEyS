using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;

namespace SistemaEyS.DatosEyS.Negocio
{
    public class Neg_Horario
    {
        protected Dt_tlb_horario DtHor = new Dt_tlb_horario();

        public Neg_Horario()
        {
        }

        public void ValidateIndividualTime(DateTime? inicio, DateTime? fin)
        {
            if (inicio == null && fin == null) return;
            if ((inicio != null && fin == null) ||
                (inicio == null && fin != null))
                throw new ArgumentException(
                    "Ambas horas deben de existir"
                    );
            int result = DateTime.Compare((DateTime)inicio, (DateTime)fin);
            if (result > 0)
                throw new ArgumentException(
                    "La hora de fin no puede ser anterior a la hora de inicio"
                    );
            else if (result == 0)
                throw new ArgumentException(
                    "Ambas horas no pueden ser iguales"
                    );
        }
        public void ValidateAllTime(Ent_Horario hor)
        {
            this.ValidateIndividualTime(hor.lunesInicio, hor.lunesSalida);
            this.ValidateIndividualTime(hor.martesInicio, hor.martesSalida);
            this.ValidateIndividualTime(hor.miercolesInicio, hor.miercolesSalida);
            this.ValidateIndividualTime(hor.juevesInicio, hor.juevesSalida);
            this.ValidateIndividualTime(hor.viernesInicio, hor.viernesSalida);
            this.ValidateIndividualTime(hor.sabadoInicio, hor.sabadoSalida);
            this.ValidateIndividualTime(hor.domingoInicio, hor.domingoSalida);
        }

        public void AddHorario(Ent_Horario hor)
        {
            try
            {
                this.ValidateAllTime(hor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtHor.InsertInto(
                hor.nombreHorario,
                hor.lunesInicio?.ToString("HH:mm:ss"), hor.lunesSalida?.ToString("HH:mm:ss"),
                hor.martesInicio?.ToString("HH:mm:ss"), hor.martesSalida?.ToString("HH:mm:ss"),
                hor.miercolesInicio?.ToString("HH:mm:ss"), hor.miercolesSalida?.ToString("HH:mm:ss"),
                hor.juevesInicio?.ToString("HH:mm:ss"), hor.juevesSalida?.ToString("HH:mm:ss"),
                hor.viernesInicio?.ToString("HH:mm:ss"), hor.viernesSalida?.ToString("HH:mm:ss"),
                hor.sabadoInicio?.ToString("HH:mm:ss"), hor.sabadoSalida?.ToString("HH:mm:ss"),
                hor.domingoInicio?.ToString("HH:mm:ss"), hor.domingoSalida?.ToString("HH:mm:ss")
                );
        }
        public void EditEmpleado(Ent_Horario hor)
        {
            try
            {
                Ent_Horario prevHor =
                    this.SearchHorario(hor.idHorario);

                if (prevHor.idHorario != hor.idHorario)
                    throw new ArgumentException(
                        "No puedes modificar el ID de un horario"
                    );
                this.ValidateAllTime(hor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtHor.UpdateSet(
                hor.idHorario.ToString(), hor.nombreHorario,
                hor.lunesInicio?.ToString("HH:mm:ss"), hor.lunesSalida?.ToString("HH:mm:ss"),
                hor.martesInicio?.ToString("HH:mm:ss"), hor.martesSalida?.ToString("HH:mm:ss"),
                hor.miercolesInicio?.ToString("HH:mm:ss"), hor.miercolesSalida?.ToString("HH:mm:ss"),
                hor.juevesInicio?.ToString("HH:mm:ss"), hor.juevesSalida?.ToString("HH:mm:ss"),
                hor.viernesInicio?.ToString("HH:mm:ss"), hor.viernesSalida?.ToString("HH:mm:ss"),
                hor.sabadoInicio?.ToString("HH:mm:ss"), hor.sabadoSalida?.ToString("HH:mm:ss"),
                hor.domingoInicio?.ToString("HH:mm:ss"), hor.domingoSalida?.ToString("HH:mm:ss")
                );
        }
        public void RemoveHorario(Ent_Horario hor)
        {
            //this.DtEmp.DeleteFromUpdate(emp.idEmpleado.ToString());
            this.DtHor.DeleteFrom(hor.idHorario.ToString());
        }
        public DateTime? StringToDateTime(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return DateTime.Parse(value);
            return null;
        }
        public Ent_Horario SearchHorario(int idHorario)
        {
            ListStore store = this.DtHor.Search(
                "AND",
                new DataTableParameter("idHorario", $"'{idHorario}'")
            );
            if (store == null) throw new NullReferenceException("El horario no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos del horario");

            Ent_Horario hor = new Ent_Horario()
            {
                idHorario = Int32.Parse(store.GetValue(iter, 0).ToString()),
                nombreHorario = store.GetValue(iter, 1).ToString(),
                lunesInicio = this.StringToDateTime(
                                    store.GetValue(iter, 2).ToString()),
                lunesSalida = this.StringToDateTime(
                                    store.GetValue(iter, 3).ToString()),
                martesInicio = this.StringToDateTime(
                                    store.GetValue(iter, 4).ToString()),
                martesSalida = this.StringToDateTime(
                                    store.GetValue(iter, 5).ToString()),
                miercolesInicio = this.StringToDateTime(
                                    store.GetValue(iter, 6).ToString()),
                miercolesSalida = this.StringToDateTime(
                                    store.GetValue(iter, 7).ToString()),
                juevesInicio = this.StringToDateTime(
                                    store.GetValue(iter, 8).ToString()),
                juevesSalida = this.StringToDateTime(
                                    store.GetValue(iter, 9).ToString()),
                viernesInicio = this.StringToDateTime(
                                    store.GetValue(iter, 10).ToString()),
                viernesSalida = this.StringToDateTime(
                                    store.GetValue(iter, 11).ToString()),
                sabadoInicio = this.StringToDateTime(
                                    store.GetValue(iter, 12).ToString()),
                sabadoSalida = this.StringToDateTime(
                                    store.GetValue(iter, 13).ToString()),
                domingoInicio = this.StringToDateTime(
                                    store.GetValue(iter, 14).ToString()),
                domingoSalida = this.StringToDateTime(
                                    store.GetValue(iter, 15).ToString()),
            };

            return hor;
        }
    }
}
