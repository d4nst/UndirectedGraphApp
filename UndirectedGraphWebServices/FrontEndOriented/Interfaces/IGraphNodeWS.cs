using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using UndirectedGraphEntity;

namespace UndirectedGraphWebServices.FrontEndOriented.Interfaces
{
    [ServiceContract(Namespace = "WS")]
    public interface IGraphNodeWS
    {
        [OperationContract]
        List<GraphNode> FindAllNodes();
    }
}
