using System;
using Gtk;
using SistemaEyS.DatosEyS;

namespace SistemaEyS.AdminForms.Settings
{
    public partial class DepartamentoSettings : Gtk.Window
    {
        protected Dt_tbl_departamento DtDep = new Dt_tbl_departamento();
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
            if (string.IsNullOrWhiteSpace(this.TxtName.Text))
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Ingrese un nombre");
                ms.Run();
                ms.Destroy();
                return;
            }
            try
            {
                this.DtDep.InsertInto(
                    this.TxtName.Text,
                    this.TxtDescription.Buffer.Text,
                    this.TxtExt.Text
                    );
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Departamento agregado");
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
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok,
                    "Seleccione un departamento en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "No puede haber datos vacíos");
                ms.Run();
                ms.Destroy();
                return;
            }

            try
            {
                this.DtDep.UpdateSet(
                    this.SelectedID.ToString(),
                    this.TxtName.Text, this.TxtDescription.Buffer.Text,
                    this.TxtExt.Text
                    );
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
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Warning, ButtonsType.Ok,
                    "Seleccione un departamento en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }

            string deptName = this.GetDeptValue(this.SelectedID, 1)?.ToString() ?? "";

            MessageDialog deletePrompt = new MessageDialog(this, DialogFlags.Modal,
                MessageType.Question, ButtonsType.YesNo,
                $"¿Desea eliminar el departamento \"{deptName}\" ({this.SelectedID})?");
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
                this.DtDep.DeleteFrom(this.SelectedID.ToString());
                MessageDialog ms = new MessageDialog(this, DialogFlags.Modal,
                    MessageType.Info, ButtonsType.Ok,
                    "Departamento eliminado");
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
            this.SelectedID = -1;
            this.UpdateData();
        }

        protected object GetDeptValue(int idDept, int column)
        {
            TreeIter iter;
            TreeModel model = this.TreeData;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idDept.ToString() == model.GetValue(iter, 0).ToString())
                    {
                        value = model.GetValue(iter, column);
                    }
                } while (model.IterNext(ref iter));
            }

            return value;
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
            TreeIter iter;
            if (this.TreeData.GetIterFirst(out iter))
            {
                do
                {
                    if (id.ToString() == (string)this.TreeData.GetValue(iter, 0))
                    {
                        this.TxtName.Text = (string)TreeData.GetValue(iter, 1);
                        this.TxtDescription.Buffer.Text =
                            (string)TreeData.GetValue(iter, 2);
                        return;
                    }
                    else
                    {
                        this.TxtName.Text = "";
                        this.TxtDescription.Buffer.Text = "";
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
