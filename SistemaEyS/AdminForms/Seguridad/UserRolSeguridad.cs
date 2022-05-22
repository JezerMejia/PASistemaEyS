using System;
using Gtk;
using SistemaEyS.DatosSeguridad;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class UserRolSeguridad : Gtk.Window
    {
        protected Dt_tbl_rol DtRol = new Dt_tbl_rol();
        protected Dt_tbl_user DtUser = new Dt_tbl_user();
        protected Dt_tbl_user_rol DtUserRol = new Dt_tbl_user_rol();

        protected ListStore DataRol;
        protected ListStore DataUser;

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;
        public int SelectedUser = -1;
        public int SelectedRol = -1;

        public UserRolSeguridad() :
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
                new StoreObject("Rol", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtUserRol.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;

            this.DataUser = DtUser.GetDataCmbx();
            this.DataRol = DtRol.GetDataCmbx();
            this.CmbxRol.Model = this.DataRol;
            this.CmbxUsuario.Model = this.DataUser;
            this.FillCmbxUsuarioModel();
            this.FillCmbxRolModel();
        }
        protected void FillCmbxUsuarioModel()
        {
            this.CmbxUsuario.Model = this.DataUser;
            this.CmbxUsuario.Active = -1;

            this.CmbxUsuario.Entry.Completion = new EntryCompletion();
            this.CmbxUsuario.Entry.Completion.Model = this.DataUser;
            this.CmbxUsuario.Entry.Completion.TextColumn = 0;
        }

        protected void FillCmbxRolModel()
        {
            this.CmbxRol.Model = this.DataRol;
            this.CmbxRol.Active = -1;

            this.CmbxRol.Entry.Completion = new EntryCompletion();
            this.CmbxRol.Entry.Completion.Model = this.DataRol;
            this.CmbxRol.Entry.Completion.TextColumn = 0;
        }

        protected void BtnNewOnClicked(object sender, EventArgs e)
        {
            this.SelectedID = -1;
            this.CmbxRol.Active = -1;
            this.CmbxRol.Entry.Text = "";
            this.CmbxUsuario.Active = -1;
            this.CmbxUsuario.Entry.Text = "";
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            if (string.IsNullOrWhiteSpace(this.CmbxUsuario.ActiveText))
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Seleccione un Usuario");
                ms.Run();
                ms.Destroy();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.CmbxRol.ActiveText))
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Seleccione un Rol");
                ms.Run();
                ms.Destroy();
                return;
            }

            string idUser = this.GetUserID();
            string idRol = this.GetRolID();

            try
            {
                this.DtUserRol.InsertInto(
                    idUser,
                    idRol
                    );
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Rol asignado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok,
                    e.Message);
                Console.WriteLine(e);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void BtnEditOnClicked(object sender, EventArgs args)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok,
                    "Seleccione un rol en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.CmbxRol.ActiveText) ||
                string.IsNullOrWhiteSpace(this.CmbxUsuario.ActiveText))
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "No puede haber datos vacíos");
                ms.Run();
                ms.Destroy();
                return;
            }

            string idUsuario = this.GetUserID();
            string idRol = this.GetRolID();

            try
            {
                this.DtUserRol.UpdateSet(
                    this.SelectedID.ToString(),
                    idUsuario, idRol
                    );
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Asignación de Rol editada");
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
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok,
                    "Seleccione un rol en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }

            string userName = this.GetUserValue(this.SelectedUser, 0)?.ToString() ?? "";
            string rolName = this.GetRolValue(this.SelectedRol, 0)?.ToString() ?? "";

            MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                MessageType.Question, ButtonsType.YesNo,
                $"¿Desea eliminar la asignación \"{userName} - {rolName}\" ({this.SelectedID})?");
            int result = deletePrompt.Run();
            deletePrompt.Destroy();

            switch (result)
            {
                case (int)ResponseType.Yes:
                    break;
                default:
                    return;
            }

            try
            {
                this.DtUserRol.DeleteFrom(this.SelectedID.ToString());
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Asignación de Rol eliminada");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok,
                    e.Message);
                Console.WriteLine(e);
                ms.Run();
                ms.Destroy();
            }
            this.SelectedID = -1;
            this.UpdateData();
        }

        protected object GetUserRolValue(int idUserRol, int column)
        {
            TreeIter iter;
            TreeModel model = this.TreeData;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idUserRol.ToString() == model.GetValue(iter, 0).ToString())
                    {
                        value = model.GetValue(iter, column);
                    }
                } while (model.IterNext(ref iter));
            }

            return value;
        }
        protected object GetUserValue(int idUser, int column)
        {
            TreeIter iter;
            TreeModel model = this.DataUser;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idUser.ToString() == model.GetValue(iter, 1).ToString())
                    {
                        value = model.GetValue(iter, column);
                    }
                } while (model.IterNext(ref iter));
            }

            return value;
        }
        protected object GetRolValue(int idRol, int column)
        {
            TreeIter iter;
            TreeModel model = this.DataRol;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idRol.ToString() == model.GetValue(iter, 1).ToString())
                    {
                        value = model.GetValue(iter, column);
                    }
                } while (model.IterNext(ref iter));
            }

            return value;
        }

        protected string GetUserID()
        {
            string idText = this.CmbxUsuario.ActiveText;
            string userID = "";
            TreeModel model = this.CmbxUsuario.Model;
            TreeIter iter;
            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idText == model.GetValue(iter, 0).ToString())
                    {
                        userID = model.GetValue(iter, 1).ToString();
                        break;
                    }
                }
                while (model.IterNext(ref iter));
            }

            return userID;
        }
        protected string GetRolID()
        {
            string idText = this.CmbxRol.ActiveText;
            string rolID = "";
            TreeModel model = this.CmbxRol.Model;
            TreeIter iter;
            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idText == model.GetValue(iter, 0).ToString())
                    {
                        rolID = model.GetValue(iter, 1).ToString();
                        break;
                    }
                }
                while (model.IterNext(ref iter));
            }

            return rolID;
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
                    this.SelectedUser = Int32.Parse(model.GetValue(iter, 1).ToString());
                    this.SelectedRol = Int32.Parse(model.GetValue(iter, 2).ToString());
                    this.SetEntryTextFromID(this.SelectedID);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        protected int GetIndexFromValue(ComboBox comboBox, string value)
        {
            int index = -1;
            TreeModel model = comboBox.Model;
            TreeIter iter;

            if (value == "")
            {
                return 0;
            }

            int i = 0;
            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (value == (string)model.GetValue(iter, 1))
                    {
                        index = i;
                        break;
                    }
                    i++;
                } while (model.IterNext(ref iter));
            }

            return index;
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
                        this.CmbxUsuario.Active = this.GetIndexFromValue(
                            this.CmbxUsuario, (string)this.TreeData.GetValue(iter, 1));
                        this.CmbxRol.Active = this.GetIndexFromValue(
                            this.CmbxRol, (string)this.TreeData.GetValue(iter, 2)); ;
                        return;
                    }
                    else
                    {
                        this.CmbxRol.Active = -1;
                        this.CmbxUsuario.Active = -1;
                    }
                }
                while (TreeData.IterNext(ref iter));
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
    }
}
