﻿using System;
using Gtk;
namespace SistemaEyS.AdminForms.Seguridad
{
    public partial class UserSeguridad : Gtk.Window
    {
        public UserSeguridad() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();

            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };

            StoreObject[] storeObjects = {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Usuario", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Contraseña", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Contraseña temporal", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Estado", typeof(string), "text", new Gtk.CellRendererText()),
            };
            //this.viewTable.SetTreeViewColumns(this.viewTable.treeView, storeObjects);

            //this.viewTable.treeView.Model = dtus.listarUsuarios();
        }
    }
}
