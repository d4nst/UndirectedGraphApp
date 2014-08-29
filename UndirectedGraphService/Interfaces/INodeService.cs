using System;
using System.Collections;
using System.Collections.Generic;
using UndirectedGraphEntity;

namespace UndirectedGraphService
{
    public interface INodeService
    {
        GraphNode FindNode(string id);

        List<GraphNode> FindAllNodes();

        List<GraphEdge> FindAllEdges();

    }
}
