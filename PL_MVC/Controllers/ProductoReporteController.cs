using System;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PL_MVC.Controllers
{
    public class ProductoReporteController : Controller
    {
        // GET: ProductoReporte
        public ActionResult GetAll()
        {
            ML.Result result = BL.ProductoPrueba.GetAll();
            ML.ProductoPrueba producto = new ML.ProductoPrueba ();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(1000);
            reportViewer.Height = Unit.Percentage(1000);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath)+ @"Reports\ProductoGetAllReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", result.Objects));
            ViewBag.ReportViewer = reportViewer;
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {

            }
            return View(producto);
        }
        public ActionResult Ventas()
        {
            ML.Result result = BL.ProductoPrueba.VentaGetByIdProducto();
            ML.ProductoPrueba producto = new ML.ProductoPrueba();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(1000);
            reportViewer.Height = Unit.Percentage(1000);
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\VentasGetByIdProducto.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", result.Objects));
            ViewBag.ReportViewer = reportViewer;
            if (result.Correct)
            {
                producto.Productos = result.Objects;
            }
            else
            {

            }
            return View(producto);
        }
    }
}