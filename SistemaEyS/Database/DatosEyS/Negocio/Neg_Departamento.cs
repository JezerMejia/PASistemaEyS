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

    }
}
