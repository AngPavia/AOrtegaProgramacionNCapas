using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Menu");
            //Console.WriteLine("1. Insertar registro");
            //Console.WriteLine("2. Eliminar un registro");
            //Console.WriteLine("3. Actualizar registro");
            //Console.WriteLine("4. Mostrar todos los registros");
            //Console.WriteLine("5. Mostrar solo un registro");
            //Console.WriteLine("/// ELEGIR OPCION ///");
            //byte opcion = byte.Parse(Console.ReadLine());
            //switch (opcion)
            //{
            //    case 1:
            //        PL.Producto.CargaMasivaTXT();
            //        break;

            //    case 2:
            //        PL.Usuario.DeleteSP();
            //        break;
            //    case 3:
            //        PL.Usuario.UpdateSP();
            //        break;
            //    case 4:
            //        //PL.Usuario.GetAll();
            //        PL.Usuario.RolGetAll();
            //        break;
            //    case 5:
            //        PL.Usuario.GetById();
            //        break;

            //}
            //PL.Usuario.Add();
            //PL.Usuario.Delete();
            //PL.Usuario.Update();
            //PL.Usuario.AddSP();
            //PL.Usuario.DeleteSP();
            //PL.Usuario.UpdateSP();
            //PL.Usuario.GetAll();
            //PL.Usuario.GetById();
            ML.Result result = PL.Producto.CargaMasivaTXT();
            if (result.Correct == true)
            {
                Console.WriteLine("Se insertó el registro");
            }
            else
            {
                Console.WriteLine("No se insertó el registro " + result.ErrorMessage);
            }
            Console.ReadKey();

        }
    }
}
