
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn
{
	public partial class AddDialogSolVac
	{
		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Alignment alignment4;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Alignment alignment9;

		private global::Gtk.Button button8;

		private global::Gtk.Entry fechaTxt;

		private global::Gtk.Label label1;

		private global::Gtk.HBox hbox4;

		private global::Gtk.ComboBoxEntry idEmp;

		private global::Gtk.Label label2;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button button9;

		private global::Gtk.Entry fecIni;

		private global::Gtk.Label label3;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Button button10;

		private global::Gtk.Entry fecSal;

		private global::Gtk.Label label4;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Alignment alignment5;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.TextView justTxt;

		private global::Gtk.Alignment alignment8;

		private global::Gtk.Label label5;

		private global::Gtk.Alignment alignment3;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button saveBtn;

		private global::Gtk.Button exitBtn;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.AddDialogSolVac
			this.Name = "SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.AddDialogSolVac";
			this.Title = global::Mono.Unix.Catalog.GetString("AddDialogSolVac");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.AddDialogSolVac.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment1.Name = "alignment1";
			this.alignment1.BorderWidth = ((uint)(10));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.alignment9 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment9.Name = "alignment9";
			// Container child alignment9.Gtk.Container+ContainerChild
			this.button8 = new global::Gtk.Button();
			this.button8.CanFocus = true;
			this.button8.Name = "button8";
			this.button8.UseUnderline = true;
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "stock_calendar", global::Gtk.IconSize.Menu);
			this.button8.Image = w1;
			this.alignment9.Add(this.button8);
			this.hbox3.Add(this.alignment9);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.alignment9]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.fechaTxt = new global::Gtk.Entry();
			this.fechaTxt.CanFocus = true;
			this.fechaTxt.Name = "fechaTxt";
			this.fechaTxt.IsEditable = true;
			this.fechaTxt.InvisibleChar = '•';
			this.hbox3.Add(this.fechaTxt);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.fechaTxt]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 1;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Fecha de solicitud:");
			this.hbox3.Add(this.label1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label1]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			this.alignment4.Add(this.hbox3);
			this.vbox1.Add(this.alignment4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment4]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.idEmp = global::Gtk.ComboBoxEntry.NewText();
			this.idEmp.Name = "idEmp";
			this.hbox4.Add(this.idEmp);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.idEmp]));
			w8.PackType = ((global::Gtk.PackType)(1));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("ID Empleado:");
			this.hbox4.Add(this.label2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label2]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.button9 = new global::Gtk.Button();
			this.button9.CanFocus = true;
			this.button9.Name = "button9";
			this.button9.UseUnderline = true;
			global::Gtk.Image w11 = new global::Gtk.Image();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "stock_calendar", global::Gtk.IconSize.Menu);
			this.button9.Image = w11;
			this.hbox5.Add(this.button9);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.button9]));
			w12.PackType = ((global::Gtk.PackType)(1));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.fecIni = new global::Gtk.Entry();
			this.fecIni.CanFocus = true;
			this.fecIni.Name = "fecIni";
			this.fecIni.IsEditable = true;
			this.fecIni.InvisibleChar = '•';
			this.hbox5.Add(this.fecIni);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.fecIni]));
			w13.PackType = ((global::Gtk.PackType)(1));
			w13.Position = 1;
			w13.Expand = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Fecha inicio:");
			this.hbox5.Add(this.label3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label3]));
			w14.PackType = ((global::Gtk.PackType)(1));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			this.vbox1.Add(this.hbox5);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox5]));
			w15.Position = 2;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.button10 = new global::Gtk.Button();
			this.button10.CanFocus = true;
			this.button10.Name = "button10";
			this.button10.UseUnderline = true;
			global::Gtk.Image w16 = new global::Gtk.Image();
			w16.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "stock_calendar", global::Gtk.IconSize.Menu);
			this.button10.Image = w16;
			this.hbox6.Add(this.button10);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.button10]));
			w17.PackType = ((global::Gtk.PackType)(1));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.fecSal = new global::Gtk.Entry();
			this.fecSal.Sensitive = false;
			this.fecSal.CanFocus = true;
			this.fecSal.Name = "fecSal";
			this.fecSal.IsEditable = false;
			this.fecSal.InvisibleChar = '•';
			this.hbox6.Add(this.fecSal);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.fecSal]));
			w18.PackType = ((global::Gtk.PackType)(1));
			w18.Position = 1;
			w18.Expand = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Fecha fin:");
			this.hbox6.Add(this.label4);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label4]));
			w19.PackType = ((global::Gtk.PackType)(1));
			w19.Position = 2;
			w19.Expand = false;
			w19.Fill = false;
			this.vbox1.Add(this.hbox6);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox6]));
			w20.Position = 3;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 0F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			this.GtkScrolledWindow.WindowPlacement = ((global::Gtk.CornerType)(3));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.justTxt = new global::Gtk.TextView();
			this.justTxt.CanFocus = true;
			this.justTxt.Name = "justTxt";
			this.GtkScrolledWindow.Add(this.justTxt);
			this.alignment5.Add(this.GtkScrolledWindow);
			this.hbox7.Add(this.alignment5);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.alignment5]));
			w23.PackType = ((global::Gtk.PackType)(1));
			w23.Position = 0;
			// Container child hbox7.Gtk.Box+BoxChild
			this.alignment8 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment8.Name = "alignment8";
			// Container child alignment8.Gtk.Container+ContainerChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Justificacion:");
			this.alignment8.Add(this.label5);
			this.hbox7.Add(this.alignment8);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.alignment8]));
			w25.PackType = ((global::Gtk.PackType)(1));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			this.vbox1.Add(this.hbox7);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox7]));
			w26.Position = 4;
			w26.Expand = false;
			w26.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment3.Name = "alignment3";
			// Container child alignment3.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.saveBtn = new global::Gtk.Button();
			this.saveBtn.CanFocus = true;
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.UseUnderline = true;
			this.saveBtn.Label = global::Mono.Unix.Catalog.GetString("Guardar");
			this.hbox2.Add(this.saveBtn);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.saveBtn]));
			w27.Position = 0;
			w27.Expand = false;
			w27.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.exitBtn = new global::Gtk.Button();
			this.exitBtn.CanFocus = true;
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.UseUnderline = true;
			this.exitBtn.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.hbox2.Add(this.exitBtn);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.exitBtn]));
			w28.Position = 1;
			w28.Expand = false;
			w28.Fill = false;
			this.alignment3.Add(this.hbox2);
			this.vbox1.Add(this.alignment3);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.alignment3]));
			w30.Position = 5;
			w30.Expand = false;
			w30.Fill = false;
			this.alignment1.Add(this.vbox1);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 432;
			this.DefaultHeight = 315;
			this.Show();
			this.button8.Clicked += new global::System.EventHandler(this.OnButton8Clicked);
			this.fecIni.TextInserted += new global::Gtk.TextInsertedHandler(this.OnFecIniTextInserted);
			this.fecIni.TextDeleted += new global::Gtk.TextDeletedHandler(this.OnFecIniTextDeleted);
			this.button9.Clicked += new global::System.EventHandler(this.OnButton9Clicked);
			this.button10.Clicked += new global::System.EventHandler(this.OnButton10Clicked);
			this.saveBtn.Clicked += new global::System.EventHandler(this.OnButton4Clicked);
			this.exitBtn.Clicked += new global::System.EventHandler(this.OnExitBtnClicked);
		}
	}
}
