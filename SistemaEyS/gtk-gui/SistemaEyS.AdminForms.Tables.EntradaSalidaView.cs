
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables
{
	public partial class EntradaSalidaView
	{
		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::SistemaEyS.AdminForms.Tables.ViewTableTemplate viewTable;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button btnUpdate;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.EntradaSalidaView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEyS.AdminForms.Tables.EntradaSalidaView";
			// Container child SistemaEyS.AdminForms.Tables.EntradaSalidaView.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(10));
			this.alignment1.TopPadding = ((uint)(10));
			this.alignment1.RightPadding = ((uint)(10));
			this.alignment1.BottomPadding = ((uint)(10));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.viewTable = new global::SistemaEyS.AdminForms.Tables.ViewTableTemplate();
			this.viewTable.CanFocus = true;
			this.viewTable.Name = "viewTable";
			this.GtkScrolledWindow.Add(this.viewTable);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnUpdate = new global::Gtk.Button();
			this.btnUpdate.CanFocus = true;
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.UseUnderline = true;
			this.btnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			this.hbox1.Add(this.btnUpdate);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnUpdate]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.alignment1.Add(this.vbox1);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.btnUpdate.Clicked += new global::System.EventHandler(this.btnUpdateOnClicked);
		}
	}
}
