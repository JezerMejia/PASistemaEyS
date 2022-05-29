using System;
using Gtk;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.DatosEyS.Negocio;

namespace SistemaEyS.UserForms
{
    public partial class UserLogin : Gtk.Window
    {
        protected Window parent;
        protected Neg_Empleado NegEmp = new Neg_Empleado();

        public UserLogin(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
        }

        public void Close()
        {
            this.Destroy();
            this.parent.Show();
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void btnEnterOnClicked(object sender, EventArgs argss)
        {
            Ent_Empleado empleado;
            try
            {
                if (string.IsNullOrWhiteSpace(this.entUser.Text))
                    throw new ArgumentException("Escriba un nombre de usuario");

                if (string.IsNullOrWhiteSpace(this.entPassword.Text))
                    throw new ArgumentException("Escriba una contraseña");

                string userID = this.entUser.Text;

                empleado = this.NegEmp.SearchEmpleado(Int32.Parse(userID));

                if (empleado.pinEmpleado != this.entPassword.Text)
                    throw new Exception("Contraseña incorrecta");

                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    $"¡Bienvenido, {empleado.GetFullName()}!");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
                return;
            }

            UserAssistanceForm assistanceForm = new UserAssistanceForm(this, empleado.idEmpleado);
            assistanceForm.Show();
            this.Hide();

            this.entPassword.Text = "";
            this.entUser.Text = "";
        }
    }
}
