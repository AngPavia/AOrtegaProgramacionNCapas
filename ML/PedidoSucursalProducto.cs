using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class PedidoSucursalProducto
    {
       public ML.DetallePedido DetallePedido { get; set; }
       public ML.ProductoSucursal ProductoSucursal { get; set; }
       public List<object> PedidoSucursalProductos { get; set; }
    }
}
