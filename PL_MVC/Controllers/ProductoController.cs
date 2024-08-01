using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();

            ML.Result result = BL.Producto.GetAll();
            producto.Productos = result.Objects;
            ML.Result listaCategoria = BL.Categoria.GetAll();

            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;

            ML.Result listaSubcategoria = BL.SubCategoria.GetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);
            producto.SubCategoria.SubCategorias = listaSubcategoria.Objects;
            return View(producto);



        }
        [HttpPost]
        public ActionResult GetAll(ML.Producto producto)
        {
            if (producto.SubCategoria == null)
            {
                producto.SubCategoria = new ML.SubCategoria();
            }
            ML.Result result = new ML.Result();
            result = BL.Producto.ProductoByIdSubCategoria(producto.SubCategoria.IdSubCategoria);
            producto.Productos = result.Objects;
            ML.Result listaCategoria = BL.Categoria.GetAll();

            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;

            ML.Result listaSubcategoria = BL.SubCategoria.GetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);
            producto.SubCategoria.SubCategorias = listaSubcategoria.Objects;
            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int IdProducto)
        {
            ML.Result listaCategoria = BL.Categoria.GetAll();
            ML.Producto producto = new ML.Producto();
            producto.SubCategoria = new ML.SubCategoria();
            producto.SubCategoria.Categoria = new ML.Categoria();
            producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;




            if (IdProducto > 0)
            {

                ML.Result result = BL.Producto.GetById(IdProducto);
                if (result.Correct)
                {
                    producto = (ML.Producto)result.Object;
                    //producto.SubCategoria.Categoria = new ML.Categoria();
                    producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;
                    ML.Result listaSubcategoria = BL.SubCategoria.GetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);
                    producto.SubCategoria.SubCategorias = listaSubcategoria.Objects;
                    return View(producto);
                }
                else
                {
                    ViewBag.Mensaje = "No se encontró";
                }
            }


            //getall de categoria
            return View(producto);
        }


        //public ActionResult Form(int IdProducto)
        //{
        //    ML.Result listaCategoria = BL.Categoria.GetAll();
        //    ML.Producto producto = new ML.Producto();
        //    producto.SubCategoria = new ML.SubCategoria();
        //    producto.SubCategoria.Categoria = new ML.Categoria();
        //    producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;


        //    List<object> subcategorias = new List<object>
        //{
        //        new ML.SubCategoria { IdSubCategoria = 1, Nombre = "Subcategoría 1" },
        //        new ML.SubCategoria { IdSubCategoria = 2, Nombre = "Subcategoría 2" },
        //        new ML.SubCategoria { IdSubCategoria = 3, Nombre = "Subcategoría 3" },
        //        new ML.SubCategoria { IdSubCategoria = 4, Nombre = "Subcategoría 4" }
        //};


        //    List<object> categorias = new List<object>
        //{
        //        new ML.Categoria { IdCategoria = 1, Nombre = "Categoría 1" },
        //        new ML.Categoria { IdCategoria = 2, Nombre = "Categoría 2" },
        //        new ML.Categoria { IdCategoria = 3, Nombre = "Categoría 3" },
        //        new ML.Categoria { IdCategoria = 4, Nombre = "Categoría 4" }
        //};


        //    if (IdProducto > 0)
        //    {
        //        ML.Result result = BL.Producto.GetById(IdProducto);
        //        if (result.Correct)
        //        {
        //            producto = (ML.Producto)result.Object;

        //            producto.SubCategoria.Categoria.Categorias = listaCategoria.Objects;
        //            producto.SubCategoria.Categoria.Categorias = categorias;

        //            ML.Result listaSubcategoria = BL.SubCategoria.GetByIdCategoria(producto.SubCategoria.Categoria.IdCategoria);


        //            producto.SubCategoria.SubCategorias = listaSubcategoria.Objects;


        //            producto.SubCategoria.SubCategorias = subcategorias;




        //            return View(producto);
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "No se encontró";
        //        }
        //    }


        //    return View(producto);
        //}



        [HttpPost]  
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["file"];
            if (file != null && file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBase64(file);
            }


            if (producto.IdProducto>0)
            {
                result = BL.Producto.Update(producto);
            }
            else
            {
                
                result = BL.Producto.Add(producto); 
            }
            if (result.Correct == true)
            {
                ViewBag.Mensaje = "Se insertó el registro correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se insertó el registro" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdProducto) 
        {
            ML.Result result = new ML.Result();
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto;   
            result = BL.Producto.Delete(producto);
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


        public byte[] ConvertToBase64(HttpPostedFileBase archivo)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(archivo.InputStream);
            data = reader.ReadBytes((int)archivo.ContentLength);
            return data;
        }
        public JsonResult GetSubCategoriaByIdCategoria(byte IdCategoria)
        {
            ML.Result result = BL.SubCategoria.GetByIdCategoria(IdCategoria);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


       
    }
    
}