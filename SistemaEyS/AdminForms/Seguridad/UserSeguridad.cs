using System;
using Gtk;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using SistemaEyS.DatosSeguridad.Negocio;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class UserSeguridad : Gtk.Window
    {
        protected Dt_tbl_user DtUser = new Dt_tbl_user();
        protected Neg_user NegUser = new Neg_user();

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        public UserSeguridad() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();

            this.ModelFilterFunc = new TreeModelFilterVisibleFunc(this.TreeModelFilterVisible);

            this.viewTable.SearchEntry = this.TxtSearch;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);

            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Usuario", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Contraseña", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Contraseña temporal", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtUser.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            //this.FillComboboxModel();
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtName.Text) ||
                    string.IsNullOrWhiteSpace(TxtLastname.Text) ||
                    string.IsNullOrWhiteSpace(TxtUser.Text) ||
                    string.IsNullOrWhiteSpace(TxtPassword.Text) ||
                    string.IsNullOrWhiteSpace(TxtEmail.Text)
                    )
                {
                    throw new ArgumentException("No puede haber datos vacíos");
                }
                if (!TxtEmail.Text.Equals(TxtEmailConfirm.Text))
                {
                    throw new ArgumentException(
                        "El Email y la confirmación no coinciden"
                        );
                }
                if (!TxtPassword.Text.Equals(TxtPasswordConfirm.Text))
                {
                    throw new ArgumentException(
                        "La Contraseña y la confirmación no coinciden"
                        );
                }

                Ent_user user = new Ent_user()
                {
                    user = this.TxtUser.Text,
                    pwd = this.TxtPassword.Text,
                    nombres = this.TxtName.Text,
                    apellidos = this.TxtLastname.Text,
                    email = this.TxtEmail.Text,
                    estado = EntidadEstado.Añadido
                };
                this.NegUser.AddUser(user);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Usuario agregado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void BtnEditOnClicked(object sender, EventArgs args)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException(
                        "No se ha seleccionado un usuario"
                        );
                }

                if (string.IsNullOrWhiteSpace(TxtName.Text) ||
                    string.IsNullOrWhiteSpace(TxtLastname.Text) ||
                    string.IsNullOrWhiteSpace(TxtUser.Text) ||
                    string.IsNullOrWhiteSpace(TxtPassword.Text) ||
                    string.IsNullOrWhiteSpace(TxtEmail.Text)
                    )
                {
                    throw new ArgumentException("No puede haber datos vacíos");
                }

                if (!TxtEmail.Text.Equals(TxtEmailConfirm.Text))
                {
                    throw new ArgumentException(
                        "El Email y la confirmación no coinciden"
                    );
                }
                if (!TxtPassword.Text.Equals(TxtPasswordConfirm.Text))
                {
                    throw new ArgumentException(
                        "La Contraseña y la confirmación no coinciden"
                    );
                }

                Ent_user user = new Ent_user()
                {
                    id_user = this.SelectedID,
                    user = this.TxtUser.Text,
                    pwd = this.TxtPassword.Text,
                    nombres = this.TxtName.Text,
                    apellidos = this.TxtLastname.Text,
                    email = this.TxtEmail.Text,
                    estado = EntidadEstado.Modificado
                };
                this.NegUser.EditUser(user);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Usuario editado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void BtnRemoveOnClicked(object sender, EventArgs args)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "No se ha seleccionado un usuario"
                        );
                }

                Ent_user user = this.NegUser.SearchUser(this.SelectedID);
                string userFullname = $"{user.nombres} {user.apellidos}";

                MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar el usuario \"{userFullname}\" ({this.SelectedID})?");
                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegUser.RemoveUser(user);
                this.ClearInput();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void BtnUpdateOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }

        protected void ClearInput()
        {
            this.SelectedID = -1;
            this.TxtUser.Text = "";
            this.TxtName.Text = "";
            this.TxtLastname.Text = "";
            this.TxtEmail.Text = "";
            this.TxtEmailConfirm.Text = "";
            this.TxtPassword.Text = "";
            this.TxtPasswordConfirm.Text = "";
        }

        protected void BtnNewOnClicked(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        protected void ViewTableOnRowActivated(object o, RowActivatedArgs args)
        {
            TreeSelection selection = this.viewTable.Selection;
            TreeIter iter;
            TreeModel model;

            if (selection.GetSelected(out model, out iter))
            {
                string selectedID = model.GetValue(iter, 0).ToString();
                try
                {
                    this.SelectedID = Int32.Parse(selectedID);
                    this.SetEntryTextFromID(this.SelectedID);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        protected void SetEntryTextFromID(int id)
        {
            try
            {
                Ent_user user = this.NegUser.SearchUser(id);

                this.TxtUser.Text = user.user;
                this.TxtName.Text = user.nombres;
                this.TxtLastname.Text = user.apellidos;
                this.TxtEmail.Text = user.email;
                this.TxtEmailConfirm.Text = "";
                this.TxtPassword.Text = user.pwd;
                this.TxtPasswordConfirm.Text = "";
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
        }

        protected bool ViewTableEqualFunc(TreeModel model, int column, string key, TreeIter iter)
        {
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                if (string.IsNullOrWhiteSpace(value)) return true;
                if (value.ToLower().Contains(key.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }

        protected bool TreeModelFilterVisible(TreeModel model, TreeIter iter)
        {
            TreePath path = model.GetPath(iter);
            //Console.WriteLine($"'{this.TxtSearch.Text}' at '{path.ToString()}'");
            if (string.IsNullOrWhiteSpace(this.TxtSearch.Text))
            {
                //Console.WriteLine("Empty search");
                return true;
            }
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                if (string.IsNullOrEmpty(value)) return false;
                //Console.WriteLine($"\t{i}: '{value}'");
                if (value.ToLower().Contains(this.TxtSearch.Text.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        protected void TxtSearchOnChanged(object sender, EventArgs e)
        {
            //Console.WriteLine($"Changed: '{this.TxtSearch.Text}'");
            this.TreeData.Refilter();
        }
    }
}
