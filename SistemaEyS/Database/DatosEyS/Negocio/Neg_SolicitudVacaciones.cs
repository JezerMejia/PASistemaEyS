using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;
namespace SistemaEyS.Database.DatosEyS.Negocio
{


    public class Neg_SolicitudVacaciones
    {
        protected Dt_tlb_SolVacaciones DtSolVac = new Dt_tlb_SolVacaciones();

        public Neg_SolicitudVacaciones()
        {
        }

        public void ValidateID(Ent_SolicitudVacaciones solvac)
        {
            if (this.DtSolVac.DoesExist(
                "AND",
                new DataTableParameter("idSolVacaciones", $"{solvac.idSolVacaciones}")
            ))
            {
                throw new Exception("EL id de solicitud ya existe");
            }
        }

        public void ValidateIDEmpleado(Ent_SolicitudVacaciones solvac)
        {
            if (this.DtSolVac.DoesExist(
                "AND",
                new DataTableParameter("idEmpleado", $"{solvac.idEmpleado}")
            ))
            {
                throw new Exception("El id ya existe");
            }
        }

        public void AddSolicitudVacaciones(Ent_SolicitudVacaciones solvac)
        {
            try
            {
                this.ValidateID(solvac);
                this.ValidateIDEmpleado(solvac);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtSolVac.InsertInto(
                solvac.fechaSol.ToString(), solvac.descripcionSol,
                solvac.idEmpleado.ToString(), solvac.fechaHoraInicio.ToString(),
                solvac.fechaHoraFin.ToString()
                );
        }

        public void EditEmpleado(Ent_SolicitudVacaciones solVac)
        {
            try
            {
                Ent_SolicitudVacaciones prevSolVac = this.SearchVacaciones(solVac.idSolVacaciones);

                if (prevSolVac.idSolVacaciones != solVac.idSolVacaciones)
                    throw new ArgumentException(
                        "No puedes modificar el ID de una solicitud"
                    );
                if (prevSolVac.idEmpleado != solVac.idEmpleado)
                    this.ValidateIDEmpleado(solVac);
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
                solVac.fechaHoraInicio.ToString("yyyy-MM-dd"),
                solVac.fechaHoraFin.ToString("yyyy-MM-dd")
            );
        }

        public void RemoveUser(Ent_SolicitudVacaciones solVac)
        {
            this.DtSolVac.DeleteFrom(solVac.idSolVacaciones.ToString());
        }


        public Ent_SolicitudVacaciones SearchVacaciones(int idSolVacaciones)
        {

            ListStore store = this.DtSolVac.Search(
                new DataTableParameter("idSolVacaciones", $"{idSolVacaciones}")
            );
            if (store == null)
                throw new NullReferenceException(
                    "La relación la solicitud no existe"
                );
            TreeIter iter;

            if (!store.GetIterFirst(out iter))
                throw new NullReferenceException("No hay datos de la solicitud");

            Ent_SolicitudVacaciones SolVac = new Ent_SolicitudVacaciones()
            {
                idSolVacaciones = Int32.Parse(store.GetValue(iter, 0).ToString()),
                fechaSol = DateTime.Parse(store.GetValue(iter, 1)?.ToString()),
                descripcionSol = store.GetValue(iter, 2).ToString(),
                fechaHoraInicio = DateTime.Parse(store.GetValue(iter, 3)?.ToString()),
                fechaHoraFin = DateTime.Parse(store.GetValue(iter, 4)?.ToString()),
                idEmpleado = Int32.Parse(store.GetValue(iter, 5)?.ToString()),
            };

            return SolVac;
        }
    }
}
