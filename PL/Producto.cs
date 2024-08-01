using ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static ML.Result CargaMasivaTXT()
        {
            ML.Result result = new ML.Result();
            string path = @"C:\Users\digis\OneDrive\Documents\Maria de los Angeles Ortega Pavia\productos.txt";
            StreamReader txt = new StreamReader(path);  
            //lee la primera línea para no procesarla
            txt.ReadLine();
            string linea = txt.ReadLine();  
            while (linea != null)
            {
                string[] valores = linea.Split('|');
                ML.Producto producto = new ML.Producto();
                producto.Nombre = valores[0];   
                producto.Descripcion = valores[1];  
                producto.Precio = Convert.ToDecimal(valores[2]);
                producto.Imagen = ConvertirImagen(valores[3]);
                producto.SubCategoria = new ML.SubCategoria();  
                producto.SubCategoria.IdSubCategoria = Convert.ToInt32(valores[4]); 
                result = BL.Producto.Add(producto); 
                linea = txt.ReadLine(); 
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
                
                Console.WriteLine("Error al convertir la imagen: " + ex.Message);
            }

            return imagenBytes;
        }



    }
}
