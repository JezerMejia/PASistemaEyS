
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms.Tables
{
	public partial class solicitudVacacionesPanel
	{
		private global::Gtk.VBox vbox1;

		private global::SistemaEyS.AdminForms.Tables.ViewTableTemplate viewTable;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button btnAdd;

		private global::Gtk.Button btnDelete;

		private global::Gtk.Button btnUpdate;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.Tables.solicitudVacacionesPanel
			global::Stetic.BinContainer.Attach(this);
			this.Name = "SistemaEyS.AdminForms.Tables.solicitudVacacionesPanel";
			// Container child SistemaEyS.AdminForms.Tables.solicitudVacacionesPanel.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.viewTable = new global::SistemaEyS.AdminForms.Tables.ViewTableTemplate();
			this.viewTable.Events = ((global::Gdk.EventMask)(256));
			this.viewTable.Name = "viewTable";
			this.vbox1.Add(this.viewTable);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.viewTable]));
			w1.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnAdd = new global::Gtk.Button();
			this.btnAdd.CanFocus = true;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.UseUnderline = true;
			this.btnAdd.Label = global::Mono.Unix.Catalog.GetString("Añadir");
			this.hbox1.Add(this.btnAdd);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnAdd]));
			w2.PackType = ((global::Gtk.PackType)(1));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnDelete = new global::Gtk.Button();
			this.btnDelete.CanFocus = true;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.UseUnderline = true;
			this.btnDelete.Label = global::Mono.Unix.Catalog.GetString("Eliminar");
			this.hbox1.Add(this.btnDelete);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnDelete]));
			w3.PackType = ((global::Gtk.PackType)(1));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.btnUpdate = new global::Gtk.Button();
			this.btnUpdate.CanFocus = true;
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.UseUnderline = true;
			this.btnUpdate.Label = global::Mono.Unix.Catalog.GetString("Actualizar");
			this.hbox1.Add(this.btnUpdate);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.btnUpdate]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
