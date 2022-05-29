using System;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using Gtk;

namespace SistemaEyS.DatosSeguridad.Negocio
{
    public class Neg_user
    {
        protected Dt_tbl_user DtUser = new Dt_tbl_user();

        public Neg_user()
        {
        }

        public void ValidateUser(Ent_user user)
        {
            if (this.DtUser.DoesExist(
                "AND",
                new DataTableParameter("user", $"'{user.user}'")
            ))
            {
                throw new Exception("El usuario ya existe");
            }
        }
        public void ValidateEmail(Ent_user user)
        {
            if (this.DtUser.DoesExist(
                "AND",
                new DataTableParameter("email", $"'{user.email}'")
            ))
            {
                throw new Exception("El correo ya existe");
            }
        }

        public void AddUser(Ent_user user)
        {
            try
            {
                this.ValidateUser(user);
                this.ValidateEmail(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtUser.InsertInto(
                user.user, user.pwd,
                user.nombres, user.apellidos,
                user.email,
                ((int)user.estado).ToString()
            );
        }
        public void EditUser(Ent_user user)
        {
            try
            {
                Ent_user prevUser = this.SearchUser(user.id_user);

                if (prevUser.user != user.user)
                    this.ValidateUser(user);
                if (prevUser.email != user.email)
                    this.ValidateEmail(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtUser.UpdateSet(
                user.id_user.ToString(), user.user, user.pwd,
                user.nombres, user.apellidos, user.email,
                ((int)user.estado).ToString()
            );
        }
        public void RemoveUser(Ent_user user)
        {
            this.DtUser.DeleteFromUpdate(user.id_user.ToString());
        }
        public Ent_user SearchUser(int id_user)
        {
            ListStore store = this.DtUser.Search(
                new DataTableParameter("id_user", $"{id_user}")
            );
            if (store == null) throw new NullReferenceException("El usuario no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos del usuario");

            Ent_user user = new Ent_user()
            {
                id_user = Int32.Parse(store.GetValue(iter, 0).ToString()),
                user = store.GetValue(iter, 1).ToString(),
                pwd = store.GetValue(iter, 2).ToString(),
                nombres = store.GetValue(iter, 3).ToString(),
                apellidos = store.GetValue(iter, 4).ToString(),
                email = store.GetValue(iter, 5).ToString(),
                pwd_temp = store.GetValue(iter, 6).ToString(),
                estado = (EntidadEstado)Int32.Parse(store.GetValue(iter, 7).ToString()),
            };

            return user;
        }
    }
}
