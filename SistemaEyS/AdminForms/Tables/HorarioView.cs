using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.DatosEyS.Negocio;
using SistemaEyS.DatosEyS.Entidades;
using SistemaEyS.AdminForms.Tables.HorPanelBtn;
using Gtk;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class HorarioView : Gtk.Bin
    {

        protected Neg_Horario NegHor = new Neg_Horario();
        protected Dt_tlb_horario DtHor = new Dt_tlb_horario();

        protected UpdateHorario updateDialog;
        protected AddDialogHor addDialog = new AddDialogHor();

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        Window parent;

        public HorarioView(Window parent)
        {
            this.Build();
            this.parent = parent;

            this.updateDialog = new UpdateHorario();
            this.viewTable.SearchEntry = this.SearchHorTxt;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Lunes - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Lunes - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Martes - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Martes - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Miércoles - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Miércoles - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Jueves - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Jueves - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Viernes - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Viernes - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Sábado - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Sábado - Fin", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Domingo - Inicio", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Domingo - Fin", typeof(string), "text", new Gtk.CellRendererText()),
            };

            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtHor.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            this.updateDialog.UpdateData();
            this.viewTable.Model = this.TreeData;
        }

        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }

        protected void OnBtnAddClicked(object sender, EventArgs e)
        {
            this.addDialog.Show();
            this.addDialog.Present();
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

        protected void OnBtnDeleteClicked(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedID < 0)
                {
                    throw new ArgumentException(
                        "Seleccione un horario en la tabla"
                        );
                }

                Ent_Horario hor = this.NegHor.SearchHorario(this.SelectedID);

                MessageDialog deletePrompt = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo,
                    $"¿Desea eliminar el horario \"{hor.nombreHorario}\" ({this.SelectedID})?");
                int result = deletePrompt.Run();
                deletePrompt.Destroy();

                if ((ResponseType)result != ResponseType.Yes) return;

                this.NegHor.RemoveHorario(hor);

                MessageDialog ms = new MessageDialog(this.parent,
                    DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
                    "Horario eliminado");
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

        protected void OnBtnEditClicked(object sender, EventArgs e)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(this.parent,
		            DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Seleccione un horario en la tabla");
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
            if (string.IsNullOrWhiteSpace(this.SearchHorTxt.Text))
            {
                return true;
            }
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                if (string.IsNullOrEmpty(value)) return false;
                if (value.ToLower().Contains(this.SearchHorTxt.Text.ToLower()))
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
