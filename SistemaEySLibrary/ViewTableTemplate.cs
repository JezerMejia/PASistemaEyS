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

namespace SistemaEySLibrary
{
    [System.ComponentModel.ToolboxItem(true)]
    public class ViewTableTemplate : Gtk.TreeView
    {
        public Gtk.ListStore listStore;

        public ViewTableTemplate() : base()
        {
            
        }

        public void SetTreeViewColumns(StoreObject[] storeObject)
        {
            Type[] types = new Type[storeObject.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = storeObject[i].type;
            }
            this.listStore = new Gtk.ListStore(types);
            this.Model = this.listStore;
            this.ShowAll();

            for (int i = 0; i < types.Length; i++)
            {
                StoreObject obj = storeObject[i];
                this.AppendColumn(obj.name, obj.cellRenderer, obj.col_type, i);
            }
        }
    }
}
