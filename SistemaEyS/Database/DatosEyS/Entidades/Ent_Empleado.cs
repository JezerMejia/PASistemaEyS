using System;
using System.Text.RegularExpressions;

namespace SistemaEyS.DatosEyS.Entidades
{
    public class Ent_Empleado
    {
        private int _idEmpleado;
        private string _primerNombre;
        private string _segundoNombre;
        private string _primerApellido;
        private string _segundoApellido;
        private DateTime? _fechaIngreso;
        private DateTime? _fechaNacimiento;
        private string _cedulaEmpleado;
        private string _pinEmpleado;
        private string _telefonoEmpleado;
        private string _emailPersonal;
        private string _emailEmpresarial;
        private int? _idCargo;
        private int? _idDepartamento;
        private int? _idHorario;

        public int idEmpleado
        {
            get => this._idEmpleado;
            set => this._idEmpleado = value;
        }
        public string primerNombre
        {
            get => this._primerNombre;
            set => this._primerNombre = value?.Substring(
                0, value.Length > 25 ? 25 : value.Length
                );
        }
        public string segundoNombre
        {
            get => this._segundoNombre;
            set => this._segundoNombre = value?.Substring(
                0, value.Length > 25 ? 25 : value.Length
                );
        }
        public string primerApellido
        {
            get => this._primerApellido;
            set => this._primerApellido = value?.Substring(
                0, value.Length > 25 ? 25 : value.Length
                );
        }
        public string segundoApellido
        {
            get => this._segundoApellido;
            set => this._segundoApellido = value?.Substring(
                0, value.Length > 25 ? 25 : value.Length
                );
        }
        public DateTime? fechaIngreso
        {
            get => this._fechaIngreso;
            set => this._fechaIngreso = value;
        }
        public DateTime? fechaNacimiento
        {
            get => this._fechaNacimiento;
            set => this._fechaNacimiento = value;
        }
        public string cedulaEmpleado
        {
            get => this._cedulaEmpleado;
            set => this._cedulaEmpleado = value?.Substring(
                0, value.Length > 14 ? 14 : value.Length
                );
        }
        public string pinEmpleado
        {
            get => this._pinEmpleado;
            set => this._pinEmpleado = value?.Substring(
                0, value.Length > 30 ? 30 : value.Length
                );
        }
        public string telefonoEmpleado
        {
            get => this._telefonoEmpleado;
            set => this._telefonoEmpleado = value?.Substring(
                0, value.Length > 15 ? 15 : value.Length
                );
        }
        public string emailPersonal
        {
            get => this._emailPersonal;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    !Regex.IsMatch(
                        value,
                        @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                        )
                )
                {
                    throw new FormatException("El correo no es válido");
                };
                this._emailPersonal = value;
            }
        }
        public string emailEmpresarial
        {
            get => this._emailEmpresarial;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    !Regex.IsMatch(
                        value,
                        @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                        )
                )
                {
                    throw new FormatException("El correo no es válido");
                };
                this._emailEmpresarial = value;
            }
        }
        public int? idCargo
        {
            get => this._idCargo;
            set => this._idCargo = value;
        }
        public int? idDepartamento
        {
            get => this._idDepartamento;
            set => this._idDepartamento = value;
        }
        public int? idHorario
        {
            get => this._idHorario;
            set => this._idHorario = value;
        }

        public Ent_Empleado()
        {
        }
    }
}
