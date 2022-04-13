using System;
namespace SistemaEySLibrary
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class TabviewLabel : Gtk.Bin
    {
        private void Construct()
        {
            this.Build();
            Gtk.IconTheme iconTheme = Gtk.IconTheme.Default;
            this.btnIcon.Image = new Gtk.Image(Gtk.Stock.Close, Gtk.IconSize.Menu);
            this.btnIcon.Relief = Gtk.ReliefStyle.None;
            Gtk.RcStyle style = new Gtk.RcStyle();
            style.Xthickness = 0;
            style.Ythickness = 0;
            this.btnIcon.ModifyStyle(style);
            this.btnIcon.FocusOnClick = false;
        }
        public TabviewLabel()
        {
            this.Construct();
            this.Text = "";
        }
        public TabviewLabel(string text)
        {
            this.Construct();
            this.Text = text;
        }

        public string Text
        {
            get
            {
                return this.label.Text;
            }
            set
            {
                this.label.Text = value;
            }
        }

        public event EventHandler<EventArgs> CloseClicked;

        protected void btnIconOnClicked(object sender, EventArgs e)
        {
            if (this.CloseClicked != null) CloseClicked(sender, e);
        }
    }
}