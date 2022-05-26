using System;
using System.Data;
using System.Text;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosSeguridad.Datos
{
    public class Dt_tbl_opcion : DataTableTemplate
    {
        public Dt_tbl_opcion()
        {
            this.conn = ConnectionSeg.OpenConnection();
            this.DBTable = "BDSistemaEyS.tbl_opcion";
            this.gTypes = new Type[3] {
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
            sb.Append("SELECT * FROM BDSistemaEyS.tbl_opcion WHERE estado <> 3;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID opcion
                        idr[1].ToString(), // Opcion
                        idr[2].ToString() // Estado
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

        public void InsertInto(string opcion, string estado)
        {
            this.InsertInto(
                    new DataTableParameter("opcion", $"'{opcion}'"),
                    new DataTableParameter("estado", $"'{estado}'")
                );
        }
        public void UpdateSet(string id_opcion, string opcion, string estado)
        {
            Console.WriteLine(id_opcion);
            this.UpdateSet(
                    //this.conn,
                    new DataTableParameter("id_opcion", id_opcion),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(opcion) ? "opcion" : "",
                        $"'{opcion}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(estado) ? "estado" : "",
                        $"'{estado}'"
                        )
                );
        }
        public void DeleteFrom(string id_opcion)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("id_opcion", id_opcion)
                );
        }
        public void DeleteFromUpdate(string id_opcion)
        {
            this.UpdateSet(
                new DataTableParameter("id_opcion", id_opcion),
                new DataTableParameter("estado", "3")
                );
        }
    }
}
