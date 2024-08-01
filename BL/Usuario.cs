using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ML;
using System.Xml;
using DL;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;
using DLEF;
using System.Security.Cryptography.X509Certificates;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(UserName, Nombre, Email, Password, IdRol, ApellidoPaterno, Sexo, Telefono, Celular, FechaNacimiento, Curp, ApellidoMaterno) VALUES (@UserName, @Nombre, @Email, @Password, @IdRol, @ApellidoPaterno, @Sexo, @Telefono, @Celular, @FechaNacimiento, @Curp, @ApellidoMaterno) ", Conexion);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Curp", usuario.Curp);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    Conexion.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
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
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("UsuarioAdd", Conexion);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Curp", usuario.Curp);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.CommandType = CommandType.StoredProcedure;
                    Conexion.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
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


        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {

                    var RowsAffected = context.UsuarioAdd(usuario.UserName, usuario.Nombre, usuario.Email, usuario.Password, usuario.Rol.IdRol, usuario.ApellidoPaterno, usuario.Sexo, usuario.Telefono, usuario.Celular, DateTime.Parse(usuario.FechaNacimiento), usuario.Curp, usuario.ApellidoMaterno, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, usuario.Imagen, usuario.IdAspNet);
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


        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario", Conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);
                    Conexion.Open();
                  
                    int RowsAffected = cmd.ExecuteNonQuery();
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

        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("UsuarioDelete", Conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    Conexion.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
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

        public static ML.Result DeleteEF(ML.Usuario usuario, ML.Direccion direccion)
        {
            ;
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    
                    int RowsAffected = context.UsuarioDelete(usuario.IdUsuario, direccion.IdDireccion);
                    context.SaveChanges();

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




        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Usuario SET UserName=@UserName, Nombre=@Nombre, Email=@Email, Password=@Password, IdRol=@IdRol, ApellidoPaterno=@ApellidoPaterno, \r\nSexo=@Sexo, Telefono=@Telefono, Celular=@Celular, FechaNacimiento=@FechaNacimiento, Curp=@Curp, ApellidoMaterno=@ApellidoMaterno WHERE IdUsuario=@IdUsuario", Conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Curp", usuario.Curp);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    Conexion.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
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

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("UsuarioUpdate", Conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Curp", usuario.Curp);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.CommandType = CommandType.StoredProcedure;
                    Conexion.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    
                    int RowsAffected = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.Email, usuario.Password, usuario.Rol.IdRol, usuario.ApellidoPaterno, usuario.Sexo, usuario.Telefono, usuario.Celular, DateTime.Parse(usuario.FechaNacimiento), usuario.Curp, usuario.ApellidoMaterno, usuario.Direccion.IdDireccion, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

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


        public static ML.Result UpdateStatus(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {

                    int RowsAffected = context.UsuarioUpdateStatus(usuario.IdUsuario, usuario.Status);

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





        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "UsuarioGetAll";
                    SqlCommand cmd = new SqlCommand(query, Conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable TableUsuario = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(TableUsuario);
                    if (TableUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow fila in TableUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(fila[0].ToString());
                            usuario.UserName = fila[1].ToString();
                            usuario.Nombre = fila[2].ToString();
                            usuario.Email = fila[3].ToString();
                            usuario.Password = fila[4].ToString();
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(fila[5].ToString());
                            usuario.ApellidoPaterno = fila[6].ToString();   
                            usuario.Sexo = fila[7].ToString();  
                            usuario.Telefono = fila[8].ToString();  
                            usuario.Celular = fila[9].ToString();
                          //  usuario.FechaNacimiento = DateTime.Parse(fila[10].ToString());  
                            usuario.Curp = fila[11].ToString();
                            usuario.ApellidoMaterno = fila[12].ToString();  
                            
                            result.Objects.Add(usuario);

                        }
                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            
            return result;

        }
        

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Rol.IdRol).ToList();
                if (query.Count > 0)
                {
                    result.Objects = new List<object>();//ESPECIFICAR QUE LOS VALORES SE TIENE QUE GUARDAR EN UNA LISTA

                    foreach (var fila in query)

                    {
                        usuario = new ML.Usuario();//INSTANCIAR LAS PROPIEDADES
                        usuario.IdUsuario = fila.IdUsuario;
                        usuario.UserName = fila.UserName;
                        usuario.Nombre = fila.Nombre;
                        usuario.Email = fila.Email;
                        usuario.Password = fila.Password;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = fila.IdRol.Value;
                        usuario.Rol.Nombre = fila.NombreRol;
                        usuario.ApellidoPaterno = fila.ApellidoPaterno;
                        usuario.Sexo = fila.Sexo;
                        usuario.Telefono = fila.Telefono;
                        usuario.Celular = fila.Celular;
                        usuario.FechaNacimiento = fila.FechaNacimiento.ToString();
                        usuario.Curp = fila.Curp;
                        usuario.ApellidoMaterno = fila.ApellidoMaterno;
                        usuario.Status = fila.Status.Value;
                        usuario.Rol.Nombre = fila.NombreRol;
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = fila.IdDireccion.Value;
                        usuario.Direccion.Calle = fila.Calle;
                        usuario.Direccion.NumeroExterior = fila.NumeroExterior;
                        usuario.Direccion.NumeroInterior = fila.NumeroInterior;
                       

                        result.Objects.Add(usuario);
                    }
                    result.Correct = true;
                }
                else
                {

                }

            }
            return result;
        }

        public static ML.Result RollGetAll()
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities()) 
            {
               var query = context.RolGetAll().ToList();
                if (query.Count>0)
                {
                    result.Objects = new List<object>();

                  
                    foreach (var fila in query)
                    {
                        ML.Rol rol = new ML.Rol();
                        rol.IdRol = fila.IdRol;
                        rol.Nombre = fila.Nombre;
                        result.Objects.Add(rol);    
                    }
                    result.Correct = true;
                }
                else
                {

                }

            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection Conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "UsuarioGetById";
                    SqlCommand cmd = new SqlCommand(query, Conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    DataTable TableUsuario = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(TableUsuario);
                    if (TableUsuario.Rows.Count > 0)
                    {
                        DataRow fila = TableUsuario.Rows[0];
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = int.Parse(fila[0].ToString());
                        usuario.UserName = fila[1].ToString();
                        usuario.Nombre = fila[2].ToString();
                        usuario.Email = fila[3].ToString();
                        usuario.Password = fila[4].ToString();
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = byte.Parse(fila[5].ToString());
                        usuario.ApellidoPaterno = fila[6].ToString();
                        usuario.Sexo = fila[7].ToString();
                        usuario.Telefono = fila[8].ToString();
                        usuario.Celular = fila[9].ToString();
                       // usuario.FechaNacimiento = DateTime.Parse(fila[10].ToString());
                        usuario.Curp = fila[11].ToString();
                        usuario.ApellidoMaterno = fila[12].ToString();

                        result.Object = usuario;
                        result.Correct = true;
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
        
        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {

                    var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString();
                        usuario.Curp = query.Curp;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                       // usuario.Rol.Nombre = query.Nombre;
                        usuario.Imagen = query.Imagen;
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion.Value;
                        usuario.Direccion.Calle = query.Calle;
                        usuario.Direccion.NumeroInterior = query.NumeroInterior;
                        usuario.Direccion.NumeroExterior = query.NumeroExterior;
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = query.IdColonia.Value;
                        usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado.Value;
                        result.Object = usuario;
                        result.Correct = true;

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

        public static ML.Result AddEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    DLEF.Usuario usuarioEF = new DLEF.Usuario();
                    usuarioEF.UserName = usuario.UserName;
                    usuarioEF.Nombre = usuario.Nombre;
                    usuarioEF.Email = usuario.Email;
                    usuarioEF.Password = usuario.Password;
                    usuarioEF.IdRol = usuario.Rol.IdRol;
                    usuarioEF.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioEF.Sexo = usuario.Sexo;
                    usuarioEF.Telefono = usuario.Telefono;
                    usuarioEF.Celular = usuario.Celular;
                   // usuarioEF.FechaNacimiento = usuario.FechaNacimiento.ToString();
                    usuarioEF.Curp = usuario.Curp;
                    usuarioEF.ApellidoMaterno = usuario.ApellidoMaterno;
                    
                    var RowsAffected = context.Usuarios.Add(usuarioEF);
                    context.SaveChanges();
                    if (RowsAffected != null)
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


        public static ML.Result UpdateEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = (from usuarioEF in context.Usuarios
                                        where usuarioEF.IdUsuario == usuario.IdUsuario
                                        select usuarioEF).FirstOrDefault();
                    context.SaveChanges();
                    if (RowsAffected != null)
                    {
                        RowsAffected.UserName = usuario.UserName;   
                        RowsAffected.Nombre = usuario.Nombre;
                        RowsAffected.Email = usuario.Email;
                        RowsAffected.Password = usuario.Password;
                        RowsAffected.IdRol = usuario.Rol.IdRol;
                        RowsAffected.ApellidoPaterno = usuario.ApellidoPaterno;
                        RowsAffected.Sexo = usuario.Sexo;
                        RowsAffected.Telefono = usuario.Telefono;
                        RowsAffected.Celular = usuario.Celular;
                       // RowsAffected.FechaNacimiento = usuario.FechaNacimiento;
                        RowsAffected.Curp = usuario.Curp;
                        RowsAffected.ApellidoMaterno = usuario.ApellidoMaterno;
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


        public static ML.Result DeleteEFLinq(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = (from usuarioEF in context.Usuarios
                                        where usuarioEF.IdUsuario == usuario.IdUsuario
                                        select usuarioEF).FirstOrDefault();
                    
                    if (RowsAffected != null)
                    {
                      context.Usuarios.Remove(RowsAffected);
                      context.SaveChanges();
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


        public static ML.Result GetAllEFLinq()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var RowsAffected = (from usuarioEF in context.Usuarios
                                        select new
                                        {
                                            usuarioEF.IdUsuario,
                                            usuarioEF.UserName,
                                            usuarioEF.Nombre,
                                            usuarioEF.Email,
                                            usuarioEF.Password,
                                            usuarioEF.IdRol,
                                            usuarioEF.ApellidoPaterno,
                                            usuarioEF.Sexo,
                                            usuarioEF.Telefono,
                                            usuarioEF.Celular,
                                            usuarioEF.FechaNacimiento,
                                            usuarioEF.Curp,
                                            usuarioEF.ApellidoMaterno
                                        }).ToList();

                    if (RowsAffected != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var fila in RowsAffected)

                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = fila.IdUsuario;
                            usuario.UserName = fila.UserName;
                            usuario.Nombre = fila.Nombre;
                            usuario.Email = fila.Email;
                            usuario.Password = fila.Password;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = fila.IdRol.Value;
                            usuario.ApellidoPaterno = fila.ApellidoPaterno;
                            usuario.Sexo = fila.Sexo;
                            usuario.Telefono = fila.Telefono;
                            usuario.Celular = fila.Celular;
                           // usuario.FechaNacimiento = DateTime.Parse(fila.FechaNacimiento.ToString());
                            usuario.Curp = fila.Curp;
                            usuario.ApellidoMaterno = fila.ApellidoMaterno;
                            result.Objects.Add(usuario);
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

        public static ML.Result GetByIdAspNet(string IdAspNet)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {

                    var query = context.UsuarioGetByIdidentity(IdAspNet).FirstOrDefault();
                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = query.IdDireccion.Value;
                        usuario.IdAspNet = query.IdAspNet;  
                        result.Object = usuario;
                        result.Correct = true;

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

        public static ML.Result GetByIdEFLinq(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                ML.Usuario usuario = new ML.Usuario();  
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var query = (from usuarioEF in context.Usuarios
                                        where usuarioEF.IdUsuario == IdUsuario
                                        select new
                                        {
                                            usuarioEF.IdUsuario,
                                            usuarioEF.UserName,
                                            usuarioEF.Nombre,
                                            usuarioEF.Email,
                                            usuarioEF.Password,
                                            usuarioEF.IdRol,
                                            usuarioEF.ApellidoPaterno,
                                            usuarioEF.Sexo,
                                            usuarioEF.Telefono,
                                            usuarioEF.Celular,
                                            usuarioEF.FechaNacimiento,
                                            usuarioEF.Curp,
                                            usuarioEF.ApellidoMaterno
                                        }).FirstOrDefault();
                    result.Object = usuario;
                    result.Correct = true;

                    if (query != null)
                    {

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                       // usuario.FechaNacimiento = DateTime.Parse(query.FechaNacimiento.ToString());
                        usuario.Curp = query.Curp;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        result.Object = usuario;
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
