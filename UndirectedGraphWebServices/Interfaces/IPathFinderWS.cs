using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Collections.Generic;
using UndirectedGraphEntity;


namespace UndirectedGraphWebServices
{
    [ServiceContract(Namespace = "WS")]
    public interface IPathFinderWS
    {
        [OperationContract]
        List<GraphNode> ShortestPath(string rootNodeId, string targetNodeId);
    }
}
