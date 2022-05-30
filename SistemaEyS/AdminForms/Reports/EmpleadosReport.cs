using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Gtk;
using SistemaEyS.DatosEyS.Datos;
using OfficeOpenXml;

namespace SistemaEyS.AdminForms.Reports
{
    public partial class EmpleadosReport : Gtk.Window
    {
        protected string TempFileName = "/tmp/SistemaEyS-Repore-Empleado.xlsx";

        protected Dt_tlb_empleado DtEmp = new Dt_tlb_empleado();

        protected ListStore Model;
        protected StoreObject[] StoreObjects;

        public EmpleadosReport() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            this.StoreObjects = new StoreObject[] {
                new StoreObject("ID", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nombre", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Apellido", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("PIN", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Ingreso", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Nacimiento", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cédula", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Teléfono", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email Personal", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Email Empresarial", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Cargo", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Departamento", typeof(string), "text", new Gtk.CellRendererText()),
                new StoreObject("Horario", typeof(string), "text", new Gtk.CellRendererText()),
            };
            this.viewTable.SetTreeViewColumns(this.StoreObjects);

            this.UpdateData();
        }

        public void Close()
        {
            this.Destroy();
        }

        public void UpdateData()
        {
            this.Model = this.DtEmp.GetDataView();
            this.viewTable.Model = Model;
        }

        protected void BtnRefreshOnClicked(object sender, EventArgs e)
        {
            this.UpdateData();
        }

        protected void BtnExitOnClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        protected void BtnSaveOnClicked(object sender, EventArgs args)
        {
            FileChooserDialog fileChooserDialog =
                new FileChooserDialog(
                    "Guardar Reporte",
                    this,
                    FileChooserAction.Save,
                    "_Cancelar",
                    Gtk.ResponseType.Cancel,
                    "_Guardar",
                    Gtk.ResponseType.Accept,
                    null
                    );

            fileChooserDialog.DoOverwriteConfirmation = true;
            fileChooserDialog.CurrentName = "Reporte Empleado.xlsx";

            int result = fileChooserDialog.Run();
            string fileName = fileChooserDialog.Filename;

            fileChooserDialog.Destroy();

            if (result != (int)ResponseType.Accept) return;

            try
            {
                if (File.Exists(this.TempFileName))
                    File.Delete(this.TempFileName);

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(this.TempFileName))
                {
                    var sheet = package.Workbook.Worksheets.Add("Empleados");

                    sheet.Cells["A1"].Value = "SistemaEyS";
                    using (ExcelRange r = sheet.Cells[1, 1, 1, this.StoreObjects.Length])
                    {
                        r.Merge = true;
                        r.Style.Font.Size = 18;
                        r.Style.Font.Bold = true;
                        r.Style.Font.Color.SetColor(Color.Black);
                        r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        r.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(240, 240, 240));
                        r.EntireRow.Height = 24;
                    }
                    sheet.Cells["A2"].Value = "Reporte de Empleados";
                    using (ExcelRange r = sheet.Cells[2, 1, 2, this.StoreObjects.Length])
                    {
                        r.Merge = true;
                        r.Style.Font.Size = 16;
                        r.Style.Font.Bold = true;
                        r.Style.Font.Color.SetColor(Color.Black);
                        r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        r.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(240, 240, 240));
                        r.EntireRow.Height = 22;
                    }

                    for (int i = 0; i < this.StoreObjects.Length; i++)
                    {
                        sheet.Cells[3, i + 1].SetCellValue(0, 0, this.StoreObjects[i].name);
                    }

                    List<List<string>> array = new List<List<string>>();

                    TreeIter iter;
                    if (this.Model.GetIterFirst(out iter))
                    {
                        int j = 1;
                        do
                        {
                            List<string> vs = new List<string>();
                            for (int i = 0; i < this.Model.NColumns; i++)
                            {
                                object value = this.Model.GetValue(iter, i);
                                string v = null;
                                if (value != null)
                                    v = value.ToString();
                                vs.Add(v);
                            }
                            array.Add(vs);
                        }
                        while (this.Model.IterNext(ref iter));
                    }

                    List<List<string>> newArray = new List<List<string>>();

                    for (int i = 0; i < array[0].Count; i++)
                        newArray.Add(new List<string>(array.Count));

                    for (int j = 0; j < array.Count; j++)
                        for (int i = 0; i < array[0].Count; i++)
                            newArray[i].Add(array[j].Count > i ? array[j][i] : default(string));

                    for (int i = 0; i < newArray.Count; i++)
                    {
                        sheet.Cells[4, i + 1].AutoFitColumns(0);
                        sheet.Cells[4, i + 1].LoadFromCollection(newArray[i]);
                    }

                    package.SaveAs(fileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
