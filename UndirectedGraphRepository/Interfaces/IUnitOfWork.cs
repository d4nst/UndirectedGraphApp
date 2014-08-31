using System;


namespace UndirectedGraphRepository.Interfaces
{
    public interface IUnitOfWork
    {
        IGraphEdgeRepository GraphEdgeRepository { get; }

        IGraphNodeRepository GraphNodeRepository { get; }

        void Save();
    }
}
