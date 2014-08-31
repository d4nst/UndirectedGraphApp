using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository;
using UndirectedGraphRepository.Interfaces;
using UndirectedGraphService.DomainSpecific;
using UndirectedGraphService.DomainSpecific.Interfaces;
using UndirectedGraphWebServices.DomainSpecific.Interfaces;

namespace UndirectedGraphWebServices.DomainSpecific
{
    public class PathFinderWS : IPathFinderWS
    {

        #region Private Members

        private IPathFinderService _pathFinderService;

        private IUnitOfWork _unitOfWork;

        #endregion

        #region Class Constructor

        public PathFinderWS()
        {
            _unitOfWork = new UnitOfWork();

            _pathFinderService = new PathFinderService(_unitOfWork);
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
            try
            {
                return _pathFinderService.ShortestPath(rootNodeId, targetNodeId);
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}
