using System;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using Gtk;

namespace SistemaEyS.DatosSeguridad.Negocio
{
    public class Neg_rol
    {
        protected Dt_tbl_rol DtRol = new Dt_tbl_rol();

        public Neg_rol()
        {
        }

        public void ValidateRol(Ent_rol rol)
        {
            if (this.DtRol.DoesExist(
                "AND",
                new DataTableParameter("rol", $"{rol.rol}")
            ))
            {
                throw new Exception("El rol ya existe");
            }
	    }

        public void AddRol(Ent_rol rol)
        {
            try
            {
                this.ValidateRol(rol);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtRol.InsertInto(
                rol.rol, ((int)rol.estado).ToString()
            );
        }
        public void EditRol(Ent_rol rol)
        {
            try
            {
                Ent_rol prevRol = this.SearchRol(rol.id_rol);

                if (prevRol.rol != rol.rol)
                    this.ValidateRol(rol);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtRol.UpdateSet(
                rol.id_rol.ToString(), rol.rol,
                ((int)rol.estado).ToString()
            );
        }
        public void RemoveRol(Ent_rol rol)
        {
            this.DtRol.DeleteFromUpdate(rol.id_rol.ToString());
        }
        public Ent_rol SearchRol(int id_rol)
        {
            ListStore store = this.DtRol.Search(
                new DataTableParameter("id_rol", $"{id_rol}")
            );
            if (store == null) throw new NullReferenceException("El rol no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos del rol");

            Ent_rol user = new Ent_rol()
            {
                id_rol = Int32.Parse(store.GetValue(iter, 0).ToString()),
                rol = store.GetValue(iter, 1).ToString(),
                estado = (EntidadEstado)Int32.Parse(store.GetValue(iter, 7).ToString()),
            };

            return user;
        }
    }
}
