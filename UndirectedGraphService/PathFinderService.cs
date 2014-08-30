using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository;

namespace UndirectedGraphService
{
    public class PathFinderService : IPathFinderService
    {
        #region Private Members

        private INodeDao _nodeDao;

        private class GraphNodeAndPrevious
        {
            public GraphNode currentNode;
            public GraphNode previousNode;
        }

        #endregion

        #region Class Constructor

        public PathFinderService()
        {
            _nodeDao = new NodeDao();
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
            var graph = _nodeDao.FindAllNodes();

            var nodeQueue = new Queue<GraphNode>(); // A queue with the nodes to be examinated in each step
            var nodeAndPreviousList = new List<GraphNodeAndPrevious>(); // A set with the already examinated nodes the nodes examinated before them

            var rootNode = graph.Find(n => n.ID == rootNodeId);
            var targetNode = graph.Find(n => n.ID == targetNodeId);

            // Initialize queue with the root node
            nodeQueue.Enqueue(rootNode);

            // Initialize set with the root node as current node and null as previous node
            nodeAndPreviousList.Add(new GraphNodeAndPrevious() { 
                currentNode = rootNode,
                previousNode = null
            });

            while (nodeQueue.Count != 0)
            {
                var currentNode = nodeQueue.Dequeue();

                if (currentNode == targetNode)
                {
                    break;
                }

                var currentNodeEdges = _nodeDao.FindAllNodeEdges(currentNode.ID);

                foreach (var edge in currentNodeEdges)
                {
                    GraphNode relatedNode = null;

                    if (edge.RelatedID != currentNode.ID)
                    {
                        relatedNode = graph.Find(n => n.ID == edge.RelatedID);
                    }
                    else
                    {
                        relatedNode = graph.Find(n => n.ID == edge.ID);
                    }

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

            var node = nodeAndPreviousList.Find(n => n.currentNode.ID == targetNodeId);
            var shortestPathList = new List<GraphNode>();
            
            if (node != null)
            {
                TraverseGraphNodeAndPreviousSet(nodeAndPreviousList, node, ref shortestPathList);
                shortestPathList.Reverse();
                shortestPathList.RemoveAt(0);
            }

            return shortestPathList;
        }

        #endregion

        #region Private Methods

        private void TraverseGraphNodeAndPreviousSet(List<GraphNodeAndPrevious> nodeAndPreviousList, GraphNodeAndPrevious node, ref List<GraphNode> shortestPathList)
        {

            if (node.previousNode != null)
            {
                shortestPathList.Add(node.previousNode);
                node = nodeAndPreviousList.Find(n => n.currentNode.ID == node.previousNode.ID);
                TraverseGraphNodeAndPreviousSet(nodeAndPreviousList, node, ref shortestPathList);
            }

        }
        
        #endregion

    }
}
