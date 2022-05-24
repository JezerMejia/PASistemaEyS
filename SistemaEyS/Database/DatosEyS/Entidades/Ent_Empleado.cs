using System;
namespace SistemaEyS.Database.DatosEyS.Entidades
{
    public class Ent_Empleado
    {
        private int _idEmpleado;
        private string _primerNombre;
        private string _segundoNombre;
        private string _primerApellido;
        private string _segundoApellido;
        private DateTime _fechaIngreso;
        private string _cedulaEmpleado;
        private string _pinEmpleado;
        private int _idCargo;
        private int _idDepartamento;
        private int _idHorario;

        public int idEmpleado
        {
            get => this._idEmpleado;
            set => this._idEmpleado = value;
        }
        public string primerNombre
        {
            get => this._primerNombre;
            set => this._primerNombre = value.Substring(
                0, value.Length > 25 ? 25 : value.Length
		        );
	    }
        public string segundoNombre
        {
            get => this._segundoNombre;
            set => this._segundoNombre = value.Substring(
                0, value.Length > 25 ? 25 : value.Length
		        );
	    }
        public string primerApellido
        {
            get => this._primerApellido;
            set => this._primerApellido = value.Substring(
                0, value.Length > 25 ? 25 : value.Length
		        );
	    }
        public string segundoApellido
        {
            get => this._segundoApellido;
            set => this._segundoApellido = value.Substring(
                0, value.Length > 25 ? 25 : value.Length
		        );
	    }
        public DateTime fechaIngreso
        {
            get => this._fechaIngreso;
            set => this._fechaIngreso = value;
	    }
        public string cedulaEmpleado
        {
            get => this._cedulaEmpleado;
            set => this._cedulaEmpleado = value.Substring(
                0, value.Length > 14 ? 14 : value.Length
		        );
	    }
        public string pinEmpleado
        {
            get => this._pinEmpleado;
            set => this._pinEmpleado = value.Substring(
                0, value.Length > 30 ? 30 : value.Length
		        );
	    }
        public int idCargo
        {
            get => this._idCargo;
            set => this._idCargo = value;
	    }
        public int idDepartamento
        {
            get => this._idDepartamento;
            set => this._idDepartamento = value;
	    }
        public int idHorario
        {
            get => this._idHorario;
            set => this._idHorario = value;
	    }

        public Ent_Empleado()
        {
        }
    }
}
