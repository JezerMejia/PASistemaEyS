
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

		private global::Gtk.Action HelpSistemaEySAction;

		private global::Gtk.Action AjustesAction;

		private global::Gtk.Action RolesAction;

		private global::Gtk.Action CargosAction;

		private global::Gtk.Action HorariosAction1;

		private global::Gtk.Action SolicitudesDeVacacionesAction;

		private global::Gtk.Action SolicitudDeVacacionesAction;

		private global::Gtk.Action SeguridadAction;

		private global::Gtk.Action UsuariosAction;

		private global::Gtk.Action OpcionesDeRolAction;

		private global::Gtk.Action DepartamentosAction;

		private global::Gtk.Action ConfiguracinAction;

		private global::Gtk.Action RolesAction1;

		private global::Gtk.Action OpcionesAction;

		private global::Gtk.Alignment alignment1;

		private global::Gtk.VBox vbox4;

		private global::Gtk.MenuBar menuBar;

		private global::Gtk.Notebook ntTabview;

		private global::Gtk.Alignment alignment4;

		private global::Gtk.VBox vbox5;

		private global::Gtk.Alignment alignment14;

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
			this.closeAction = new global::Gtk.Action("closeAction", global::Mono.Unix.Catalog.GetString("Cerrar sesi??n"), null, "gtk-close");
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
			this.HelpSistemaEySAction = new global::Gtk.Action("HelpSistemaEySAction", global::Mono.Unix.Catalog.GetString("SistemaEyS"), null, "gtk-dialog-question");
			this.HelpSistemaEySAction.ShortLabel = global::Mono.Unix.Catalog.GetString("SistemaEyS");
			w1.Add(this.HelpSistemaEySAction, null);
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
			this.SolicitudesDeVacacionesAction = new global::Gtk.Action("SolicitudesDeVacacionesAction", global::Mono.Unix.Catalog.GetString("Solicitudes de vacaciones"), null, null);
			this.SolicitudesDeVacacionesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Solicitudes de vacaciones");
			w1.Add(this.SolicitudesDeVacacionesAction, null);
			this.SolicitudDeVacacionesAction = new global::Gtk.Action("SolicitudDeVacacionesAction", global::Mono.Unix.Catalog.GetString("Solicitud de vacaciones"), null, null);
			this.SolicitudDeVacacionesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Solicitud de vacaciones");
			w1.Add(this.SolicitudDeVacacionesAction, null);
			this.SeguridadAction = new global::Gtk.Action("SeguridadAction", global::Mono.Unix.Catalog.GetString("Seguridad"), null, null);
			this.SeguridadAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Seguridad");
			w1.Add(this.SeguridadAction, null);
			this.UsuariosAction = new global::Gtk.Action("UsuariosAction", global::Mono.Unix.Catalog.GetString("Usuarios"), null, null);
			this.UsuariosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Usuarios");
			w1.Add(this.UsuariosAction, null);
			this.OpcionesDeRolAction = new global::Gtk.Action("OpcionesDeRolAction", global::Mono.Unix.Catalog.GetString("Opciones de rol"), null, null);
			this.OpcionesDeRolAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Opciones de rol");
			w1.Add(this.OpcionesDeRolAction, null);
			this.DepartamentosAction = new global::Gtk.Action("DepartamentosAction", global::Mono.Unix.Catalog.GetString("Departamentos"), null, null);
			this.DepartamentosAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Departamentos");
			w1.Add(this.DepartamentosAction, null);
			this.ConfiguracinAction = new global::Gtk.Action("ConfiguracinAction", global::Mono.Unix.Catalog.GetString("Configuraci??n"), null, null);
			this.ConfiguracinAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Configuraci??n");
			w1.Add(this.ConfiguracinAction, null);
			this.RolesAction1 = new global::Gtk.Action("RolesAction1", global::Mono.Unix.Catalog.GetString("Roles"), null, null);
			this.RolesAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Roles");
			w1.Add(this.RolesAction1, null);
			this.OpcionesAction = new global::Gtk.Action("OpcionesAction", global::Mono.Unix.Catalog.GetString("Opciones"), null, null);
			this.OpcionesAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Opciones");
			w1.Add(this.OpcionesAction, null);
			this.UIManager.InsertActionGroup(w1, 0);
			this.AddAccelGroup(this.UIManager.AccelGroup);
			this.Name = "SistemaEyS.AdminForms.AdminPanel";
			this.Title = global::Mono.Unix.Catalog.GetString("Administrador | Panel");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child SistemaEyS.AdminForms.AdminPanel.Gtk.Container+ContainerChild
			this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString("<ui><menubar name=\'menuBar\'><menu name=\'ArchivoAction\' action=\'ArchivoAction\'><me" +
					"nuitem name=\'PerfilAction\' action=\'PerfilAction\'/><menuitem name=\'closeAction\' a" +
					"ction=\'closeAction\'/></menu><menu name=\'TablasAction\' action=\'TablasAction\'><men" +
					"uitem name=\'EmpleadosAction\' action=\'EmpleadosAction\'/><menuitem name=\'HorariosA" +
					"ction\' action=\'HorariosAction\'/><menuitem name=\'EntradasSalidasAction\' action=\'E" +
					"ntradasSalidasAction\'/><menuitem name=\'SolicitudDeVacacionesAction\' action=\'Soli" +
					"citudDeVacacionesAction\'/></menu><menu name=\'" +
					"AjustesAction\' action=\'AjustesAction\'><menuitem name=\'CargosAction\' action=\'Carg" +
					"osAction\'/><menuitem name=\'DepartamentosAction\' action=\'DepartamentosAction\'/></" +
					"menu><menu name=\'SeguridadAction\' action=\'SeguridadAction\'><menu name=\'UsuariosA" +
					"ction\' action=\'UsuariosAction\'><menuitem name=\'ConfiguracinAction\' action=\'Confi" +
					"guracinAction\'/><menuitem name=\'RolesAction1\' action=\'RolesAction1\'/></menu><men" +
					"uitem name=\'RolesAction\' action=\'RolesAction\'/><menuitem name=\'OpcionesDeRolActi" +
					"on\' action=\'OpcionesDeRolAction\'/><menuitem name=\'OpcionesAction\' action=\'Opcion" +
					"esAction\'/></menu><menu name=\'AyudaAction\' action=\'AyudaAction\'><menuitem name=\'" +
					"HelpSistemaEySAction\' action=\'HelpSistemaEySAction\'/></menu></menubar></ui>");
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
			this.alignment14 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignment14.Name = "alignment14";
			// Container child alignment14.Gtk.Container+ContainerChild
			this.clockwidget1 = new global::SistemaEySLibrary.ClockWidget();
			this.clockwidget1.Name = "clockwidget1";
			this.alignment14.Add(this.clockwidget1);
			this.vbox5.Add(this.alignment14);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.alignment14]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.lbDateTime = new global::Gtk.Label();
			this.lbDateTime.Name = "lbDateTime";
			this.lbDateTime.LabelProp = global::Mono.Unix.Catalog.GetString("<span size=\"200%\" weight=\"bold\">DATETIME</span>");
			this.lbDateTime.UseMarkup = true;
			this.vbox5.Add(this.lbDateTime);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.lbDateTime]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.alignment4.Add(this.vbox5);
			this.ntTabview.Add(this.alignment4);
			// Notebook tab
			this.lbHome = new global::Gtk.Label();
			this.lbHome.Name = "lbHome";
			this.lbHome.LabelProp = global::Mono.Unix.Catalog.GetString("Inicio");
			this.ntTabview.SetTabLabel(this.alignment4, this.lbHome);
			this.lbHome.ShowAll();
			this.vbox4.Add(this.ntTabview);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.ntTabview]));
			w8.Position = 1;
			this.alignment1.Add(this.vbox4);
			this.Add(this.alignment1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 679;
			this.DefaultHeight = 430;
			this.Show();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
			this.PerfilAction.Activated += new global::System.EventHandler(this.PerfilActionOnActivated);
			this.closeAction.Activated += new global::System.EventHandler(this.actCloseOnActivated);
			this.EmpleadosAction.Activated += new global::System.EventHandler(this.TablasEmpleadosActionOnActivated);
			this.HorariosAction.Activated += new global::System.EventHandler(this.TablasHorariosActionOnActivated);
			this.EntradasSalidasAction.Activated += new global::System.EventHandler(this.TablasEntradasSalidasActionOnActivated);
			this.HelpSistemaEySAction.Activated += new global::System.EventHandler(this.HelpSistemaEySActionOnActivated);
			this.RolesAction.Activated += new global::System.EventHandler(this.SeguridadRolesOnActivated);
			this.CargosAction.Activated += new global::System.EventHandler(this.AjustesCargosOnActivated);
			this.SolicitudesDeVacacionesAction.Activated += new global::System.EventHandler(this.TablasSolicitudVacacionesActionOnActivated);
			this.SolicitudDeVacacionesAction.Activated += new global::System.EventHandler(this.TablasSolicitudVacacionesActionOnActivated);
			this.OpcionesDeRolAction.Activated += new global::System.EventHandler(this.OnOpcionesDeRolActionActivated);
			this.DepartamentosAction.Activated += new global::System.EventHandler(this.AjustesDepartamentosOnActivated);
			this.ConfiguracinAction.Activated += new global::System.EventHandler(this.SeguridadUsuariosConfOnActivated);
			this.RolesAction1.Activated += new global::System.EventHandler(this.SeguridadUsuariosRolesOnActivated);
			this.OpcionesAction.Activated += new global::System.EventHandler(this.OnOpcionesActionActivated);
		}
	}
}
