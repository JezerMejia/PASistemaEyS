using System;
namespace SistemaEySLibrary
{
    [System.ComponentModel.ToolboxItem(true)]
    public class NumericEntry : Gtk.Entry
    {
        override protected void OnTextInserted(string text, ref int position)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c)) return;
            }
            base.OnTextInserted(text, ref position);
        }
    }
}
