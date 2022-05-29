using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using Gtk;

namespace SistemaEyS.DatosEyS.Negocio
{
    public class Neg_Departamento
    {
        Dt_tbl_departamento DtDep = new Dt_tbl_departamento();

        public Neg_Departamento()
        {
        }

        public void ValidateNombreDep(Ent_Departamento dep)
        {
            if (this.DtDep.DoesExist(
                "AND",
                new DataTableParameter("nombreDepartamento", $"'{dep.nombreDepartamento}'")
            ))
            {
                throw new Exception("El nombre ya existe");
            }
        }

        public void AddDepartamento(Ent_Departamento dep)
        {
            try
            {
                this.ValidateNombreDep(dep);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtDep.InsertInto(
                dep.nombreDepartamento,
                dep.descripcionDepartamento,
                dep.extensionDepartamento
                );
        }

        public void EditDepartamento(Ent_Departamento dep)
        {
            try
            {
                Ent_Departamento prevDep = this.SearchDep(dep.idDepartamento);

                if (dep.nombreDepartamento != prevDep.nombreDepartamento)
                    this.ValidateNombreDep(dep);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            this.DtDep.UpdateSet(
                dep.idDepartamento.ToString(),
                dep.nombreDepartamento,
                dep.descripcionDepartamento,
                dep.extensionDepartamento
                );
        }

        public void RemoveDepartamento(Ent_Departamento dep)
        {
            this.DtDep.DeleteFrom(dep.idDepartamento.ToString());
        }

        protected Ent_Departamento GetDepartamento(ListStore store)
        {
            if (store == null) throw new NullReferenceException("El departamento no existe");
            TreeIter iter;

            if (!store.GetIterFirst(out iter)) throw new NullReferenceException("No hay datos en el departamento");

            Ent_Departamento dep = new Ent_Departamento()
            {
                idDepartamento = Int32.Parse(store.GetValue(iter, 0).ToString()),
                nombreDepartamento = store.GetValue(iter, 1).ToString(),
                descripcionDepartamento = store.GetValue(iter, 2).ToString(),
                extensionDepartamento = store.GetValue(iter, 3).ToString()
            };

            return dep;
        }

        public Ent_Departamento SearchDep(int idDepartamento)
        {
            ListStore store = this.DtDep.Search(
                "AND",
                new DataTableParameter("idDepartamento", $"'{idDepartamento}'")
            );

            return this.GetDepartamento(store);
        }
    }
}
