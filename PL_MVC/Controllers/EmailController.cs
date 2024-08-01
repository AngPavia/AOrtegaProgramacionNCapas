using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            ML.Result result = new ML.Result();
            string htmlContent = string.Empty;
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("angeles.pavia28@gmail.com", "lkbydxatdnmtxvxk"),
                    EnableSsl = true,
                };

                var mensaje = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress("angeles.pavia28@gmail.com"),
                    Subject = "Test",
                    Body = "Correo de prueba",
                    IsBodyHtml = true,
                };
                mensaje.To.Add("angeles.pavia28@gmail.com");
                //smtpClient.Send(mensaje);
                ML.DetallePedido pedido = new ML.DetallePedido();   
                ML.DetallePedido detallePedido = (ML.DetallePedido)Session["Producto"];
                StringBuilder productosHtml = new StringBuilder();
                
                foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
                {
                    productosHtml.Append("<tr>");
                    productosHtml.Append("<td><strong>" + detallePedidoItem.Producto.Nombre + "</strong></td>");
                    productosHtml.Append("<td>" + detallePedidoItem.Cantidad + "</td>");
                    productosHtml.Append("</tr>");
                }
               


                string htmlFile = Server.MapPath("~/Content/CorreoTemplate/Template.html"); 
                using (StreamReader reader = new StreamReader(htmlFile))
                {
                    htmlContent = reader.ReadToEnd();
                }
                var Usuario = User.Identity.GetUserName();
                mensaje.Body = htmlContent;
                mensaje.Body = mensaje.Body.Replace("{Productos}", productosHtml.ToString());
                mensaje.Body = mensaje.Body.Replace("{Nombre}", Usuario);

                Attachment htmlAttachment = new Attachment(htmlFile, MediaTypeNames.Text.Html);
                mensaje.Attachments.Add(htmlAttachment);
                smtpClient.Send(mensaje);
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return RedirectToAction("ProductoGetAll", "Pedido");
        }
    }
}