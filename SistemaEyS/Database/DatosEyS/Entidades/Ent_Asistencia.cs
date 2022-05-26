using System;
namespace SistemaEyS.DatosEyS.Entidades
{
    public class Ent_Asistencia
    {
        private int _idAsistencia;
        private DateTime _fechaAsistencia;
        private DateTime? _horaEntrada;
        private DateTime? _horaSalida;
        private int _idEmpleado;

        public int idAsistencia
        {
            get => this._idAsistencia;
            set => this._idAsistencia = value;
        }

        public DateTime fechaAsistencia
        {
            get => this._fechaAsistencia;
            set => this._fechaAsistencia = value;
        }

        public DateTime? horaEntrada
        {
            get => this._horaEntrada;
            set => this._horaEntrada = value;
        }

        public DateTime? horaSalida
        {
            get => this._horaSalida;
            set => this._horaSalida = value;
        }

        public int idEmpleado
        {
            get => this._idEmpleado;
            set => this._idEmpleado = value;
        }

        public Ent_Asistencia()
        {
        }
    }
}
