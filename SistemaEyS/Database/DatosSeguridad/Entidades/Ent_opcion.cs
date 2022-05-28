using System;
using SistemaEyS.DatosSeguridad.Datos;

namespace SistemaEyS.DatosSeguridad.Entidades
{
    public class Ent_opcion
    {
        private int _id_opcion;
        private string _opcion;
        private string _descripcion;
        private int _estado;

        public int id_opcion
        {
            get => this._id_opcion;
            set => this._id_opcion = value;
        }
        public string opcion
        {
            get => this._opcion;
            set => this._opcion = value.Substring(
                0, value.Length > 50 ? 50 : value.Length
		        );
        }
        public string descripcion
        {
            get => this._descripcion;
            set => this._descripcion = value?.Substring(
                0, value.Length > 100 ? 100 : value.Length
		        );
        }

        public EntidadEstado estado
        {
            get => (EntidadEstado)this._estado;
            set => this._estado = (int)value;
        }

        public Ent_opcion()
        {
        }
    }
}
