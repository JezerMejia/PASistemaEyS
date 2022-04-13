﻿using System;
using Gtk;
namespace SistemaEyS.AdminForms
{
    public partial class AdminPanel : Gtk.Window
    {
        protected Window parent;
        protected uint timeout;
        public AdminPanel(Window parent) :
                base(Gtk.WindowType.Toplevel)
        {
            this.parent = parent;
            this.Build();
            this.SetDateTimeTimeout();
            this.SetNtTabViewPages();
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

        protected void SetNtTabViewPages()
        {
            for (int i = 0; i < 3; i++)
            {
                string label = String.Format("Page {0}", i + 1);
                this.ntTabview.AppendPage(new Button("UWU"), new Label(label));
            }
            this.ntTabview.ShowAll();
        }

        protected void OnDeleteEvent(object o, DeleteEventArgs args)
        {
            this.Close();
        }

        protected void actCloseOnActivated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}