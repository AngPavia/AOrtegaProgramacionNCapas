using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var query = context.Categorias.ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();
                            categoria.IdCategoria = row.IdCategoria;
                            categoria.Nombre = row.Nombre;
                            result.Objects.Add(categoria);
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
    }
}
