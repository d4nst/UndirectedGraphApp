using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository;
using UndirectedGraphRepository.Interfaces;
using UndirectedGraphService.DataManagement.Interfaces;

namespace UndirectedGraphService.DataManagement
{
    public class DataLoaderService : IDataLoaderService
    {

        #region Private Members

        private IGraphNodeParser _nodeParser;

        private IUnitOfWork _unitOfWork;

        #endregion


        #region Class Constructor

        public DataLoaderService(IGraphNodeParser nodeParser, IUnitOfWork unitOfWork)
        {
            _nodeParser = nodeParser;

            _unitOfWork = unitOfWork;
        }

        #endregion  


        #region Public Methods

        /// <summary>
        /// Adds the file in the given path to the database
        /// </summary>
        /// <param name="filePath"></param>
        public void NodeFileToDatabase(string filePath)
        {

            // parse graph node from file
            var graphNode = _nodeParser.NodeFileToNodeEntity(filePath);

            var existingNode = _unitOfWork.GraphNodeRepository.FindNode(graphNode.ID);

            if (existingNode != null)
            {
                existingNode.Label = graphNode.Label;
                _unitOfWork.GraphNodeRepository.UpdateNode(existingNode);

                CreateGraphEdges(graphNode);

            }
            else
            {
                _unitOfWork.GraphNodeRepository.AddNode(new GraphNode
                {
                    ID = graphNode.ID,
                    Label = graphNode.Label
                });

                CreateGraphEdges(graphNode);


            }

            _unitOfWork.Save();

        }


        /// <summary>
        /// Clears all the data in the database and
        /// adds all the files under the given path to the database
        /// </summary>
        /// <param name="directoryPath">Directory path</param>
        public void NodeDirectoryToDatabase(string directoryPath)
        {

            ClearDatabase();

            string[] files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                NodeFileToDatabase(file);
            }

        }

        #endregion


        #region Private Methods

        /// <summary>
        ///  Clears all the data in the database
        /// </summary>
        private void ClearDatabase()
        {
            _unitOfWork.GraphNodeRepository.DeleteAllNodes();

            _unitOfWork.GraphEdgeRepository.DeleteAllEdges();

            _unitOfWork.Save();
        }


        /// <summary>
        /// Creates all the edges for the given node.
        /// If a related node doesn't exists, it creates a new node
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="graphNode"></param>
        private void CreateGraphEdges(GraphNode graphNode)
        {
            foreach (var graphEdge in graphNode.GraphEdges)
            {
                var existingRelatedNode = _unitOfWork.GraphNodeRepository.FindNode(graphEdge.RelatedID);

                if (existingRelatedNode == null)
                {
                    _unitOfWork.GraphNodeRepository.AddNode(new GraphNode
                    {
                        ID = graphEdge.RelatedID,
                    });
                }

                var existingEdge = _unitOfWork.GraphEdgeRepository.FindEdge(graphEdge.ID, graphEdge.RelatedID);

                if (existingEdge != null)
                {
                    existingEdge.RelatedID = graphEdge.RelatedID;
                    _unitOfWork.GraphEdgeRepository.UpdateEdge(existingEdge);
                }
                else
                {
                    _unitOfWork.GraphEdgeRepository.AddEdge(new GraphEdge
                    {
                        ID = graphEdge.ID,
                        RelatedID = graphEdge.RelatedID
                    });
                }

            }
        }

        #endregion

    }
}


