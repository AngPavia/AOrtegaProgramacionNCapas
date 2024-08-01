using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el Nombre de Usuario")]
        public string NombreDeUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese el email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el Email no es válido")]
        public string Email {  get; set; }
        public string Area {  get; set; }
        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string Password { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ingrese el Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Ingrese el Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Ingrese el Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Ingrese un Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Ingrese número Celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Ingrese la fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese el CURP")]
        public string Curp { get; set; }
        public string Imagen {  get; set; }
        public bool Status { get; set; }    
        public string IdAspNet { get; set; }    
      


           

        public ML.Rol Rol { get; set; }
        public ML.Estado Estado { get; set; }
        public ML.Direccion Direccion { get; set; }
        public List<object> Usuarios { get; set; }  

    }
}
