using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductoSucursal
    {
        public static ML.Result ProductoByIdSucursal(int IdSucursal)
        {
            ML.Result result = new ML.Result();

            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.ProductoByIdSucursal(IdSucursal).ToList();
                if (query.Count > 0)
                {
                    result.Objects = new List<object>();


                    foreach (var fila in query)
                    {
                        ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
                        productoSucursal.IdProductoSucursal = fila.IdProductoSucursal;
                        productoSucursal.Stock = fila.Stock.Value;
                        productoSucursal.Producto = new ML.Producto();  
                        productoSucursal.Producto.IdProducto = fila.ProductoId;
                        productoSucursal.Producto.Imagen = fila.Imagen;
                        productoSucursal.Producto.Nombre = fila.Producto;
                        productoSucursal.Sucursal = new ML.Sucursal();
                        productoSucursal.Sucursal.IdSucursal = fila.SucursalID;
                        productoSucursal.Sucursal.Nombre = fila.Sucursal;
                        result.Objects.Add(productoSucursal);

                    }
                    result.Correct = true;
                }
                else
                {

                }

            }
            return result;
        }



        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var query = context.ProductoSucursalGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in query)
                        {
                            ML.ProductoSucursal productoSucursal = new ML.ProductoSucursal();
                            productoSucursal.IdProductoSucursal = fila.IdProductoSucursal;
                            productoSucursal.Stock = fila.Stock.Value;
                            productoSucursal.Producto = new ML.Producto();
                            productoSucursal.Producto.IdProducto = fila.ProductoId;
                            productoSucursal.Producto.Nombre = fila.Producto;
                            productoSucursal.Sucursal = new ML.Sucursal();
                            productoSucursal.Sucursal.IdSucursal = fila.SucursalID;
                            productoSucursal.Sucursal.Nombre = fila.Sucursal;
                            result.Objects.Add(productoSucursal);
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

        public static ML.Result Delete(ML.ProductoSucursal productoSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = context.ProductoSucursalDelete(productoSucursal.IdProductoSucursal);
                    if (RowsAffected > 0)
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



        public static ML.Result Update(ML.ProductoSucursal productoSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = context.ProductoSucursalUpdate(productoSucursal.Stock, productoSucursal.IdProductoSucursal);
                    if (RowsAffected > 0)
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }




    }
}
