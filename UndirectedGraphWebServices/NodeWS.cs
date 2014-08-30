using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UndirectedGraphService;
using UndirectedGraphEntity;
using System.Collections;


namespace UndirectedGraphWebServices
{
    public class NodeWS : INodeWS
    {
        #region Private Members

        private INodeService _nodeService;

        #endregion

        #region Class Constructor

        public NodeWS()
        {
            _nodeService = new NodeService();
        }

        #endregion

        #region Public Methods

        public GraphNode FindNode(string id)
        {
            return _nodeService.FindNode(id);
        }

        public List<GraphNode> FindAllNodes()
        {
           return _nodeService.FindAllNodes();
        }

        public List<GraphEdge> FindAllEdges()
        {
            return _nodeService.FindAllEdges();
        }

        #endregion



    }
}
