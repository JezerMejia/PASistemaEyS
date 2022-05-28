
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables
{
	public partial class HorarioView
	{
		private global::Gtk.Alignment alignment2;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label1;

		private global::Gtk.Entry SearchHorTxt;

		private global::Gtk.Alignment alignment3;

		private global::Gtk.Label label2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::SistemaEySLibrary.ViewTableTemplate viewTable;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button BtnDelete;

		private global::Gtk.Button BtnUpdate;

		private global::Gtk.Button BtnEdit;

		private global::Gtk.Button BtnAdd;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.HorarioView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEyS.AdminForms.Tables.HorarioView";
			// Container child SistemaEyS.AdminForms.Tables.HorarioView.Gtk.Container+ContainerChild
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
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 0F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Buscar:");
			this.hbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.SearchHorTxt = new global::Gtk.Entry();
			this.SearchHorTxt.CanFocus = true;
			this.SearchHorTxt.Name = "SearchHorTxt";
			this.SearchHorTxt.IsEditable = true;
			this.SearchHorTxt.InvisibleChar = '•';
			this.hbox2.Add(this.SearchHorTxt);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.SearchHorTxt]));
			w2.Position = 1;
			w2.Expand = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment3.Name = "alignment3";
			this.alignment3.RightPadding = ((uint)(150));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.alignment3.Add(this.label2);
			this.hbox2.Add(this.alignment3);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.alignment3]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.alignment1.Add(this.hbox2);
			this.vbox1.Add(this.alignment1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.viewTable = new global::SistemaEySLibrary.ViewTableTemplate();
			this.viewTable.CanFocus = true;
			this.viewTable.Name = "viewTable";
			this.GtkScrolledWindow.Add(this.viewTable);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w8.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnDelete = new global::Gtk.Button();
			this.BtnDelete.CanFocus = true;
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.UseUnderline = true;
			this.BtnDelete.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			global::Gtk.Image w9 = new global::Gtk.Image();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.BtnDelete.Image = w9;
			this.hbox1.Add(this.BtnDelete);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnDelete]));
			w10.PackType = ((global::Gtk.PackType)(1));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnUpdate = new global::Gtk.Button();
			this.BtnUpdate.CanFocus = true;
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.UseUnderline = true;
			this.BtnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			global::Gtk.Image w11 = new global::Gtk.Image();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.BtnUpdate.Image = w11;
			this.hbox1.Add(this.BtnUpdate);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnUpdate]));
			w12.PackType = ((global::Gtk.PackType)(1));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnEdit = new global::Gtk.Button();
			this.BtnEdit.CanFocus = true;
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.UseUnderline = true;
			this.BtnEdit.Label = global::Mono.Unix.Catalog.GetString("Editar");
			global::Gtk.Image w13 = new global::Gtk.Image();
			w13.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-copy", global::Gtk.IconSize.Menu);
			this.BtnEdit.Image = w13;
			this.hbox1.Add(this.BtnEdit);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnEdit]));
			w14.PackType = ((global::Gtk.PackType)(1));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnAdd = new global::Gtk.Button();
			this.BtnAdd.CanFocus = true;
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.UseUnderline = true;
			this.BtnAdd.Label = global::Mono.Unix.Catalog.GetString("Añadir");
			global::Gtk.Image w15 = new global::Gtk.Image();
			w15.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-new", global::Gtk.IconSize.Menu);
			this.BtnAdd.Image = w15;
			this.hbox1.Add(this.BtnAdd);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnAdd]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			this.alignment2.Add(this.vbox1);
			this.Add(this.alignment2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.SearchHorTxt.Changed += new global::System.EventHandler(this.OnSearchHorTxtChanged);
			this.viewTable.RowActivated += new global::Gtk.RowActivatedHandler(this.OnViewTableRowActivated);
			this.BtnAdd.Clicked += new global::System.EventHandler(this.OnBtnAddClicked);
			this.BtnEdit.Clicked += new global::System.EventHandler(this.OnBtnEditClicked);
			this.BtnUpdate.Clicked += new global::System.EventHandler(this.btnUpdateOnClicked);
			this.BtnDelete.Clicked += new global::System.EventHandler(this.OnBtnDeleteClicked);
		}
	}
}
