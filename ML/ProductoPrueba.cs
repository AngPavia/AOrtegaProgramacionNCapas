using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ProductoPrueba
    {
        public int ProductID {  get; set; }    
        public string ProductName { get; set; } 
        public int SupplierID {  get; set; }    
        public int CategoryID {  get; set; }  
        public string QuantityPerUnit { get; set; } 
        public decimal UnitPrice { get; set; }  
        public int UnitsInStock { get; set; }
        public int UnitsInOrder {  get; set; }  
        public int ReorderLevel { get; set; }   
        public bool Discontinued { get; set; }  
        public List<object> Productos { get; set; }
    }
}
