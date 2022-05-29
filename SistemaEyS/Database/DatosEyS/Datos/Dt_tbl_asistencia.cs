using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS.Datos
{
    public class Dt_tlb_asistencia : DataTableTemplate
    {
        public Dt_tlb_asistencia()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.Asistencia";
            this.gTypes = new Type[5] {
                typeof(string), typeof(string),
                typeof(string), typeof(string),
                typeof(string)
            };
            this.Model = new ListStore(this.gTypes);
        }
        public override void UpdateModel()
        {
            this.Model.Clear();
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Asistencia;");
            try
            {
                idr = conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID
                        idr[4].ToString(), // ID Empleado
                        idr.GetDateTime(1).ToString("yyyy-MM-dd"), // Fecha
                        idr[2].ToString(), // Entrada
                        idr[3].ToString() // Salida
                    );
                }
            }
            catch (Exception e)
            {
                MessageDialog ms = new MessageDialog(null, DialogFlags.Modal, MessageType.Error,
                    ButtonsType.Ok, e.Message);
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

        public void InsertInto(
            string idEmpleado, string fechaAsistencia,
            string horaEntrada, string horaSalida
        )
        {
            this.InsertInto(
                new DataTableParameter("idEmpleado", $"'{idEmpleado}'"),
                new DataTableParameter("fechaAsistencia", $"'{fechaAsistencia}'"),
                new DataTableParameter(
                    "horaEntrada",
                    string.IsNullOrWhiteSpace(horaEntrada) ? "NULL" : $"'{horaEntrada}'"
                    ),
                new DataTableParameter(
                    "horaSalida",
                    string.IsNullOrWhiteSpace(horaSalida) ? "NULL" : $"'{horaSalida}'"
                    )
                );
        }
        public void UpdateSet(
            string idEmpleado, string fechaAsistencia,
            string horaEntrada, string horaSalida
        )
        {
            horaEntrada = string.IsNullOrWhiteSpace(horaEntrada) ? "NULL" : $"'{horaEntrada}'";
            horaSalida = string.IsNullOrWhiteSpace(horaSalida) ? "NULL" : $"'{horaSalida}'";

            string Query = $"UPDATE {this.DBTable} SET " +
                $"`horaEntrada` = {horaEntrada}, " +
                $"`horaSalida` = {horaSalida} " +
                $"WHERE `idEmpleado` = '{idEmpleado}' AND `fechaAsistencia` = '{fechaAsistencia}'";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                Console.WriteLine(Query);
                Console.WriteLine(e);
                throw e;
            }
        }

        public void InsertEnterAssistance(string idEmpleado, string fechaAsistencia, string horaEntrada)
        {
            string QueryParameters = "idEmpleado,fechaAsistencia,horaEntrada";
            string QueryValues = $"'{idEmpleado}','{fechaAsistencia}','{horaEntrada}'";

            string Query = $"INSERT INTO {this.DBTable} ({QueryParameters}) " +
                $"VALUES ({QueryValues}) " +
                $"ON DUPLICATE KEY UPDATE horaEntrada='{horaEntrada}';";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                Console.WriteLine(Query);
                Console.WriteLine(e);
                throw e;
            }
        }
        public void InsertExitAssistance(string idEmpleado, string fechaAsistencia, string horaSalida)
        {
            string QueryParameters = "idEmpleado,fechaAsistencia,horaSalida";
            string QueryValues = $"'{idEmpleado}','{fechaAsistencia}','{horaSalida}'";

            string Query = $"INSERT INTO {this.DBTable} ({QueryParameters}) " +
                $"VALUES ({QueryValues}) " +
                $"ON DUPLICATE KEY UPDATE horaSalida='{horaSalida}';";

            try
            {
                this.conn.Execute(CommandType.Text, Query);
            }
            catch (Exception e)
            {
                Console.WriteLine(Query);
                Console.WriteLine(e);
                throw e;
            }
        }
    }
}
