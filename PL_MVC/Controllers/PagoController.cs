using System.Collections.Generic;
using System.Web.Mvc;
using Stripe;
using Stripe.Checkout;

namespace PL_MVC.Controllers
{
    public class PagoController : Controller
    {
        public PagoController()
        {
            StripeConfiguration.ApiKey = "sk_test_51PYD5u2L6T74wSGI9HpT9C5ux7X6PND9hiaBS8TXIdsyn0CPB1XEPHNhkjyfdJZ0zCLH7fTY5iwmM6NM9d80Wxph00rzuFm27V";
        }

        // POST: /Pago/CreateCheckoutSession
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult CreateCheckoutSession()
        {
            var lineItems = new List<SessionLineItemOptions>();
            ML.DetallePedido detallePedido = (ML.DetallePedido)Session["Producto"];
            foreach (ML.DetallePedido detallePedidoItem in detallePedido.DetallePedidos)
            {

              
                var item = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(detallePedidoItem.Producto.Precio * 100), // Precio en centavos
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
                    "card", // Permitir pagos con tarjeta de crédito/débito
                },
                LineItems = lineItems, // Asignar la lista de line items construida
                Mode = "payment",
                SuccessUrl = "http://localhost:4242/success",
                CancelUrl = "http://localhost:4242/cancel",
            };


            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url); 
        }
    }
}
