
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables
{
	public partial class SolVacacionesView
	{
		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::SistemaEyS.AdminForms.Tables.ViewTableTemplate viewTable;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button BtnDelSV;

		private global::Gtk.Button BtnActSV;

		private global::Gtk.Button BtnUpSV;

		private global::Gtk.Button BtnAddSV;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.SolVacacionesView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEyS.AdminForms.Tables.SolVacacionesView";
			// Container child SistemaEyS.AdminForms.Tables.SolVacacionesView.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(15));
			this.alignment1.TopPadding = ((uint)(15));
			this.alignment1.RightPadding = ((uint)(15));
			this.alignment1.BottomPadding = ((uint)(15));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
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
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.BtnDelSV = new global::Gtk.Button();
			this.BtnDelSV.CanFocus = true;
			this.BtnDelSV.Name = "BtnDelSV";
			this.BtnDelSV.UseUnderline = true;
			this.BtnDelSV.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			this.hbox5.Add(this.BtnDelSV);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.BtnDelSV]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.BtnActSV = new global::Gtk.Button();
			this.BtnActSV.CanFocus = true;
			this.BtnActSV.Name = "BtnActSV";
			this.BtnActSV.UseUnderline = true;
			this.BtnActSV.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			this.hbox5.Add(this.BtnActSV);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.BtnActSV]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.BtnUpSV = new global::Gtk.Button();
			this.BtnUpSV.CanFocus = true;
			this.BtnUpSV.Name = "BtnUpSV";
			this.BtnUpSV.UseUnderline = true;
			this.BtnUpSV.Label = global::Mono.Unix.Catalog.GetString("Editar");
			this.hbox5.Add(this.BtnUpSV);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.BtnUpSV]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.BtnAddSV = new global::Gtk.Button();
			this.BtnAddSV.CanFocus = true;
			this.BtnAddSV.Name = "BtnAddSV";
			this.BtnAddSV.UseUnderline = true;
			this.BtnAddSV.Label = global::Mono.Unix.Catalog.GetString("Añadir");
			this.hbox5.Add(this.BtnAddSV);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.BtnAddSV]));
			w6.PackType = ((global::Gtk.PackType)(1));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add(this.hbox5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox5]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.alignment1.Add(this.vbox1);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
