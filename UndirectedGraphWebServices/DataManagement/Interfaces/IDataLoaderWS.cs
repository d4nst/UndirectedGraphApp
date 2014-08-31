using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace UndirectedGraphWebServices.DataManagement.Interfaces
{
    [ServiceContract]
    public interface IDataLoaderWS
    {
        [OperationContract]
        bool DataLoadXml(string path, out string error);
    }
}
