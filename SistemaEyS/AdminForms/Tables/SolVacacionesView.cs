using System;
using Gtk;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Negocio;
using SistemaEyS.DatosEyS.Entidades;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class SolVacacionesView : Gtk.Bin
    {
        protected Dt_tlb_SolVacaciones DtSolv = new Dt_tlb_SolVacaciones();
        protected Neg_SolicitudVacaciones NegSolVac = new Neg_SolicitudVacaciones();

        protected AddDialogSolVac addDialog;
        protected UpdateDialogSolVac updateDialog;

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        protected Window parent;

        public SolVacacionesView(Window parent)
        {
            this.Build();
            this.parent = parent;

            this.addDialog = new AddDialogSolVac(this);
            this.updateDialog = new UpdateDialogSolVac(this);

            this.ModelFilterFunc = new TreeModelFilterVisibleFunc(this.TreeModelFilterVisible);

            this.viewTable.SearchEntry = this.TxtSearch;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("ID Empleado", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Fecha Solicitud", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Justificación", typeof(string), "text", new Gtk.CellRendererText()),
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

            this.addDialog.UpdateData();
            this.updateDialog.UpdateData();
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
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException(
                        "Seleccione un horario en la tabla"
                        );
                }

                Ent_SolicitudVacaciones solVac =
                    this.NegSolVac.SearchVacaciones(this.SelectedID);

                MessageDialog deletePrompt = new MessageDialog(this.parent,
                    DialogFlags.Modal,
                    MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar la solicitud \"{solVac.descripcionSol}\" ({this.SelectedID})?");

                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegSolVac.RemoveSolicitudVacaciones(solVac);

                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Solicitud eliminada");
                ms.Run();
                ms.Destroy();
            }
            catch (Exception ex)
            {
                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Error,
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
                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Seleccione una solicitud en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }
            this.updateDialog.SelectedID = this.SelectedID;
            this.updateDialog.UpdateData();
            this.updateDialog.Show();
            this.updateDialog.Present();
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

        protected void TxtSearchOnChanged(object sender, EventArgs e)
        {
            this.TreeData.Refilter();
        }
    }
}
