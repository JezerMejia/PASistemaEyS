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

        AddDialogSolVac solVac = new AddDialogSolVac();
        Dt_tlb_SolVacaciones dtSolVac = new Dt_tlb_SolVacaciones();
        TreeModelFilter TreeData;
        TreeModelFilterVisibleFunc ModelFilterFunc;
        int SelectedID = -1;
        ConnectionEyS connection = ConnectionEyS.OpenConnection();
        //UpdateHorario upHor = new UpdateHorario();

        public SolVacacionesView()
        {
            this.Build();
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
            this.TreeData = new TreeModelFilter(dtSolVac.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            //this.FillComboboxModel();
        }

        protected void OnBtnAddSVClicked(object sender, EventArgs e)
        {

            solVac.Show();

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

        protected object GetUserValue(int idUser, int column)
        {
            TreeIter iter;
            TreeModel model = this.TreeData;

            object value = null;

            if (model.GetIterFirst(out iter))
            {
                do
                {
                    if (idUser.ToString() == model.GetValue(iter, 0).ToString())
                    {
                        value = model.GetValue(iter, column);
                    }
                } while (model.IterNext(ref iter));
            }

            return value;
        }

        protected void OnBtnActSVClicked(object sender, EventArgs e)
        {
            UpdateData();
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
                dtSolVac.DeleteFrom(SelectedID.ToString());
               
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
           
            UpdateData();
        }
    }
}
