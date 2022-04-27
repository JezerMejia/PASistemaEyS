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
            Conexion con1 = Conexion.OpenConnection();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
            con1.CloseConnection();
        }
    }
}
