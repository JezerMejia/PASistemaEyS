
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Seguridad
{
	public partial class UserSeguridad
	{
		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Alignment alignment2;

		private global::Gtk.Label label3;

		private global::Gtk.Entry TxtName;

		private global::Gtk.HBox hbox9;

		private global::Gtk.Alignment alignment6;

		private global::Gtk.Label label5;

		private global::Gtk.Entry TxtLastname;

		private global::Gtk.HBox hbox10;

		private global::Gtk.Alignment alignment7;

		private global::Gtk.Label label6;

		private global::Gtk.Entry TxtEmail;

		private global::Gtk.HBox hbox11;

		private global::Gtk.Alignment alignment8;

		private global::Gtk.Label label7;

		private global::Gtk.Entry TxtEmailConfirm;

		private global::Gtk.VBox vbox6;

		private global::Gtk.HBox hbox14;

		private global::Gtk.Alignment alignment11;

		private global::Gtk.Label label10;

		private global::Gtk.Entry TxtUser;

		private global::Gtk.HBox hbox12;

		private global::Gtk.Alignment alignment9;

		private global::Gtk.Label label8;

		private global::Gtk.Entry TxtPassword;

		private global::Gtk.HBox hbox13;

		private global::Gtk.Alignment alignment10;

		private global::Gtk.Label label9;

		private global::Gtk.Entry TxtPasswordConfirm;

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

		private global::SistemaEySLibrary.ViewTableTemplate viewTable;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Seguridad.UserSeguridad
			this.Name = "SistemaEyS.AdminForms.Seguridad.UserSeguridad";
			this.Title = global::Mono.Unix.Catalog.GetString("Seguridad | Usuario");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child SistemaEyS.AdminForms.Seguridad.UserSeguridad.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(10));
			this.alignment1.TopPadding = ((uint)(10));
			this.alignment1.RightPadding = ((uint)(10));
			this.alignment1.BottomPadding = ((uint)(10));
			// Container child alignment1.Gtk.Container+ContainerChild
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
			this.alignment2 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			// Container child alignment2.Gtk.Container+ContainerChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre:");
			this.label3.Justify = ((global::Gtk.Justification)(1));
			this.alignment2.Add(this.label3);
			this.hbox5.Add(this.alignment2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.alignment2]));
			w2.Position = 0;
			// Container child hbox5.Gtk.Box+BoxChild
			this.TxtName = new global::Gtk.Entry();
			this.TxtName.CanFocus = true;
			this.TxtName.Name = "TxtName";
			this.TxtName.IsEditable = true;
			this.TxtName.WidthChars = 20;
			this.TxtName.InvisibleChar = '???';
			this.hbox5.Add(this.TxtName);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.TxtName]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox4.Add(this.hbox5);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox5]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Apellidos:");
			this.alignment6.Add(this.label5);
			this.hbox9.Add(this.alignment6);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.alignment6]));
			w6.Position = 0;
			// Container child hbox9.Gtk.Box+BoxChild
			this.TxtLastname = new global::Gtk.Entry();
			this.TxtLastname.CanFocus = true;
			this.TxtLastname.Name = "TxtLastname";
			this.TxtLastname.IsEditable = true;
			this.TxtLastname.WidthChars = 20;
			this.TxtLastname.InvisibleChar = '???';
			this.hbox9.Add(this.TxtLastname);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.TxtLastname]));
			w7.Position = 1;
			w7.Expand = false;
			this.vbox4.Add(this.hbox9);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox9]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox10 = new global::Gtk.HBox();
			this.hbox10.Name = "hbox10";
			this.hbox10.Spacing = 6;
			// Container child hbox10.Gtk.Box+BoxChild
			this.alignment7 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment7.Name = "alignment7";
			// Container child alignment7.Gtk.Container+ContainerChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Email:");
			this.alignment7.Add(this.label6);
			this.hbox10.Add(this.alignment7);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.alignment7]));
			w10.Position = 0;
			// Container child hbox10.Gtk.Box+BoxChild
			this.TxtEmail = new global::Gtk.Entry();
			this.TxtEmail.CanFocus = true;
			this.TxtEmail.Name = "TxtEmail";
			this.TxtEmail.IsEditable = true;
			this.TxtEmail.WidthChars = 20;
			this.TxtEmail.InvisibleChar = '???';
			this.hbox10.Add(this.TxtEmail);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox10[this.TxtEmail]));
			w11.Position = 1;
			w11.Expand = false;
			this.vbox4.Add(this.hbox10);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox10]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox11 = new global::Gtk.HBox();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.alignment8 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment8.Name = "alignment8";
			// Container child alignment8.Gtk.Container+ContainerChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Confirmar\nEmail:");
			this.label7.Wrap = true;
			this.label7.Justify = ((global::Gtk.Justification)(1));
			this.alignment8.Add(this.label7);
			this.hbox11.Add(this.alignment8);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.alignment8]));
			w14.Position = 0;
			// Container child hbox11.Gtk.Box+BoxChild
			this.TxtEmailConfirm = new global::Gtk.Entry();
			this.TxtEmailConfirm.CanFocus = true;
			this.TxtEmailConfirm.Name = "TxtEmailConfirm";
			this.TxtEmailConfirm.IsEditable = true;
			this.TxtEmailConfirm.WidthChars = 20;
			this.TxtEmailConfirm.InvisibleChar = '???';
			this.hbox11.Add(this.TxtEmailConfirm);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.TxtEmailConfirm]));
			w15.Position = 1;
			w15.Expand = false;
			this.vbox4.Add(this.hbox11);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox11]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			this.hbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox4]));
			w17.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox6 = new global::Gtk.VBox();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox14 = new global::Gtk.HBox();
			this.hbox14.Name = "hbox14";
			this.hbox14.Spacing = 6;
			// Container child hbox14.Gtk.Box+BoxChild
			this.alignment11 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment11.Name = "alignment11";
			// Container child alignment11.Gtk.Container+ContainerChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Usuario:");
			this.alignment11.Add(this.label10);
			this.hbox14.Add(this.alignment11);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.alignment11]));
			w19.Position = 0;
			// Container child hbox14.Gtk.Box+BoxChild
			this.TxtUser = new global::Gtk.Entry();
			this.TxtUser.CanFocus = true;
			this.TxtUser.Name = "TxtUser";
			this.TxtUser.IsEditable = true;
			this.TxtUser.WidthChars = 20;
			this.TxtUser.InvisibleChar = '???';
			this.hbox14.Add(this.TxtUser);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.TxtUser]));
			w20.Position = 1;
			w20.Expand = false;
			this.vbox6.Add(this.hbox14);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox14]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox12 = new global::Gtk.HBox();
			this.hbox12.Name = "hbox12";
			this.hbox12.Spacing = 6;
			// Container child hbox12.Gtk.Box+BoxChild
			this.alignment9 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment9.Name = "alignment9";
			// Container child alignment9.Gtk.Container+ContainerChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Contrase??a:");
			this.alignment9.Add(this.label8);
			this.hbox12.Add(this.alignment9);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.alignment9]));
			w23.Position = 0;
			// Container child hbox12.Gtk.Box+BoxChild
			this.TxtPassword = new global::Gtk.Entry();
			this.TxtPassword.CanFocus = true;
			this.TxtPassword.Name = "TxtPassword";
			this.TxtPassword.IsEditable = true;
			this.TxtPassword.WidthChars = 20;
			this.TxtPassword.InvisibleChar = '???';
			this.hbox12.Add(this.TxtPassword);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.TxtPassword]));
			w24.Position = 1;
			w24.Expand = false;
			this.vbox6.Add(this.hbox12);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox12]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox13 = new global::Gtk.HBox();
			this.hbox13.Name = "hbox13";
			this.hbox13.Spacing = 6;
			// Container child hbox13.Gtk.Box+BoxChild
			this.alignment10 = new global::Gtk.Alignment(1F, 0.5F, 1F, 1F);
			this.alignment10.Name = "alignment10";
			// Container child alignment10.Gtk.Container+ContainerChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Confirmar\nContrase??a:");
			this.alignment10.Add(this.label9);
			this.hbox13.Add(this.alignment10);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.alignment10]));
			w27.Position = 0;
			// Container child hbox13.Gtk.Box+BoxChild
			this.TxtPasswordConfirm = new global::Gtk.Entry();
			this.TxtPasswordConfirm.CanFocus = true;
			this.TxtPasswordConfirm.Name = "TxtPasswordConfirm";
			this.TxtPasswordConfirm.IsEditable = true;
			this.TxtPasswordConfirm.WidthChars = 20;
			this.TxtPasswordConfirm.InvisibleChar = '???';
			this.hbox13.Add(this.TxtPasswordConfirm);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.TxtPasswordConfirm]));
			w28.Position = 1;
			w28.Expand = false;
			this.vbox6.Add(this.hbox13);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox13]));
			w29.Position = 2;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox15 = new global::Gtk.HBox();
			this.hbox15.Name = "hbox15";
			this.hbox15.Spacing = 6;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnRemove = new global::Gtk.Button();
			this.BtnRemove.CanFocus = true;
			this.BtnRemove.Name = "BtnRemove";
			this.BtnRemove.UseUnderline = true;
			this.BtnRemove.Label = global::Mono.Unix.Catalog.GetString("Quitar");
			global::Gtk.Image w30 = new global::Gtk.Image();
			w30.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.BtnRemove.Image = w30;
			this.hbox15.Add(this.BtnRemove);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnRemove]));
			w31.PackType = ((global::Gtk.PackType)(1));
			w31.Position = 0;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnEdit = new global::Gtk.Button();
			this.BtnEdit.CanFocus = true;
			this.BtnEdit.Name = "BtnEdit";
			this.BtnEdit.UseUnderline = true;
			this.BtnEdit.Label = global::Mono.Unix.Catalog.GetString("_Editar");
			global::Gtk.Image w32 = new global::Gtk.Image();
			w32.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.BtnEdit.Image = w32;
			this.hbox15.Add(this.BtnEdit);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnEdit]));
			w33.PackType = ((global::Gtk.PackType)(1));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnAdd = new global::Gtk.Button();
			this.BtnAdd.CanFocus = true;
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.UseUnderline = true;
			this.BtnAdd.Label = global::Mono.Unix.Catalog.GetString("_A??adir");
			global::Gtk.Image w34 = new global::Gtk.Image();
			w34.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.BtnAdd.Image = w34;
			this.hbox15.Add(this.BtnAdd);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnAdd]));
			w35.PackType = ((global::Gtk.PackType)(1));
			w35.Position = 2;
			w35.Expand = false;
			w35.Fill = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.BtnNew = new global::Gtk.Button();
			this.BtnNew.CanFocus = true;
			this.BtnNew.Name = "BtnNew";
			this.BtnNew.UseUnderline = true;
			this.BtnNew.Label = global::Mono.Unix.Catalog.GetString("Nuevo");
			global::Gtk.Image w36 = new global::Gtk.Image();
			w36.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-new", global::Gtk.IconSize.Menu);
			this.BtnNew.Image = w36;
			this.hbox15.Add(this.BtnNew);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.BtnNew]));
			w37.PackType = ((global::Gtk.PackType)(1));
			w37.Position = 3;
			w37.Expand = false;
			w37.Fill = false;
			this.vbox6.Add(this.hbox15);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox15]));
			w38.Position = 3;
			w38.Expand = false;
			w38.Fill = false;
			this.hbox3.Add(this.vbox6);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox6]));
			w39.Position = 1;
			w39.Expand = false;
			w39.Fill = false;
			this.vbox1.Add(this.hbox3);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox3]));
			w40.Position = 0;
			w40.Expand = false;
			w40.Fill = false;
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
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w41.Position = 0;
			w41.Expand = false;
			w41.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.TxtSearch = new global::Gtk.Entry();
			this.TxtSearch.CanFocus = true;
			this.TxtSearch.Name = "TxtSearch";
			this.TxtSearch.IsEditable = true;
			this.TxtSearch.WidthChars = 30;
			this.TxtSearch.InvisibleChar = '???';
			this.hbox1.Add(this.TxtSearch);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.TxtSearch]));
			w42.Position = 1;
			w42.Expand = false;
			w42.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnUpdate = new global::Gtk.Button();
			this.BtnUpdate.CanFocus = true;
			this.BtnUpdate.Name = "BtnUpdate";
			this.BtnUpdate.UseUnderline = true;
			this.BtnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			global::Gtk.Image w43 = new global::Gtk.Image();
			w43.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.BtnUpdate.Image = w43;
			this.hbox1.Add(this.BtnUpdate);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnUpdate]));
			w44.PackType = ((global::Gtk.PackType)(1));
			w44.Position = 2;
			w44.Expand = false;
			w44.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w45.Position = 0;
			w45.Expand = false;
			w45.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.viewTable = new global::SistemaEySLibrary.ViewTableTemplate();
			this.viewTable.CanFocus = true;
			this.viewTable.Name = "viewTable";
			this.GtkScrolledWindow.Add(this.viewTable);
			this.vbox2.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w47.Position = 1;
			this.vbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vbox2]));
			w48.Position = 1;
			this.alignment1.Add(this.vbox1);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 630;
			this.DefaultHeight = 400;
			this.Show();
			this.BtnNew.Clicked += new global::System.EventHandler(this.BtnNewOnClicked);
			this.BtnAdd.Clicked += new global::System.EventHandler(this.BtnAddOnClicked);
			this.BtnEdit.Clicked += new global::System.EventHandler(this.BtnEditOnClicked);
			this.BtnRemove.Clicked += new global::System.EventHandler(this.BtnRemoveOnClicked);
			this.TxtSearch.Changed += new global::System.EventHandler(this.TxtSearchOnChanged);
			this.BtnUpdate.Clicked += new global::System.EventHandler(this.BtnUpdateOnClicked);
			this.viewTable.RowActivated += new global::Gtk.RowActivatedHandler(this.ViewTableOnRowActivated);
		}
	}
}
