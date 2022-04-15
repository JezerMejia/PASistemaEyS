using System;

public struct StoreObject
{
    public StoreObject(string name, Type type, string col_type, Gtk.CellRenderer cellRenderer)
    {
        this.name = name;
        this.type = type;
        this.col_type = col_type;
        this.cellRenderer = cellRenderer;
    }
    public string name;
    public Type type;
    public string col_type;
    public Gtk.CellRenderer cellRenderer;
}

namespace SistemaEyS.AdminForms.Panels
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class PanelTemplate : Gtk.Bin
    {
        public Gtk.ListStore listStore;
        public Gtk.TreeView treeView { 
            get
            {
                return this.treeview1;
            }
        }
        public PanelTemplate()
        {
            this.Build();
        }

        internal protected void SetTreeViewColumns(Gtk.TreeView treeView, StoreObject[] storeObject)
        {
            Type[] types = new Type[storeObject.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = storeObject[i].type;
            }
            this.listStore = new Gtk.ListStore(types);
            treeView.Model = this.listStore;
            treeView.ShowAll();

            for (int i = 0; i < types.Length; i++)
            {
                StoreObject obj = storeObject[i];
                treeView.AppendColumn(obj.name, obj.cellRenderer, obj.col_type, i);
            }
        }
    }
}
