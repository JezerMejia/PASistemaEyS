using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosSeguridad.Datos
{
    public class Dt_tbl_rol : DataTableTemplate
    {
        public Dt_tbl_rol()
        {
            this.conn = ConnectionSeg.OpenConnection();
            this.DBTable = "BDSistemaEyS.tbl_rol";
            this.gTypes = new Type[4] {
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
            sb.Append("SELECT * FROM BDSistemaEyS.tbl_rol WHERE estado <> 3;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID Rol
                        idr[1].ToString(), // Nombre
                        idr[2].ToString(), // Descripción
                        idr[3].ToString() // Estado
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

            ListStore model = new ListStore(this.gTypes);

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

        public void InsertInto(string rol, string descripcion, string estado)
        {
            this.InsertInto(
                    //this.conn,
                    new DataTableParameter("rol", $"'{rol}'"),
                    new DataTableParameter("descripcion", $"'{descripcion}'"),
                    new DataTableParameter("estado", $"'{estado}'")
                );
        }

        public void UpdateSet(string id_rol, string rol, string descripcion, string estado)
        {
            this.UpdateSet(
                    //this.conn,
                    new DataTableParameter("id_rol", id_rol),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(rol) ? "rol" : "",
                        $"'{rol}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(descripcion) ? "descripcion" : "",
                        $"'{descripcion}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(estado) ? "estado" : "",
                        $"'{estado}'"
                        )
                );
        }

        public void DeleteFrom(string id_rol)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("id_rol", id_rol)
                );
        }
        public void DeleteFromUpdate(string id_rol)
        {
            this.UpdateSet(
                new DataTableParameter("id_rol", id_rol),
                new DataTableParameter("estado", "3")
                );
        }
    }
}
