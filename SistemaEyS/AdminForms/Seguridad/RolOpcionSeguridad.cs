using System;
using Gtk;
using SistemaEyS.DatosSeguridad.Datos;

namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class RolOpcionSeguridad : Gtk.Window
    {

        protected Dt_tbl_rol DtRol = new Dt_tbl_rol();
        protected Dt_tbl_opcion DtOpc = new Dt_tbl_opcion();
        protected Dt_tbl_rol_opcion DtRolOpc = new Dt_tbl_rol_opcion();

        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        public int SelectedID = -1;

        protected ListStore DataRol;
        protected ListStore DataOpcion;

        public RolOpcionSeguridad() :
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
                new StoreObject("ID Rol-Opcion", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Rol", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Opcion", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(storeObjects);

            this.UpdateData();
        }

        public void UpdateData()
        {
            this.TreeData = new TreeModelFilter(DtRolOpc.GetData(), null);
            this.TreeData.VisibleFunc = this.ModelFilterFunc;
            this.viewTable.Model = this.TreeData;

            this.DataRol = DtRol.GetDataCmbx();
            this.DataOpcion = DtOpc.GetDataCmbx();
            this.rolTxt.Model = this.DataRol;
            this.opcionTxt.Model = this.DataOpcion;
            this.FillCmbxRolModel();
            this.FillCmbxOpcionModel();
        }

        protected void FillCmbxRolModel()
        {
            this.rolTxt.Model = this.DataRol;
            this.rolTxt.Active = -1;


            this.rolTxt.Entry.Completion = new EntryCompletion();
            this.rolTxt.Entry.Completion.Model = this.DataRol;
            this.rolTxt.Entry.Completion.TextColumn = 0;
        }

        protected void FillCmbxOpcionModel()
        {
            this.opcionTxt.Model = this.DataOpcion;
            this.opcionTxt.Active = -1;

            this.opcionTxt.Entry.Completion = new EntryCompletion();
            this.opcionTxt.Entry.Completion.Model = this.DataOpcion;
            this.opcionTxt.Entry.Completion.TextColumn = 0;
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


    }
}
