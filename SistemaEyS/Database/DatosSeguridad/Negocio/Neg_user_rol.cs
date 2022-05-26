using System;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using Gtk;

namespace SistemaEyS.DatosSeguridad.Negocio
{
    public class Neg_user_rol
    {
        protected Dt_tbl_user_rol DtUserRol = new Dt_tbl_user_rol();

        public Neg_user_rol()
        {
        }

        public void ValidateRelation(Ent_user_rol userRol)
        {
            if (this.DtUserRol.DoesExist(
                "AND",
                new DataTableParameter("id_user", $"'{userRol.id_user}'"),
                new DataTableParameter("id_rol", $"'{userRol.id_rol}'")
            ))
            {
                throw new Exception($"La relación user-rol ya existe");
            }
	    }

        public void AddUserRol(Ent_user_rol userRol)
        {
            try
            {
                this.ValidateRelation(userRol);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtUserRol.InsertInto(
		        userRol.id_user.ToString(),
                userRol.id_rol.ToString()
            );
        }
        public void EditUserRol(Ent_user_rol userRol)
        {
            try
            {
                Ent_user_rol prevUserRol =
		            this.SearchUserRol(userRol.id_UserRol);

                if (prevUserRol.id_user != userRol.id_user ||
		            prevUserRol.id_rol != userRol.id_rol)
                    this.ValidateRelation(userRol);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtUserRol.UpdateSet(
                userRol.id_UserRol.ToString(),
                userRol.id_user.ToString(),
		        userRol.id_rol.ToString()
            );
        }
        public void RemoveUserRol(Ent_user_rol userRol)
        {
            this.DtUserRol.DeleteFrom(userRol.id_UserRol.ToString());
        }
        public Ent_user_rol SearchUserRol(int id_UserRol)
        {
            ListStore store = this.DtUserRol.Search(
                new DataTableParameter("id_UserRol", $"{id_UserRol}")
            );
            if (store == null)
		        throw new NullReferenceException(
		            "La relación user-rol no existe"
		        );
            TreeIter iter;

            if (!store.GetIterFirst(out iter))
		        throw new NullReferenceException("No hay datos de la relación");

            Ent_user_rol userRol = new Ent_user_rol()
            {
                id_UserRol = Int32.Parse(store.GetValue(iter, 0).ToString()),
                id_user = Int32.Parse(store.GetValue(iter, 1).ToString()),
                id_rol = Int32.Parse(store.GetValue(iter, 2).ToString()),
            };

            return userRol;
        }
    }
}
