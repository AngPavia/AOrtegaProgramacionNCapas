using BL;
using Microsoft.AspNet.Identity;
using ML;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult ProductoGetAll()
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

     
        public ActionResult PedidoSucursalProducto(int? IdProducto)
        {
            if (IdProducto==null || IdProducto==0)
            {
                ML.DetallePedido detalle = (ML.DetallePedido)Session["Producto"];
                return View(detalle); 
            }
            else
            {
                bool existe = false;
                ML.DetallePedido detallePedido = new ML.DetallePedido();
                if (Session["Producto"] == null)
                {

                    detallePedido.DetallePedidos = new List<object>();
                    ML.DetallePedido detallePedidoItem = new ML.DetallePedido();
                    ML.Result result = BL.Producto.GetById(IdProducto.Value);
                    detallePedidoItem.Producto = new ML.Producto();
                    detallePedidoItem.Producto = (ML.Producto)result.Object;
                    detallePedidoItem.Cantidad = 1;
                    detallePedido.DetallePedidos.Add(detallePedidoItem);
                    Session["Producto"] = detallePedido;
                    return View(detallePedido);
                }
                else
                {

                    detallePedido = (ML.DetallePedido)Session["Producto"];

                    foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
                    {
                        if (IdProducto == detallePedidoItem.Producto.IdProducto)
                        {
                            detallePedidoItem.Cantidad = detallePedidoItem.Cantidad + 1;
                            existe = true;
                            break;
                        }

                    }
                    if (!existe)
                    {

                        ML.DetallePedido detallePedidoItem = new ML.DetallePedido();
                        ML.Result result = BL.Producto.GetById(IdProducto.Value);
                        detallePedidoItem.Producto = new ML.Producto();
                        detallePedidoItem.Producto = (ML.Producto)result.Object;
                        detallePedidoItem.Cantidad = 1;
                        detallePedido.DetallePedidos.Add(detallePedidoItem);
                    }

                }
                Session["Producto"] = detallePedido;

                return View(detallePedido);

            }



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

        public ActionResult AumentarCantidad(int IdProducto)
        {
            bool existe = false;
            ML.DetallePedido detallePedido = new ML.DetallePedido();
            if (Session["Producto"] == null)
            {

                detallePedido.DetallePedidos = new List<object>();
                ML.DetallePedido detallePedidoItem = new ML.DetallePedido();
                ML.Result result = BL.Producto.GetById(IdProducto);
                detallePedidoItem.Producto = new ML.Producto();
                detallePedidoItem.Producto = (ML.Producto)result.Object;
                detallePedido.DetallePedidos.Add(detallePedidoItem);
                Session["Producto"] = detallePedido;
                return View(detallePedido);
            }
            else
            {

                detallePedido = (ML.DetallePedido)Session["Producto"];

                foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
                {
                    if (IdProducto == detallePedidoItem.Producto.IdProducto)
                    {
                        detallePedidoItem.Cantidad = detallePedidoItem.Cantidad + 1;
                        existe = true;
                        break;
                    }

                }

            }
            Session["Producto"] = detallePedido;

            return View("PedidoSucursalProducto", detallePedido);
        }


        public ActionResult DecrementarCantidad(int IdProducto)
        {
            bool existe = false;
            ML.DetallePedido detallePedido = new ML.DetallePedido();
            if (Session["Producto"] == null)
            {

                detallePedido.DetallePedidos = new List<object>();
                ML.DetallePedido detallePedidoItem = new ML.DetallePedido();
                ML.Result result = BL.Producto.GetById(IdProducto);
                detallePedidoItem.Producto = new ML.Producto();
                detallePedidoItem.Producto = (ML.Producto)result.Object;
                detallePedido.DetallePedidos.Add(detallePedidoItem);
                Session["Producto"] = detallePedido;
                return View(detallePedido);
            }
            else
            {

                detallePedido = (ML.DetallePedido)Session["Producto"];

                foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
                {
                    if (IdProducto == detallePedidoItem.Producto.IdProducto)
                    {
                        detallePedidoItem.Cantidad = detallePedidoItem.Cantidad - 1;
                        existe = true;
                        if (detallePedidoItem.Cantidad == 0)
                        {
                            detallePedido.DetallePedidos.Remove(detallePedidoItem);

                        }
                        break;

                    }
                }

            }
            Session["Producto"] = detallePedido;
            if (detallePedido.DetallePedidos.Count == 0)
            {
                ViewBag.Mensaje = "El carrito está vacío";
                return PartialView("Modal");
            }
            return View("PedidoSucursalProducto", detallePedido);
        }


        public ActionResult DeleteProducto(int IdProducto)
        {
            ML.DetallePedido detallePedido = new ML.DetallePedido();
            if (Session["Producto"] != null)
            {

                detallePedido = (ML.DetallePedido)Session["Producto"];

                ML.DetallePedido productoAEliminar = null;

                foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
                {
                    if (detallePedidoItem.Producto.IdProducto == IdProducto)
                    {
                        productoAEliminar = detallePedidoItem;
                        break;
                    }
                }

                if (productoAEliminar != null)
                {

                    detallePedido.DetallePedidos.Remove(productoAEliminar);


                    Session["Producto"] = detallePedido;


                    //return RedirectToAction("PedidoSucursalProducto", detallePedido);
                }
                if (detallePedido.DetallePedidos.Count == 0)
                {
                    ViewBag.Mensaje = "El carrito está vacío";
                    return PartialView("Modal");
                }
            }
            return View("PedidoSucursalProducto", detallePedido);
        }
        public PedidoController()
        {
            StripeConfiguration.ApiKey = "sk_test_51PYD5u2L6T74wSGI9HpT9C5ux7X6PND9hiaBS8TXIdsyn0CPB1XEPHNhkjyfdJZ0zCLH7fTY5iwmM6NM9d80Wxph00rzuFm27V";
        }
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProcesarCompra()
        {
            //código para procesar la compra
            var IdUsuario = User.Identity.GetUserId();
            ML.Pedido pedido = new ML.Pedido();
            ML.Result result = BL.Usuario.GetByIdAspNet(IdUsuario);
      
            pedido.Usuario = (ML.Usuario)result.Object;
           
            ML.DetallePedido detallePedido = (ML.DetallePedido)Session["Producto"];
            
            if (result.Correct)
            {
                result = BL.Pedido.Add(pedido);
            }
            
            int idPedido = (int)result.Object;
            foreach (ML.DetallePedido detallePedidoItem  in detallePedido.DetallePedidos )
            {
                
                detallePedidoItem.Pedido = new ML.Pedido();
                detallePedidoItem.Pedido.IdPedido = idPedido;
                BL.DetallePedido.Add(detallePedidoItem);
                
               
            }


            var lineItems = new List<SessionLineItemOptions>();
           // ML.DetallePedido detallePedido = (ML.DetallePedido)Session["Producto"];
            foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
            {


                var item = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(detallePedidoItem.Producto.Precio * 100),
                        Currency = "MXN",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = detallePedidoItem.Producto.Nombre,
                        },
                    },
                    Quantity = detallePedidoItem.Cantidad,
                };

                lineItems.Add(item);

            }
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card", // Permitir pagos con tarjeta
                },
                LineItems = lineItems, // Asignar la lista de line items construida
                Mode = "payment",
                SuccessUrl = Url.Action("Index", "Email", null, Request.Url.Scheme),

                CancelUrl = "http://localhost:4242/cancel",

            };


            var service = new SessionService();
            Session session = service.Create(options);
            
            return Redirect(session.Url);

            
        }



    }
}