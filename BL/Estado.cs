using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.EstadoGetAll().ToList();
                if (query.Count > 0)
                {
                    result.Objects = new List<object>();


                    foreach (var fila in query)
                    {
                        ML.Estado estado = new ML.Estado();
                        estado.IdEstado = fila.IdEstado;
                        estado.Nombre = fila.Nombre;
                        result.Objects.Add(estado);
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
