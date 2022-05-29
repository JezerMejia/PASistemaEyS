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

        public void ValidateNombreCargo(Ent_Cargo car)
        {
            if (this.DtCar.DoesExist(
                "AND",
                new DataTableParameter("nombreCargo", $"'{car.nombreCargo}'")
            ))
            {
                throw new Exception("El nombre ya existe");
            }
        }

        public void AddCargo(Ent_Cargo cargo)
        {
            try
            {
                this.ValidateNombreCargo(cargo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtCar.InsertInto(
                cargo.nombreCargo,
                cargo.descripcionCargo
                );
        }
        public void EditCargo(Ent_Cargo cargo)
        {
            try
            {
                Ent_Cargo prevCargo = this.SearchCargo(cargo.idCargo);

                if (cargo.nombreCargo != prevCargo.nombreCargo)
                    this.ValidateNombreCargo(cargo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtCar.UpdateSet(
                cargo.idCargo.ToString(),
                cargo.nombreCargo,
                cargo.descripcionCargo
                );
        }
        public void RemoveCargo(Ent_Cargo cargo)
        {
            this.DtCar.DeleteFrom(cargo.idCargo.ToString());
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
        protected Ent_Cargo GetCargo(ListStore store)
        {
            if (store == null) throw new NullReferenceException("La asistencia no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos de la asistencia");

            Ent_Cargo cargo = new Ent_Cargo()
            {
                idCargo = Int32.Parse(store.GetValue(iter, 0).ToString()),
                nombreCargo = store.GetValue(iter, 1).ToString(),
                descripcionCargo = store.GetValue(iter, 2).ToString(),
            };

            return cargo;
        }
        public Ent_Cargo SearchCargo(int idCargo)
        {
            ListStore store = this.DtCar.Search(
                "AND",
                new DataTableParameter("idCargo", $"{idCargo}")
            );

            return this.GetCargo(store);
        }
    }
}
