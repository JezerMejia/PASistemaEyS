using System;
using Gtk;
using SistemaEyS.DatosSeguridad;
using SistemaEyS.Database.Connection;
using System.Data;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class UserSeguridad : Gtk.Window
    {
        Dt_tlb_user dt_user = new Dt_tlb_user();
        TreeModelFilter datos;
        TreeModelFilterVisibleFunc modelFilterVisibleFunc;
        int SelectedID = -1;

        public UserSeguridad() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();

            this.modelFilterVisibleFunc = new TreeModelFilterVisibleFunc(this.TreeModelFilterVisible);

            this.datos = new TreeModelFilter(dt_user.listarUsuarios(), null);
            this.datos.VisibleFunc = this.modelFilterVisibleFunc;

            this.viewTable.SearchEntry = this.TxtSearch;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);
            
            this.CmbxID.Entry.WidthChars = 16;

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

            this.viewTable.Model = this.datos;

            this.FillComboboxModel();
        }

        protected void FillComboboxModel()
        {
            ListStore store = (ListStore)this.CmbxID.Model;
            store.Clear();
            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    this.CmbxID.InsertText(
                        Convert.ToInt32(datos.GetValue(iter, 0)),
                        (String)datos.GetValue(iter, 0)
                    );
                }
                while (datos.IterNext(ref iter));
            }

            this.CmbxID.Entry.Completion = new EntryCompletion();
            this.CmbxID.Entry.Completion.Model = datos;
            this.CmbxID.Entry.Completion.TextColumn = 0;
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

            Console.WriteLine(Query);

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
        }

        protected void BtnRemoveOnClicked(object sender, EventArgs args)
        {
            ConnectionSeg connection = ConnectionSeg.OpenConnection();

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
        }

        protected void ViewTableOnRowActivated(object o, RowActivatedArgs args)
        {
            TreeSelection selection = this.viewTable.Selection;
            TreeIter iter;
            TreeModel model;

            if (selection.GetSelected(out model, out iter))
            {
                this.CmbxID.Entry.Text = (string) model.GetValue(iter, 0);
            }
        }

        protected void BtnUpdateOnClicked(object sender, EventArgs e)
        {
            this.datos = new TreeModelFilter(dt_user.listarUsuarios(), null);
            this.datos.VisibleFunc = this.modelFilterVisibleFunc;
            this.viewTable.Model = this.datos;
            this.FillComboboxModel();
        }

        protected void CmbxIdOnChanged(object sender, EventArgs args)
        {
            string id = this.CmbxID.ActiveText;
            try
            {
                this.SelectedID = Int32.Parse(id);
            }
            catch (Exception e)
            {
                return;
            }

            TreeIter iter;
            if (datos.GetIterFirst(out iter))
            {
                do
                {
                    if (id == (string)datos.GetValue(iter, 0))
                    {
                        this.TxtUser.Text = (string) datos.GetValue(iter, 1);
                        this.TxtName.Text = (string) datos.GetValue(iter, 3);
                        this.TxtLastname.Text = (string) datos.GetValue(iter, 4);
                        this.TxtEmail.Text = (string) datos.GetValue(iter, 5);
                        this.TxtPassword.Text = (string) datos.GetValue(iter, 2);
                        return;
                    }
                    else
                    {
                        this.TxtUser.Text = "";
                        this.TxtName.Text = "";
                        this.TxtLastname.Text = "";
                        this.TxtEmail.Text = "";
                        this.TxtPassword.Text = "";
                    }
                }
                while (datos.IterNext(ref iter));
            }
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
            Console.WriteLine($"'{this.TxtSearch.Text}' at '{path.ToString()}'");
            if (string.IsNullOrWhiteSpace(this.TxtSearch.Text))
            {
                Console.WriteLine("Empty search");
                return true;
            }
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                Console.WriteLine($"\t{i}: '{value}'");
                if (value.ToLower().Contains(this.TxtSearch.Text.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        protected void TxtSearchOnChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Changed: '{this.TxtSearch.Text}'");
            this.datos.Refilter();
        }
    }
}
