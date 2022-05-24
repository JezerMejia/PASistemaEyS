using System;
using System.Text.RegularExpressions;
using SistemaEyS.DatosSeguridad.Datos;

public enum EntidadEstado
{
    Indefinido = 0,
    Añadido = 1,
    Modificado = 2,
    Eliminado = 3
}

namespace SistemaEyS.DatosSeguridad.Entidades
{
    public class Ent_user
    {
        protected Dt_tbl_user DtUser = new Dt_tbl_user();

        private int _id_user;
        private string _user;
        private string _pwd;
        private string _nombres;
        private string _apellidos;
        private string _email;
        private int _estado;
        private string _pwd_temp = null;

        public int id_user {
            get => this._id_user;
            set => this._id_user = value;
	    }
        public string user
        {
            get => this._user;
            set => this._user = value;
        }
        public string pwd
        {
            get => this._pwd;
            set => this._pwd = value.Substring(
                0, value.Length > 50 ? 50 : value.Length
		        );
        }
        public string nombres
        {
            get => this._nombres;
            set => this._nombres = value.Substring(
                0, value.Length > 50 ? 50 : value.Length
		        );
        }
        public string apellidos
        {
            get => this._apellidos;
            set => this._apellidos = value.Substring(
                0, value.Length > 50 ? 50 : value.Length
		        );
        }
        public string email
        {
            get => this._email;
            set
            {
                if (!Regex.IsMatch(
                    value,
                    @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                    )
                )
                {
                    throw new FormatException("El correo no es válido");
                };
                this._email = value;
            }
        }
        public EntidadEstado estado
        {
            get => (EntidadEstado)this._estado;
            set => this._estado = (int)value;
        }
        public string pwd_temp
        {
            get => this._pwd_temp;
            set => this._pwd_temp = value.Substring(
                0, value.Length > 50 ? 50 : value.Length
		        );
        }


        public Ent_user()
        {
        }
    }
}