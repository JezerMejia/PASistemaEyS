using System;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.EmpPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class EmpleadosView : Gtk.Bin
    {
        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();
        protected AddDialog AddDialog;
        protected UpdateDialog UpdateDialog;

        protected ListStore DataEmp;
        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        protected Window parent;

        public EmpleadosView(Window parent)
        {
            this.Build();
            this.parent = parent;

            this.AddDialog = new AddDialog(this);
            this.UpdateDialog = new UpdateDialog(this);

            this.ModelFilterFunc = new TreeModelFilterVisibleFunc(this.TreeModelFilterVisible);

            this.viewTable.SearchEntry = this.TxtSearch;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Ingreso", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cédula", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("PIN", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cargo", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Departamento", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("ID Horario", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.UpdateDialog.UpdateData();

            this.TreeData = new TreeModelFilter(DtEmp.GetDataView(), null);
            this.DataEmp = DtEmp.GetData();

            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            this.FillCmbxIDEmpleadoModel();
        }

        protected void FillCmbxIDEmpleadoModel()
        {
            this.CmbxIDEmpleado.Model = this.DataEmp;
            this.CmbxIDEmpleado.Active = -1;

            this.CmbxIDEmpleado.Entry.Completion = new EntryCompletion();
            this.CmbxIDEmpleado.Entry.Completion.Model = this.DataEmp;
            this.CmbxIDEmpleado.Entry.Completion.TextColumn = 0;
        }

        protected void BtnUpdateOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }


        protected void BtnAddOnClicked(object sender, EventArgs e)
        {
            this.AddDialog.Show();
            this.AddDialog.Present();
            this.AddDialog.SetIDRandom();
        }

        protected void BtnEditOnClicked(object sender, EventArgs e)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok,
                    "Seleccione un usuario en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }
            this.UpdateDialog.UpdateData();
            this.UpdateDialog.Show();
            this.UpdateDialog.Present();
            this.UpdateDialog.SelectedID = this.SelectedID;
        }

        protected void BtnDeleteOnClicked(object sender, EventArgs args)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok,
                    "Seleccione un usuario en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }

            string userName = this.GetEmpValue(this.SelectedID, 1)?.ToString() ?? "";
            string userLastname = this.GetEmpValue(this.SelectedID, 2)?.ToString() ?? "";
            string userFullname = $"{userName} {userLastname}";

            MessageDialog deletePrompt = new MessageDialog(this.parent, DialogFlags.Modal,
                MessageType.Question, ButtonsType.YesNo,
                $"¿Desea eliminar el usuario \"{userFullname}\" ({this.SelectedID})?");
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
                this.DtEmp.DeleteFrom(this.SelectedID.ToString());
                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Empleado eliminado");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Error, ButtonsType.Ok,
                    e.Message);
                ms.Run();
                ms.Destroy();
            }
            this.SelectedID = -1;
            this.UpdateData();
        }

        protected object GetEmpValue(int idEmpleado, int column)
        {
            TreeIter iter;
            TreeModel model = this.TreeData;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idEmpleado.ToString() == model.GetValue(iter, 0).ToString())
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
                        this.CmbxIDEmpleado.Active = this.GetIndexFromValue(
                            this.CmbxIDEmpleado,
                            (string) this.TreeData.GetValue(iter, 0)
                            );
                        return;
                    }
                    else
                    {
                        this.CmbxIDEmpleado.Active = -1;
                        this.CmbxIDEmpleado.Entry.Text = "";
                    }
                }
                while (TreeData.IterNext(ref iter));
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
                    if (value == (string)model.GetValue(iter, 0))
                    {
                        index = i;
                        break;
                    }
                    i++;
                } while (model.IterNext(ref iter));
            }

            return index;
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
            this.TreeData.Refilter();
        }

        protected void CmbxEmpleadoOnChanged(object sender, EventArgs args)
        {
            try
            {
                object value = this.GetEmpValue(
                    Int32.Parse(this.CmbxIDEmpleado.ActiveText), 0
                );
                if (value != null)
                {
                    this.SelectedID = Int32.Parse(value.ToString());
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
