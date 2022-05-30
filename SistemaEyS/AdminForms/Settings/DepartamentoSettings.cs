using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.DatosEyS.Negocio;

namespace SistemaEyS.AdminForms.Settings
{
    public partial class DepartamentoSettings : Gtk.Window
    {
        protected Dt_tbl_departamento DtDep = new Dt_tbl_departamento();
        protected Neg_Departamento NegDep = new Neg_Departamento();

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        public DepartamentoSettings() :
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
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Descripción", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Extensión", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtDep.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            //this.FillComboboxModel();
        }

        protected void BtnNewOnClicked(object sender, EventArgs e)
        {
            this.SelectedID = -1;
            this.TxtName.Text = "";
            this.TxtExt.Text = "";
            this.TxtDescription.Buffer.Text = "";
        }

        protected void BtnUpdateOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }

        protected void BtnAddOnClicked(object sender, EventArgs args)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.TxtName.Text))
                {
                    throw new ArgumentException("Ingrese un nombre");
                }
                Ent_Departamento dep = new Ent_Departamento()
                {
                    nombreDepartamento = this.TxtName.Text,
                    descripcionDepartamento = this.TxtDescription.Buffer.Text,
                    extensionDepartamento = this.TxtExt.Text,
                    estado = EntidadEstado.Añadido,
                };
                this.NegDep.AddDepartamento(dep);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Departamento agregado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
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
                    throw new ArgumentException(
			            "Seleccione un departamento en la tabla"
			            );
                if (string.IsNullOrWhiteSpace(this.TxtName.Text))
                    throw new ArgumentException("Ingrese un nombre");

                Ent_Departamento dep = new Ent_Departamento()
                {
                    idDepartamento = this.SelectedID,
                    nombreDepartamento = this.TxtName.Text,
                    descripcionDepartamento = this.TxtDescription.Buffer.Text,
                    extensionDepartamento = this.TxtExt.Text,
                    estado = EntidadEstado.Modificado,
                };
                this.NegDep.EditDepartamento(dep);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Departamento editado");
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
                    throw new ArgumentException(
			            "Seleccione un departamento en la tabla"
			            );
                Ent_Departamento dep = this.NegDep.SearchDep(this.SelectedID);

                MessageDialog deletePrompt = new MessageDialog(this,
                    DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar el departamento \"{dep.nombreDepartamento}\" ({this.SelectedID})?");
                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegDep.RemoveDepartamento(dep);

                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok, "Departamento eliminado");
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
            this.SelectedID = -1;
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
                Ent_Departamento dep = this.NegDep.SearchDep(id);

                this.TxtName.Text = dep.nombreDepartamento;
                this.TxtDescription.Buffer.Text = dep.descripcionDepartamento;
                this.TxtExt.Text = dep.extensionDepartamento;
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
