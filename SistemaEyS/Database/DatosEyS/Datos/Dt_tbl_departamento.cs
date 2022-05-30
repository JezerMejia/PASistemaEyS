using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS.Datos
{
    public class Dt_tbl_departamento : DataTableTemplate
    {
        public Dt_tbl_departamento()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.Departamento";
            this.gTypes = new Type[5] {
                typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string)
            };
            this.Model = new ListStore(this.gTypes);
        }

        public override void UpdateModel()
        {
            this.Model.Clear();

            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Departamento;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());
                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), // Nombre
                        idr[2].ToString(), // Descripción
                        idr[3].ToString(), // Extensión
                        idr[4].ToString()  // Estado
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
                typeof(string), typeof(string),
                typeof(string), typeof(string)
                );

            if (this.Model.GetIterFirst(out iter))
            {
                do
                {
                    model.AppendValues(
                        this.Model.GetValue(iter, 1),
                        this.Model.GetValue(iter, 0),
                        this.Model.GetValue(iter, 2),
                        this.Model.GetValue(iter, 3),
                        this.Model.GetValue(iter, 4)
                    );
                }
                while (this.Model.IterNext(ref iter));
            }

            return model;
        }

        public void InsertInto(string nombre, string descripcion, string extension, string estado)
        {
            this.InsertInto(
                    new DataTableParameter("nombreDepartamento", $"'{nombre}'"),
                    new DataTableParameter("descripcionDepartamento", $"'{descripcion}'"),
                    new DataTableParameter("extensionDepartamento", $"'{extension}'"),
                    new DataTableParameter("estado", $"'{estado}'")
                );
        }

        public void UpdateSet(string idDepartamento, string nombre, string descripcion, string extension, string estado)
        {
            this.UpdateSet(
                    new DataTableParameter("idDepartamento", $"'{idDepartamento}'"),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(nombre) ? "nombreDepartamento" : "",
                        $"'{nombre}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(descripcion) ? "descripcionDepartamento" : "",
                        $"'{descripcion}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(extension) ? "extensionDepartamento" : "",
                        $"'{extension}'"
                        ),
                    new DataTableParameter(
                        !string.IsNullOrWhiteSpace(extension) ? "estado" : "",
                        $"'{estado}'"
                        )
                );
        }

        public void DeleteFrom(string idDepartamento)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("idDepartamento", $"'{idDepartamento}'")
                );
        }
    }
}
