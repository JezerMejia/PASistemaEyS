using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosSeguridad.Datos
{
    public class Dt_tbl_rol_opcion : DataTableTemplate
    {
        public Dt_tbl_rol_opcion()
        {
            this.conn = ConnectionSeg.OpenConnection();
            this.DBTable = "BDSistemaEyS.tbl_rolOpcion";
            this.Model = new ListStore(
                typeof(string),
                typeof(string),
                typeof(string)
                );
        }

        public override void UpdateModel()
        {
            this.Model.Clear();

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.tbl_rolOpcion;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID Rol-Opción
                        idr[1].ToString(), // ID Rol
                        idr[2].ToString() // ID Opción
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

        public void InsertInto(string id_rol, string id_opcion)
        {
            this.InsertInto(
                    new DataTableParameter("id_rol", $"'{id_rol}'"),
                    new DataTableParameter("id_opcion", $"'{id_opcion}'")
                );
        }
        public void UpdateSet(string id_rolOpcion, string id_rol, string id_opcion)
        {
            this.UpdateSet(
                    //this.conn,
                    new DataTableParameter("id_rolOpcion", id_rolOpcion),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(id_rol) ? "id_rol" : "",
                        $"'{id_rol}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(id_opcion) ? "id_opcion" : "",
                        $"'{id_opcion}'"
                        )
                );
        }
        public void DeleteFrom(string id_rolOpcion)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("id_rolOpcion", id_rolOpcion)
                );
        }
    }
}
