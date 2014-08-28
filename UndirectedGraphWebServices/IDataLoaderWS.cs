using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UndirectedGraphWebServices
{
    [ServiceContract(Namespace = "AjaxService")]
    public interface IDataLoaderWS
    {

        [OperationContract]
        bool DataLoadXml(string path);

    }

}
