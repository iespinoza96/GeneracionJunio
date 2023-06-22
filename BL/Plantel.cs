using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LEscogidoProgramacionNCapasGJEntities context = new DL_EF.LEscogidoProgramacionNCapasGJEntities())
                {
                    var query = context.PlantelGetAll().ToList();

                    if(query.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach(var rowPlantel in query)
                        {
                            ML.Plantel plantel = new ML.Plantel();

                            plantel.IdPlantel = rowPlantel.IdPlantel;
                            plantel.Nombre = rowPlantel.Nombre;

                            result.Objects.Add(plantel);
                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta "+ex.Message;
                throw;
            }
            return result;
        }
    }
}
