using System;
using System.Collections;
using System.Collections.Generic;
using UndirectedGraphEntity;

namespace UndirectedGraphRepository
{
    public interface INodeDao
    {
        GraphNode FindNode(string id);

        List<GraphNode> FindAllNodes();

        List<GraphEdge> FindAllNodeEdges(string id);

        List<GraphEdge> FindAllEdges();

    }
}
