using System;
using System.Data;
using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;
using Gtk;

namespace SistemaEyS.AdminForms.Tables
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class EmpleadosPanel : Gtk.Bin
    {
        public Gtk.ListStore listStore;

        //DataBase
        string connectionString;
        string query;
        SqliteCommand cmd;
        SqliteConnection conn;
        SqliteDataReader dr;

        public EmpleadosPanel()
        {
            this.Build();

            connectionString = "Data Source=data.db;Version=3;New=true;Compress=True;";
            conn = new SqliteConnection(connectionString);
            query = "select id_user,nombres,apellidos,email from tbl_user";

            try
            {

                this.treeView.AppendColumn("id_user", new CellRendererText(), "text", 0);
                this.treeView.AppendColumn("nombres", new CellRendererText(), "text", 1);
                this.treeView.AppendColumn("apellidos", new CellRendererText(), "text", 2);
                this.treeView.AppendColumn("email", new CellRendererText(), "text", 3);
                ListStore data = new ListStore(
                    typeof(string),
                    typeof(string),
                    typeof(string),
                    typeof(string)
                );
                conn.Open();
                cmd = new SqliteCommand(query, conn); dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }

                this.treeView.Model = data;
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




            StoreObject[] storeObjects = {
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
