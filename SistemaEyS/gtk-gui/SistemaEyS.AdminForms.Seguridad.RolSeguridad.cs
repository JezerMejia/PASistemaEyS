
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Seguridad
{
	public partial class RolSeguridad
	{
		private global::Gtk.Alignment alignment2;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Entry TxtName;

		private global::Gtk.Alignment alignment3;

		private global::Gtk.Label label3;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Entry TxtEstado;

		private global::Gtk.Alignment alignment4;

		private global::Gtk.Label label4;

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
			// Widget SistemaEyS.AdminForms.Seguridad.RolSeguridad
			this.Name = "SistemaEyS.AdminForms.Seguridad.RolSeguridad";
			this.Title = global::Mono.Unix.Catalog.GetString("RolSeguridad");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEyS.AdminForms.Seguridad.RolSeguridad.Gtk.Container+ContainerChild
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
			this.TxtName.InvisibleChar = '●';
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
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.TxtEstado = new global::Gtk.Entry();
			this.TxtEstado.CanFocus = true;
			this.TxtEstado.Name = "TxtEstado";
			this.TxtEstado.IsEditable = true;
			this.TxtEstado.WidthChars = 20;
			this.TxtEstado.InvisibleChar = '●';
			this.hbox6.Add(this.TxtEstado);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.TxtEstado]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Estado:");
			this.label4.Justify = ((global::Gtk.Justification)(1));
			this.alignment4.Add(this.label4);
			this.hbox6.Add(this.alignment4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.alignment4]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 1;
			w7.Expand = false;
			this.vbox4.Add(this.hbox6);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox6]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.hbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox4]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
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
			global::Gtk.Image w11 = new global::Gtk.Image();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.BtnRemove.Image = w11;
			this.hbox15.Add(this.BtnRemove);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnRemove]));
			w12.PackType = ((global::Gtk.PackType)(1));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnEdit = new global::Gtk.Button();
			this.BtnEdit.CanFocus = true;
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.UseUnderline = true;
			this.BtnEdit.Label = global::Mono.Unix.Catalog.GetString("_Editar");
			global::Gtk.Image w13 = new global::Gtk.Image();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.BtnEdit.Image = w13;
			this.hbox15.Add(this.BtnEdit);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnEdit]));
			w14.PackType = ((global::Gtk.PackType)(1));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnAdd = new global::Gtk.Button();
			this.BtnAdd.CanFocus = true;
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.UseUnderline = true;
			this.BtnAdd.Label = global::Mono.Unix.Catalog.GetString("_Añadir");
			global::Gtk.Image w15 = new global::Gtk.Image();
			w15.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.BtnAdd.Image = w15;
			this.hbox15.Add(this.BtnAdd);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnAdd]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 2;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnNew = new global::Gtk.Button();
			this.BtnNew.CanFocus = true;
			this.BtnNew.Name = "BtnNew";
			this.BtnNew.UseUnderline = true;
			this.BtnNew.Label = global::Mono.Unix.Catalog.GetString("Nuevo");
			global::Gtk.Image w17 = new global::Gtk.Image();
			w17.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-new", global::Gtk.IconSize.Menu);
			this.BtnNew.Image = w17;
			this.hbox15.Add(this.BtnNew);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnNew]));
			w18.PackType = ((global::Gtk.PackType)(1));
			w18.Position = 3;
			w18.Expand = false;
			w18.Fill = false;
			this.vbox1.Add(this.hbox15);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox15]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
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
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.TxtSearch = new global::Gtk.Entry();
			this.TxtSearch.CanFocus = true;
			this.TxtSearch.Name = "TxtSearch";
			this.TxtSearch.IsEditable = true;
			this.TxtSearch.WidthChars = 30;
			this.TxtSearch.InvisibleChar = '●';
			this.hbox1.Add(this.TxtSearch);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.TxtSearch]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnUpdate = new global::Gtk.Button();
			this.BtnUpdate.CanFocus = true;
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.UseUnderline = true;
			this.BtnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			global::Gtk.Image w22 = new global::Gtk.Image();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.BtnUpdate.Image = w22;
			this.hbox1.Add(this.BtnUpdate);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnUpdate]));
			w23.PackType = ((global::Gtk.PackType)(1));
			w23.Position = 2;
			w23.Expand = false;
			w23.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.viewTable = null;
			this.GtkScrolledWindow.Add(this.viewTable);
			this.vbox2.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w26.Position = 1;
			this.vbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
			w27.Position = 2;
			this.alignment2.Add(this.vbox1);
			this.Add(this.alignment2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 429;
			this.DefaultHeight = 423;
			this.Show();
			this.BtnNew.Clicked += new global::System.EventHandler(this.BtnNewOnClicked);
			this.BtnAdd.Clicked += new global::System.EventHandler(this.BtnAddOnClicked);
			this.BtnEdit.Clicked += new global::System.EventHandler(this.BtnEditOnClicked);
			this.BtnRemove.Clicked += new global::System.EventHandler(this.BtnRemoveOnClicked);
			this.TxtSearch.Changed += new global::System.EventHandler(this.TxtSearchOnChanged);
		}
	}
}
