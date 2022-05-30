using System;
using Gtk;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using SistemaEyS.DatosSeguridad.Negocio;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class RolOpcionSeguridad : Gtk.Window
    {
        protected Neg_rol_opcion NegRolOpcion = new Neg_rol_opcion();
        protected Neg_rol NegRol = new Neg_rol();
        protected Neg_opcion NegOpcion = new Neg_opcion();

        protected Dt_tbl_rol DtRol = new Dt_tbl_rol();
        protected Dt_tbl_opcion DtOpc = new Dt_tbl_opcion();
        protected Dt_tbl_rol_opcion DtRolOpc = new Dt_tbl_rol_opcion();

        protected ListStore DataRol;
        protected ListStore DataOpcion;

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;
        public int SelectedRol = -1;
        public int SelectedOpcion = -1;


        public RolOpcionSeguridad() :
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
                new StoreObject("Rol", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Opcion", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtRolOpc.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;

            this.DataRol = DtRol.GetDataCmbx();
            this.DataOpcion = DtOpc.GetDataCmbx();
            this.rolTxt.Model = this.DataRol;
            this.opcionTxt.Model = this.DataOpcion;
            this.FillCmbxRolModel();
            this.FillCmbxOpcionModel();
        }

        protected void FillCmbxRolModel()
        {
            this.rolTxt.Model = this.DataRol;
            this.rolTxt.Active = -1;

            this.rolTxt.Entry.Completion = new EntryCompletion();
            this.rolTxt.Entry.Completion.Model = this.DataRol;
            this.rolTxt.Entry.Completion.TextColumn = 0;
        }

        protected void FillCmbxOpcionModel()
        {
            this.opcionTxt.Model = this.DataOpcion;
            this.opcionTxt.Active = -1;

            this.opcionTxt.Entry.Completion = new EntryCompletion();
            this.opcionTxt.Entry.Completion.Model = this.DataOpcion;
            this.opcionTxt.Entry.Completion.TextColumn = 0;
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

        protected void ClearInput()
        {
            this.SelectedID = -1;
            this.rolTxt.Active = -1;
            this.rolTxt.Entry.Text = "";
            this.opcionTxt.Active = -1;
            this.opcionTxt.Entry.Text = "";
        }

        protected void OnBtnNewClicked(object sender, EventArgs e)
        {
            this.ClearInput();
        }

        protected void OnBtnAddClicked(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.rolTxt.ActiveText))
                {
                    throw new ArgumentException("Ingrese un rol");
                }
                if (string.IsNullOrWhiteSpace(this.opcionTxt.ActiveText))
                {
                    throw new ArgumentException("Seleccione una Opcion");
                }
                string idRol = this.rolTxt.ActiveText;
                string idOpcion = this.opcionTxt.ActiveText;

                Ent_rol_opcion RolOpcion = new Ent_rol_opcion()
                {
                  id_rol = Int32.Parse(idRol),
                  id_opcion = Int32.Parse(idOpcion),

                };
                this.NegRolOpcion.AddRolOpcion(RolOpcion);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Rol asignado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void OnBtnEditClicked(object sender, EventArgs args)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException("Seleccione un Rol en la tabla");
                }
                if (string.IsNullOrWhiteSpace(this.rolTxt.ActiveText) ||
                    string.IsNullOrWhiteSpace(this.opcionTxt.ActiveText))
                {
                    throw new ArgumentException("No puede haber datos vacíos");
                }
                string idRol = this.rolTxt.ActiveText;
                string idOpcion = this.opcionTxt.ActiveText;

                Ent_rol_opcion rolOpcion = new Ent_rol_opcion()
                {
                    id_rolOpcion = this.SelectedID,
                    id_rol = Int32.Parse(idRol),
                    id_opcion = Int32.Parse(idOpcion),
                };
                this.NegRolOpcion.EditRolOpcion(rolOpcion);

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

        protected void OnBtnRemoveClicked(object sender, EventArgs args)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException("Seleccione un Rol en la tabla");
                }

                Ent_rol_opcion RolOpcion = this.NegRolOpcion.SearchRolOpcion(this.SelectedID);

                MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar el rol \"{RolOpcion.id_opcion}\" ({this.SelectedID})?");
                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegRolOpcion.RemoveRolOpcion(RolOpcion);
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Rol eliminado");
                ms.Run();
                ms.Destroy();
                this.ClearInput();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok,
                    ex.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected string idRol()
        {
            string idText = this.rolTxt.ActiveText;
            string userID = "";
            TreeModel model = this.rolTxt.Model;
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

        protected string idOpcion()
        {
            string idText = this.opcionTxt.ActiveText;
            string rolID = "";
            TreeModel model = this.opcionTxt.Model;
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
                    this.SelectedRol = Int32.Parse(model.GetValue(iter, 1).ToString());
                    this.SelectedOpcion = Int32.Parse(model.GetValue(iter, 2).ToString());
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
                Ent_rol_opcion RolOpcion = this.NegRolOpcion.SearchRolOpcion(id);

                this.rolTxt.Active = this.GetIndexFromValue(
                    this.rolTxt, RolOpcion.id_rol.ToString());
                this.opcionTxt.Active = this.GetIndexFromValue(
                    this.opcionTxt, RolOpcion.id_opcion.ToString());
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
       
    }
}
