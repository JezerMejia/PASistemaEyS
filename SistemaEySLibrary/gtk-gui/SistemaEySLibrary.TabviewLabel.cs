
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEySLibrary
{
	public partial class TabviewLabel
	{
		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label;

		private global::Gtk.Button btnIcon;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEySLibrary.TabviewLabel
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEySLibrary.TabviewLabel";
			// Container child SistemaEySLibrary.TabviewLabel.Gtk.Container+ContainerChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			// Container child hbox3.Gtk.Box+BoxChild
			this.label = new global::Gtk.Label();
			this.label.Name = "label";
			this.label.LabelProp = global::Mono.Unix.Catalog.GetString("label7");
			this.hbox3.Add(this.label);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label]));
			w1.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnIcon = new global::Gtk.Button();
			this.btnIcon.CanFocus = true;
			this.btnIcon.Name = "btnIcon";
			this.hbox3.Add(this.btnIcon);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnIcon]));
			w2.Position = 1;
			this.Add(this.hbox3);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.btnIcon.Clicked += new global::System.EventHandler(this.btnIconOnClicked);
		}
	}
}
