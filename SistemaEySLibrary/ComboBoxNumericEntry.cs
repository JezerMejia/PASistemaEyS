using System;
using Gtk;
namespace SistemaEySLibrary
{
    [System.ComponentModel.ToolboxItem(true)]
    public class ComboBoxNumericEntry : Gtk.ComboBoxEntry
    {
        public new NumericEntry Entry;

        public ComboBoxNumericEntry()
        {
            ListStore store = new ListStore(typeof(string), typeof(string));
            this.Model = store;

            this.Entry = new NumericEntry();
            this.Entry.Show();
            this.Add(this.Entry);

            this.Active = 0;
            this.TextColumn = 0;
        }
    }
}
