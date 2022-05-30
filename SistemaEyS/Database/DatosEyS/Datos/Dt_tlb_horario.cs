using System;
using System.Data;
using Gtk;
using System.Text;
using SistemaEyS.Database.Connection;

namespace SistemaEyS.DatosEyS.Datos
{
    public class Dt_tlb_horario : DataTableTemplate
    {

        public Dt_tlb_horario()
        {
            this.conn = ConnectionEyS.OpenConnection();
            this.DBTable = "BDSistemaEyS.Horario";
            this.gTypes = new Type[17] {
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string), typeof(string),
                typeof(string), typeof(string)
            };
            this.Model = new ListStore(this.gTypes);
        }

        public void UpdateModelHor()
        {
            this.Model.Clear();
            IDataReader idr = null;
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("SELECT * FROM BDSistemaEyS.Horario WHERE estado <> 3;");
            try
            {
                idr = this.conn.Read(CommandType.Text, sb.ToString());

                while (idr.Read())
                {
                    this.Model.AppendValues(
                        idr[0].ToString(), // ID
                        idr[1].ToString(), // Nombre
                        idr[2].ToString(), idr[3].ToString(), // Lunes
                        idr[4].ToString(), idr[5].ToString(), // Martes
                        idr[6].ToString(), idr[7].ToString(), // Miércoles
                        idr[8].ToString(), idr[9].ToString(), // Jueves
                        idr[10].ToString(), idr[11].ToString(), // Viernes
                        idr[12].ToString(), idr[13].ToString(), // Sábado
                        idr[14].ToString(), idr[15].ToString(), // Domingo
                        idr[16].ToString() // Estado
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

        public ListStore GetDataCmbx()
        {
            this.UpdateModel();
            TreeIter iter;

            ListStore model = new ListStore(
                typeof(string),
                typeof(string)
                );

            if (this.Model.GetIterFirst(out iter))
            {
                do
                {
                    model.AppendValues(
                        this.Model.GetValue(iter, 1),
                        this.Model.GetValue(iter, 0)
                    );
                }
                while (this.Model.IterNext(ref iter));
            }
            return model;
        }


        public override void UpdateModel()
        {
            this.UpdateModelHor();
        }

        public void InsertInto(
            string nombreHorario,
            string lunesInicio, string lunesSalida,
            string martesInicio, string martesSalida,
            string miercolesInicio, string miercolesSalida,
            string juevesInicio, string juevesSalida,
            string viernesInicio, string viernesSalida,
            string sabadoInicio, string sabadoSalida,
            string domingoInicio, string domingoSalida,
            string estado
            )
        {
            this.InsertInto(
                new DataTableParameter(
                    "nombreHorario", $"'{nombreHorario}'"
                    ),
                new DataTableParameter(
                    "lunesInicio",
                    string.IsNullOrWhiteSpace(lunesInicio) ? "NULL" : $"'{lunesInicio}'"
                    ),
                new DataTableParameter(
                    "lunesSalida",
                    string.IsNullOrWhiteSpace(lunesSalida) ? "NULL" : $"'{lunesSalida}'"
                    ),
                new DataTableParameter(
                    "martesInicio",
                    string.IsNullOrWhiteSpace(martesInicio) ? "NULL" : $"'{martesInicio}'"
                    ),
                new DataTableParameter(
                    "martesSalida",
                    string.IsNullOrWhiteSpace(martesSalida) ? "NULL" : $"'{martesSalida}'"
                    ),
                new DataTableParameter(
                    "miercolesInicio",
                    string.IsNullOrWhiteSpace(miercolesInicio) ? "NULL" : $"'{miercolesInicio}'"
                    ),
                new DataTableParameter(
                    "miercolesSalida",
                    string.IsNullOrWhiteSpace(miercolesSalida) ? "NULL" : $"'{miercolesSalida}'"
                    ),
                new DataTableParameter(
                    "juevesInicio",
                    string.IsNullOrWhiteSpace(juevesInicio) ? "NULL" : $"'{juevesInicio}'"
                    ),
                new DataTableParameter(
                    "juevesSalida",
                    string.IsNullOrWhiteSpace(juevesSalida) ? "NULL" : $"'{juevesSalida}'"
                    ),
                new DataTableParameter(
                    "viernesInicio",
                    string.IsNullOrWhiteSpace(viernesInicio) ? "NULL" : $"'{viernesInicio}'"
                    ),
                new DataTableParameter(
                    "viernesSalida",
                    string.IsNullOrWhiteSpace(viernesSalida) ? "NULL" : $"'{viernesSalida}'"
                    ),
                new DataTableParameter(
                    "sabadoInicio",
                    string.IsNullOrWhiteSpace(sabadoInicio) ? "NULL" : $"'{sabadoInicio}'"
                    ),
                new DataTableParameter(
                    "sabadoSalida",
                    string.IsNullOrWhiteSpace(sabadoSalida) ? "NULL" : $"'{sabadoSalida}'"
                    ),
                new DataTableParameter(
                    "domingoInicio",
                    string.IsNullOrWhiteSpace(domingoInicio) ? "NULL" : $"'{domingoInicio}'"
                    ),
                new DataTableParameter(
                    "domingoSalida",
                    string.IsNullOrWhiteSpace(domingoSalida) ? "NULL" : $"'{domingoSalida}'"
                    ),
                new DataTableParameter("estado", $"'{estado}'")
                );
        }


        public void UpdateSet(
            string idHorario, string nombreHorario,
            string lunesInicio, string lunesSalida,
            string martesInicio, string martesSalida,
            string miercolesInicio, string miercolesSalida,
            string juevesInicio, string juevesSalida,
            string viernesInicio, string viernesSalida,
            string sabadoInicio, string sabadoSalida,
            string domingoInicio, string domingoSalida,
            string estado
            )
        {
            this.UpdateSet(
                new DataTableParameter("idHorario", $"'{idHorario}'"),
                new DataTableParameter("nombreHorario", $"'{nombreHorario}'"),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(lunesInicio) ? "lunesInicio" : "",
                    $"'{lunesInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(lunesSalida) ? "lunesSalida" : "",
                    $"'{lunesSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(martesInicio) ? "martesInicio" : "",
                    $"'{martesInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(martesSalida) ? "martesSalida" : "",
                    $"'{martesSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(miercolesInicio) ? "miercolesInicio" : "",
                    $"'{miercolesInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(miercolesSalida) ? "miercolesSalida" : "",
                    $"'{miercolesSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(juevesInicio) ? "juevesInicio" : "",
                    $"'{juevesInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(juevesSalida) ? "juevesSalida" : "",
                    $"'{juevesSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(viernesInicio) ? "viernesInicio" : "",
                    $"'{viernesInicio}'"
                    ),
               new DataTableParameter(
                    !string.IsNullOrWhiteSpace(viernesSalida) ? "viernesSalida" : "",
                    $"'{viernesSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(sabadoInicio) ? "sabadoInicio" : "",
                    $"'{sabadoInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(sabadoSalida) ? "sabadoSalida" : "",
                    $"'{sabadoSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(domingoInicio) ? "domingoInicio" : "",
                    $"'{domingoInicio}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(domingoSalida) ? "domingoSalida" : "",
                    $"'{domingoSalida}'"
                    ),
                new DataTableParameter(
                    !string.IsNullOrWhiteSpace(estado) ? "estado" : "",
                    $"'{estado}'"
                    )
                );
        }

        public void DeleteFrom(string idHorario)
        {
            this.UpdateSet(
                new DataTableParameter("idHorario", idHorario),
                new DataTableParameter("estado", "3")
                );
        }
    }
}
