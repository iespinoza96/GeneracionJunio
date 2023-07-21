using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Semestre" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Semestre.svc or Semestre.svc.cs at the Solution Explorer and start debugging.
    public class Semestre : ISemestre
    {
        //public ML.Result Add(string nombre)
        //{
        //    ML.Result result = BL.Semestre.Add(nombre);

        //    return result;
        //}

        public SL.Result Add(string nombre)
        {
            ML.Result result = BL.Semestre.Add(nombre);

            return new SL.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }

        public SL.Result GetAll()
        {
            ML.Result result = BL.Semestre.GetAll();
            return new SL.Result { Correct = result.Correct, Ex = result.Ex, Message = result.Message, Object = result.Object, Objects = result.Objects };
        }

    }
}
