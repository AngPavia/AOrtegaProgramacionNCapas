using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DropDownListController : Controller
    {
        // GET: DropDownList
        public ActionResult GetAll()
        {
            
            ML.Result listaEstados = BL.Estado.GetAll();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();   
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();   
            usuario.Direccion.Colonia.Municipio.Estado.Estados = listaEstados.Objects;
            return View(usuario);
        }

        [HttpGet]
        public JsonResult GetMunicipiosByIdEstado(byte IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetColoniasByIdMunicipio(byte IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}