
// This file has been generated by the GUI designer. Do not modify.
namespace SistemaEyS.AdminForms
{
	public partial class AdminPanel
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action ArchivoAction;

		private global::Gtk.Action TablasAction;

		private global::Gtk.Action ReportesAction;

		private global::Gtk.Action AyudaAction;

		private global::Gtk.Action PerfilAction;

		private global::Gtk.Action closeAction;

		private global::Gtk.Action EmpleadosAction;

		private global::Gtk.Action HorariosAction;

		private global::Gtk.Action EntradasSalidasAction;

		private global::Gtk.Action EntradasSalidasAction1;

		private global::Gtk.Action AtrasosAction;

		private global::Gtk.Action HorasTrabajadasAction;

		private global::Gtk.Action HorasExtrasAction;

		private global::Gtk.Action HorasSuplementariasAction;

		private global::Gtk.Action AusenciasAction;

		private global::Gtk.Action NovedadesAsistenciaAction;

		private global::Gtk.Action PermisosAction;

		private global::Gtk.Action dialogInfoAction;

		private global::Gtk.Action dialogQuestionAction;

		private global::Gtk.Action AjustesAction;

		private global::Gtk.Action RolesAction;

		private global::Gtk.Action CargosAction;

		private global::Gtk.Action HorariosAction1;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox4;

		private global::Gtk.MenuBar menuBar;

		private global::Gtk.Notebook ntTabview;

		private global::Gtk.Alignment alignment4;

		private global::Gtk.VBox vbox5;

		private global::SistemaEySLibrary.ClockWidget clockwidget1;

		private global::Gtk.Label lbDateTime;

		private global::Gtk.Label lbHome;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget SistemaEyS.AdminForms.AdminPanel
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
			this.ArchivoAction = new global::Gtk.Action("ArchivoAction", global::Mono.Unix.Catalog.GetString("Archivo"), null, null);
			this.ArchivoAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Archivo");
			w1.Add(this.ArchivoAction, null);
			this.TablasAction = new global::Gtk.Action("TablasAction", global::Mono.Unix.Catalog.GetString("Tablas"), null, null);
			this.TablasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Tablas");
			w1.Add(this.TablasAction, null);
			this.ReportesAction = new global::Gtk.Action("ReportesAction", global::Mono.Unix.Catalog.GetString("Reportes"), null, null);
			this.ReportesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Reportes");
			w1.Add(this.ReportesAction, null);
			this.AyudaAction = new global::Gtk.Action("AyudaAction", global::Mono.Unix.Catalog.GetString("Ayuda"), null, null);
			this.AyudaAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Ayuda");
			w1.Add(this.AyudaAction, null);
			this.PerfilAction = new global::Gtk.Action("PerfilAction", global::Mono.Unix.Catalog.GetString("Perfil"), null, null);
			this.PerfilAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Perfil");
			w1.Add(this.PerfilAction, null);
			this.closeAction = new global::Gtk.Action("closeAction", global::Mono.Unix.Catalog.GetString("Cerrar sesión"), null, "gtk-close");
			this.closeAction.ShortLabel = global::Mono.Unix.Catalog.GetString("_Close");
			w1.Add(this.closeAction, null);
			this.EmpleadosAction = new global::Gtk.Action("EmpleadosAction", global::Mono.Unix.Catalog.GetString("Empleados"), null, null);
			this.EmpleadosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Empleados");
			w1.Add(this.EmpleadosAction, null);
			this.HorariosAction = new global::Gtk.Action("HorariosAction", global::Mono.Unix.Catalog.GetString("Horarios"), null, null);
			this.HorariosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Horarios");
			w1.Add(this.HorariosAction, null);
			this.EntradasSalidasAction = new global::Gtk.Action("EntradasSalidasAction", global::Mono.Unix.Catalog.GetString("Entradas/Salidas"), null, null);
			this.EntradasSalidasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Entradas/Salidas");
			w1.Add(this.EntradasSalidasAction, null);
			this.EntradasSalidasAction1 = new global::Gtk.Action("EntradasSalidasAction1", global::Mono.Unix.Catalog.GetString("Entradas/Salidas"), null, null);
			this.EntradasSalidasAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Entradas/Salidas");
			w1.Add(this.EntradasSalidasAction1, null);
			this.AtrasosAction = new global::Gtk.Action("AtrasosAction", global::Mono.Unix.Catalog.GetString("Atrasos"), null, null);
			this.AtrasosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Atrasos");
			w1.Add(this.AtrasosAction, null);
			this.HorasTrabajadasAction = new global::Gtk.Action("HorasTrabajadasAction", global::Mono.Unix.Catalog.GetString("Horas Trabajadas"), null, null);
			this.HorasTrabajadasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Horas Trabajadas");
			w1.Add(this.HorasTrabajadasAction, null);
			this.HorasExtrasAction = new global::Gtk.Action("HorasExtrasAction", global::Mono.Unix.Catalog.GetString("Horas Extras"), null, null);
			this.HorasExtrasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Horas Extras");
			w1.Add(this.HorasExtrasAction, null);
			this.HorasSuplementariasAction = new global::Gtk.Action("HorasSuplementariasAction", global::Mono.Unix.Catalog.GetString("Horas Suplementarias"), null, null);
			this.HorasSuplementariasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Horas Suplementarias");
			w1.Add(this.HorasSuplementariasAction, null);
			this.AusenciasAction = new global::Gtk.Action("AusenciasAction", global::Mono.Unix.Catalog.GetString("Ausencias"), null, null);
			this.AusenciasAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Ausencias");
			w1.Add(this.AusenciasAction, null);
			this.NovedadesAsistenciaAction = new global::Gtk.Action("NovedadesAsistenciaAction", global::Mono.Unix.Catalog.GetString("Novedades Asistencia"), null, null);
			this.NovedadesAsistenciaAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Novedades Asistencia");
			w1.Add(this.NovedadesAsistenciaAction, null);
			this.PermisosAction = new global::Gtk.Action("PermisosAction", global::Mono.Unix.Catalog.GetString("Permisos"), null, null);
			this.PermisosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Permisos");
			w1.Add(this.PermisosAction, null);
			this.dialogInfoAction = new global::Gtk.Action("dialogInfoAction", global::Mono.Unix.Catalog.GetString("Manual"), null, "gtk-dialog-info");
			this.dialogInfoAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Manual");
			w1.Add(this.dialogInfoAction, null);
			this.dialogQuestionAction = new global::Gtk.Action("dialogQuestionAction", global::Mono.Unix.Catalog.GetString("SistemaEyS"), null, "gtk-dialog-question");
			this.dialogQuestionAction.ShortLabel = global::Mono.Unix.Catalog.GetString("SistemaEyS");
			w1.Add(this.dialogQuestionAction, null);
			this.AjustesAction = new global::Gtk.Action("AjustesAction", global::Mono.Unix.Catalog.GetString("Ajustes"), null, null);
			this.AjustesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Ajustes");
			w1.Add(this.AjustesAction, null);
			this.RolesAction = new global::Gtk.Action("RolesAction", global::Mono.Unix.Catalog.GetString("Roles"), null, null);
			this.RolesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Roles");
			w1.Add(this.RolesAction, null);
			this.CargosAction = new global::Gtk.Action("CargosAction", global::Mono.Unix.Catalog.GetString("Cargos"), null, null);
			this.CargosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Cargos");
			w1.Add(this.CargosAction, null);
			this.HorariosAction1 = new global::Gtk.Action("HorariosAction1", global::Mono.Unix.Catalog.GetString("Horarios"), null, null);
			this.HorariosAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Horarios");
			w1.Add(this.HorariosAction1, null);
			this.UIManager.InsertActionGroup(w1, 0);
			this.AddAccelGroup(this.UIManager.AccelGroup);
			this.Name = "SistemaEyS.AdminForms.AdminPanel";
			this.Title = global::Mono.Unix.Catalog.GetString("AdminPanel");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SistemaEyS.AdminForms.AdminPanel.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString(@"<ui><menubar name='menuBar'><menu name='ArchivoAction' action='ArchivoAction'><menuitem name='PerfilAction' action='PerfilAction'/><menuitem name='closeAction' action='closeAction'/></menu><menu name='TablasAction' action='TablasAction'><menuitem name='EmpleadosAction' action='EmpleadosAction'/><menuitem name='HorariosAction' action='HorariosAction'/><menuitem name='EntradasSalidasAction' action='EntradasSalidasAction'/></menu><menu name='ReportesAction' action='ReportesAction'><menuitem name='EntradasSalidasAction1' action='EntradasSalidasAction1'/><menuitem name='AtrasosAction' action='AtrasosAction'/><menuitem name='HorasTrabajadasAction' action='HorasTrabajadasAction'/><menuitem name='HorasExtrasAction' action='HorasExtrasAction'/><menuitem name='HorasSuplementariasAction' action='HorasSuplementariasAction'/><menuitem name='AusenciasAction' action='AusenciasAction'/><menuitem name='NovedadesAsistenciaAction' action='NovedadesAsistenciaAction'/><menuitem name='PermisosAction' action='PermisosAction'/></menu><menu name='AjustesAction' action='AjustesAction'><menuitem name='RolesAction' action='RolesAction'/><menuitem name='CargosAction' action='CargosAction'/><menuitem name='HorariosAction1' action='HorariosAction1'/></menu><menu name='AyudaAction' action='AyudaAction'><menuitem name='dialogInfoAction' action='dialogInfoAction'/><menuitem name='dialogQuestionAction' action='dialogQuestionAction'/></menu></menubar></ui>");
			this.menuBar = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menuBar")));
			this.menuBar.Name = "menuBar";
			this.vbox4.Add(this.menuBar);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.menuBar]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.ntTabview = new global::Gtk.Notebook();
			this.ntTabview.CanFocus = true;
			this.ntTabview.Name = "ntTabview";
			this.ntTabview.CurrentPage = 0;
			this.ntTabview.EnablePopup = true;
			this.ntTabview.Scrollable = true;
			// Container child ntTabview.Gtk.Notebook+NotebookChild
			this.alignment4 = new global::Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.clockwidget1 = new global::SistemaEySLibrary.ClockWidget();
			this.clockwidget1.Name = "clockwidget1";
			this.vbox5.Add(this.clockwidget1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.clockwidget1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.lbDateTime = new global::Gtk.Label();
			this.lbDateTime.Name = "lbDateTime";
			this.lbDateTime.LabelProp = global::Mono.Unix.Catalog.GetString("<span size=\"200%\" weight=\"bold\">DATETIME</span>");
			this.lbDateTime.UseMarkup = true;
			this.vbox5.Add(this.lbDateTime);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.lbDateTime]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.alignment4.Add(this.vbox5);
			this.ntTabview.Add(this.alignment4);
			// Notebook tab
			this.lbHome = new global::Gtk.Label();
			this.lbHome.Name = "lbHome";
			this.lbHome.LabelProp = global::Mono.Unix.Catalog.GetString("Inicio");
			this.ntTabview.SetTabLabel(this.alignment4, this.lbHome);
			this.lbHome.ShowAll();
			this.vbox4.Add(this.ntTabview);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.ntTabview]));
			w7.Position = 1;
			this.alignment1.Add(this.vbox4);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 650;
			this.DefaultHeight = 335;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.closeAction.Activated += new global::System.EventHandler(this.actCloseOnActivated);
			this.EmpleadosAction.Activated += new global::System.EventHandler(this.TablasEmpleadosActionOnActivated);
			this.HorariosAction.Activated += new global::System.EventHandler(this.TablasHorariosActionOnActivated);
			this.EntradasSalidasAction.Activated += new global::System.EventHandler(this.TablasEntradasSalidasActionOnActivated);
			this.RolesAction.Activated += new global::System.EventHandler(this.RolesOnActivated);
			this.CargosAction.Activated += new global::System.EventHandler(this.AjustesCargosOnActivated);
		}
	}
}
