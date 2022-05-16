using System;
using SistemaEyS.DatosEyS;
using SistemaEyS.AdminForms.Tables.HorPanelBtn;
using Gtk;
using System.Data;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class HorarioView : Gtk.Bin
    {
        AddDialogHor adh = new AddDialogHor();
        Dt_tlb_horario dthor = new Dt_tlb_horario();
        TreeModelFilter TreeData;
        TreeModelFilterVisibleFunc ModelFilterFunc;
        int SelectedID = -1;
        ConnectionEyS connection = ConnectionEyS.OpenConnection();
        UpdateHorario upHor = new UpdateHorario();

        public HorarioView()
        {
            this.Build();
            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
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
            this.TreeData = new TreeModelFilter(dthor.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;
            //this.FillComboboxModel();
        }


        protected void btnUpdateOnClicked(object sender, EventArgs e)
        {
            UpdateData(); 
        }

        protected void OnBtnAddClicked(object sender, EventArgs e)
        {
            adh.Show();
            adh.Present();
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

        protected void OnBtnDeleteClicked(object sender, EventArgs e)
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
                String Query = "DELETE FROM BDSistemaEyS.Horario WHERE idHorario = " +
                $"{this.SelectedID.ToString()};";

                try
                {
                    connection.Execute(CommandType.Text, Query);
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

        protected void OnBtnEditClicked(object sender, EventArgs e)
        {
            if (this.SelectedID < 0)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning,
                    ButtonsType.Ok, "Seleccione un horario en la tabla");
                ms.Run();
                ms.Destroy();
                return;
            }

            upHor.Show();
        }
    }
}
