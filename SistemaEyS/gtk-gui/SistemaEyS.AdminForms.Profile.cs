
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms
{
	public partial class Profile
	{
		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Label label1;

		private global::Gtk.Alignment alignment2;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Entry TxtUser;

		private global::Gtk.Label label9;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Entry TxtName;

		private global::Gtk.Label label10;

		private global::Gtk.HBox hbox8;

		private global::Gtk.Entry TxtSurname;

		private global::Gtk.Label label11;

		private global::Gtk.HBox hbox9;

		private global::Gtk.Entry TxtEmail;

		private global::Gtk.Label label12;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button BtnExit;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Profile
			this.Name = "SistemaEyS.AdminForms.Profile";
			this.Title = global::Mono.Unix.Catalog.GetString("Administrador | Perfil");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Container child SistemaEyS.AdminForms.Profile.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.LeftPadding = ((uint)(10));
			this.alignment1.TopPadding = ((uint)(10));
			this.alignment1.RightPadding = ((uint)(10));
			this.alignment1.BottomPadding = ((uint)(10));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = "<span weight=\"heavy\" size=\"x-large\">Perfil</span>";
			this.label1.UseMarkup = true;
			this.vbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			w1.Padding = ((uint)(10));
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 1F);
			this.alignment2.Name = "alignment2";
			// Container child alignment2.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 12;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.TxtUser = new global::Gtk.Entry();
			this.TxtUser.Name = "TxtUser";
			this.TxtUser.IsEditable = false;
			this.TxtUser.WidthChars = 25;
			this.hbox6.Add(this.TxtUser);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.TxtUser]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 0;
			w2.Expand = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Usuario:");
			this.hbox6.Add(this.label9);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label9]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox2.Add(this.hbox6);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox6]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.TxtName = new global::Gtk.Entry();
			this.TxtName.Name = "TxtName";
			this.TxtName.IsEditable = false;
			this.TxtName.WidthChars = 25;
			this.hbox7.Add(this.TxtName);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.TxtName]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 0;
			w5.Expand = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Nombres:");
			this.hbox7.Add(this.label10);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label10]));
			w6.PackType = ((global::Gtk.PackType)(1));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox2.Add(this.hbox7);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox7]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.TxtSurname = new global::Gtk.Entry();
			this.TxtSurname.Name = "TxtSurname";
			this.TxtSurname.IsEditable = false;
			this.TxtSurname.WidthChars = 25;
			this.hbox8.Add(this.TxtSurname);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.TxtSurname]));
			w8.PackType = ((global::Gtk.PackType)(1));
			w8.Position = 0;
			w8.Expand = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Apellidos:");
			this.hbox8.Add(this.label11);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.label11]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox2.Add(this.hbox8);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox8]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.TxtEmail = new global::Gtk.Entry();
			this.TxtEmail.Name = "TxtEmail";
			this.TxtEmail.IsEditable = false;
			this.TxtEmail.WidthChars = 25;
			this.hbox9.Add(this.TxtEmail);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.TxtEmail]));
			w11.PackType = ((global::Gtk.PackType)(1));
			w11.Position = 0;
			w11.Expand = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.label12 = new global::Gtk.Label();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Correo:");
			this.hbox9.Add(this.label12);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.label12]));
			w12.PackType = ((global::Gtk.PackType)(1));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			this.vbox2.Add(this.hbox9);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox9]));
			w13.Position = 3;
			w13.Expand = false;
			w13.Fill = false;
			this.alignment2.Add(this.vbox2);
			this.vbox1.Add(this.alignment2);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment2]));
			w15.Position = 1;
			w15.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.BtnExit = new global::Gtk.Button();
			this.BtnExit.CanFocus = true;
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.UseUnderline = true;
			this.BtnExit.Label = global::Mono.Unix.Catalog.GetString("Salir");
			global::Gtk.Image w16 = new global::Gtk.Image();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-quit", global::Gtk.IconSize.Menu);
			this.BtnExit.Image = w16;
			this.hbox1.Add(this.BtnExit);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.BtnExit]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w18.PackType = ((global::Gtk.PackType)(1));
			w18.Position = 2;
			w18.Expand = false;
			w18.Fill = false;
			this.alignment1.Add(this.vbox1);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 396;
			this.DefaultHeight = 297;
			this.Show();
			this.BtnExit.Clicked += new global::System.EventHandler(this.BtnExitOnClicked);
		}
	}
}
