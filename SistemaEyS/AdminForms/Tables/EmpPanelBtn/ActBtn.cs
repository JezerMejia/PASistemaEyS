using System;
using System.Data;
using Gtk;
using MySql.Data.MySqlClient;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosEyS;
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
    public partial class ActBtn : Gtk.Window
    {
        Dt_tlb_empleado dtus = new Dt_tlb_empleado();
        ListStore datos;

        public ActBtn() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            this.datos = dtus.listarUsuarios();
            llenarcbxUser();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
        }

        protected void llenarcbxUser()
        {
            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    this.comboboxentry2.InsertText(
                        Convert.ToInt32(datos.GetValue(iter, 0)),
                        (String)datos.GetValue(iter, 0)
                    );
                }
                while (datos.IterNext(ref iter));
            }

            comboboxentry2.Entry.Completion = new EntryCompletion();
            comboboxentry2.Entry.Completion.Model = datos;
            comboboxentry2.Entry.Completion.TextColumn = 0;
        }

        protected void ComboBoxOnChanged(object sender, EventArgs e)
        {
            string id = this.comboboxentry2.ActiveText;

            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    if (id == (string)datos.GetValue(iter, 0))
                    {
                        this.name.Text = (string)datos.GetValue(iter, 1);
                        this.secondName.Text = (string)datos.GetValue(iter, 2);
                        this.surname.Text = (string)datos.GetValue(iter, 3);
                        this.secondSurname.Text = (string)datos.GetValue(iter, 4);
                        this.dIngress.Text = (string)datos.GetValue(iter, 5);
                        this.Icard.Text = (string)datos.GetValue(iter, 6);
                        this.password.Text = (string)datos.GetValue(iter, 7);
                        this.idCar.Text = (string)datos.GetValue(iter, 8);
                        this.idDep.Text = (string)datos.GetValue(iter, 9);
                        this.idHor.Text = (string)datos.GetValue(iter, 10);
                        this.idGroup.Text = (string)datos.GetValue(iter, 11);
                        return;
                    }
                }
                while (datos.IterNext(ref iter));
            }
        }

        protected void OnButton5Clicked(object sender, EventArgs e)
        {

            ConnectionEyS connection = ConnectionEyS.OpenConnection();


            if (comboboxentry2.Active.Equals(-1)) {

                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Escoga un empleado");
                ms.Run();
                ms.Destroy();

            }
            else {
            

                String Query = "UPDATE BDSistemaEyS.Empleado SET idEmpleado = '" + newId.Text + 
                                                         "', primerNombre='"+ name.Text +
                                                         "', segundoNombre= '"+ secondName.Text +
                                                         "', primerApellido= '"+ surname.Text +
                                                         "', segundoApellido= '"+ secondSurname.Text +
                                                         "', cedulaEmpleado= '"+ Icard.Text+
                                                         "', password= '"+ password.Text +
                                                         "', idCargo= '" + idCar.Text +
                                                         "', idDepartamento= '" + idDep.Text +
                                                         "', idHorario= '" + idHor.Text +
                                                         "', idGrupo= '" + idGroup.Text +
                                                         "'WHERE (idEmpleado = '" + comboboxentry2.ActiveText + "');";


                try
                {
                    connection.Execute(CommandType.Text, Query);
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                        ButtonsType.Ok, "Guardado");
                    ms.Run();
                    ms.Destroy();
                    ClearInput();
                }
                catch (Exception ex)
                {
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                        ButtonsType.Ok, ex.Message);
                    ms.Run();
                    ms.Destroy();
                }
                  
            }

        }

        public void ClearInput()
        {
            this.comboboxentry2.Active = -1;
            this.comboboxentry2.Entry.Text = "";
            this.newId.Text = "";
            this.name.Text = "";
            this.secondName.Text = "";
            this.surname.Text = "";
            this.secondSurname.Text = "";
            this.dIngress.Text = "";
            this.Icard.Text = "";
            this.password.Text = "";
            this.idCar.Text = "";
        }

        public void SetIDRandom()
        {
            Random r = new Random();
            this.newId.Text = Convert.ToString(r.Next(10000, 100000));
        }

        protected void OnButton4Clicked(object sender, EventArgs e)
        {
            this.ClearInput();
            this.Hide();
        }
    }
}
