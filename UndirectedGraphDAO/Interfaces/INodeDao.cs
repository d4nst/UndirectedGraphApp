using System;
using System.Collections.Generic;
using UndirectedGraphEntity;

namespace UndirectedGraphDAO
{
    public interface INodeDao
    {
        GraphNode FindNode(string id);
        List<GraphNode> FindAllNodes();

    }
}
