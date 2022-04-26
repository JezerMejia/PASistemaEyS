using System;
namespace SistemadeControldeAsistencia.Entidades
{
    public class Tbl_user
    {
        //Atributos
        private Int32 id_user;
        private string user;
        private string pwd;
        private string nombres;
        private string email;
        private string pwd_temp;
        private Int32 estado;

        //Metodos
        public int Id_user { get => id_user; set => id_user = value; }
        public string User { get => user; set => user = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Email { get => email; set => email = value; }
        public string Pwd_temp { get => pwd_temp; set => pwd_temp = value; }
        public int Estado { get => estado; set => estado = value; }
    }
}
