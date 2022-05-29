using System;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using Gtk;

namespace SistemaEyS.DatosSeguridad.Negocio
{
    public class Neg_rol_opcion
    {
        protected Dt_tbl_rol_opcion DtRolOpcion = new Dt_tbl_rol_opcion();

        public Neg_rol_opcion()
        {
        }

        public void ValidateRelation(Ent_rol_opcion rolOpcion)
        {
            if (this.DtRolOpcion.DoesExist(
                "AND",
                new DataTableParameter("id_rol", $"'{rolOpcion.id_rol}'"),
                new DataTableParameter("id_opcion", $"'{rolOpcion.id_opcion}'")
            ))
            {
                throw new Exception($"La relación rol-opción ya existe");
            }
        }

        public void AddRolOpcion(Ent_rol_opcion rolOpcion)
        {
            try
            {
                this.ValidateRelation(rolOpcion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtRolOpcion.InsertInto(
                rolOpcion.id_rol.ToString(),
                rolOpcion.id_opcion.ToString()
            );
        }
        public void EditRolOpcion(Ent_rol_opcion rolOpcion)
        {
            try
            {
                Ent_rol_opcion prevRolOpcion =
                    this.SearchRolOpcion(rolOpcion.id_rolOpcion);

                if (prevRolOpcion.id_opcion != rolOpcion.id_opcion ||
                    prevRolOpcion.id_rol != rolOpcion.id_rol)
                    this.ValidateRelation(rolOpcion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtRolOpcion.UpdateSet(
                rolOpcion.id_rolOpcion.ToString(),
                rolOpcion.id_rol.ToString(),
                rolOpcion.id_opcion.ToString()
            );
        }
        public void RemoveRolOpcion(Ent_rol_opcion rolOpcion)
        {
            this.DtRolOpcion.DeleteFrom(rolOpcion.id_rolOpcion.ToString());
        }
        public Ent_rol_opcion SearchRolOpcion(int id_rolOpcion)
        {
            ListStore store = this.DtRolOpcion.Search(
                "AND",
                new DataTableParameter("id_rolOpcion", $"'{id_rolOpcion}'")
            );
            if (store == null)
                throw new NullReferenceException(
                    "La relación rol-opción no existe"
                );
            TreeIter iter;

            if (!store.GetIterFirst(out iter))
                throw new NullReferenceException("No hay datos de la relación");

            Ent_rol_opcion rolOpcion = new Ent_rol_opcion()
            {
                id_rolOpcion = Int32.Parse(store.GetValue(iter, 0).ToString()),
                id_rol = Int32.Parse(store.GetValue(iter, 1).ToString()),
                id_opcion = Int32.Parse(store.GetValue(iter, 2).ToString()),
            };

            return rolOpcion;
        }
    }
}
