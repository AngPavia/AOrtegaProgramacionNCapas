using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.RolGetAll().ToList();
                if (query.Count > 0)
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


    }
}
