using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS
{
    public class Dt_tlb_empleado : DataTableTemplate
    {
        public ListStore ModelView;

        public Dt_tlb_empleado()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.Empleado";
            this.ModelView = new ListStore(
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string)
            );
            this.Model = new ListStore(
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string)
            );
        }

        public void UpdateModelView()
        {
            this.ModelView.Clear();
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.vwEmpleado;");
            try
            {
                idr = this.conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    this.ModelView.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), // Nombre
                        idr[2].ToString(), // Apellido
                        idr.IsDBNull(3) ? "" :
                            idr.GetDateTime(3).ToString("yyyy-MM-dd"), // fechaIngreso
                        idr[4].ToString(), // CedulaEmpleado
                        idr[5].ToString(), // Contraseña
                        idr[6].ToString(), // Cargo
                        idr[7].ToString(), // Departamento
                        idr[8].ToString() // ID Horario
                    );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                Console.WriteLine(e);
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

        public void UpdateModelEmp()
        {
            this.Model.Clear();
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Empleado;");
            try
            {
                idr = this.conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), // primerNombre
                        idr[2].ToString(), // segundoNombre
                        idr[3].ToString(), // primerApellido
                        idr[4].ToString(), // segundoApellido
                        idr.IsDBNull(5) ? "" :
                            idr.GetDateTime(5).ToString("yyyy-MM-dd"), // fechaIngreso
                        idr[6].ToString(), // cedulaEmpleado
                        idr[7].ToString(), // Contraseña
                        idr[8].ToString(), // idcargo
                        idr[9].ToString(),  // idDepartamento
                        idr[10].ToString() // idHorario
                    );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                Console.WriteLine(e);
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
            this.UpdateModelEmp();
            this.UpdateModelView();
        }

        public ListStore GetDataView()
        {
            this.UpdateModel();
            return this.ModelView;
        }

        public void InsertInto(string idEmpleado, string primerNombre,
            string segundoNombre, string primerApellido, string segundoApellido,
            string password)
        {
            this.InsertInto(
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'"),
                new DataTableParameter("primerNombre", $"'{primerNombre}'"),
                new DataTableParameter("segundoNombre", $"'{segundoNombre}'"),
                new DataTableParameter("primerApellido", $"'{primerApellido}'"),
                new DataTableParameter("segundoApellido", $"'{segundoApellido}'"),
                new DataTableParameter("password", $"'{password}'")
                );
        }

        public void UpdateSet(string idEmpleado, string primerNombre,
            string segundoNombre, string primerApellido, string segundoApellido,
            string password, string cedulaEmpleado, string fechaIngreso,
            string idCargo, string idDepartamento, string idHorario)
        {
            this.UpdateSet(
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'"),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(primerNombre) ? "primerNombre" : "",
                    $"'{primerNombre}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(segundoNombre) ? "segundoNombre" : "",
                    $"'{segundoNombre}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(primerApellido) ? "primerApellido" : "",
                    $"'{primerApellido}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(segundoApellido) ? "segundoApellido" : "",
                    $"'{segundoApellido}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(password) ? "password" : "",
                    $"'{password}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(cedulaEmpleado) ? "cedulaEmpleado" : "",
                    $"'{cedulaEmpleado}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(fechaIngreso) ? "fechaIngreso" : "",
                    $"'{fechaIngreso}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(idCargo) ? "idCargo" : "",
                    $"{idCargo}"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(idDepartamento) ? "idDepartamento" : "",
                    $"{idDepartamento}"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(idHorario) ? "idHorario" : "",
                    $"{idHorario}"
                    )
                );
        }

        public void DeleteFrom(string idEmpleado)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'")
                );
        }
    }
}
