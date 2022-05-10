
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.UserForms
{
	public partial class UserLogin
	{
		private global::Gtk.Alignment alignment10;

		private global::Gtk.VBox vbox9;

		private global::Gtk.HBox hbox13;

		private global::Gtk.Label lbUser;

		private global::SistemaEySLibrary.NumericEntry entUser;

		private global::Gtk.HBox hbox14;

		private global::Gtk.Label lbPassword;

		private global::SistemaEySLibrary.NumericEntry entPassword;

		private global::Gtk.Alignment alignment11;

		private global::Gtk.Button btnEnter;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.UserForms.UserLogin
			this.Name = "SistemaEyS.UserForms.UserLogin";
			this.Title = global::Mono.Unix.Catalog.GetString("Empleado | Login");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child SistemaEyS.UserForms.UserLogin.Gtk.Container+ContainerChild
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
			this.lbUser.Name = "lbUser";
			this.lbUser.LabelProp = global::Mono.Unix.Catalog.GetString("ID:");
			this.lbUser.Justify = ((global::Gtk.Justification)(1));
			this.hbox13.Add(this.lbUser);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.lbUser]));
			w1.Position = 0;
			w1.Fill = false;
			// Container child hbox13.Gtk.Box+BoxChild
			this.entUser = new global::SistemaEySLibrary.NumericEntry();
			this.entUser.CanFocus = true;
			this.entUser.Name = "entUser";
			this.entUser.IsEditable = true;
			this.entUser.WidthChars = 18;
			this.entUser.InvisibleChar = '•';
			this.hbox13.Add(this.entUser);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.entUser]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
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
			this.lbPassword.Name = "lbPassword";
			this.lbPassword.LabelProp = global::Mono.Unix.Catalog.GetString("PIN:");
			this.lbPassword.Justify = ((global::Gtk.Justification)(1));
			this.hbox14.Add(this.lbPassword);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.lbPassword]));
			w4.Position = 0;
			w4.Fill = false;
			// Container child hbox14.Gtk.Box+BoxChild
			this.entPassword = new global::SistemaEySLibrary.NumericEntry();
			this.entPassword.CanFocus = true;
			this.entPassword.Name = "entPassword";
			this.entPassword.IsEditable = true;
			this.entPassword.WidthChars = 18;
			this.entPassword.InvisibleChar = '•';
			this.hbox14.Add(this.entPassword);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.entPassword]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox9.Add(this.hbox14);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox14]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.alignment11 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment11.Name = "alignment11";
			// Container child alignment11.Gtk.Container+ContainerChild
			this.btnEnter = new global::Gtk.Button();
			this.btnEnter.CanFocus = true;
			this.btnEnter.Name = "btnEnter";
			this.btnEnter.UseUnderline = true;
			this.btnEnter.Label = global::Mono.Unix.Catalog.GetString("Entrar");
			this.alignment11.Add(this.btnEnter);
			this.vbox9.Add(this.alignment11);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.alignment11]));
			w8.Position = 2;
			w8.Fill = false;
			w8.Padding = ((uint)(10));
			this.alignment10.Add(this.vbox9);
			this.Add(this.alignment10);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 302;
			this.DefaultHeight = 261;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.btnEnter.Clicked += new global::System.EventHandler(this.btnEnterOnClicked);
		}
	}
}
