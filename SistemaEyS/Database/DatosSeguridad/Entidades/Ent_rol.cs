using System;
using SistemaEyS.DatosSeguridad.Datos;

namespace SistemaEyS.DatosSeguridad.Entidades
{
    public class Ent_rol
    {
        protected Dt_tbl_rol DtOpcion = new Dt_tbl_rol();

        private int _id_rol;
        private string _rol;
        private int _estado;

        public int id_rol
        {
            get => this._id_rol;
            set => this._id_rol = value;
        }
        public string rol
        {
            get => this._rol;
            set => this._rol = value.Substring(
                0, value.Length > 50 ? 50 : value.Length
		        );
        }

        public EntidadEstado estado
        {
            get => (EntidadEstado)this._estado;
            set => this._estado = (int)value;
        }

        public Ent_rol()
        {
        }
    }
}
