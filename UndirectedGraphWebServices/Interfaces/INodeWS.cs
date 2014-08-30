using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using UndirectedGraphEntity;
using System.Collections;

namespace UndirectedGraphWebServices
{
    [ServiceContract(Namespace = "WS")]
    public interface INodeWS    
    {
        [OperationContract]
        GraphNode FindNode(string id);

        [OperationContract]
        List<GraphNode> FindAllNodes();

        [OperationContract]
        List<GraphEdge> FindAllEdges();

    }
}