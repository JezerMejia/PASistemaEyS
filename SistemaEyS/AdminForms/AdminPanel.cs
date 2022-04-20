using System;
using Gtk;
using SistemaEySLibrary;
using System.Data;
using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace SistemaEyS.AdminForms
{
    public partial class AdminPanel : Gtk.Window
    {
        //DataBase
        string connectionString;
        string query;
        SqliteCommand cmd;
        SqliteConnection conn;
        SqliteDataReader dr;

        protected Window parent;
        protected uint timeout;
        public AdminPanel(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.SetDateTimeTimeout();
            connectionString = "Data Source=data.db;Version=3;New=true;Compress=True;";
            conn = new SqliteConnection(connectionString);
            query = "select id_user,nombres,apellidos,email from tbl_user";

            try{

                treeview.AppendColumn("id_user", new CellRendererText(), "text", 0);
                treeview.AppendColumn("nombres", new CellRendererText(), "text", 1);
                treeview.AppendColumn("apellidos", new CellRendererText(), "text", 2);
                treeview.AppendColumn("email", new CellRendererText(), "text", 3);
                ListStore data = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
                conn.Open();
                cmd = new SqliteCommand(query, conn); dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.AppendValues(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }

                treeview.Model = data;
                dr.Close();
                conn.Close();



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void Close()
        {
            GLib.Source.Remove(this.timeout);
            this.Destroy();
            this.parent.Show();
        }

        protected void SetDateTimeTimeout()
        {
            this.UpdateDateTime();
            this.timeout = GLib.Timeout.Add(500, this.UpdateDateTime);
        }
        protected bool UpdateDateTime()
        {
            DateTime dateTime = DateTime.Now;
            string str = dateTime.ToString("yyyy-MM-dd h:mm:ss tt");
            this.lbDateTime.Markup = $"<span size=\"200%\" weight=\"bold\">{str}</span>";
            this.lbDateTime.UseMarkup = true;
            return true;
        }
        public void AddTab(Notebook notebook, Widget widget, string label)
        {
            TabviewLabel tabviewLabel = new TabviewLabel(label);
            notebook.AppendPage(widget, tabviewLabel);
            tabviewLabel.CloseClicked += delegate (object obj, EventArgs args)
            {
                this.ntTabview.RemovePage(notebook.PageNum(widget));
            };
            widget.Show();
            tabviewLabel.Show();
        }

        protected void actCloseOnActivated(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void EmpleadosActionOnActivated(object sender, EventArgs e)
        {
            Panels.EmpleadosPanel empleadosPanel = new Panels.EmpleadosPanel();
            this.AddTab(this.ntTabview, empleadosPanel, "Empleados");
        }

        protected void HorariosActionOnActivated(object sender, EventArgs e)
        {
            Panels.HorariosPanel horariosPanel = new Panels.HorariosPanel();
            this.AddTab(this.ntTabview, horariosPanel, "Horarios");
        }

        protected void EntradasSalidasActionOnActivated(object sender, EventArgs e)
        {
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            Application.Quit();
            args.RetVal = true;
        }
    }
}