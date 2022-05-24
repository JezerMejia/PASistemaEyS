using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosSeguridad.Datos
{
    public class Dt_tbl_user : DataTableTemplate
    {
        public Dt_tbl_user()
        {
            this.conn = ConnectionSeg.OpenConnection();
            this.DBTable = "Seguridad.tbl_user";
            this.gTypes = new Type[8] {
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string),
                typeof(string)
            };
            this.Model = new ListStore(this.gTypes);
        }

        public override void UpdateModel()
        {
            this.Model.Clear();

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM Seguridad.tbl_user WHERE estado <> 3;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID Usuario
                        idr[1].ToString(), // Usario
                        idr[2].ToString(), // Contraseña
                        idr[3].ToString(), // Nombres
                        idr[4].ToString(), // Apellidos
                        idr[5].ToString(), // Email
                        idr[6].ToString(), // Contraseña temp
                        idr[7].ToString() // Estado
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
        }

        public ListStore GetDataCmbx()
        {
            this.UpdateModel();
            TreeIter iter;

            ListStore model = new ListStore(
                typeof(string),
                typeof(string),
                typeof(string)
                );

            if (this.Model.GetIterFirst(out iter))
            {
                do
                {
                    model.AppendValues(
                        this.Model.GetValue(iter, 1),
                        this.Model.GetValue(iter, 0),
                        this.Model.GetValue(iter, 2)
                    );
                }
                while (this.Model.IterNext(ref iter));
            }

            return model;
        }
        public void InsertInto(string user, string pwd, string nombres,
            string apellidos, string email, string estado)
        {
            this.InsertInto(
                    //this.conn,
                    new DataTableParameter("user", $"'{user}'"),
                    new DataTableParameter("pwd", $"'{pwd}'"),
                    new DataTableParameter("nombres", $"'{nombres}'"),
                    new DataTableParameter("apellidos", $"'{apellidos}'"),
                    new DataTableParameter("email", $"'{email}'"),
                    new DataTableParameter("estado", $"'{estado}'")
                );
        }

        public void UpdateSet(string id_user, string user, string pwd,
            string nombres, string apellidos, string email, string estado)
        {
            Console.WriteLine(id_user);
            this.UpdateSet(
                    //this.conn,
                    new DataTableParameter("id_user", id_user),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(user) ? "user" : "",
                        $"'{user}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(pwd) ? "pwd" : "",
                        $"'{pwd}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(nombres) ? "nombres" : "",
                        $"'{nombres}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(apellidos) ? "apellidos" : "",
                        $"'{apellidos}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(email) ? "email" : "",
                        $"'{email}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(estado) ? "estado" : "",
                        $"'{estado}'"
                        )
                );
            //this.UpdateSet(id_user, user, pwd, nombres, apellidos, email, "");
        }

        public void DeleteFrom(string id_user)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("id_user", id_user)
                );
        }
        public void DeleteFromUpdate(string id_user)
        {
            this.UpdateSet(
                new DataTableParameter("id_user", id_user),
                new DataTableParameter("estado", "3")
                );
        }
    }
}
