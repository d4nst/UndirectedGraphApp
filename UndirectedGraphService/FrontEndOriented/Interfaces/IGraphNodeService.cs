using System;
using System.Collections.Generic;
using UndirectedGraphEntity; 

namespace UndirectedGraphService.FrontEndOriented.Interfaces
{
    public interface IGraphNodeService
    {
        List<GraphNode> FindAllNodes();
    }
}
