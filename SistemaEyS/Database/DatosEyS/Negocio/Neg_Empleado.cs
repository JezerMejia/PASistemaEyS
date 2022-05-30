using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;

namespace SistemaEyS.DatosEyS.Negocio
{
    public class Neg_Empleado
    {
        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();

        public Neg_Empleado()
        {
        }

        public void ValidateID(Ent_Empleado emp)
        {
            if (this.DtEmp.DoesExist(
                "AND",
                new DataTableParameter("idEmpleado", $"{emp.idEmpleado}")
            ))
            {
                throw new Exception("El empleado ya existe");
            }
        }
        public void ValidateCedula(Ent_Empleado emp)
        {
            if (this.DtEmp.DoesExist(
                "AND",
                new DataTableParameter("cedulaEmpleado", $"'{emp.cedulaEmpleado}'")
            ))
            {
                throw new Exception("La cédula ya existe");
            }
        }
        public void ValidateEmailPersonal(Ent_Empleado emp)
        {
            if (
                !string.IsNullOrWhiteSpace(emp.emailPersonal) &&
                this.DtEmp.DoesExist(
                    "AND",
                    new DataTableParameter("emailPersonal", $"'{emp.emailPersonal}'")
            ))
            {
                throw new Exception("El correo personal ya está registrado");
            }
        }
        public void ValidateEmailEmpresarial(Ent_Empleado emp)
        {
            if (
                !string.IsNullOrWhiteSpace(emp.emailEmpresarial) &&
                this.DtEmp.DoesExist(
                    "AND",
                    new DataTableParameter("emailEmpresarial", $"'{emp.emailEmpresarial}'")
            ))
            {
                throw new Exception("El correo empresarial ya está registrado");
            }
        }
        public void ValidateTelefono(Ent_Empleado emp)
        {
            if (
                !string.IsNullOrWhiteSpace(emp.telefonoEmpleado) &&
                this.DtEmp.DoesExist(
                    "AND",
                    new DataTableParameter("telefonoEmpleado", $"'{emp.telefonoEmpleado}'")
            ))
            {
                throw new Exception("El número de teléfono ya está registrado");
            }
        }

        public void AddEmpleado(Ent_Empleado emp)
        {
            try
            {
                this.ValidateID(emp);
                this.ValidateCedula(emp);
                this.ValidateTelefono(emp);
                this.ValidateEmailPersonal(emp);
                this.ValidateEmailEmpresarial(emp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtEmp.InsertInto(
                emp.idEmpleado.ToString(),
                emp.primerNombre, emp.segundoNombre,
                emp.primerApellido, emp.segundoApellido,
                emp.pinEmpleado,
                ((int)emp.estado).ToString()
            );
        }
        public void EditEmpleado(Ent_Empleado emp)
        {
            try
            {
                Ent_Empleado prevEmp = this.SearchEmpleado(emp.idEmpleado);

                if (prevEmp.idEmpleado != emp.idEmpleado)
                    throw new ArgumentException(
                        "No puedes modificar el ID de un empleado"
                    );
                if (prevEmp.cedulaEmpleado != emp.cedulaEmpleado)
                    this.ValidateCedula(emp);
                if (prevEmp.telefonoEmpleado != emp.telefonoEmpleado)
                    this.ValidateTelefono(emp);
                if (prevEmp.emailPersonal != emp.emailPersonal)
                    this.ValidateEmailPersonal(emp);
                if (prevEmp.emailEmpresarial != emp.emailEmpresarial)
                    this.ValidateEmailEmpresarial(emp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtEmp.UpdateSet(
                emp.idEmpleado.ToString(),
                emp.primerNombre, emp.segundoNombre,
                emp.primerApellido, emp.segundoApellido,
                emp.pinEmpleado, emp.cedulaEmpleado,
                emp.fechaIngreso?.ToString("yyyy-MM-dd"),
                emp.fechaNacimiento?.ToString("yyyy-MM-dd"),
                emp.telefonoEmpleado,
                emp.emailPersonal,
                emp.emailEmpresarial,
                emp.idCargo?.ToString() ?? "NULL",
                emp.idDepartamento?.ToString() ?? "NULL",
                emp.idHorario?.ToString() ?? "NULL",
                ((int)emp.estado).ToString()
            );
        }
        public void RemoveEmpleado(Ent_Empleado emp)
        {
            this.DtEmp.DeleteFromUpdate(emp.idEmpleado.ToString());
        }

        public DateTime? StringToDateTime(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return DateTime.Parse(value);
            return null;
        }
        public int? StringToInt(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                return Int32.Parse(value);
            return null;
        }
        public Ent_Empleado SearchEmpleado(int idEmpleado)
        {
            ListStore store = this.DtEmp.Search(
                "AND",
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'"),
                new DataTableParameter("estado", $"'3'", "<>")
            );
            if (store == null) throw new NullReferenceException("El empleado no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos del empleado");

            Ent_Empleado user = new Ent_Empleado()
            {
                idEmpleado = Int32.Parse(store.GetValue(iter, 0).ToString()),
                primerNombre = store.GetValue(iter, 1)?.ToString() ?? "",
                segundoNombre = store.GetValue(iter, 2)?.ToString() ?? "",
                primerApellido = store.GetValue(iter, 3)?.ToString() ?? "",
                segundoApellido = store.GetValue(iter, 4)?.ToString() ?? "",
                fechaIngreso = this.StringToDateTime(
                        (string)store.GetValue(iter, 5)
                        ),
                fechaNacimiento = this.StringToDateTime(
                        (string)store.GetValue(iter, 6)
                        ),
                cedulaEmpleado = store.GetValue(iter, 7)?.ToString() ?? "",
                pinEmpleado = store.GetValue(iter, 8)?.ToString() ?? "",
                telefonoEmpleado = store.GetValue(iter, 9)?.ToString() ?? "",
                emailPersonal = store.GetValue(iter, 10)?.ToString() ?? "",
                emailEmpresarial = store.GetValue(iter, 11)?.ToString() ?? "",
                idCargo = this.StringToInt(
                        (string)store.GetValue(iter, 12)
                        ),
                idDepartamento = this.StringToInt(
                        (string)store.GetValue(iter, 13)
                        ),
                idHorario = this.StringToInt(
                        (string)store.GetValue(iter, 14)
                        ),
                estado = (EntidadEstado)this.StringToInt(
                        (string)store.GetValue(iter, 15)
                        )
            };

            return user;
        }
    }
}
