using System;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using Gtk;

namespace SistemaEyS.DatosSeguridad.Negocio
{
    public class Neg_opcion
    {
        protected Dt_tbl_opcion DtOpcion = new Dt_tbl_opcion();

        public Neg_opcion()
        {
        }

        public void ValidateOpcion(Ent_opcion opcion)
        {
            if (this.DtOpcion.DoesExist(
                "AND",
                new DataTableParameter("opcion", $"'{opcion.opcion}'")
            ))
            {
                throw new Exception("El rol ya existe");
            }
	    }

        public void AddOpcion(Ent_opcion opcion)
        {
            try
            {
                this.ValidateOpcion(opcion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtOpcion.InsertInto(
                opcion.opcion, ((int)opcion.estado).ToString()
            );
        }
        public void EditOpcion(Ent_opcion opcion)
        {
            try
            {
                Ent_opcion prevOpcion = this.SearchOpcion(opcion.id_opcion);

                if (prevOpcion.opcion != opcion.opcion)
                    this.ValidateOpcion(opcion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtOpcion.UpdateSet(
                opcion.id_opcion.ToString(), opcion.opcion,
                ((int)opcion.estado).ToString()
            );
        }
        public void RemoveOpcion(Ent_opcion opcion)
        {
            this.DtOpcion.DeleteFromUpdate(opcion.id_opcion.ToString());
        }
        public Ent_opcion SearchOpcion(int id_opcion)
        {
            ListStore store = this.DtOpcion.Search(
                new DataTableParameter("id_opcion", $"{id_opcion}")
            );
            if (store == null) throw new NullReferenceException("El rol no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos de la opción");

            Ent_opcion opcion = new Ent_opcion()
            {
                id_opcion = Int32.Parse(store.GetValue(iter, 0).ToString()),
                opcion = store.GetValue(iter, 1).ToString(),
                estado = (EntidadEstado)Int32.Parse(store.GetValue(iter, 7).ToString()),
            };

            return opcion;
        }
    }
}
