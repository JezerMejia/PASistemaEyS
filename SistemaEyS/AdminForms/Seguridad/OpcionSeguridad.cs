using System;
using Gtk;
using SistemaEyS.DatosSeguridad.Datos;
using SistemaEyS.DatosSeguridad.Entidades;
using SistemaEyS.DatosSeguridad.Negocio;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class OpcionSeguridad : Gtk.Window
    {

        protected Dt_tbl_opcion DtOpc = new Dt_tbl_opcion();
        protected Neg_opcion NegOpc = new Neg_opcion();

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        public OpcionSeguridad() :
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
                new StoreObject("Opcion", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Descripcion", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtOpc.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;

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
            this.opcionTxt.Text = "";
            this.desTxt.Buffer.Text = "";
        }

        protected void OnBtnNewClicked(object sender, EventArgs e)
        {
            ClearInput();
        }

        protected void OnBtnAddClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.opcionTxt.Text))
                {
                    throw new ArgumentException("Ingrese un nombre");
                }
                Ent_opcion opc = new Ent_opcion()
                {
                    opcion = this.opcionTxt.Text,
                    descripcion = this.desTxt.Buffer.Text,
                    //estado = EntidadEstado.Añadido
                };
                this.NegOpc.AddOpcion(opc);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Rol agregado");
                ms.Run();
                ms.Destroy();
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

        protected void SetEntryTextFromID(int id)
        {
            try
            {
                Ent_opcion EntOpc = this.NegOpc.SearchOpcion(id);

                this.opcionTxt.Text = EntOpc.opcion;
                this.desTxt.Buffer.Text = EntOpc.descripcion;
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

        protected void OnBtnEditClicked(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException(
                        "Seleccione una opcion en la tabla"
                        );
                }
                if (string.IsNullOrWhiteSpace(this.opcionTxt.Text))
                {
                    throw new ArgumentException("Ingrese un nombre");
                }

                Ent_opcion entOpc = new Ent_opcion()
                {
                    id_opcion = this.SelectedID,
                    opcion = this.opcionTxt.Text,
                    descripcion = this.desTxt.Buffer.Text,
                    estado = EntidadEstado.Modificado
                };
                this.NegOpc.EditOpcion(entOpc);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Rol editado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Error, ButtonsType.Ok, ex.Message);
                ms.Run();
                ms.Destroy();
            }
            this.UpdateData();
        }

        protected void OnViewTableRowActivated(object o, RowActivatedArgs args)
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

        protected void OnBtnRemoveClicked(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException(
                        "Seleccione un rol en la tabla"
                        );
                }

                Ent_opcion opc = this.NegOpc.SearchOpcion(this.SelectedID);

                MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar el rol \"{opc.id_opcion}\" ({this.SelectedID})?");
                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegOpc.RemoveOpcion(opc);
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
    }
}
