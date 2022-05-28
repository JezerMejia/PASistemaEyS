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
            try {
             
                if (asis.horaEntrada > asis.horaSalida)
                {
                    throw new Exception("La hora de entrada no puede ser mayor a la de salida");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void ValidarIgual(Ent_Asistencia asis)
        {

            try
            {

                if (asis.horaEntrada == asis.horaSalida)
                {
                    throw new Exception("La hora de entrada no puede ser igual a la de salida");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

        }



    }
}
