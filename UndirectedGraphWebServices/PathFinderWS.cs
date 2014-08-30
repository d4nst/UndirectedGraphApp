using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphService;
using UndirectedGraphEntity;

namespace UndirectedGraphWebServices
{
    public class PathFinderWS : IPathFinderWS
    {
        #region Private Members

        private IPathFinderService _pathFinderService;

        #endregion

        #region Class Constructor

        public PathFinderWS()
        {
            _pathFinderService = new PathFinderService();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns a single shortest path between a root node and a target node 
        /// using the Breadth-first search algorithm
        /// </summary>
        /// <param name="rootNodeId">Root node ID</param>
        /// <param name="targetNodeId">Target node ID</param>
        /// <returns>List with all the nodes within the shortest path</returns>
        public List<GraphNode> ShortestPath(string rootNodeId, string targetNodeId)
        {
            return _pathFinderService.ShortestPath(rootNodeId, targetNodeId);
        }

        #endregion
    }
}
