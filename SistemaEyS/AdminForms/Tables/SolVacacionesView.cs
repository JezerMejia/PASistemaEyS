using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn;
using Gtk;
using SistemaEyS.Database.Connection;
using SistemaEyS.AdminForms.Tables.HorPanelBtn;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class SolVacacionesView : Gtk.Bin
    {

        AddDialogSolVac addDialog = new AddDialogSolVac();
        UpdateDialogSolVac UpdateDialogSolVac;
        Dt_tlb_SolVacaciones DtSolv = new Dt_tlb_SolVacaciones();
        TreeModelFilter TreeData;
        TreeModelFilterVisibleFunc ModelFilterFunc;
        int SelectedID = -1;

        public SolVacacionesView()
        {
            this.Build();
            this.UpdateDialogSolVac = new UpdateDialogSolVac();
            this.viewTable.SearchEntry = this.SearchSolVacTxt;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("ID Empleado", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fecha Solicitud", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Descripción", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fin", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(this.DtSolv.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            //this.FillComboboxModel();
        }

        protected void OnBtnAddSVClicked(object sender, EventArgs e)
        {
            this.addDialog.Show();
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
                    //this.SetEntryTextFromID(this.SelectedID);
                }
                catch (Exception)
                {
                    return;
                }

            }
        }

        protected void OnBtnActSVClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }

        protected void OnBtnDelSVClicked(object sender, EventArgs e)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Seleccione un horario en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }

            MessageDialog deletePrompt = new MessageDialog(null, DialogFlags.Modal,
            MessageType.Question, ButtonsType.YesNo, $"¿Desea eliminar el horario ({this.SelectedID})?");
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
                this.DtSolv.DeleteFrom(this.SelectedID.ToString());
               
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Info,
                        ButtonsType.Ok, "Eliminado");
                    ms.Run();
                    ms.Destroy();
                    //ClearInput();
             }
                catch (Exception ex)
             {
                    MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, ex.Message);
                    ms.Run();
                    ms.Destroy();
             }
           
            this.UpdateData();
        }


        protected void OnBtnUpSVClicked(object sender, EventArgs e)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Seleccione una solicitud en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }
            this.UpdateDialogSolVac.UpdateData();
            this.UpdateDialogSolVac.Show();
            this.UpdateDialogSolVac.Present();
            this.UpdateDialogSolVac.SelectedID = this.SelectedID;
        }

        protected bool TreeModelFilterVisible(TreeModel model, TreeIter iter)
        {
            TreePath path = model.GetPath(iter);
            //Console.WriteLine($"'{this.TxtSearch.Text}' at '{path.ToString()}'");
            if (string.IsNullOrWhiteSpace(this.SearchSolVacTxt.Text))
            {
                //Console.WriteLine("Empty search");
                return true;
            }
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                if (string.IsNullOrEmpty(value)) return false;
                //Console.WriteLine($"\t{i}: '{value}'");
                if (value.ToLower().Contains(this.SearchSolVacTxt.Text.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        protected void OnSearchHorTxtChanged(object sender, EventArgs e)
        {
            this.TreeData.Refilter();
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


    }
}
