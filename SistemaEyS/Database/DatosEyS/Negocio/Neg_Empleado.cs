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
                new DataTableParameter("cedulaEmpleado", $"{emp.cedulaEmpleado}")
            ))
            {
                throw new Exception("La cédula ya existe");
            }
        }

        public void AddEmpleado(Ent_Empleado emp)
        {
            try
            {
                this.ValidateID(emp);
                this.ValidateCedula(emp);
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
                emp.pinEmpleado
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
                emp.idCargo?.ToString() ?? "NULL",
                emp.idDepartamento?.ToString() ?? "NULL",
                emp.idHorario?.ToString() ?? "NULL"
            );
        }
        public void RemoveUser(Ent_Empleado emp)
        {
            //this.DtEmp.DeleteFromUpdate(emp.idEmpleado.ToString());
            this.DtEmp.DeleteFrom(emp.idEmpleado.ToString());
        }
        public Ent_Empleado SearchEmpleado(int idEmpleado)
        {
            ListStore store = this.DtEmp.Search(
                new DataTableParameter("idEmpleado", $"{idEmpleado}")
            );
            if (store == null) throw new NullReferenceException("El empleado no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos del empleado");

            DateTime? fechaIngreso = null;
            if (!string.IsNullOrWhiteSpace((string)store.GetValue(iter, 5)))
            {
                fechaIngreso = DateTime.Parse((string) store.GetValue(iter, 5));
            }
            int? idCargo = null;
            if (!string.IsNullOrWhiteSpace((string)store.GetValue(iter, 8))) {
                idCargo = Int32.Parse((string)store.GetValue(iter, 8));
	        }
            int? idDep = null;
            if (!string.IsNullOrWhiteSpace((string)store.GetValue(iter, 9))) {
                idDep = Int32.Parse((string)store.GetValue(iter, 9));
	        }
            int? idHor = null;
            if (!string.IsNullOrWhiteSpace((string)store.GetValue(iter, 10))) {
                idHor = Int32.Parse((string)store.GetValue(iter, 10));
	        }

            Ent_Empleado user = new Ent_Empleado()
            {
                idEmpleado = Int32.Parse(store.GetValue(iter, 0).ToString()),
                primerNombre = store.GetValue(iter, 1)?.ToString() ?? "",
                segundoNombre = store.GetValue(iter, 2)?.ToString() ?? "",
                primerApellido = store.GetValue(iter, 3)?.ToString() ?? "",
                segundoApellido = store.GetValue(iter, 4)?.ToString() ?? "",
                fechaIngreso = fechaIngreso,
                cedulaEmpleado = store.GetValue(iter, 6)?.ToString() ?? "",
                pinEmpleado = store.GetValue(iter, 7)?.ToString() ?? "",
                idCargo = idCargo,
                idDepartamento = idDep,
                idHorario = idHor
            };

            return user;
        }
    }
}
