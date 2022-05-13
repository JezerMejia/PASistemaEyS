using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosSeguridad
{
    public class Dt_tlb_user
    {

        public ListStore Model;
        public ConnectionSeg conn = ConnectionSeg.OpenConnection();

        public void UpdateModel()
        {
            ListStore datos = new ListStore(
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string)
                );

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM Seguridad.tbl_user;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    datos.AppendValues(
                        idr[0].ToString(), // ID Usuario
                        idr[1].ToString(), // Usario
                        idr[2].ToString(), // Contraseña
                        idr[3].ToString(), // Nombres
                        idr[4].ToString(), // Apellidos
                        idr[5].ToString(), // Email
                        idr[6].ToString(), // Contraseña temp
                        idr[7].ToString()  // Estado
                        );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.SetPosition(WindowPosition.Mouse);
                ms.Run();
                ms.Destroy();
            }
            finally
            {
                if (idr != null && !idr.IsClosed)
                {
                    idr.Close();
                }
            }
            this.Model = datos;
        }

        public void InsertInto(string user, string pwd, string nombres,
            string apellidos, string email)
        {
            if (string.IsNullOrWhiteSpace(user))
            {
                throw new Exception("No se proporcionó un usuario");
            }

            string Query = "INSERT INTO Seguridad.tbl_user (" +
                    "user, pwd, estado, " +
                    "nombres, apellidos, email) " +
                    "VALUES (" +
                    $"'{user}', '{pwd ?? ""}', 1," +
                    $"'{nombres ?? ""}', '{apellidos ?? ""}'," +
                    $"'{email ?? ""}');";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateSet(string id_user, string user, string pwd,
            string nombres, string apellidos, string email)
        {
            string ModifiedQuery = "estado = 2, ";

            if (string.IsNullOrWhiteSpace(id_user))
            {
                throw new Exception("No se proporcionó el ID del usuario");
            }
            if (!string.IsNullOrWhiteSpace(user))
            {
                ModifiedQuery += $"user = '{user}', ";
            }
            if (!string.IsNullOrWhiteSpace(pwd))
            {
                ModifiedQuery += $"pwd = '{pwd}', ";
            }
            if (!string.IsNullOrWhiteSpace(nombres))
            {
                ModifiedQuery += $"nombres = '{nombres}', ";
            }
            if (!string.IsNullOrWhiteSpace(apellidos))
            {
                ModifiedQuery += $"apellidos = '{apellidos}', ";
            }
            if (!string.IsNullOrWhiteSpace(email))
            {
                ModifiedQuery += $"email = '{email}', ";
            }

            ModifiedQuery = ModifiedQuery.Trim();
            if (ModifiedQuery.EndsWith(","))
                ModifiedQuery = ModifiedQuery.Remove(ModifiedQuery.Length - 1);

            string Query = $"UPDATE Seguridad.tbl_user SET {ModifiedQuery} " +
                $"WHERE id_user = {id_user};";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteFrom(string id_user)
        {
            string Query = "DELETE FROM Seguridad.tbl_user WHERE id_user = " +
                $"{id_user};";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void DeleteFromUpdate(string id_user)
        {
            string Query = "UPDATE Seguridad.tbl_user SET " +
                "estado = 3 " +
                $"WHERE id_user = {id_user};";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ListStore GetData()
        {
            this.UpdateModel();
            return this.Model;
        }

        public Dt_tlb_user()
        {
        }
    }
}
