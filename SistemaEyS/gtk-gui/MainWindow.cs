
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox4;

	private global::Gtk.Image image76;

	private global::Gtk.Alignment alignment4;

	private global::Gtk.VBox vbox5;

	private global::Gtk.Label label5;

	private global::Gtk.Alignment alignment6;

	private global::Gtk.HBox hbox3;

	private global::Gtk.Button BtnEnterUserLogin;

	private global::Gtk.Button BtnEnterAdminLogin;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Sistema EyS");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		this.DefaultWidth = 500;
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox4 = new global::Gtk.VBox();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.image76 = new global::Gtk.Image();
		this.image76.WidthRequest = 500;
		this.image76.HeightRequest = 180;
		this.image76.Name = "image76";
		this.image76.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("SistemaEyS.Resources.Logotipo GIT.jpg");
		this.vbox4.Add(this.image76);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.image76]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.alignment4 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 0.5F);
		this.alignment4.Name = "alignment4";
		this.alignment4.LeftPadding = ((uint)(10));
		this.alignment4.TopPadding = ((uint)(10));
		this.alignment4.RightPadding = ((uint)(10));
		this.alignment4.BottomPadding = ((uint)(10));
		// Container child alignment4.Gtk.Container+ContainerChild
		this.vbox5 = new global::Gtk.VBox();
		this.vbox5.Name = "vbox5";
		this.vbox5.Spacing = 6;
		// Container child vbox5.Gtk.Box+BoxChild
		this.label5 = new global::Gtk.Label();
		this.label5.Name = "label5";
		this.label5.LabelProp = "<span weight=\"bold\" size=\"xx-large\">SistemaEyS</span>\n\nSeleccione su método de en" +
			"trada al SistemaEyS";
		this.label5.UseMarkup = true;
		this.label5.Justify = ((global::Gtk.Justification)(2));
		this.vbox5.Add(this.label5);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.label5]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		w2.Padding = ((uint)(20));
		// Container child vbox5.Gtk.Box+BoxChild
		this.alignment6 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 1F);
		this.alignment6.Name = "alignment6";
		// Container child alignment6.Gtk.Container+ContainerChild
		this.hbox3 = new global::Gtk.HBox();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.BtnEnterUserLogin = new global::Gtk.Button();
		this.BtnEnterUserLogin.CanFocus = true;
		this.BtnEnterUserLogin.Name = "BtnEnterUserLogin";
		this.BtnEnterUserLogin.UseUnderline = true;
		this.BtnEnterUserLogin.Label = global::Mono.Unix.Catalog.GetString("Empleado");
		this.hbox3.Add(this.BtnEnterUserLogin);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.BtnEnterUserLogin]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child hbox3.Gtk.Box+BoxChild
		this.BtnEnterAdminLogin = new global::Gtk.Button();
		this.BtnEnterAdminLogin.CanFocus = true;
		this.BtnEnterAdminLogin.Name = "BtnEnterAdminLogin";
		this.BtnEnterAdminLogin.UseUnderline = true;
		this.BtnEnterAdminLogin.Label = global::Mono.Unix.Catalog.GetString("Administrador");
		this.hbox3.Add(this.BtnEnterAdminLogin);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.BtnEnterAdminLogin]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		this.alignment6.Add(this.hbox3);
		this.vbox5.Add(this.alignment6);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.alignment6]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		this.alignment4.Add(this.vbox5);
		this.vbox4.Add(this.alignment4);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.alignment4]));
		w8.Position = 1;
		this.Add(this.vbox4);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultHeight = 415;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.BtnEnterUserLogin.Clicked += new global::System.EventHandler(this.BtnEnterUserLoginOnClicked);
		this.BtnEnterAdminLogin.Clicked += new global::System.EventHandler(this.BtnEnterAdminLoginOnClicked);
	}
}
