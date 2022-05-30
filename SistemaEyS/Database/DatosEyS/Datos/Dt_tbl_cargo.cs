using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS.Datos
{
    public class Dt_tbl_cargo : DataTableTemplate
    {
        public Dt_tbl_cargo()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.Cargo";
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
            sb.Append("SELECT * FROM BDSistemaEyS.Cargo;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), // Nombre
                        idr[2].ToString(), // Descripcion
                        idr[3].ToString()  // Estado
                    );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
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
                        this.Model.GetValue(iter, 2),
                        this.Model.GetValue(iter, 3)
                    );
                }
                while (this.Model.IterNext(ref iter));
            }

            return model;
        }

        public void InsertInto(string nombre, string descripcion, string estado)
        {
            this.InsertInto(
                    new DataTableParameter("nombreCargo", $"'{nombre}'"),
                    new DataTableParameter("descripcionCargo", $"'{descripcion}'"),
                    new DataTableParameter("descripcionCargo", $"'{estado}'")
                );
        }

        public void UpdateSet(string idCargo, string nombre, string descripcion, string estado)
        {
            this.UpdateSet(
                    new DataTableParameter("idCargo", $"'{idCargo}'"),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(nombre) ? "nombreCargo" : "",
                        $"'{nombre}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(descripcion) ? "descripcionCargo" : "",
                        $"'{descripcion}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(descripcion) ? "estado" : "",
                        $"'{estado}'"
                        )
                );
        }

        public void DeleteFrom(string idCargo)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("idCargo", $"'{idCargo}'")
                );
        }
    }
}
