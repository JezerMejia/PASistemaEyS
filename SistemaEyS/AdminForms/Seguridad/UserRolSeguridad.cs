using System;
using Gtk;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using SistemaEyS.DatosSeguridad.Negocio;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class UserRolSeguridad : Gtk.Window
    {
        protected Neg_user_rol NegUserRol = new Neg_user_rol();
        protected Neg_user NegUser = new Neg_user();
        protected Neg_rol NegRol = new Neg_rol();

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
            this.TreeData = new TreeModelFilter(DtUserRol.GetDataView(), null);
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

        protected void ClearInput()
        {
            this.SelectedID = -1;
            this.CmbxRol.Active = -1;
            this.CmbxRol.Entry.Text = "";
            this.CmbxUsuario.Active = -1;
            this.CmbxUsuario.Entry.Text = "";
        }

        protected void BtnNewOnClicked(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.CmbxUsuario.ActiveText))
                {
                    throw new ArgumentException("Seleccione un Usuario");
                }
                if (string.IsNullOrWhiteSpace(this.CmbxRol.ActiveText))
                {
                    throw new ArgumentException("Seleccione un Rol");
                }
                string idUser = this.GetUserID();
                string idRol = this.GetRolID();

                Ent_user_rol userRol = new Ent_user_rol()
                {
                    id_user = Int32.Parse(idUser),
                    id_rol = Int32.Parse(idRol),
                };
                this.NegUserRol.AddUserRol(userRol);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Rol asignado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok,
                    e.Message);
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
                    throw new ArgumentException("Seleccione un Rol en la tabla");
                }
                if (string.IsNullOrWhiteSpace(this.CmbxRol.ActiveText) ||
                    string.IsNullOrWhiteSpace(this.CmbxUsuario.ActiveText))
                {
                    throw new ArgumentException("No puede haber datos vacíos");
                }

                string idUser = this.GetUserID();
                string idRol = this.GetRolID();

                Ent_user_rol userRol = new Ent_user_rol()
                {
                    id_UserRol = this.SelectedID,
                    id_user = Int32.Parse(idUser),
                    id_rol = Int32.Parse(idRol),
                };
                this.NegUserRol.EditUserRol(userRol);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Asignación de Rol editada");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
                    throw new ArgumentException("Seleccione un Rol en la tabla");
                }

                Ent_user_rol userRol = this.NegUserRol.SearchUserRol(this.SelectedID);
                Ent_user user = this.NegUser.SearchUser(userRol.id_user);
                Ent_rol rol = this.NegRol.SearchRol(userRol.id_rol);

                string userName = user.nombres + " " + user.apellidos;
                string rolName = rol.rol;

                MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar la asignación \"{userName} - {rolName}\" ({this.SelectedID})?");
                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegUserRol.RemoveUserRol(userRol);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Asignación de Rol eliminada");
                ms.Run();
                ms.Destroy();
                this.ClearInput();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, e.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
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
            try
            {
                Ent_user_rol UserRol = this.NegUserRol.SearchUserRol(id);

                this.CmbxUsuario.Active = this.GetIndexFromValue(
                    this.CmbxUsuario, UserRol.id_user.ToString());
                this.CmbxRol.Active = this.GetIndexFromValue(
                    this.CmbxRol, UserRol.id_rol.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
            if (string.IsNullOrWhiteSpace(this.TxtSearch.Text))
            {
                return true;
            }
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                if (string.IsNullOrEmpty(value)) return false;
                if (value.ToLower().Contains(this.TxtSearch.Text.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        protected void TxtSearchOnChanged(object sender, EventArgs e)
        {
            this.TreeData.Refilter();
        }
    }
}
