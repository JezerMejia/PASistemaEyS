using System;
using System.Data;
using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;
using Gtk;
using MySql.Data;
using System.Text;
using System.Collections.Generic;
using SistemaEyS.Datos;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]

    public partial class EmpleadosPanel : Gtk.Bin
    {
        Dt_tlb_user dtus = new Dt_tlb_user();

        public EmpleadosPanel()

        {
            this.Build();
            this.treeView.Model = dtus.listarUsuarios();

            string[] titulos = { "idUser", "User", "Nombres", "Apellidos", "Email", "Estado" };
            for (int i = 0; i < titulos.Length; i++)
            {
                this.treeView.AppendColumn(titulos[i], new CellRendererText(), "text", i);
            }

            {
            }

            /*StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Dirección", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Teléfono", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email", typeof(string), "text", new Gtk.CellRendererText()),
            };

            this.SetTreeViewColumns(this.treeView, storeObjects);

            this.listStore = (Gtk.ListStore) this.treeView.Model;

            this.listStore.AppendValues("000031725", "Jezer", "Mejía", "", "81211855", "jezer.mejia13523@est.uca.edu.ni");
            this.listStore.AppendValues("000031231", "Juan", "Juan", "", "81921935", "juan.juan23214@est.uca.edu.ni");
        */
        }

        private void SetTreeViewColumns(Gtk.TreeView treeView, StoreObject[] storeObject)
        {
            Type[] types = new Type[storeObject.Length];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = storeObject[i].type;
            }
            Gtk.ListStore store = new Gtk.ListStore(types);
            treeView.Model = store;
            treeView.ShowAll();

            for (int i = 0; i < types.Length; i++)
            {
                StoreObject obj = storeObject[i];
                treeView.AppendColumn(obj.name, obj.cellRenderer, obj.col_type, i);
            }
        }
    }
}
