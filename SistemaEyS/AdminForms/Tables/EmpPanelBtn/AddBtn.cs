using System;
using Gtk;
using SistemaEyS.Database.Connection;
using MySql.Data.MySqlClient;
using System.Data;
using SistemaEySLibrary;

namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class AddBtn : Gtk.Window
    {
        public AddBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            idRandom();
            this.Hide();

            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void OnButton4Clicked(object sender, EventArgs e)
        {
            MessageDialog mensaje = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Ha cancelado");
            mensaje.Run();
            mensaje.Destroy();
        }

        protected void OnButton2Clicked(object sender, EventArgs e)
        {


            ConnectionEyS conecction = ConnectionEyS.OpenConnection();

            if (!(
                    entry1.Text.Length == 0 || 
                    entry2.Text.Length == 0 || 
                    entry3.Text.Length == 0 ||
                    entry4.Text.Length == 0 ||
                    entry5.Text.Length == 0 ||
                    entry6.Text.Length == 0
                ))
            {

                //No change to BDSistemaEyS.Empleado, only Empleado :c.
                String Query = "INSERT INTO Empleado (idEmpleado, primerNombre, segundoNombre, primerApellido, segundoApellido, password) VALUES ('" + entry1.Text + "','" + entry2.Text + "' , '"
                                + entry3.Text + "' , '" + entry4.Text + "' , '" + entry5.Text + "' , '" + entry6.Text + "');";

                MySqlCommand command = new MySqlCommand(Query, conecction.conn);
                conecction.Execute(CommandType.Text, Query);

                ConnectionEyS.CloseConnection();

                MessageDialog mensaje = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Agregado");
                mensaje.Run();
                mensaje.Destroy();
                cleanBtn();

            }
            else
            {
                MessageDialog mensaje = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "No pueden haber datos vacios");
                mensaje.Run();
                mensaje.Destroy();
                cleanBtn();
            }
        }

        // Funcion to clean all entrys
        public void cleanBtn()
        {
            entry1.Text = "";
            entry2.Text = "";
            entry3.Text = "";
            entry4.Text = "";
            entry5.Text = "";
            entry6.Text = "";
        }

        //Generate a idRandom
        public void idRandom()
        {
            entry1.Text = "";
            Random r = new Random();
            entry1.Text = Convert.ToString(r.Next(10000, 100000));
        }

    }
}
