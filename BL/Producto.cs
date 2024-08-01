using DLEF;
using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = context.ProductoAdd(producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.SubCategoria.IdSubCategoria);
                    if (RowsAffected>0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;   
                    }
                }


            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.SubCategoria.IdSubCategoria);
                    if (RowsAffected>0) 
                    { 
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;  
                    }
                }
            }catch (Exception ex) 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = context.ProductoDelete(producto.IdProducto);
                    if (RowsAffected > 0)
                    {
                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
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
                    //producto.SubCategoria = new ML.SubCategoria();
                    var query = context.ProductoGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Producto producto = new ML.Producto();    
                            producto.IdProducto = row.IdProducto;
                            producto.Nombre = row.Nombre;
                            producto.Descripcion = row.Descripcion;
                            producto.Precio = row.Precio.Value;
                            producto.Imagen = row.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = row.IdSubCategoria.Value;
                            producto.SubCategoria.Nombre = row.Categoria;
                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
                return result;
        }

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Descripcion = query.Descripcion;
                        producto.Precio = query.Precio.Value;
                        producto.Imagen = query.Imagen;
                        ML.Categoria categoria = new ML.Categoria();
                        categoria.IdCategoria = query.IdCategoria;
                        producto.SubCategoria = new ML.SubCategoria();
                        producto.SubCategoria.IdSubCategoria = query.IdSubCategoria.Value;
                        producto.SubCategoria.Categoria = categoria;
                        result.Object= producto;  
                        result.Correct= true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result ProductoByIdSubCategoria(int IdSubCategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    ML.Producto producto = new ML.Producto();
                    producto.SubCategoria = new ML.SubCategoria();
                    var query = context.ProductoByIdSubcategoria(IdSubCategoria).ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            producto = new ML.Producto();
                            producto.IdProducto = row.IdProducto;
                            producto.Nombre = row.Nombre;
                            producto.Descripcion = row.Descripcion;
                            producto.Precio = row.Precio.Value;
                            producto.Imagen = row.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = row.IdSubCategoria.Value;
                            producto.SubCategoria.Nombre = row.NombreCategoria;
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
                        ML.Producto producto = new ML.Producto();
                        producto.ProductoSucursal = new ML.ProductoSucursal();
                        producto.ProductoSucursal.IdProductoSucursal = fila.IdProductoSucursal;
                        producto.ProductoSucursal.Producto.IdProducto = fila.IdProducto.Value;
                        producto.ProductoSucursal.Sucursal.IdSucursal = fila.IdSucursal.Value;
                        producto.IdProducto = fila.ProductoId;
                        producto.Nombre = fila.Producto;
                        producto.Sucursal = new ML.Sucursal();
                        producto.Sucursal.IdSucursal = fila.SucursalID;
                        producto.Sucursal.Nombre = fila.Sucursal;
                        result.Objects.Add(producto);
                    }
                    result.Correct = true;
                }
                else
                {

                }

            }
            return result;
        }



        public static byte[] ConvertirImagen(object valor)
        {
            if (valor == DBNull.Value || valor == null)
            {
                return null; // Retorna null si el valor de la imagen es DBNull o nulo
            }

            byte[] imagenBytes = null;

            try
            {
                // Convierte el valor en un array de bytes
                if (valor is byte[])
                {
                    // Si el valor ya es un arreglo de bytes, no es necesario realizar más conversiones
                    imagenBytes = (byte[])valor;
                }
                else if (valor is string)
                {
                    // Si el valor es una cadena, intenta convertirla a un arreglo de bytes
                    imagenBytes = Convert.FromBase64String((string)valor);
                }
                else if (valor is Stream)
                {
                    // Si el valor es un Stream, lee los datos del Stream y conviértelos en un arreglo de bytes
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        ((Stream)valor).CopyTo(memoryStream);
                        imagenBytes = memoryStream.ToArray();
                    }
                }
                else
                {
                    // Si el tipo de valor no es compatible, muestra un mensaje de error o lanza una excepción según sea necesario
                    throw new InvalidOperationException("Tipo de dato no compatible para la conversión a bytes.");
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la conversión
                // Esto puede incluir errores de formato de datos, conversión fallida, etc.
                Console.WriteLine("Error al convertir la imagen: " + ex.Message);
            }

            return imagenBytes;
        }




        public static ML.Result LeerExcel(string valor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (OleDbConnection context = new OleDbConnection(valor))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = query;  
                    cmd.Connection = context;
                    cmd.Connection.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        result.Objects = new List<object>();
                        while (reader.Read())
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Nombre = reader[0].ToString();
                            producto.Descripcion = reader[1].ToString();
                            producto.Precio = Convert.ToDecimal(reader[2]);
                          //  producto.Imagen = ConvertirImagen(reader[3]);
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = Convert.ToInt32(reader[3]);
                            result.Objects.Add(producto);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puedo realizar la consulta al Excel";
                    }
                }
            }catch (Exception ex) {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;  
        }



        public static ML.Result ValidarExcel(List<object> productos)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            int i = 1;
            foreach (ML.Producto producto in productos)
            {
                ML.ErrorExcel error = new ML.ErrorExcel();
                if (producto.Nombre == "")
                {
                    error.Mensaje += "El nombre no puede ser un campo vacío";
                }
                if (producto.Descripcion == "")
                {
                    error.Mensaje += "La descripción no puede ser un campo vacío";
                }
                if (producto.Precio == 0 )
                {
                    error.Mensaje += "El precio no puede ser un campo vacío";
                }
                //if (producto.Imagen == null || producto.Imagen.Length == 0)
                //{
                //    error.Mensaje += "La imagen no puede ser un campo vacío";
                //}
                if (producto.SubCategoria.IdSubCategoria == 0)
                {
                    error.Mensaje += "La Subcategoría no puede ser un campo vacío";
                }
                if (error.Mensaje != null)
                {
                    error.IdRegistro = i;
                    result.Objects.Add(error);
                }
                i++;    
            }
            return result;
        }


       
    }
}
