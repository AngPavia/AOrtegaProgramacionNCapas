using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DetallePedido
    {
        public static ML.Result Add(ML.DetallePedido detallePedido)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                   

                    var query = context.DetallePedidoAdd(detallePedido.Pedido.IdPedido, detallePedido.Producto.IdProducto, detallePedido.Cantidad);
                    if (query > 0)
                    {
                        result.Correct = true;
                        
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
