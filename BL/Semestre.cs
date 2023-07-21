using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Semestre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    var query = context.SemestreGetAll().ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var semestreList in query)
                        {
                            ML.Semestre semestre = new ML.Semestre();

                            semestre.IdSemestre = semestreList.IdSemestre;
                            semestre.Nombre = semestreList.Nombre;

                            result.Objects.Add(semestre);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
                
            }
           return result;
        }

        public static ML.Result Add(string semestreNombre)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    int queryResult = context.SemestreAdd(semestreNombre);

                    if (queryResult > 0)
                    {
                        result.Correct = true;
                    }
                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al intentar registrar" + result.Ex;
            }

            return result;

        }
    }
}
