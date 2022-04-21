using System;
using Gtk;
using SistemadeControldeAsistencia.datos;

namespace SistemaEyS
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Conexion con1 = new Conexion();
            con1.AbrirConexion();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            con1.CerrarConexion();
        }
    }
}
