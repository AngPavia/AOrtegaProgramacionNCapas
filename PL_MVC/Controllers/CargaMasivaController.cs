using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        [HttpPost]
        public ActionResult CargaMasiva()
        {
            if (Session["pathExcel"] == null)
            {
                ML.Result result = new ML.Result();
                HttpPostedFileBase excel = Request.Files["Excel"];
                if (excel != null)
                {

                    string extension = Path.GetExtension(excel.FileName);
                    if (extension == ".xlsx")
                    {
                        string filePath = Server.MapPath("~/CargaMasiva") + Path.GetFileNameWithoutExtension(excel.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx";
                        if (!System.IO.File.Exists(filePath))
                        {
                            excel.SaveAs(filePath);
                            string context = ConfigurationManager.ConnectionStrings["OleDbConnection"].ToString() + filePath;
                            result = BL.Producto.LeerExcel(context);
                            if (result.Correct)
                            {
                                ML.Result validarExcel = BL.Producto.ValidarExcel(result.Objects);
                                if (validarExcel.Objects.Count == 0)
                                {
                                    Session["pathExcel"] = filePath;

                                }
                                else {
                                   // ViewBag.Mensaje = "Errores";
                                    ViewBag.Result= validarExcel.Objects;
                                    return PartialView("Modal");
                                }
                            }
                            else
                            {
                                ViewBag.Mensaje = "Ocurrió un error en la lectura del Excel" + result.ErrorMessage;
                                return PartialView("Modal");
                            }
                        }
                        else
                        {
                            ViewBag.Mensaje = "No existe";
                            return PartialView("Modal");
                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "No es una extensión permitida";
                        return PartialView("Modal");
                    }


                }
                else
                {
                    ViewBag.Mensaje = "Seleccione un archivo";
                    return PartialView("Modal");
                }
            }
            else
            {


                var conexion = ConfigurationManager.ConnectionStrings["OleDbConnection"].ToString();
                var sesion = Session["pathExcel"].ToString();
                string context = ConfigurationManager.ConnectionStrings["OleDbConnection"].ToString() + Session["pathExcel"].ToString();
                ML.Result result = BL.Producto.LeerExcel(context);
                if (result.Correct)
                {
                    ML.Result resultErrores = new ML.Result();
                    resultErrores.Objects = result.Objects;
                    foreach (ML.Producto producto in result.Objects)
                    {
                        ML.Result resultAdd = BL.Producto.Add(producto);
                        if (!resultAdd.Correct)
                        {
                            string error = "Error al insertar" + producto.Nombre + " " + resultAdd.ErrorMessage;

                            resultErrores.Objects.Add(error);
                            ViewBag.Errores = resultErrores.Objects;
                        }

                    }
                }
                Session["pathExcel"] = null;

                ViewBag.Mensaje = "La inserción fue correcta";
                return PartialView("Modal");


            }

            TempData["Action"] = "Agregar";
            return RedirectToAction("GetAll", "Producto");
        }
    }
}