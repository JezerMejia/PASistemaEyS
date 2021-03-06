using System;
namespace SistemaEyS.DatosEyS.Entidades
{
    public class Ent_Cargo
    {
        private int _idCargo;
        private string _nombreCargo;
        private string _descripcionCargo;
        private int _estado;

        public int idCargo
        {
            get => this._idCargo;
            set => this._idCargo = value;
        }

        public string nombreCargo
        {
            get => this._nombreCargo;
            set => this._nombreCargo = value?.Substring(
                0, value.Length > 25 ? 25 : value.Length
                );
        }

        public string descripcionCargo
        {
            get => this._descripcionCargo;
            set => this._descripcionCargo = value?.Substring(
                0, value.Length > 100 ? 100 : value.Length
                );
        }

        public EntidadEstado estado
        {
            get => (EntidadEstado)this._estado;
            set => this._estado = (int)value;
        }

        public Ent_Cargo()
        {
        }
    }
}
