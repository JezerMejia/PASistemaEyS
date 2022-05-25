using System;
namespace SistemaEyS.DatosEyS.Entidades
{
    public class Ent_Departamento
    {
        private int _idDepartamento;
        private string _nombreDepartamento;
        private string _descripcionDepartamento;
        private string _extensionDepartamento;

        public int idDepartamento
        {
            get => this._idDepartamento;
            set => this._idDepartamento = value;
        }

        public string nombreDepartamento
        {
            get => this._nombreDepartamento;
            set => this._nombreDepartamento = value?.Substring(
                0, value.Length > 25 ? 25 : value.Length
                );
        }

        public string descripcionDepartamento
        {
            get => this._descripcionDepartamento;
            set => this._descripcionDepartamento = value?.Substring(
                0, value.Length > 100 ? 100 : value.Length
                );
        }

        public string extensionDepartamento
        {
            get => this._extensionDepartamento;
            set => this._extensionDepartamento = value?.Substring(
                0, value.Length > 5 ? 5 : value.Length
                );
        }

        public Ent_Departamento()
        {
        }
    }
}
