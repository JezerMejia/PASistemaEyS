using System;
using Gtk;
using SistemaEyS.DatosEyS;
using SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn.Calendar;

namespace SistemaEyS.AdminForms.Tables.SolVacacionesPanelBtn
{
    public partial class AddDialogSolVac : Gtk.Window
    {
        Dt_tlb_empleado dtEmp = new Dt_tlb_empleado();
        protected ListStore DataUser;
        protected TreeModelFilter TreeData;
        protected TreeModelFilterVisibleFunc ModelFilterFunc;
        calendar ca = new calendar();
        public int SelectedID = -1;
        public int SelectedUser = -1;
        DateTime dt;
        DateTime dtIni;
        DateTime dtSal;


        public AddDialogSolVac() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Hide();
            this.DeleteEvent += delegate (object obj, DeleteEventArgs args)
            {
                args.RetVal = this.HideOnDelete();
            };
            //this.ModelFilterFunc = new TreeModelFilterVisibleFunc(this.TreeModelFilterVisible);
            UpdateData();
        }

        public void UpdateData()
        {
            //this.TreeData = new TreeModelFilter(DtUserRol.GetData(), null);
            //this.TreeData.VisibleFunc = this.ModelFilterFunc;
            //this.viewTable.Model = this.TreeData;

            this.DataUser = dtEmp.GetDataView();
            //this.DataRol = DtRol.GetDataCmbx();
            //this.CmbxRol.Model = this.DataRol;
            this.idEmp.Model = this.DataUser;
            this.FillCmbxUsuarioModel();
            //this.FillCmbxRolModel();
        }
        protected void FillCmbxUsuarioModel()
        {
            this.idEmp.Model = this.DataUser;
            this.idEmp.Active = -1;

            this.idEmp.Entry.Completion = new EntryCompletion();
            this.idEmp.Entry.Completion.Model = this.DataUser;
            this.idEmp.Entry.Completion.TextColumn = 0;
        }

        public void setFecha(DateTime fechaEntrada)
        {
            try
            {
                dt = fechaEntrada;
                this.fechaTxt.Text = fechaEntrada.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                Console.WriteLine("Error" + ex.StackTrace);
                throw;
            }
        }

        public void setFechaIni(DateTime fechaEntrada)
        {
            try
            {
                dtIni = fechaEntrada;
                this.fecIni.Text = fechaEntrada.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                Console.WriteLine("Error" + ex.StackTrace);
                throw;
            }
        }

        public void setFechaSal(DateTime fechaEntrada)
        {
            try
            {
                dtSal = fechaEntrada;
                this.fecSal.Text = fechaEntrada.ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
                Console.WriteLine("Error" + ex.StackTrace);
                throw;
            }
        }

        protected void OnButton8Clicked(object sender, EventArgs e)
        {
            ca.fecha = new calendar.selectFecha(this.setFecha);
            ca.Show();
        }

        protected void OnButton9Clicked(object sender, EventArgs e)
        {
            ca.fecha = new calendar.selectFecha(this.setFechaIni);
            ca.Show();
        }

        protected void OnButton10Clicked(object sender, EventArgs e)
        {
            ca.fecha = new calendar.selectFecha(this.setFechaSal);
            ca.Show();
        }
    }
}
