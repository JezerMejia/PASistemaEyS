
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables.EmpPanelBtn
{
	public partial class ActBtn
	{
		private global::Gtk.Alignment alignment5;

		private global::Gtk.VBox vbox6;

		private global::Gtk.HBox hbox1;

		private global::Gtk.VBox vbox7;

		private global::Gtk.HBox hbox13;

		private global::SistemaEySLibrary.ComboBoxNumericEntry CmbxEntry;

		private global::Gtk.Label label5;

		private global::Gtk.HBox hbox17;

		private global::Gtk.Button BtnNewIDUpdate;

		private global::Gtk.Entry newId;

		private global::Gtk.Label label9;

		private global::Gtk.HBox hbox14;

		private global::Gtk.Entry name;

		private global::Gtk.Label label6;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Entry secondName;

		private global::Gtk.Label label1;

		private global::Gtk.HBox hbox15;

		private global::Gtk.Entry surname;

		private global::Gtk.Label label7;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Entry secondSurname;

		private global::Gtk.Label label2;

		private global::Gtk.HBox hbox16;

		private global::Gtk.Entry password;

		private global::Gtk.Label label8;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Entry dIngress;

		private global::Gtk.Label label3;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Entry Icard;

		private global::Gtk.Label label4;

		private global::Gtk.HBox hbox18;

		private global::Gtk.Entry idCar;

		private global::Gtk.Label label10;

		private global::Gtk.HBox hbox19;

		private global::Gtk.Entry idDep;

		private global::Gtk.Label label11;

		private global::Gtk.HBox hbox20;

		private global::Gtk.Entry idHor;

		private global::Gtk.Label label12;

		private global::Gtk.HBox hbox21;

		private global::Gtk.Entry idGroup;

		private global::Gtk.Label label13;

		private global::Gtk.Alignment alignment6;

		private global::Gtk.HBox hbox12;

		private global::Gtk.Button BtnAccept;

		private global::Gtk.Button BtnCancel;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.EmpPanelBtn.ActBtn
			this.Name = "SistemaEyS.AdminForms.Tables.EmpPanelBtn.ActBtn";
			this.Title = global::Mono.Unix.Catalog.GetString("ActBtn");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEyS.AdminForms.Tables.EmpPanelBtn.ActBtn.Gtk.Container+ContainerChild
			this.alignment5 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment5.Name = "alignment5";
			this.alignment5.BorderWidth = ((uint)(10));
			// Container child alignment5.Gtk.Container+ContainerChild
			this.vbox6 = new global::Gtk.VBox();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox13 = new global::Gtk.HBox();
			this.hbox13.Name = "hbox13";
			this.hbox13.Spacing = 6;
			// Container child hbox13.Gtk.Box+BoxChild
			this.CmbxEntry = new global::SistemaEySLibrary.ComboBoxNumericEntry();
			this.CmbxEntry.Name = "CmbxEntry";
			this.hbox13.Add(this.CmbxEntry);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.CmbxEntry]));
			w1.PackType = ((global::Gtk.PackType)(1));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox13.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("ID:");
			this.hbox13.Add(this.label5);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox13[this.label5]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox7.Add(this.hbox13);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox13]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox17 = new global::Gtk.HBox();
			this.hbox17.Name = "hbox17";
			this.hbox17.Spacing = 6;
			// Container child hbox17.Gtk.Box+BoxChild
			this.BtnNewIDUpdate = new global::Gtk.Button();
			this.BtnNewIDUpdate.CanFocus = true;
			this.BtnNewIDUpdate.Name = "BtnNewIDUpdate";
			this.BtnNewIDUpdate.UseUnderline = true;
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.BtnNewIDUpdate.Image = w4;
			this.hbox17.Add(this.BtnNewIDUpdate);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.BtnNewIDUpdate]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox17.Gtk.Box+BoxChild
			this.newId = new global::Gtk.Entry();
			this.newId.CanFocus = true;
			this.newId.Name = "newId";
			this.newId.IsEditable = true;
			this.newId.WidthChars = 15;
			this.newId.InvisibleChar = '•';
			this.hbox17.Add(this.newId);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.newId]));
			w6.PackType = ((global::Gtk.PackType)(1));
			w6.Position = 1;
			w6.Expand = false;
			// Container child hbox17.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Nuevo ID:");
			this.hbox17.Add(this.label9);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox17[this.label9]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox7.Add(this.hbox17);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox17]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox14 = new global::Gtk.HBox();
			this.hbox14.Name = "hbox14";
			this.hbox14.Spacing = 6;
			// Container child hbox14.Gtk.Box+BoxChild
			this.name = new global::Gtk.Entry();
			this.name.CanFocus = true;
			this.name.Name = "name";
			this.name.IsEditable = true;
			this.name.WidthChars = 20;
			this.name.InvisibleChar = '•';
			this.hbox14.Add(this.name);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.name]));
			w9.PackType = ((global::Gtk.PackType)(1));
			w9.Position = 0;
			w9.Expand = false;
			// Container child hbox14.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Primer Nombre:");
			this.hbox14.Add(this.label6);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox14[this.label6]));
			w10.PackType = ((global::Gtk.PackType)(1));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox7.Add(this.hbox14);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox14]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.secondName = new global::Gtk.Entry();
			this.secondName.CanFocus = true;
			this.secondName.Name = "secondName";
			this.secondName.IsEditable = true;
			this.secondName.WidthChars = 20;
			this.secondName.InvisibleChar = '•';
			this.hbox2.Add(this.secondName);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.secondName]));
			w12.PackType = ((global::Gtk.PackType)(1));
			w12.Position = 0;
			w12.Expand = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Segundo Nombre:");
			this.hbox2.Add(this.label1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label1]));
			w13.PackType = ((global::Gtk.PackType)(1));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			this.vbox7.Add(this.hbox2);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox2]));
			w14.Position = 3;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox15 = new global::Gtk.HBox();
			this.hbox15.Name = "hbox15";
			this.hbox15.Spacing = 6;
			// Container child hbox15.Gtk.Box+BoxChild
			this.surname = new global::Gtk.Entry();
			this.surname.CanFocus = true;
			this.surname.Name = "surname";
			this.surname.IsEditable = true;
			this.surname.WidthChars = 20;
			this.surname.InvisibleChar = '•';
			this.hbox15.Add(this.surname);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.surname]));
			w15.PackType = ((global::Gtk.PackType)(1));
			w15.Position = 0;
			w15.Expand = false;
			// Container child hbox15.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Primer Apellido:");
			this.hbox15.Add(this.label7);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox15[this.label7]));
			w16.PackType = ((global::Gtk.PackType)(1));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			this.vbox7.Add(this.hbox15);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox15]));
			w17.Position = 4;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.secondSurname = new global::Gtk.Entry();
			this.secondSurname.CanFocus = true;
			this.secondSurname.Name = "secondSurname";
			this.secondSurname.IsEditable = true;
			this.secondSurname.WidthChars = 20;
			this.secondSurname.InvisibleChar = '•';
			this.hbox3.Add(this.secondSurname);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.secondSurname]));
			w18.PackType = ((global::Gtk.PackType)(1));
			w18.Position = 0;
			w18.Expand = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Segundo Apellido:");
			this.hbox3.Add(this.label2);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label2]));
			w19.PackType = ((global::Gtk.PackType)(1));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.vbox7.Add(this.hbox3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox3]));
			w20.Position = 5;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.hbox16 = new global::Gtk.HBox();
			this.hbox16.Name = "hbox16";
			this.hbox16.Spacing = 6;
			// Container child hbox16.Gtk.Box+BoxChild
			this.password = new global::Gtk.Entry();
			this.password.CanFocus = true;
			this.password.Name = "password";
			this.password.IsEditable = true;
			this.password.WidthChars = 20;
			this.password.InvisibleChar = '•';
			this.hbox16.Add(this.password);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox16[this.password]));
			w21.PackType = ((global::Gtk.PackType)(1));
			w21.Position = 0;
			w21.Expand = false;
			// Container child hbox16.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Contraseña:");
			this.hbox16.Add(this.label8);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox16[this.label8]));
			w22.PackType = ((global::Gtk.PackType)(1));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			this.vbox7.Add(this.hbox16);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.hbox16]));
			w23.Position = 6;
			w23.Expand = false;
			w23.Fill = false;
			this.hbox1.Add(this.vbox7);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox7]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.dIngress = new global::Gtk.Entry();
			this.dIngress.CanFocus = true;
			this.dIngress.Name = "dIngress";
			this.dIngress.IsEditable = true;
			this.dIngress.WidthChars = 20;
			this.dIngress.InvisibleChar = '•';
			this.hbox4.Add(this.dIngress);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.dIngress]));
			w25.PackType = ((global::Gtk.PackType)(1));
			w25.Position = 0;
			w25.Expand = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Fecha de Ingreso:");
			this.hbox4.Add(this.label3);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.label3]));
			w26.PackType = ((global::Gtk.PackType)(1));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			this.vbox2.Add(this.hbox4);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
			w27.Position = 0;
			w27.Expand = false;
			w27.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.Icard = new global::Gtk.Entry();
			this.Icard.CanFocus = true;
			this.Icard.Name = "Icard";
			this.Icard.IsEditable = true;
			this.Icard.WidthChars = 20;
			this.Icard.InvisibleChar = '•';
			this.hbox5.Add(this.Icard);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.Icard]));
			w28.PackType = ((global::Gtk.PackType)(1));
			w28.Position = 0;
			w28.Expand = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Cédula de Identidad:");
			this.hbox5.Add(this.label4);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.label4]));
			w29.PackType = ((global::Gtk.PackType)(1));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w30.Position = 1;
			w30.Expand = false;
			w30.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox18 = new global::Gtk.HBox();
			this.hbox18.Name = "hbox18";
			this.hbox18.Spacing = 6;
			// Container child hbox18.Gtk.Box+BoxChild
			this.idCar = new global::Gtk.Entry();
			this.idCar.CanFocus = true;
			this.idCar.Name = "idCar";
			this.idCar.IsEditable = true;
			this.idCar.WidthChars = 20;
			this.idCar.InvisibleChar = '•';
			this.hbox18.Add(this.idCar);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox18[this.idCar]));
			w31.PackType = ((global::Gtk.PackType)(1));
			w31.Position = 0;
			w31.Expand = false;
			// Container child hbox18.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Cargo:");
			this.hbox18.Add(this.label10);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.hbox18[this.label10]));
			w32.PackType = ((global::Gtk.PackType)(1));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			this.vbox2.Add(this.hbox18);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox18]));
			w33.Position = 2;
			w33.Expand = false;
			w33.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox19 = new global::Gtk.HBox();
			this.hbox19.Name = "hbox19";
			this.hbox19.Spacing = 6;
			// Container child hbox19.Gtk.Box+BoxChild
			this.idDep = new global::Gtk.Entry();
			this.idDep.CanFocus = true;
			this.idDep.Name = "idDep";
			this.idDep.IsEditable = true;
			this.idDep.WidthChars = 20;
			this.idDep.InvisibleChar = '•';
			this.hbox19.Add(this.idDep);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.hbox19[this.idDep]));
			w34.PackType = ((global::Gtk.PackType)(1));
			w34.Position = 0;
			w34.Expand = false;
			// Container child hbox19.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Departamento:");
			this.hbox19.Add(this.label11);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.hbox19[this.label11]));
			w35.PackType = ((global::Gtk.PackType)(1));
			w35.Position = 1;
			w35.Expand = false;
			w35.Fill = false;
			this.vbox2.Add(this.hbox19);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox19]));
			w36.Position = 3;
			w36.Expand = false;
			w36.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox20 = new global::Gtk.HBox();
			this.hbox20.Name = "hbox20";
			this.hbox20.Spacing = 6;
			// Container child hbox20.Gtk.Box+BoxChild
			this.idHor = new global::Gtk.Entry();
			this.idHor.CanFocus = true;
			this.idHor.Name = "idHor";
			this.idHor.IsEditable = true;
			this.idHor.WidthChars = 20;
			this.idHor.InvisibleChar = '•';
			this.hbox20.Add(this.idHor);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hbox20[this.idHor]));
			w37.PackType = ((global::Gtk.PackType)(1));
			w37.Position = 0;
			w37.Expand = false;
			// Container child hbox20.Gtk.Box+BoxChild
			this.label12 = new global::Gtk.Label();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Horario:");
			this.hbox20.Add(this.label12);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.hbox20[this.label12]));
			w38.PackType = ((global::Gtk.PackType)(1));
			w38.Position = 1;
			w38.Expand = false;
			w38.Fill = false;
			this.vbox2.Add(this.hbox20);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox20]));
			w39.Position = 4;
			w39.Expand = false;
			w39.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox21 = new global::Gtk.HBox();
			this.hbox21.Name = "hbox21";
			this.hbox21.Spacing = 6;
			// Container child hbox21.Gtk.Box+BoxChild
			this.idGroup = new global::Gtk.Entry();
			this.idGroup.CanFocus = true;
			this.idGroup.Name = "idGroup";
			this.idGroup.IsEditable = true;
			this.idGroup.WidthChars = 20;
			this.idGroup.InvisibleChar = '•';
			this.hbox21.Add(this.idGroup);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.hbox21[this.idGroup]));
			w40.PackType = ((global::Gtk.PackType)(1));
			w40.Position = 0;
			w40.Expand = false;
			// Container child hbox21.Gtk.Box+BoxChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Grupo:");
			this.hbox21.Add(this.label13);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox21[this.label13]));
			w41.PackType = ((global::Gtk.PackType)(1));
			w41.Position = 1;
			w41.Expand = false;
			w41.Fill = false;
			this.vbox2.Add(this.hbox21);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox21]));
			w42.Position = 5;
			w42.Expand = false;
			w42.Fill = false;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w43.Position = 1;
			this.vbox6.Add(this.hbox1);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox1]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment6.Name = "alignment6";
			this.alignment6.TopPadding = ((uint)(20));
			// Container child alignment6.Gtk.Container+ContainerChild
			this.hbox12 = new global::Gtk.HBox();
			this.hbox12.Name = "hbox12";
			this.hbox12.Spacing = 10;
			// Container child hbox12.Gtk.Box+BoxChild
			this.BtnAccept = new global::Gtk.Button();
			this.BtnAccept.CanFocus = true;
			this.BtnAccept.Name = "BtnAccept";
			this.BtnAccept.UseUnderline = true;
			this.BtnAccept.Label = global::Mono.Unix.Catalog.GetString("Aceptar");
			this.hbox12.Add(this.BtnAccept);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.BtnAccept]));
			w45.Position = 0;
			w45.Expand = false;
			w45.Fill = false;
			// Container child hbox12.Gtk.Box+BoxChild
			this.BtnCancel = new global::Gtk.Button();
			this.BtnCancel.CanFocus = true;
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.UseUnderline = true;
			this.BtnCancel.Label = global::Mono.Unix.Catalog.GetString("Cancelar");
			this.hbox12.Add(this.BtnCancel);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.hbox12[this.BtnCancel]));
			w46.Position = 1;
			w46.Expand = false;
			w46.Fill = false;
			this.alignment6.Add(this.hbox12);
			this.vbox6.Add(this.alignment6);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.alignment6]));
			w48.Position = 1;
			w48.Expand = false;
			w48.Fill = false;
			this.alignment5.Add(this.vbox6);
			this.Add(this.alignment5);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 591;
			this.DefaultHeight = 379;
			this.Show();
			this.CmbxEntry.Changed += new global::System.EventHandler(this.ComboBoxOnChanged);
			this.BtnNewIDUpdate.Clicked += new global::System.EventHandler(this.BtnNewIDUpdateOnClicked);
			this.BtnAccept.Clicked += new global::System.EventHandler(this.BtnAcceptOnClicked);
			this.BtnCancel.Clicked += new global::System.EventHandler(this.BtnCancelOnClicked);
		}
	}
}
