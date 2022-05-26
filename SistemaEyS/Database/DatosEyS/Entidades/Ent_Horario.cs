﻿using System;
namespace SistemaEyS.DatosEyS.Entidades
{
    public class Ent_Horario
    {

        private int _idHorario;
        private DateTime? _lunesInicio;
        private DateTime? _lunesSalida;
        private DateTime? _martesInicio;
        private DateTime? _martesSalida;
        private DateTime? _miercolesInicio;
        private DateTime? _miercolesSalida;
        private DateTime? _juevesInicio;
        private DateTime? _juevesSalida;
        private DateTime? _viernesInicio;
        private DateTime? _viernesSalida;
        private DateTime? _sabadoInicio;
        private DateTime? _sabadoSalida;
        private DateTime? _domingoInicio;
        private DateTime? _domingoSalida;

        public int idHorario
        {
            get => this._idHorario;
            set => this._idHorario = value;
        }

        //Lunes
        public DateTime? lunesInicio
        {
            get => this._lunesInicio;
            set => this._lunesInicio = value;
        }

        public DateTime? lunesSalida
        {
            get => this._lunesSalida;
            set => this._lunesSalida = value;
        }

        //Martes
        public DateTime? martesInicio
        {
            get => this._martesInicio;
            set => this._martesInicio = value;
        }
        public DateTime? martesSalida
        {
            get => this._martesSalida;
            set => this._martesSalida = value;
        }

        //Miercoles
        public DateTime? miercolesInicio
        {
            get => this._miercolesInicio;
            set => this._miercolesInicio = value;
        }
        public DateTime? miercolesSalida
        {
            get => this._miercolesSalida;
            set => this._miercolesSalida = value;
        }

        //Jueves
        public DateTime? juevesInicio
        {
            get => this._juevesInicio;
            set => this._juevesInicio = value;
        }
        public DateTime? juevesSalida
        {
            get => this._juevesSalida;
            set => this._juevesSalida = value;
        }

        //Viernes
        public DateTime? viernesInicio
        {
            get => this._viernesInicio;
            set => this._viernesInicio = value;
        }
        public DateTime? viernesSalida
        {
            get => this._viernesSalida;
            set => this._viernesSalida = value;
        }

        //Sabado
        public DateTime? sabadoInicio
        {
            get => this._sabadoInicio;
            set => this._sabadoInicio = value;
        }
        public DateTime? sabadoSalida
        {
            get => this._sabadoSalida;
            set => this._sabadoSalida = value;
        }

        //Domingo
        public DateTime? domingoInicio
        {
            get => this._domingoInicio;
            set => this._domingoInicio = value;
        }
        public DateTime? domingoSalida
        {
            get => this._domingoSalida;
            set => this._domingoSalida = value;
        }



        public Ent_Horario()
        {
        }
    }
}