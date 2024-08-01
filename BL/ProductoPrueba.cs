using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoPrueba
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.NorthwindEntities context = new DLEF.NorthwindEntities())
                {
                   
                    var query = context.ProductoPruebaGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.ProductoPrueba producto = new ML.ProductoPrueba();
                            producto.ProductID = row.ProductID;
                            producto.ProductName = row.ProductName;
                            producto.SupplierID = row.SupplierID.Value;
                            producto.CategoryID = row.CategoryID.Value;
                            producto.QuantityPerUnit = row.QuantityPerUnit;
                            producto.UnitPrice = row.UnitPrice.Value;
                            producto.UnitsInStock = row.UnitsInStock.Value;
                            producto.UnitsInOrder = row.UnitsOnOrder.Value;
                            producto.ReorderLevel = row.ReorderLevel.Value;
                            producto.Discontinued = row.Discontinued;

                            result.Objects.Add(producto);
                        }
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result VentaGetByIdProducto()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.NorthwindEntities context = new DLEF.NorthwindEntities ())
                {
                    var query = context.VentaGetByIdProducto().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in query)
                        {
                            result.Objects.Add(fila);
                        }
                        result.Correct = true;
                    }
                }
            }catch (Exception ex) 
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }

    
}
