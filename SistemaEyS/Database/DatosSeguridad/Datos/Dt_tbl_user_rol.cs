using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosSeguridad.Datos
{
    public class Dt_tbl_user_rol : DataTableTemplate
    {
        public ListStore ModelView;

        public Dt_tbl_user_rol()
        {
            this.conn = ConnectionSeg.OpenConnection();
            this.DBTable = "BDSistemaEyS.tbl_UserRol";
            this.gTypes = new Type[3] {
                typeof(string),
                typeof(string),
                typeof(string)
            };
            this.ModelView = new ListStore(this.gTypes);
            this.Model = new ListStore(this.gTypes);
        }

        public void UpdateModelUserRol()
        {
            this.Model.Clear();

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.tbl_UserRol;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID UserRol
                        idr[1].ToString(), // ID Usuario
                        idr[2].ToString() // ID Rol
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
        public void UpdateModelView()
        {
            this.ModelView.Clear();

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.vwUserRol;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.ModelView.AppendValues(
                        idr[0].ToString(), // ID UserRol
                        idr[1].ToString(), // Usuario
                        idr[2].ToString() // Rol
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

        public override void UpdateModel()
        {
            this.UpdateModelUserRol();
            this.UpdateModelView();
        }

        public ListStore GetDataView()
        {
            this.UpdateModel();
            return this.ModelView;
        }

        public void InsertInto(string id_user, string id_rol)
        {
            this.InsertInto(
                    new DataTableParameter("id_user", $"'{id_user}'"),
                    new DataTableParameter("id_rol", $"'{id_rol}'")
                );
        }

        public void UpdateSet(string id_UserRol, string id_user, string id_rol)
        {
            this.UpdateSet(
                    new DataTableParameter("id_UserRol", id_UserRol),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(id_user) ? "id_user" : "",
                        $"'{id_user}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(id_rol) ? "id_rol" : "",
                        $"'{id_rol}'"
                    )
                );
        }

        public void DeleteFrom(string id_UserRol)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("id_UserRol", $"'{id_UserRol}'")
                );
        }
    }
}
