using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(byte IdMunicipio)
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.ColoniaGetByIdMunicipio(IdMunicipio).ToList();
                if (query.Count > 0)
                {
                    result.Objects = new List<object>();


                    foreach (var fila in query)
                    {
                        ML.Colonia colonia = new ML.Colonia();
                        colonia.IdColonia = fila.IdColonia;
                        colonia.Nombre = fila.Nombre;
                       //colonia.Municipio = new ML.Municipio();
                       //colonia.Municipio.IdMunicipio = fila.IdMunicipio.Value;
                        result.Objects.Add(colonia);
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
