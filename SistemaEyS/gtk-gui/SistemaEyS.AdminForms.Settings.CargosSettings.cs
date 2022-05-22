
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Settings
{
	public partial class CargosSettings
	{
		private global::Gtk.Alignment alignment2;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Entry TxtName;

		private global::Gtk.Alignment alignment3;

		private global::Gtk.Label label3;

		private global::Gtk.Alignment alignment5;

		private global::Gtk.HBox hbox9;

		private global::Gtk.Alignment alignment6;

		private global::Gtk.Label label5;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gtk.TextView TxtDescription;

		private global::Gtk.HBox hbox15;

		private global::Gtk.Button BtnRemove;

		private global::Gtk.Button BtnEdit;

		private global::Gtk.Button BtnAdd;

		private global::Gtk.Button BtnNew;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label1;

		private global::Gtk.Entry TxtSearch;

		private global::Gtk.Button BtnUpdate;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::SistemaEyS.AdminForms.Tables.ViewTableTemplate viewTable;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Settings.CargosSettings
			this.Name = "SistemaEyS.AdminForms.Settings.CargosSettings";
			this.Title = global::Mono.Unix.Catalog.GetString("Ajustes | Cargos");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child SistemaEyS.AdminForms.Settings.CargosSettings.Gtk.Container+ContainerChild
			this.alignment2 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.LeftPadding = ((uint)(10));
			this.alignment2.TopPadding = ((uint)(10));
			this.alignment2.RightPadding = ((uint)(10));
			this.alignment2.BottomPadding = ((uint)(10));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 16;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Homogeneous = true;
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.TxtName = new global::Gtk.Entry();
			this.TxtName.CanFocus = true;
			this.TxtName.Name = "TxtName";
			this.TxtName.IsEditable = true;
			this.TxtName.WidthChars = 20;
			this.hbox5.Add(this.TxtName);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.TxtName]));
			w1.PackType = ((global::Gtk.PackType)(1));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			// Container child alignment3.Gtk.Container+ContainerChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre:");
			this.label3.Justify = ((global::Gtk.Justification)(1));
			this.alignment3.Add(this.label3);
			this.hbox5.Add(this.alignment3);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.alignment3]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 1;
			w3.Expand = false;
			this.vbox4.Add(this.hbox5);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox5]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			this.hbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment(0.5F, 0.5F, 0.1F, 1F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.hbox9 = new global::Gtk.HBox();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment(1F, 0F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.Yalign = 0.2F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Descripción:");
			this.alignment6.Add(this.label5);
			this.hbox9.Add(this.alignment6);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.alignment6]));
			w8.Position = 0;
			w8.Expand = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.TxtDescription = new global::Gtk.TextView();
			this.TxtDescription.WidthRequest = 250;
			this.TxtDescription.CanFocus = true;
			this.TxtDescription.Name = "TxtDescription";
			this.GtkScrolledWindow1.Add(this.TxtDescription);
			this.hbox9.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.GtkScrolledWindow1]));
			w10.PackType = ((global::Gtk.PackType)(1));
			w10.Position = 1;
			w10.Expand = false;
			this.alignment5.Add(this.hbox9);
			this.vbox1.Add(this.alignment5);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment5]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox15 = new global::Gtk.HBox();
			this.hbox15.Name = "hbox15";
			this.hbox15.Spacing = 6;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnRemove = new global::Gtk.Button();
			this.BtnRemove.CanFocus = true;
			this.BtnRemove.Name = "BtnRemove";
			this.BtnRemove.UseUnderline = true;
			this.BtnRemove.Label = global::Mono.Unix.Catalog.GetString("Quitar");
			global::Gtk.Image w13 = new global::Gtk.Image();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.BtnRemove.Image = w13;
			this.hbox15.Add(this.BtnRemove);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnRemove]));
			w14.PackType = ((global::Gtk.PackType)(1));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnEdit = new global::Gtk.Button();
			this.BtnEdit.CanFocus = true;
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.UseUnderline = true;
			this.BtnEdit.Label = global::Mono.Unix.Catalog.GetString("_Editar");
			global::Gtk.Image w15 = new global::Gtk.Image();
			w15.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.BtnEdit.Image = w15;
			this.hbox15.Add(this.BtnEdit);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnEdit]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnAdd = new global::Gtk.Button();
			this.BtnAdd.CanFocus = true;
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.UseUnderline = true;
			this.BtnAdd.Label = global::Mono.Unix.Catalog.GetString("_Añadir");
			global::Gtk.Image w17 = new global::Gtk.Image();
			w17.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.BtnAdd.Image = w17;
			this.hbox15.Add(this.BtnAdd);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnAdd]));
			w18.PackType = ((global::Gtk.PackType)(1));
			w18.Position = 2;
			w18.Expand = false;
			w18.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnNew = new global::Gtk.Button();
			this.BtnNew.CanFocus = true;
			this.BtnNew.Name = "BtnNew";
			this.BtnNew.UseUnderline = true;
			this.BtnNew.Label = global::Mono.Unix.Catalog.GetString("Nuevo");
			global::Gtk.Image w19 = new global::Gtk.Image();
			w19.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-new", global::Gtk.IconSize.Menu);
			this.BtnNew.Image = w19;
			this.hbox15.Add(this.BtnNew);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnNew]));
			w20.PackType = ((global::Gtk.PackType)(1));
			w20.Position = 3;
			w20.Expand = false;
			w20.Fill = false;
			this.vbox1.Add(this.hbox15);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox15]));
			w21.Position = 2;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Buscar:");
			this.hbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.TxtSearch = new global::Gtk.Entry();
			this.TxtSearch.CanFocus = true;
			this.TxtSearch.Name = "TxtSearch";
			this.TxtSearch.IsEditable = true;
			this.TxtSearch.WidthChars = 30;
			this.hbox1.Add(this.TxtSearch);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.TxtSearch]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnUpdate = new global::Gtk.Button();
			this.BtnUpdate.CanFocus = true;
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.UseUnderline = true;
			this.BtnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			global::Gtk.Image w24 = new global::Gtk.Image();
			w24.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.BtnUpdate.Image = w24;
			this.hbox1.Add(this.BtnUpdate);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnUpdate]));
			w25.PackType = ((global::Gtk.PackType)(1));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w26.Position = 0;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.viewTable = new global::SistemaEyS.AdminForms.Tables.ViewTableTemplate();
			this.viewTable.CanFocus = true;
			this.viewTable.Name = "viewTable";
			this.GtkScrolledWindow.Add(this.viewTable);
			this.vbox2.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w28.Position = 1;
			this.vbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
			w29.Position = 3;
			this.alignment2.Add(this.vbox1);
			this.Add(this.alignment2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 382;
			this.DefaultHeight = 408;
			this.Show();
			this.BtnNew.Clicked += new global::System.EventHandler(this.BtnNewOnClicked);
			this.BtnAdd.Clicked += new global::System.EventHandler(this.BtnAddOnClicked);
			this.BtnEdit.Clicked += new global::System.EventHandler(this.BtnEditOnClicked);
			this.BtnRemove.Clicked += new global::System.EventHandler(this.BtnRemoveOnClicked);
			this.TxtSearch.Changed += new global::System.EventHandler(this.TxtSearchOnChanged);
			this.viewTable.RowActivated += new global::Gtk.RowActivatedHandler(this.ViewTableOnRowActivated);
		}
	}
}
