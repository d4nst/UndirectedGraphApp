using System;
using UndirectedGraphEntity;
using System.Collections.Generic;

namespace UndirectedGraphRepository.Interfaces
{
    public interface IGraphNodeRepository
    {
        List<GraphNode> FindAllNodes();

        GraphNode FindNode(string id);

        void AddNode(GraphNode node);

        void UpdateNode(GraphNode node);

        void DeleteAllNodes();

        void Save();
    }
}
