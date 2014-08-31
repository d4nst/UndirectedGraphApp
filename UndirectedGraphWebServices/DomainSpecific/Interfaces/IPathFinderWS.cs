using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using UndirectedGraphEntity;

namespace UndirectedGraphWebServices.DomainSpecific.Interfaces
{
    [ServiceContract(Namespace = "WS")]
    public interface IPathFinderWS
    {
        [OperationContract]
        List<GraphNode> ShortestPath(string rootNodeId, string targetNodeId);
    }
}

