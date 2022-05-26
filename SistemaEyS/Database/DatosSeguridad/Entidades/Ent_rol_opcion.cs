using System;
using SistemaEyS.DatosSeguridad.Datos;

namespace SistemaEyS.DatosSeguridad.Entidades
{
    public class Ent_rol_opcion
    {
        private int _id_rolOpcion;
        private int _id_rol;
        private int _id_opcion;

        public int id_rolOpcion
        {
            get => this._id_rolOpcion;
            set => this._id_rolOpcion = value;
        }
        public int id_rol
        {
            get => this._id_rol;
            set => this._id_rol = value;
        }
        public int id_opcion
        {
            get => this._id_opcion;
            set => this._id_opcion = value;
        }

        public Ent_rol_opcion()
        {
        }
    }
}
