using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;
using SistemaEyS.DatosEyS;

namespace SistemaEyS.DatosEyS.Datos
{
    public class Dt_tlb_SolVacaciones : DataTableTemplate
    {

        public ListStore ModelView;

        public Dt_tlb_SolVacaciones()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.SolVacaciones";
            this.ModelView = new ListStore(
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string)
            );
            this.Model = new ListStore(
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string)
            );
        }

        public void UpdateModelEmp()
        {
            this.Model.Clear();
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.SolVacaciones;");
            try
            {
                idr = this.conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID
                        idr[5].ToString(), // ID Empleado
                        idr[1].ToString(), // Fecha de Solicitud
                        idr[2].ToString(), // Descripción
                        idr[3].ToString(), // Inicio
                        idr[4].ToString() // Fin
                    );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
                Console.WriteLine(e);
                ms.Run();
                ms.Destroy();
            }
            finally
            {
                if (idr != null && !idr.IsClosed)
                {
                    idr.Close();
                }
            }
        }


        public override void UpdateModel()
        {
            this.UpdateModelEmp();
            //this.UpdateModelView();
        }

        public ListStore GetDataView()
        {
            this.UpdateModel();
            return this.ModelView;
        }

        public void InsertInto(string fechaSol, string descripcionSol, string idEmpleado, string FechaHoraInicio,
            string FechaHoraFin 
            )
        {
            this.InsertInto(
                new DataTableParameter("fechaSol", $"'{fechaSol}'"),
                new DataTableParameter("descripcionSol", $"'{descripcionSol}'"),
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'"),
                new DataTableParameter("FechaHoraInicio", $"'{FechaHoraInicio}'"),
                new DataTableParameter("FechaHoraFin", $"'{FechaHoraFin}'")
                );
        }


        public void UpdateSet( string fechaSol, string descripcionSol, string idEmpleado, string FechaHoraInicio,
                                string FechaHoraFin)

        {
            this.UpdateSet(
                //new DataTableParameter("idSolVacaciones", $"'{idSolVacaciones}'"),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(fechaSol) ? "fechaSol" : "",
                    $"'{fechaSol}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(descripcionSol) ? "descripcionSol" : "",
                    $"'{descripcionSol}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(idEmpleado) ? "idEmpleado" : "",
                    $"'{idEmpleado}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(FechaHoraInicio) ? "FechaHoraInicio" : "",
                    $"'{FechaHoraInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(FechaHoraFin) ? "FechaHoraFin" : "",
                    $"'{FechaHoraFin}'"
                    )

                );
        }

        public void DeleteFrom(string idSolVacaciones)
        {
            this.DeleteFrom(this.conn,
                new DataTableParameter("idSolVacaciones", $"'{idSolVacaciones}'")
                );
        }

    }
}
