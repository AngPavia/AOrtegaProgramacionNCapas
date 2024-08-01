using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pedido
    {
        public static ML.Result Add(ML.Pedido pedido)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    //pedido = new ML.Pedido();
                    //pedido.Usuario = new ML.Usuario();  
                    //pedido.Usuario.Direccion = new ML.Direccion();
                    ObjectParameter output = new ObjectParameter("IdPedido", typeof(int));

                    var query = context.PedidoAdd(pedido.Usuario.IdUsuario,pedido.Usuario.Direccion.IdDireccion, output);
                    if (query>0)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(output.Value);
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {

            }

            return result;
        }
    }
}
