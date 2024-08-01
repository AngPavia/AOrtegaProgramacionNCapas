using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //metodoWebAPI
        public ML.Result AddWebAPI(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var poatTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add/", usuario);
                poatTask.Wait();    
                var resultServicio = poatTask.Result;
                if (resultServicio.IsSuccessStatusCode)
                {
                    result.Correct = true;
                }
            }
            return result;
        }


        public ML.Result UpdateWebAPI(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var poatTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Update/", usuario);
                poatTask.Wait();
                var resultServicio = poatTask.Result;
                if (resultServicio.IsSuccessStatusCode)
                {
                    result.Correct = true;
                }
            }
            return result;
        }

        public ML.Result DeleteWebAPI(ML.Usuario usuario, ML.Direccion direccion)
        {
            ML. Result result = new ML.Result();
            int IdUsuario = usuario.IdUsuario;
            int IdDireccion = direccion.IdDireccion;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var deleteTask = client.DeleteAsync("Usuario/Delete/" + IdUsuario + "/" + IdDireccion);
                deleteTask.Wait();
                var resultServicio = deleteTask.Result;
                if (resultServicio.IsSuccessStatusCode)
                {
                    result.Correct = true;
                }
            }

            return result;
        }

        public ML.Result GetAllWebAPI (ML.Usuario usuario)
        {
            ML. Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var responseTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/GetAll", usuario);
                responseTask.Wait();
                var resultServicio = responseTask.Result;
                if (resultServicio.IsSuccessStatusCode)
                {
                    result.Correct=true;
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();    
                    readTask.Wait();
                    result.Objects = new List<object>();
                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        result.Objects.Add(resultItemList);
                    }
                }
            }
                return result;
        }

        public ML.Result GetBYIdWebAPI(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var responseTask = client.GetAsync("Usuario/GetById/"+ IdUsuario);
                responseTask.Wait();
                var resultServicio = responseTask.Result;
                if (resultServicio.IsSuccessStatusCode)
                {
                    result.Correct = true;
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                        result.Object=resultItemList;
                    
                }
            }
            return result;
        }


        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            if (usuario.Rol == null)
            {
                usuario.Rol = new ML.Rol();
            }

            //SERVICIO WCF
            //ServiceUsuario.ServiceUsuarioClient servicio = new ServiceUsuario.ServiceUsuarioClient();
            //ServiceUsuario.Result result = servicio.GetAll(usuario);

            //SERVICIO API
           ML.Result result = new ML.Result();
            result = GetAllWebAPI(usuario);
          //ML.Result result = BL.Usuario.GetAllEF(usuario);

            //usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;
            //rol

            ML.Result listaRol = BL.Rol.GetAll();

            usuario.Rol.Objects = listaRol.Objects;
            return View(usuario);
        }
        [HttpGet]
        public ActionResult FormAdd(int IdUsuario)
        {
            //rol
            ML.Result listaRol = BL.Rol.GetAll();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Objects = listaRol.Objects;
            ML.Result listaEstado = BL.Estado.GetAll();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

            if (IdUsuario > 0)
            {
                //Update
                //ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
                //SERVICIO WCF
                //ServiceUsuario.ServiceUsuarioClient servicio = new ServiceUsuario.ServiceUsuarioClient();
                //ServiceUsuario.Result result = servicio.GetById(IdUsuario);

                //SERVICIO API
                ML.Result result = new ML.Result();
                result = GetBYIdWebAPI(IdUsuario);

                if (result.Correct)
                {
                    
                    usuario = (ML.Usuario)result.Object;
                    DateTime OnlyDate = DateTime.Parse(usuario.FechaNacimiento).Date;
                    usuario.FechaNacimiento = OnlyDate.ToString("yyyy-MM-dd");
                    usuario.Rol.Objects = listaRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = listaEstado.Objects;
                    ML.Result listaMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = listaMunicipio.Objects;
                    ML.Result listaColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = listaColonia.Objects;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Mensaje = "No se encontró";
                }
            }
            else
            {
                usuario.Rol.Objects = listaRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = listaEstado.Objects;
                return View(usuario);//Add
            }
            return View();
        }
        [HttpPost]
        public ActionResult FormAdd(ML.Usuario usuario)
        {
            //SERVICIO 
            //ServiceUsuario.ServiceUsuarioClient servicio = new ServiceUsuario.ServiceUsuarioClient();
            //ServiceUsuario.Result result = new ServiceUsuario.Result(); 
        
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["file"];
            if (file != null && file.ContentLength>0)
            {
                //convertir imagen
                usuario.Imagen = ConvertToBase64(file);//si la codición es falsa quiere decir que la imagen no cambió en el formulario. 
            }


            //validaciones
            if (ModelState.IsValid)
            {
                if (usuario.IdUsuario > 0)
                {
                    //servicio API
                    result = UpdateWebAPI(usuario);

                    //result = BL.Usuario.UpdateEF(usuario);

                }
                else
                {
                    //SERVICIO API
                    result = AddWebAPI(usuario);
                    //servicio WCF
                    //result = servicio.Add(usuario);
                    //result = BL.Usuario.AddEF(usuario);
                }
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
        [HttpGet]
        public ActionResult Delete(int IdUsuario, int IdDireccion)
        {

 
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Direccion direccion = new ML.Direccion();    
            direccion.IdDireccion = IdDireccion;
            //ML.Result result = BL.Usuario.DeleteEF(usuario, direccion);

            //SERVICIO WCF
            //ServiceUsuario.ServiceUsuarioClient servicio = new ServiceUsuario.ServiceUsuarioClient();
            //ServiceUsuario.Result result = servicio.Delete(IdUsuario, IdDireccion);

            //SERVICIO API
            ML.Result result = new ML.Result();
            result = DeleteWebAPI(usuario, direccion);

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

        public string ConvertToBase64 (HttpPostedFileBase archivo)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(archivo.InputStream);
            data = reader.ReadBytes((int)archivo.ContentLength);
            return Convert.ToBase64String(data);
        }
        [HttpPost]
        public JsonResult ChangeStatus(int IdUsuario, bool Status)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            usuario.Status = Status;
            ML.Result result = BL.Usuario.UpdateStatus(usuario);           
            return Json(result);
        }


    }

}