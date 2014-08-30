using System;
using UndirectedGraphEntity;

namespace UndirectedGraphRepository
{
    public interface INodeParser
    {
        GraphNode NodeFiletoNodeEntity(string path);
    }
}
