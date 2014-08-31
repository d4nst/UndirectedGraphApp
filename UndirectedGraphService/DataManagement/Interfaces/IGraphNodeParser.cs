using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;

namespace UndirectedGraphService.DataManagement.Interfaces
{
    public interface IGraphNodeParser
    {
        GraphNode NodeFileToNodeEntity(string path);
    }
}


