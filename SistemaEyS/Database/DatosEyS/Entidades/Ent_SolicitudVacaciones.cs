using System;
namespace SistemaEyS.DatosEyS.Entidades
{
    public class Ent_SolicitudVacaciones
    {

        private int _idSolVacaciones;
        private DateTime _fechaSol;
        private string _descripcionSol;
        private DateTime _fechaHoraInicio;
        private DateTime _fechaHoraFin;
        private int _idEmpleado;

        public int idSolVacaciones
        {
            get => this._idSolVacaciones;
            set => this._idSolVacaciones = value;
        }

        public DateTime fechaSol
        {
            get => this._fechaSol;
            set => this._fechaSol = value;
        }

        public string descripcionSol
        {
            get => this._descripcionSol;
            set => this._descripcionSol = value?.Substring(
                0, value.Length > 100 ? 100 : value.Length
                );

        }

        public DateTime fechaHoraInicio
        {
            get => this._fechaHoraInicio;
            set => this._fechaHoraInicio = value;
        }

        public DateTime fechaHoraFin
        {
            get => this._fechaHoraFin;
            set => this._fechaHoraFin = value;
        }

        public int idEmpleado
        {
            get => this._idEmpleado;
            set => this._idEmpleado = value;
        }

        public Ent_SolicitudVacaciones()
        {
        }
    }
}
