using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISemestre" in both code and config file together.
    [ServiceContract]
    public interface ISemestre
    {
        [OperationContract]
        SL.Result Add(string nombre);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Semestre))]
        SL.Result GetAll();

    }
}
