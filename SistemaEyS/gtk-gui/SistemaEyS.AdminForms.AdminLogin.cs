
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms
{
	public partial class AdminLogin
	{
		private global::Gtk.Alignment alignment10;

		private global::Gtk.VBox vbox9;

		private global::Gtk.HBox hbox13;

		private global::Gtk.Label lbUser;

		private global::Gtk.Entry entUser;

		private global::Gtk.HBox hbox14;

		private global::Gtk.Label lbPassword;

		private global::Gtk.Entry entPassword;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label lbRole;

		private global::Gtk.ComboBox combobox2;

		private global::Gtk.Alignment alignment11;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button btnExit;

		private global::Gtk.Button btnEnter;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.AdminLogin
			this.Name = "SistemaEyS.AdminForms.AdminLogin";
			this.Title = global::Mono.Unix.Catalog.GetString("Administrador | Login");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child SistemaEyS.AdminForms.AdminLogin.Gtk.Container+ContainerChild
			this.alignment10 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment10.Name = "alignment10";
			this.alignment10.LeftPadding = ((uint)(30));
			this.alignment10.TopPadding = ((uint)(30));
			this.alignment10.RightPadding = ((uint)(30));
			this.alignment10.BottomPadding = ((uint)(30));
			// Container child alignment10.Gtk.Container+ContainerChild
			this.vbox9 = new global::Gtk.VBox();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 30;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox13 = new global::Gtk.HBox();
			this.hbox13.Name = "hbox13";
			this.hbox13.Spacing = 6;
			// Container child hbox13.Gtk.Box+BoxChild
			this.lbUser = new global::Gtk.Label();
			this.lbUser.WidthRequest = 80;
			this.lbUser.Name = "lbUser";
			this.lbUser.LabelProp = global::Mono.Unix.Catalog.GetString("Usuario:");
			this.lbUser.Justify = ((global::Gtk.Justification)(1));
			this.hbox13.Add(this.lbUser);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.lbUser]));
			w1.Position = 0;
			w1.Fill = false;
			// Container child hbox13.Gtk.Box+BoxChild
			this.entUser = new global::Gtk.Entry();
			this.entUser.CanFocus = true;
			this.entUser.Name = "entUser";
			this.entUser.IsEditable = true;
			this.entUser.WidthChars = 18;
			this.entUser.InvisibleChar = '•';
			this.hbox13.Add(this.entUser);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.entUser]));
			w2.Position = 1;
			this.vbox9.Add(this.hbox13);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox13]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox14 = new global::Gtk.HBox();
			this.hbox14.Name = "hbox14";
			this.hbox14.Spacing = 6;
			// Container child hbox14.Gtk.Box+BoxChild
			this.lbPassword = new global::Gtk.Label();
			this.lbPassword.WidthRequest = 80;
			this.lbPassword.Name = "lbPassword";
			this.lbPassword.LabelProp = global::Mono.Unix.Catalog.GetString("Contraseña:");
			this.lbPassword.Justify = ((global::Gtk.Justification)(1));
			this.hbox14.Add(this.lbPassword);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.lbPassword]));
			w4.Position = 0;
			w4.Fill = false;
			// Container child hbox14.Gtk.Box+BoxChild
			this.entPassword = new global::Gtk.Entry();
			this.entPassword.CanFocus = true;
			this.entPassword.Name = "entPassword";
			this.entPassword.IsEditable = true;
			this.entPassword.WidthChars = 18;
			this.entPassword.Visibility = false;
			this.entPassword.InvisibleChar = '•';
			this.hbox14.Add(this.entPassword);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.entPassword]));
			w5.Position = 1;
			this.vbox9.Add(this.hbox14);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox14]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.lbRole = new global::Gtk.Label();
			this.lbRole.WidthRequest = 80;
			this.lbRole.Name = "lbRole";
			this.lbRole.LabelProp = global::Mono.Unix.Catalog.GetString("Rol:");
			this.lbRole.Justify = ((global::Gtk.Justification)(1));
			this.hbox1.Add(this.lbRole);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.lbRole]));
			w7.Position = 0;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.combobox2 = global::Gtk.ComboBox.NewText();
			this.combobox2.AppendText(global::Mono.Unix.Catalog.GetString("RRHH"));
			this.combobox2.AppendText(global::Mono.Unix.Catalog.GetString("Gerencia General"));
			this.combobox2.AppendText(global::Mono.Unix.Catalog.GetString("IT"));
			this.combobox2.Name = "combobox2";
			this.combobox2.Active = 0;
			this.hbox1.Add(this.combobox2);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.combobox2]));
			w8.Position = 1;
			w8.Fill = false;
			this.vbox9.Add(this.hbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox1]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.alignment11 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment11.Name = "alignment11";
			// Container child alignment11.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Homogeneous = true;
			this.hbox2.Spacing = 20;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnExit = new global::Gtk.Button();
			this.btnExit.CanFocus = true;
			this.btnExit.Name = "btnExit";
			this.btnExit.UseUnderline = true;
			this.btnExit.Label = global::Mono.Unix.Catalog.GetString("Salir");
			this.hbox2.Add(this.btnExit);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.btnExit]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.btnEnter = new global::Gtk.Button();
			this.btnEnter.CanFocus = true;
			this.btnEnter.Name = "btnEnter";
			this.btnEnter.UseUnderline = true;
			this.btnEnter.Label = global::Mono.Unix.Catalog.GetString("Entrar");
			this.hbox2.Add(this.btnEnter);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.btnEnter]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.alignment11.Add(this.hbox2);
			this.vbox9.Add(this.alignment11);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.alignment11]));
			w13.Position = 3;
			w13.Fill = false;
			w13.Padding = ((uint)(10));
			this.alignment10.Add(this.vbox9);
			this.Add(this.alignment10);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 448;
			this.DefaultHeight = 326;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.btnExit.Clicked += new global::System.EventHandler(this.btnExitOnClicked);
			this.btnEnter.Clicked += new global::System.EventHandler(this.btnEnterOnClicked);
		}
	}
}
