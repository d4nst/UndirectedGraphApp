using System;
using UndirectedGraphEntity;

namespace UndirectedGraphDataLoader
{
    public interface INodeParser
    {
        GraphNode NodeFiletoNodeEntity(string path);
    }
}
