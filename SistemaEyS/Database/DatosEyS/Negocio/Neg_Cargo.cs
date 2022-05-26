using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;

namespace SistemaEyS.DatosEyS.Negocio
{
    public class Neg_Cargo
    {

        protected Dt_tbl_cargo DtCar = new Dt_tbl_cargo();

        public Neg_Cargo()
        {
        }

        public void ValidateID(Ent_Cargo car)
        {
            if (this.DtCar.DoesExist(
                "AND",
                new DataTableParameter("idEmpleado", $"{car.idCargo}")
            ))
            {
                throw new Exception("El cargo ya existe");
            }
        }
    }
}
