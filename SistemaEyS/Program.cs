using System;
using Gtk;
using SistemaEyS.Database.Connection;

namespace SistemaEyS
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            ConnectionEyS connectionEyS = ConnectionEyS.OpenConnection();

            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();

            connectionEyS.CloseConnection();
        }
    }
}
