﻿using System;
using SistemaEyS.DatosEyS.Datos;
using SistemaEyS.AdminForms.Tables.HorPanelBtn;
using Gtk;
using System.Data;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.AdminForms.Tables
{
    public partial class HorarioView : Gtk.Bin
    {
        //ConnectionEyS connection = ConnectionEyS.OpenConnection();
        protected UpdateHorario UpdateHorario;
        protected AddDialogHor adh = new AddDialogHor();
        protected Dt_tlb_horario dthor = new Dt_tlb_horario();
        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        int SelectedID = -1;

        public HorarioView()
        {
            this.Build();

            this.UpdateHorario = new UpdateHorario();
            this.viewTable.SearchEntry = this.SearchHorTxt;
            this.viewTable.SearchEqualFunc = new TreeViewSearchEqualFunc(this.ViewTableEqualFunc);

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
            this.UpdateHorario.UpdateData();
            this.viewTable.Model = this.TreeData;
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
                dthor.DeleteFrom(SelectedID.ToString());
               
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

            this.UpdateHorario.UpdateData();
            this.UpdateHorario.Show();
            this.UpdateHorario.Present();
            this.UpdateHorario.SelectedID = this.SelectedID;
        }

        protected bool TreeModelFilterVisible(TreeModel model, TreeIter iter)
        {
            TreePath path = model.GetPath(iter);
            //Console.WriteLine($"'{this.TxtSearch.Text}' at '{path.ToString()}'");
            if (string.IsNullOrWhiteSpace(this.SearchHorTxt.Text))
            {
                //Console.WriteLine("Empty search");
                return true;
            }
            for (int i = 0; i < model.NColumns; i++)
            {
                string value = (string)model.GetValue(iter, i);
                if (string.IsNullOrEmpty(value)) return false;
                //Console.WriteLine($"\t{i}: '{value}'");
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
