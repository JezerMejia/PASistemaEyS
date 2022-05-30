using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS.Datos
{
    public class Dt_tlb_empleado : DataTableTemplate
    {
        public ListStore ModelView;

        public Dt_tlb_empleado()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.Empleado";
            this.gTypes = new Type[16] {
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string)
            };
            this.ModelView = new ListStore(this.gTypes);
            this.Model = new ListStore(this.gTypes);
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
                        idr[3].ToString(), // PIN
                        idr.IsDBNull(4) ? "" :
                            idr.GetDateTime(4).ToString("yyyy-MM-dd"), // fechaIngreso
                        idr.IsDBNull(5) ? "" :
                            idr.GetDateTime(5).ToString("yyyy-MM-dd"), // fechaNacimiento
                        idr[6].ToString(), // CedulaEmpleado
                        idr[7].ToString(), // Teléfono
                        idr[8].ToString(), // Email personal
                        idr[9].ToString(), // Email empresarial
                        idr[10].ToString(), // Cargo
                        idr[11].ToString(), // Departamento
                        idr[12].ToString() // Horario
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
            sb.Append("SELECT * FROM BDSistemaEyS.Empleado WHERE estado <> 3;");
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
                        idr.IsDBNull(6) ? "" :
                            idr.GetDateTime(6).ToString("yyyy-MM-dd"), // fechaNacimiento
                        idr[7].ToString(), // CedulaEmpleado
                        idr[8].ToString(), // PIN
                        idr[9].ToString(), // Teléfono
                        idr[10].ToString(), // Email personal
                        idr[11].ToString(), // Email empresarial
                        idr[12].ToString(), // idCargo
                        idr[13].ToString(), // idDepartamento
                        idr[14].ToString(), // idHorario
                        idr[15].ToString() // estado
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
            string pinEmpleado, string estado)
        {
            this.InsertInto(
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'"),
                new DataTableParameter("primerNombre", $"'{primerNombre}'"),
                new DataTableParameter("segundoNombre", $"'{segundoNombre}'"),
                new DataTableParameter("primerApellido", $"'{primerApellido}'"),
                new DataTableParameter("segundoApellido", $"'{segundoApellido}'"),
                new DataTableParameter("pinEmpleado", $"'{pinEmpleado}'"),
                new DataTableParameter("estado", $"'{estado}'")
                );
        }

        public void UpdateSet(
            string idEmpleado, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido,
            string pinEmpleado, string cedulaEmpleado,
            string fechaIngreso, string fechaNacimiento, string telefonoEmpleado,
            string emailPersonal, string emailEmpresarial,
            string idCargo, string idDepartamento, string idHorario,
            string estado
            )
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
                    !string.IsNullOrWhiteSpace(pinEmpleado) ? "pinEmpleado" : "",
                    $"'{pinEmpleado}'"
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
                    !string.IsNullOrWhiteSpace(fechaNacimiento) ? "fechaNacimiento" : "",
                    $"'{fechaNacimiento}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(telefonoEmpleado) ? "telefonoEmpleado" : "",
                    $"'{telefonoEmpleado}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(emailPersonal) ? "emailPersonal" : "",
                    $"'{emailPersonal}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(emailEmpresarial) ? "emailEmpresarial" : "",
                    $"'{emailEmpresarial}'"
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
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(estado) ? "estado" : "",
                    $"{estado}"
                    )
                );
        }

        public void DeleteFrom(string idEmpleado)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'")
                );
        }
        public void DeleteFromUpdate(string idEmpleado)
        {
            this.UpdateSet(
                new DataTableParameter("idEmpleado", idEmpleado),
                new DataTableParameter("estado", "3")
                );
        }
    }
}
