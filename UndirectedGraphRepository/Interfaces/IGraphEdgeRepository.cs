using System;
using System.Collections.Generic;
using UndirectedGraphEntity;

namespace UndirectedGraphRepository.Interfaces
{
    public interface IGraphEdgeRepository
    {
        List<GraphEdge> FindAllEdgesByNodeId(string id);

        void AddEdge(GraphEdge edge);

        GraphEdge FindEdge(string id, string relatedId);

        void UpdateEdge(GraphEdge edge);

        void DeleteAllEdges();

        void Save();
    }
}
