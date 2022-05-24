
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables
{
	public partial class EmpleadosView
	{
		private global::Gtk.Alignment alignment2;

		private global::Gtk.VBox vbox1;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Label label3;

		private global::SistemaEySLibrary.ComboBoxNumericEntry CmbxIDEmpleado;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label1;

		private global::Gtk.Entry TxtSearch;

		private global::Gtk.Button BtnUpdate;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::SistemaEyS.AdminForms.Tables.ViewTableTemplate viewTable;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button BtnDelete;

		private global::Gtk.Button BtnEdit;

		private global::Gtk.Button BtnAdd;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.EmpleadosView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEyS.AdminForms.Tables.EmpleadosView";
			// Container child SistemaEyS.AdminForms.Tables.EmpleadosView.Gtk.Container+ContainerChild
			this.alignment2 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.LeftPadding = ((uint)(15));
			this.alignment2.TopPadding = ((uint)(15));
			this.alignment2.RightPadding = ((uint)(15));
			this.alignment2.BottomPadding = ((uint)(15));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(1));
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("ID Empleado:");
			this.hbox5.Add(this.label3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.CmbxIDEmpleado = new global::SistemaEySLibrary.ComboBoxNumericEntry();
			this.CmbxIDEmpleado.Name = "CmbxIDEmpleado";
			this.hbox5.Add(this.CmbxIDEmpleado);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.CmbxIDEmpleado]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			w3.Padding = ((uint)(5));
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Buscar:");
			this.hbox3.Add(this.label1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.TxtSearch = new global::Gtk.Entry();
			this.TxtSearch.CanFocus = true;
			this.TxtSearch.Name = "TxtSearch";
			this.TxtSearch.IsEditable = true;
			this.TxtSearch.WidthChars = 30;
			this.TxtSearch.InvisibleChar = '●';
			this.hbox3.Add(this.TxtSearch);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.TxtSearch]));
			w5.Position = 1;
			w5.Expand = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.BtnUpdate = new global::Gtk.Button();
			this.BtnUpdate.CanFocus = true;
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.UseUnderline = true;
			this.BtnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.BtnUpdate.Image = w6;
			this.hbox3.Add(this.BtnUpdate);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.BtnUpdate]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.viewTable = null;
			this.GtkScrolledWindow.Add(this.viewTable);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w11.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.BtnDelete = new global::Gtk.Button();
			this.BtnDelete.CanFocus = true;
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.UseUnderline = true;
			this.BtnDelete.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			global::Gtk.Image w12 = new global::Gtk.Image();
			w12.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.BtnDelete.Image = w12;
			this.hbox2.Add(this.BtnDelete);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.BtnDelete]));
			w13.PackType = ((global::Gtk.PackType)(1));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.BtnEdit = new global::Gtk.Button();
			this.BtnEdit.CanFocus = true;
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.UseUnderline = true;
			this.BtnEdit.Label = global::Mono.Unix.Catalog.GetString("Editar");
			global::Gtk.Image w14 = new global::Gtk.Image();
			w14.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.BtnEdit.Image = w14;
			this.hbox2.Add(this.BtnEdit);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.BtnEdit]));
			w15.PackType = ((global::Gtk.PackType)(1));
			w15.Position = 1;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.BtnAdd = new global::Gtk.Button();
			this.BtnAdd.CanFocus = true;
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.UseUnderline = true;
			this.BtnAdd.Label = global::Mono.Unix.Catalog.GetString("Añadir");
			global::Gtk.Image w16 = new global::Gtk.Image();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.BtnAdd.Image = w16;
			this.hbox2.Add(this.BtnAdd);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.BtnAdd]));
			w17.PackType = ((global::Gtk.PackType)(1));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w18.Position = 2;
			w18.Expand = false;
			w18.Fill = false;
			w18.Padding = ((uint)(1));
			this.alignment2.Add(this.vbox1);
			this.Add(this.alignment2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.CmbxIDEmpleado.Changed += new global::System.EventHandler(this.CmbxEmpleadoOnChanged);
			this.TxtSearch.Changed += new global::System.EventHandler(this.TxtSearchOnChanged);
			this.BtnUpdate.Clicked += new global::System.EventHandler(this.BtnUpdateOnClicked);
			this.BtnAdd.Clicked += new global::System.EventHandler(this.BtnAddOnClicked);
			this.BtnEdit.Clicked += new global::System.EventHandler(this.BtnEditOnClicked);
			this.BtnDelete.Clicked += new global::System.EventHandler(this.BtnDeleteOnClicked);
		}
	}
}
