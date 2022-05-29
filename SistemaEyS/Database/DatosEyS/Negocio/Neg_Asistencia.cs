using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;

namespace SistemaEyS.DatosEyS.Negocio
{
    public class Neg_Asistencia
    {

        protected Dt_tlb_asistencia DtAss = new Dt_tlb_asistencia();

        public Neg_Asistencia()
        {
        }

        public void ValidateHorario(Ent_Asistencia asis)
        {
            if (asis.horaEntrada == null || asis.horaSalida == null)
                return;
            if (DateTime.Compare((DateTime)asis.horaEntrada, (DateTime)asis.horaSalida) > 0)
                throw new Exception(
                    "La hora de entrada no puede ser mayor a la hora de salida"
                    );
            if (DateTime.Compare((DateTime)asis.horaEntrada, (DateTime)asis.horaSalida) == 0)
                throw new Exception(
                    "La hora de entrada no puede ser igual a la de salida"
                    );
        }

        public void AddAsistencia(Ent_Asistencia asis)
        {
            try
            {
                this.ValidateHorario(asis);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtAss.InsertInto(
                asis.idEmpleado.ToString(),
                asis.fechaAsistencia.ToString("yyyy-MM-dd"),
                asis.horaEntrada?.ToString("HH:mm:ss"),
                asis.horaSalida?.ToString("HH:mm:ss")
		        );
        }
        public void EditAsistencia(Ent_Asistencia asis)
        {
            try
            {
                this.ValidateHorario(asis);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            Ent_Asistencia prevAsis = this.SearchAsistencia(asis.fechaAsistencia, asis.idEmpleado);

            DateTime? horaEntrada = asis.horaEntrada ?? prevAsis.horaEntrada;
            DateTime? horaSalida = asis.horaSalida ?? prevAsis.horaSalida;

            this.DtAss.UpdateSet(
                asis.idEmpleado.ToString(),
                asis.fechaAsistencia.ToString("yyyy-MM-dd"),
                horaEntrada?.ToString("HH:mm:ss"),
                horaSalida?.ToString("HH:mm:ss")
		        );
        }

        public void MarkAssistance(Ent_Asistencia asis)
        {
            if (this.DtAss.DoesExist(
                "AND",
                new DataTableParameter(
		            "fechaAsistencia",
		            $"'{asis.fechaAsistencia.ToString("yyyy-MM-dd")}'"
		            ),
                new DataTableParameter(
		            "idEmpleado",
		            $"'{asis.idEmpleado}'"
		            )
            ))
            {
                this.EditAsistencia(asis);
                return;
            }
            this.AddAsistencia(asis);
        }

        public DateTime? StringToDateTime(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return DateTime.Parse(value);
            return null;
        }
        public int? StringToInt(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return Int32.Parse(value);
            return null;
        }
        protected Ent_Asistencia GetAsistencia(ListStore store)
        {
            if (store == null) throw new NullReferenceException("La asistencia no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos de la asistencia");

            Ent_Asistencia asis = new Ent_Asistencia()
            {
                idAsistencia = Int32.Parse(store.GetValue(iter, 0).ToString()),
                fechaAsistencia = (DateTime)this.StringToDateTime(
                    (string)store.GetValue(iter, 1)
                    ),
                horaEntrada = this.StringToDateTime(
                    (string)store.GetValue(iter, 2)
                    ),
                horaSalida = this.StringToDateTime(
                    (string)store.GetValue(iter, 3)
                    ),
                idEmpleado = (int)this.StringToInt(
                    (string)store.GetValue(iter, 4)
                    )
            };

            return asis;
        }
        public Ent_Asistencia SearchAsistencia(int idAsistencia)
        {
            ListStore store = this.DtAss.Search(
                "AND",
                new DataTableParameter("idAsistencia", $"{idAsistencia}")
            );

            return this.GetAsistencia(store);
        }
        public Ent_Asistencia SearchAsistencia(DateTime fechaAsistencia, int idEmpleado)
        {
            ListStore store = this.DtAss.Search(
                "AND",
                new DataTableParameter(
                    "fechaAsistencia", $"'{fechaAsistencia.ToString("yyyy-MM-dd")}'"
                    ),
                new DataTableParameter(
                    "idEmpleado", $"'{idEmpleado}'"
                    )
            );

            return this.GetAsistencia(store);
        }
    }
}
