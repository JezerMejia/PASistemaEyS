using System;
using Gtk;
using SistemaEyS.DatosSeguridad;
using SistemaEyS.Database.Connection;
using System.Data;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class UserSeguridad : Gtk.Window
    {
        Dt_tlb_user DtUser = new Dt_tlb_user();
        TreeModelFilter TreeData;
        TreeModelFilterVisibleFunc ModelFilterFunc;
        int SelectedID = -1;

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
                new StoreObject("Estado", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtUser.listarUsuarios(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            //this.FillComboboxModel();
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            ConnectionSeg connection = ConnectionSeg.OpenConnection();

            if (string.IsNullOrWhiteSpace(TxtName.Text) ||
                string.IsNullOrWhiteSpace(TxtLastname.Text) ||
                string.IsNullOrWhiteSpace(TxtUser.Text) ||
                string.IsNullOrWhiteSpace(TxtPassword.Text) ||
                string.IsNullOrWhiteSpace(TxtEmail.Text)
                )
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "No puede haber datos vacíos");
                ms.Run();
                ms.Destroy();
                return;
            }

            if (!TxtEmail.Text.Equals(TxtEmailConfirm.Text)) {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "El Email y la confirmación no coinciden");
                ms.Run();
                ms.Destroy();
                return;
            }
            if (!TxtPassword.Text.Equals(TxtPasswordConfirm.Text)) {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "La Contraseña y la confirmación no coinciden");
                ms.Run();
                ms.Destroy();
                return;
            }

            string Query = "INSERT INTO Seguridad.tbl_user (" +
                    "user, pwd, estado, " +
                    "nombres, apellidos, email) " +
                    "VALUES (" +
                    $"'{TxtUser.Text}', '{TxtPassword.Text}', 1," +
                    $"'{TxtName.Text}', '{TxtLastname.Text}', '{TxtEmail.Text}');";

            try
            {
                connection.Execute(CommandType.Text, Query);
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
            ConnectionSeg connection = ConnectionSeg.OpenConnection();

            if (string.IsNullOrWhiteSpace(TxtName.Text) ||
                string.IsNullOrWhiteSpace(TxtLastname.Text) ||
                string.IsNullOrWhiteSpace(TxtUser.Text) ||
                string.IsNullOrWhiteSpace(TxtPassword.Text) ||
                string.IsNullOrWhiteSpace(TxtEmail.Text)
                )
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "No puede haber datos vacíos");
                ms.Run();
                ms.Destroy();
                return;
            }

            if (!TxtEmail.Text.Equals(TxtEmailConfirm.Text)) {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "El Email y la confirmación no coinciden");
                ms.Run();
                ms.Destroy();
                return;
            }
            if (!TxtPassword.Text.Equals(TxtPasswordConfirm.Text)) {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, "La Contraseña y la confirmación no coinciden");
                ms.Run();
                ms.Destroy();
                return;
            }

            string Query = "UPDATE Seguridad.tbl_user SET " +
                    $"user = '{TxtUser.Text}', pwd = '{TxtPassword.Text}', estado = 2, " +
                    $"nombres = '{TxtName.Text}', apellidos = '{TxtLastname.Text}', " +
                    $"email = '{TxtEmail.Text}' " +
                    $"WHERE id_user = '{this.SelectedID}'";

            try
            {
                connection.Execute(CommandType.Text, Query);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Usuario editado");
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

        protected object GetUserValue(int idUser, int column)
        {
            TreeIter iter;
            TreeModel model = this.TreeData;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idUser.ToString() == model.GetValue(iter, 0).ToString())
                    {
                        value = model.GetValue(iter, column);
                    }
                } while (model.IterNext(ref iter));
            }

            return value;
        }

        protected void BtnRemoveOnClicked(object sender, EventArgs args)
        {
            ConnectionSeg connection = ConnectionSeg.OpenConnection();

            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Seleccione un usuario en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }

            string userName = this.GetUserValue(this.SelectedID, 3)?.ToString() ?? "";
            string userLastname = this.GetUserValue(this.SelectedID, 4).ToString() ?? "";
            string userFullname = $"{userName} {userLastname}";

            MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                MessageType.Question, ButtonsType.YesNo,
                $"¿Desea eliminar el usuario \"{userFullname}\" ({this.SelectedID})?");
            int result = deletePrompt.Run();
            deletePrompt.Destroy();

            switch (result)
            {
                case (int) ResponseType.Yes:
                    break;
                default:
                    return;
            }

            string Query = "UPDATE Seguridad.tbl_user SET " +
                    $"estado = 3 " +
                    $"WHERE id_user = '{this.SelectedID}'";

            try
            {
                connection.Execute(CommandType.Text, Query);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal, MessageType.Info,
                    ButtonsType.Ok, "Usuario eliminado");
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
                catch (Exception e)
                {
                    return;
                }
            }
        }

        protected void SetEntryTextFromID(int id)
        {
            TreeIter iter;
            if (this.TreeData.GetIterFirst(out iter))
            {
                do
                {
                    if (id.ToString() == (string)this.TreeData.GetValue(iter, 0))
                    {
                        this.TxtUser.Text = (string)TreeData.GetValue(iter, 1);
                        this.TxtName.Text = (string)TreeData.GetValue(iter, 3);
                        this.TxtLastname.Text = (string)TreeData.GetValue(iter, 4);
                        this.TxtEmail.Text = (string)TreeData.GetValue(iter, 5);
                        this.TxtEmailConfirm.Text = "";
                        this.TxtPassword.Text = (string)TreeData.GetValue(iter, 2);
                        this.TxtPasswordConfirm.Text = "";
                        return;
                    }
                    else
                    {
                        this.TxtUser.Text = "";
                        this.TxtName.Text = "";
                        this.TxtLastname.Text = "";
                        this.TxtEmail.Text = "";
                        this.TxtEmailConfirm.Text = "";
                        this.TxtPassword.Text = "";
                        this.TxtPasswordConfirm.Text = "";
                    }
                }
                while (TreeData.IterNext(ref iter));
            }
        }

        protected void BtnUpdateOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }

        protected bool ViewTableEqualFunc(TreeModel model, int column, string key, TreeIter iter)
        {
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
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

        protected void BtnNewOnClicked(object sender, EventArgs e)
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
    }
}
