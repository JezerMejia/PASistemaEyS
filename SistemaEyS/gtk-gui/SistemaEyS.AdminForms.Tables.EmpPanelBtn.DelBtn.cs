
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
	public partial class DelBtn
	{
		private global::Gtk.Alignment alignment8;

		private global::Gtk.VBox vbox8;

		private global::Gtk.Alignment alignment11;

		private global::Gtk.Alignment alignment13;

		private global::Gtk.VBox vbox9;

		private global::Gtk.HBox hbox18;

		private global::Gtk.ComboBoxEntry CmbxEntry;

		private global::Gtk.Label label9;

		private global::Gtk.HBox hbox19;

		private global::Gtk.Entry TxtName;

		private global::Gtk.Label label10;

		private global::Gtk.HBox hbox20;

		private global::Gtk.Entry TxtLastName;

		private global::Gtk.Label label11;

		private global::Gtk.Alignment alignment12;

		private global::Gtk.HBox hbox17;

		private global::Gtk.Button BtnAccept;

		private global::Gtk.Button BtnCancel;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.EmpPanelBtn.DelBtn
			this.Name = "SistemaEyS.AdminForms.Tables.EmpPanelBtn.DelBtn";
			this.Title = global::Mono.Unix.Catalog.GetString("DelBtn");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEyS.AdminForms.Tables.EmpPanelBtn.DelBtn.Gtk.Container+ContainerChild
			this.alignment8 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment8.Name = "alignment8";
			this.alignment8.BorderWidth = ((uint)(10));
			// Container child alignment8.Gtk.Container+ContainerChild
			this.vbox8 = new global::Gtk.VBox();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.alignment11 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment11.Name = "alignment11";
			// Container child alignment11.Gtk.Container+ContainerChild
			this.alignment13 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment13.Name = "alignment13";
			// Container child alignment13.Gtk.Container+ContainerChild
			this.vbox9 = new global::Gtk.VBox();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 6;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox18 = new global::Gtk.HBox();
			this.hbox18.Name = "hbox18";
			this.hbox18.Spacing = 6;
			// Container child hbox18.Gtk.Box+BoxChild
			this.CmbxEntry = global::Gtk.ComboBoxEntry.NewText();
			this.CmbxEntry.Name = "CmbxEntry";
			this.hbox18.Add(this.CmbxEntry);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox18[this.CmbxEntry]));
			w1.PackType = ((global::Gtk.PackType)(1));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox18.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("ID:");
			this.hbox18.Add(this.label9);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox18[this.label9]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox9.Add(this.hbox18);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox18]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox19 = new global::Gtk.HBox();
			this.hbox19.Name = "hbox19";
			this.hbox19.Spacing = 6;
			// Container child hbox19.Gtk.Box+BoxChild
			this.TxtName = new global::Gtk.Entry();
			this.TxtName.CanFocus = true;
			this.TxtName.Name = "TxtName";
			this.TxtName.IsEditable = false;
			this.TxtName.WidthChars = 25;
			this.TxtName.InvisibleChar = '•';
			this.hbox19.Add(this.TxtName);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox19[this.TxtName]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 0;
			w4.Expand = false;
			// Container child hbox19.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Nombre:");
			this.hbox19.Add(this.label10);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox19[this.label10]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox9.Add(this.hbox19);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox19]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox9.Gtk.Box+BoxChild
			this.hbox20 = new global::Gtk.HBox();
			this.hbox20.Name = "hbox20";
			this.hbox20.Spacing = 6;
			// Container child hbox20.Gtk.Box+BoxChild
			this.TxtLastName = new global::Gtk.Entry();
			this.TxtLastName.CanFocus = true;
			this.TxtLastName.Name = "TxtLastName";
			this.TxtLastName.IsEditable = false;
			this.TxtLastName.WidthChars = 25;
			this.TxtLastName.InvisibleChar = '•';
			this.hbox20.Add(this.TxtLastName);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox20[this.TxtLastName]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 0;
			w7.Expand = false;
			// Container child hbox20.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Apellido:");
			this.hbox20.Add(this.label11);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox20[this.label11]));
			w8.PackType = ((global::Gtk.PackType)(1));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox9.Add(this.hbox20);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.hbox20]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.alignment13.Add(this.vbox9);
			this.alignment11.Add(this.alignment13);
			this.vbox8.Add(this.alignment11);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.alignment11]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.alignment12 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment12.Name = "alignment12";
			this.alignment12.BorderWidth = ((uint)(10));
			// Container child alignment12.Gtk.Container+ContainerChild
			this.hbox17 = new global::Gtk.HBox();
			this.hbox17.Name = "hbox17";
			this.hbox17.Spacing = 10;
			// Container child hbox17.Gtk.Box+BoxChild
			this.BtnAccept = new global::Gtk.Button();
			this.BtnAccept.CanFocus = true;
			this.BtnAccept.Name = "BtnAccept";
			this.BtnAccept.UseUnderline = true;
			this.BtnAccept.Label = global::Mono.Unix.Catalog.GetString("Aceptar");
			this.hbox17.Add(this.BtnAccept);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.BtnAccept]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox17.Gtk.Box+BoxChild
			this.BtnCancel = new global::Gtk.Button();
			this.BtnCancel.CanFocus = true;
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.UseUnderline = true;
			this.BtnCancel.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.hbox17.Add(this.BtnCancel);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.BtnCancel]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			this.alignment12.Add(this.hbox17);
			this.vbox8.Add(this.alignment12);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.alignment12]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			this.alignment8.Add(this.vbox8);
			this.Add(this.alignment8);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 302;
			this.DefaultHeight = 241;
			this.Show();
			this.CmbxEntry.Changed += new global::System.EventHandler(this.ComboBoxOnChanged);
			this.BtnAccept.Clicked += new global::System.EventHandler(this.BtnAcceptOnClicked);
			this.BtnCancel.Clicked += new global::System.EventHandler(this.BtnCancelOnClicked);
		}
	}
}
