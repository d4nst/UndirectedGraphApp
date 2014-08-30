﻿using System;
using System.Collections.Generic;
using UndirectedGraphEntity;

namespace UndirectedGraphService
{
    public interface IPathFinderService
    {
       List<GraphNode> ShortestPath(string rootNodeId, string targetNodeId);
    }
}
