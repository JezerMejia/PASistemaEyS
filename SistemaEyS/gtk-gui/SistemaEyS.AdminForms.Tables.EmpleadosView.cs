
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables
{
	public partial class EmpleadosView
	{
		private global::Gtk.Alignment alignment2;

		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::SistemaEyS.AdminForms.Tables.ViewTableTemplate viewTable;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button button1;

		private global::Gtk.Button button7;

		private global::Gtk.Button button3;

		private global::Gtk.Button button4;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.EmpleadosView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEyS.AdminForms.Tables.EmpleadosView";
			// Container child SistemaEyS.AdminForms.Tables.EmpleadosView.Gtk.Container+ContainerChild
			this.alignment2 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.LeftPadding = ((uint)(5));
			this.alignment2.TopPadding = ((uint)(5));
			this.alignment2.RightPadding = ((uint)(5));
			this.alignment2.BottomPadding = ((uint)(6));
			this.alignment2.BorderWidth = ((uint)(10));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(1));
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
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.button1 = new global::Gtk.Button();
			this.button1.CanFocus = true;
			this.button1.Name = "button1";
			this.button1.UseUnderline = true;
			this.button1.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			this.hbox2.Add(this.button1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button1]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.button7 = new global::Gtk.Button();
			this.button7.CanFocus = true;
			this.button7.Name = "button7";
			this.button7.UseUnderline = true;
			this.button7.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			this.hbox2.Add(this.button7);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button7]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.button3 = new global::Gtk.Button();
			this.button3.CanFocus = true;
			this.button3.Name = "button3";
			this.button3.UseUnderline = true;
			this.button3.Label = global::Mono.Unix.Catalog.GetString("Editar");
			this.hbox2.Add(this.button3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button3]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.button4 = new global::Gtk.Button();
			this.button4.CanFocus = true;
			this.button4.Name = "button4";
			this.button4.UseUnderline = true;
			this.button4.Label = global::Mono.Unix.Catalog.GetString("Añadir");
			this.hbox2.Add(this.button4);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.button4]));
			w6.PackType = ((global::Gtk.PackType)(1));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			w7.Padding = ((uint)(1));
			this.alignment2.Add(this.vbox1);
			this.Add(this.alignment2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.button4.Clicked += new global::System.EventHandler(this.btnAddOnClicked);
			this.button3.Clicked += new global::System.EventHandler(this.OnButton3Clicked);
			this.button7.Clicked += new global::System.EventHandler(this.btnUpdateOnClicked);
			this.button1.Clicked += new global::System.EventHandler(this.OnButton1Clicked);
		}
	}
}
