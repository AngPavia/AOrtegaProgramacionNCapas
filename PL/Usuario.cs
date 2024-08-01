using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese su Nombre de Usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el IdRol");
            usuario.Rol = new Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese su Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese su Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese su Fecha de Nacimiento");
           // usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su CURP");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();



            ML.Result result = BL.Usuario.AddEFLinq(usuario);
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
        public static void AddSP()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese su Nombre de Usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el IdRol");
            usuario.Rol = new Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese su Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese su Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese su Fecha de Nacimiento");
           // usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su CURP");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            //BL.Usuario.Add(usuario);


            ML.Result result = BL.Usuario.AddSP(usuario);
            if (result.Correct == true)
            {
                Console.WriteLine("Se insertó el registro, STORED PROCEDURE");
            }
            else
            {
                Console.WriteLine("No se insertó el registro, STORED PROCEDURE " + result.ErrorMessage);
            }
            Console.ReadKey();


        }
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            
            Console.WriteLine("Ingrese el ID a borrar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            
            ML.Result result = BL.Usuario.DeleteEFLinq(usuario);

            if (result.Correct == true)
            {
                Console.WriteLine("se borró el registro");
            }
            else
            {
                Console.WriteLine("No se borró el registro " + result.ErrorMessage);
            }
            Console.ReadKey();


        }
        public static void DeleteSP()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el ID a borrar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.DeleteEFLinq(usuario);

            if (result.Correct == true)
            {
                Console.WriteLine("se borró el registro, STORED PROCEDURE");
            }
            else
            {
                Console.WriteLine("No se borró el registro STORED " + result.ErrorMessage);
            }
            Console.ReadKey();


        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el ID del Usuario que quiere modificar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su Nombre de Usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el IdRol");
            usuario.Rol = new Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese su Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese su Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese su Fecha de Nacimiento");
            //usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su CURP");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            ML.Result result = BL.Usuario.UpdateEFLinq(usuario);
            if (result.Correct == true)
            {
                Console.WriteLine("se actualizó el registro");
            }
            else
            {
                Console.WriteLine("No se actualizó el registro " + result.ErrorMessage);
            }
            Console.ReadKey();

           //BL.Usuario.Update(usuario);
        }
        public static void UpdateSP()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el ID del Usuario que quiere modificar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese su Nombre de Usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese su Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese su Email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el IdRol");
            usuario.Rol = new Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su Apellido Paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese su Sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese su Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese su Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese su Fecha de Nacimiento");
          //  usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese su CURP");
            usuario.Curp = Console.ReadLine();

            Console.WriteLine("Ingrese su Apellido Materno");
            usuario.ApellidoMaterno = Console.ReadLine();


            ML.Result result = BL.Usuario.UpdateEF(usuario);
            if (result.Correct == true)
            {
                Console.WriteLine("se actualizó el registro, STORED PROCEDURE");
            }
            else
            {
                Console.WriteLine("No se actualizó el registro, STORED PROCEDURE " + result.ErrorMessage);
            }
            Console.ReadKey();

        }

        //public static void GetAll()
        //{
            
        //    ML.Result result = BL.Usuario.GetAllEF();
        //    if (result.Correct)
        //    {
        //        foreach (ML.Usuario usuario in result.Objects)
        //        {
                   
        //            Console.WriteLine("ID:" + usuario.IdUsuario);
        //            Console.WriteLine("Nombre de Usuario:" + usuario.UserName);
        //            Console.WriteLine("Nombre:" + usuario.Nombre);
        //            Console.WriteLine("Apellido Paterno:" + usuario.ApellidoPaterno);
        //            Console.WriteLine("Apellido Materno:" + usuario.ApellidoPaterno);
        //            Console.WriteLine("EMail:" + usuario.Email);
        //            Console.WriteLine("Contraseña:" + usuario.Password);
        //            Console.WriteLine("IdRol:" + usuario.Rol.IdRol);
        //            Console.WriteLine("Rol:" + usuario.Rol.Nombre);
        //            Console.WriteLine("Sexo:" + usuario.Sexo);
        //            Console.WriteLine("Telefono:" + usuario.Telefono);
        //            Console.WriteLine("Celular:" + usuario.Celular);
        //            Console.WriteLine("Fecha de Nacimiento:" + usuario.FechaNacimiento);
        //            Console.WriteLine("CURP:" + usuario.Curp);
                    

        //            Console.WriteLine("/////////////////////////////////////////////////");

        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se puede consultar " + result.ErrorMessage);
        //    }
        //    Console.ReadKey();


        //}



        public static void RolGetAll()
        {

            ML.Result result = BL.Usuario.RollGetAll();
            if (result.Correct)
            {
                foreach (ML.Rol rol in result.Objects)
                {

                    Console.WriteLine("ID:" + rol.IdRol);
                    Console.WriteLine("Nombre:" + rol.Nombre);
                    Console.WriteLine("/////////////////////////////////////////////////");
                }
            }
            else
            {
                Console.WriteLine("No se puede consultar " + result.ErrorMessage);
            }
            Console.ReadKey();


        }




        public static void GetById()
        {
            Console.WriteLine("Escriba el Id del Usuario");
            int IdUsuario = int.Parse(Console.ReadLine());
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                Console.WriteLine("ID:" + usuario.IdUsuario);
                Console.WriteLine("Nombre de Usuario:" + usuario.UserName);
                Console.WriteLine("Nombre:" + usuario.Nombre);
                Console.WriteLine("Apellido Paterno:" + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno:" + usuario.ApellidoPaterno);
                Console.WriteLine("EMail:" + usuario.Email);
                Console.WriteLine("Contraseña:" + usuario.Password);
                Console.WriteLine("IdRol:" + usuario.Rol.IdRol);
                Console.WriteLine("Rol:" + usuario.Rol.Nombre);
                Console.WriteLine("Sexo:" + usuario.Sexo);
                Console.WriteLine("Telefono:" + usuario.Telefono);
                Console.WriteLine("Celular:" + usuario.Celular);
                Console.WriteLine("Fecha de Nacimiento:" + usuario.FechaNacimiento);
                Console.WriteLine("CURP:" + usuario.Curp);

            }
            else
            {
                Console.WriteLine("No se puede consultar");
            }
            Console.ReadKey();
        }


    }
}
