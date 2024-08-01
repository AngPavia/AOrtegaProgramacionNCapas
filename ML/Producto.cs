using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto {  get; set; }    
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }    
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; } 
        public ML.SubCategoria SubCategoria { get; set; }
        public ML.Sucursal Sucursal { get; set; }
        public ML.ProductoSucursal ProductoSucursal { get; set; }  
        public ML.ErrorExcel Error { get; set; }    
        public List<object> Productos { get; set; }
    }
}
