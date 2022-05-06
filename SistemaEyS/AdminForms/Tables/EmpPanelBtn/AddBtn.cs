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
            Random r = new Random();
            entry1.Text = Convert.ToString(r.Next(1000, 10000));

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

            ConnectionSeg conecction = ConnectionSeg.OpenConnection();

            String Query = "INSERT INTO tbl_user (id_user, user, pwd, nombres, apellidos, email, pwd_temp, estado) VALUES ('" + entry1.Text + "','" + entry2.Text + "' , '"
                            + entry3.Text + "' , '" + entry4.Text + "' , '" + entry5.Text + "' , '" + entry6.Text + "' , '" + entry7.Text + "' , '" + entry8.Text + "');";

            MySqlCommand command = new MySqlCommand(Query, conecction.conn);
            conecction.Execute(CommandType.Text,Query);
          
            ConnectionSeg.CloseConnection();

            MessageDialog mensaje = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Agregado");
            mensaje.Run();
            mensaje.Destroy();

           
        }
    }
}
