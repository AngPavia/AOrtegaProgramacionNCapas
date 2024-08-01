using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubCategoria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
                {
                    var query = context.SubCategorias.ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var row in query)
                        {
                            ML.SubCategoria subcategoria = new ML.SubCategoria();
                            subcategoria.IdSubCategoria = row.IdSubCategoria;
                            subcategoria.Nombre = row.Nombre;
                            result.Objects.Add(subcategoria);
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
        public static ML.Result GetByIdCategoria(int idCategoria)
        {
            ML.Result result = new ML.Result();
            using (DLEF.AOrtegaProgramacionNCapasEntities context = new DLEF.AOrtegaProgramacionNCapasEntities())
            {
                var query = context.SubCategorias.ToList().Where(u => u.IdCategoria == idCategoria);
                if (query != null)
                {
                    result.Objects = new List<object>();


                    foreach (var fila in query)
                    {
                        ML.SubCategoria subcategoria = new ML.SubCategoria();
                      
                        subcategoria.IdSubCategoria = fila.IdSubCategoria;
                        subcategoria.Nombre = fila.Nombre;
                        result.Objects.Add(subcategoria);
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
