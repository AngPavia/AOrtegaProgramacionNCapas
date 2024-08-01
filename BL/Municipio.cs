using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {

        public static ML.Result GetByIdEstado(byte IdEstado)
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.MunicipioGetByIdEstado(IdEstado).ToList();
                if (query.Count > 0)
                {
                    result.Objects = new List<object>();


                    foreach (var fila in query)
                    {
                        ML.Municipio municipio = new ML.Municipio();
                        municipio.IdMunicipio = fila.IdMunicipio;
                        municipio.Nombre = fila.Nombre;
                        municipio.Estado = new ML.Estado();
                        municipio.Estado.IdEstado = fila.IdEstado.Value;
                        result.Objects.Add(municipio);
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
