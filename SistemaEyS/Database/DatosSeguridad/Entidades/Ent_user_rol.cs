using System;
using SistemaEyS.DatosSeguridad.Datos;

namespace SistemaEyS.DatosSeguridad.Entidades
{
    public class Ent_user_rol
    {
        private int _id_UserRol;
        private int _id_user;
        private int _id_rol;

        public int id_UserRol {
            get => this._id_UserRol;
            set => this._id_UserRol = value;
	    }
        public int id_user {
            get => this._id_user;
            set => this._id_user = value;
	    }
        public int id_rol {
            get => this._id_rol;
            set => this._id_rol = value;
	    }

        public Ent_user_rol()
        {
        }
    }
}
