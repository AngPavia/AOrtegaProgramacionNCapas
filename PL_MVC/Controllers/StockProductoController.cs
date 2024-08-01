using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class StockProductoController : Controller
    {
        // GET: StockProducto
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
            productoSucursal.ProductosSucursal = result.Objects;
            ML.Result listaSucursal = BL.Sucursal.GetAll();
            productoSucursal.Sucursal = new ML.Sucursal();
            productoSucursal.Sucursal.Sucursales = listaSucursal.Objects;

            result = BL.ProductoSucursal.GetAll();
            productoSucursal.ProductosSucursal = result.Objects;
            return View(productoSucursal);
        }
        [HttpPost]
        public ActionResult GetAll(ML.ProductoSucursal productoSucursal)
        {
            if (productoSucursal.Sucursal == null)
            {
                productoSucursal.Sucursal = new ML.Sucursal();
            }
            ML.Result result = new ML.Result();
            result = BL.ProductoSucursal.ProductoByIdSucursal(productoSucursal.Sucursal.IdSucursal);
            productoSucursal = new ML.ProductoSucursal();
            productoSucursal.ProductosSucursal = result.Objects;
            ML.Result listaSucursal = BL.Sucursal.GetAll();
            productoSucursal.Sucursal = new ML.Sucursal();
            productoSucursal.Sucursal.Sucursales = listaSucursal.Objects;
            return View(productoSucursal);
        }
        public ActionResult Delete(int IdProductoSucursal)
        {
            ML.Result result = new ML.Result();
            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
            productoSucursal.IdProductoSucursal = IdProductoSucursal;
            result = BL.ProductoSucursal.Delete(productoSucursal);
            if (result.Correct == true)
            {
                ViewBag.Mensaje = "Se borró exitosamente";
            }
            else
            {
                ViewBag.Mensaje = "No se borró el registro " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult Update(ML.ProductoSucursal productoSucursal)
        {
            ML.Result result = new ML.Result();
            result = BL.ProductoSucursal.Update(productoSucursal);  
            if (result.Correct == true)
            {
                ViewBag.Mensaje = "Se editó exitosamente";
            }
            else
            {
                ViewBag.Mensaje = "No se editó el registro " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }




    }
}