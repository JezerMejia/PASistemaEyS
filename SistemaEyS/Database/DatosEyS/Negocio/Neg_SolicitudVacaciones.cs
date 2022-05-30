using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;
namespace SistemaEyS.DatosEyS.Negocio
{


    public class Neg_SolicitudVacaciones
    {
        protected Dt_tlb_SolVacaciones DtSolVac = new Dt_tlb_SolVacaciones();

        public Neg_SolicitudVacaciones()
        {
        }

        public void ValidateDateTime(Ent_SolicitudVacaciones solvac)
        {
            if (solvac.fechaHoraInicio <= DateTime.Now)
            {
                throw new ArgumentException(
                    "La fecha de inicio es anterior a la fecha actual"
                    );
            }
            if (solvac.fechaHoraFin <= DateTime.Now)
            {
                throw new ArgumentException(
                    "La fecha de fin es anterior a la fecha actual"
                    );
            }
            if (solvac.fechaHoraFin <= solvac.fechaHoraInicio)
            {
                throw new ArgumentException(
                    "La fecha de fin no puede ser anterior o igual a la fecha de inicio"
                    );
            }
        }

        public void AddSolicitudVacaciones(Ent_SolicitudVacaciones solVac)
        {
            try
            {
                this.ValidateDateTime(solVac);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtSolVac.InsertInto(
                solVac.fechaSol.ToString("yyy-MM-dd"),
		        solVac.descripcionSol,
                solVac.idEmpleado.ToString(),
		        solVac.fechaHoraInicio.ToString("yyy-MM-dd HH:mm"),
                solVac.fechaHoraFin.ToString("yyy-MM-dd HH:mm"),
                ((int)solVac.estado).ToString()
                );
        }

        public void EditSolicitudVacaciones(Ent_SolicitudVacaciones solVac)
        {
            try
            {
                Ent_SolicitudVacaciones prevSolVac = this.SearchVacaciones(solVac.idSolVacaciones);

                if (prevSolVac.idSolVacaciones != solVac.idSolVacaciones)
                    throw new ArgumentException(
                        "No puedes modificar el ID de una solicitud"
                    );
                this.ValidateDateTime(solVac);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtSolVac.UpdateSet(
                solVac.idSolVacaciones.ToString(),
                solVac.fechaSol.ToString("yyyy-MM-dd"),
                solVac.descripcionSol,
                solVac.idEmpleado.ToString(),
                solVac.fechaHoraInicio.ToString("yyyy-MM-dd HH:mm"),
                solVac.fechaHoraFin.ToString("yyyy-MM-dd HH:mm"),
                ((int)solVac.estado).ToString()
            );
        }

        public void RemoveSolicitudVacaciones(Ent_SolicitudVacaciones solVac)
        {
            this.DtSolVac.DeleteFrom(solVac.idSolVacaciones.ToString());
        }

        public int? StringToInt(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return Int32.Parse(value);
            return null;
        }
        public Ent_SolicitudVacaciones SearchVacaciones(int idSolVacaciones)
        {
            ListStore store = this.DtSolVac.Search(
                "AND",
                new DataTableParameter("idSolVacaciones", $"'{idSolVacaciones}'")
            );
            if (store == null)
                throw new NullReferenceException("La solicitud no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter))
                throw new NullReferenceException("No hay datos de la solicitud");

            Ent_SolicitudVacaciones SolVac = new Ent_SolicitudVacaciones()
            {
                idSolVacaciones = Int32.Parse(store.GetValue(iter, 0).ToString()),
                fechaSol = DateTime.Parse(store.GetValue(iter, 1)?.ToString()),
                descripcionSol = store.GetValue(iter, 2)?.ToString(),
                fechaHoraInicio = DateTime.Parse(store.GetValue(iter, 3)?.ToString()),
                fechaHoraFin = DateTime.Parse(store.GetValue(iter, 4)?.ToString()),
                idEmpleado = Int32.Parse(store.GetValue(iter, 5)?.ToString()),
                estado = (EntidadEstado) this.StringToInt(
                        (string) store.GetValue(iter, 6)
			            )
            };

            return SolVac;
        }
    }
}
