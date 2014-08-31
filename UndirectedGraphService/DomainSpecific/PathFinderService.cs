using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository;
using UndirectedGraphRepository.Interfaces;
using UndirectedGraphService.DomainSpecific.Interfaces;

namespace UndirectedGraphService.DomainSpecific
{
    public class PathFinderService : IPathFinderService
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;

        private class GraphNodeAndPrevious
        {
            public GraphNode currentNode;
            public GraphNode previousNode;
        }

        #endregion

        #region Class Constructor

        public PathFinderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var graph = _unitOfWork.GraphNodeRepository.FindAllNodes();

            var nodeQueue = new Queue<GraphNode>(); // A queue with the nodes to be examinated
            var nodeAndPreviousList = new List<GraphNodeAndPrevious>(); // A list with all the examinated nodes and the nodes examinated before them

            var rootNode = graph.Find(n => n.ID == rootNodeId);
            var targetNode = graph.Find(n => n.ID == targetNodeId);

            // Enqueue the root node
            nodeQueue.Enqueue(rootNode);

            // Initialize the list with the root node as current node and null as previous node
            nodeAndPreviousList.Add(new GraphNodeAndPrevious()
            {
                currentNode = rootNode,
                previousNode = null
            });

            // While there are nodes to examinate
            while (nodeQueue.Count != 0)
            {
                // Dequeue a node and examine it
                var currentNode = nodeQueue.Dequeue();

                // Finish the search if the current node is the target node
                if (currentNode == targetNode)
                {
                    break;
                }

                // Find all edges (in both directions)
                var currentNodeEdges = _unitOfWork.GraphEdgeRepository.FindAllEdgesByNodeId(currentNode.ID);

                foreach (var edge in currentNodeEdges)
                {
                    GraphNode relatedNode = null;

                    // Take related node regardless the edge direction
                    if (edge.RelatedID != currentNode.ID)
                    {
                        relatedNode = graph.Find(n => n.ID == edge.RelatedID);
                    }
                    else
                    {
                        relatedNode = graph.Find(n => n.ID == edge.ID);
                    }

                    // If the related node hasn't be examinated yet, we add it to the queue and the list
                    if (!nodeAndPreviousList.Any(n => n.currentNode == relatedNode))
                    {
                        nodeAndPreviousList.Add(new GraphNodeAndPrevious()
                        {
                            currentNode = relatedNode,
                            previousNode = currentNode
                        });

                        nodeQueue.Enqueue(relatedNode);
                    }
                }
            }


            var shortestPathList = new List<GraphNode>();
            var nodeAndPrevious = nodeAndPreviousList.Find(n => n.currentNode.ID == targetNodeId);

            // If the node has been found, traverse the list to add the found nodes to the output list
            if (nodeAndPrevious != null)
            {
                TraverseGraphNodeAndPreviousList(nodeAndPreviousList, nodeAndPrevious, ref shortestPathList);
                // Add the root node to the list and reverse it
                shortestPathList.Reverse();
                shortestPathList.Add(targetNode);
            }

            return shortestPathList;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This recursive method traverse a list that contains examinated nodes and
        /// nodes examinated before them, taking the target node as a start and ending when the root node is found.
        /// </summary>
        /// <param name="nodeAndPreviousList">List that contains the examinated nodes and the nodes examinated before them</param>
        /// <param name="nodeAndPrevious">Current traversed node</param>
        /// <param name="shortestPathList">Output list</param>
        private void TraverseGraphNodeAndPreviousList(List<GraphNodeAndPrevious> nodeAndPreviousList, GraphNodeAndPrevious nodeAndPrevious, ref List<GraphNode> shortestPathList)
        {

            if (nodeAndPrevious.previousNode != null)
            {
                shortestPathList.Add(nodeAndPrevious.previousNode);
                nodeAndPrevious = nodeAndPreviousList.Find(n => n.currentNode.ID == nodeAndPrevious.previousNode.ID);
                TraverseGraphNodeAndPreviousList(nodeAndPreviousList, nodeAndPrevious, ref shortestPathList);
            }

        }

        #endregion

    }
}
