using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphDAO;
using UndirectedGraphEntity;

namespace UndirectedGraphService
{
    public class NodeService : INodeService
    {
        #region Private Members

        private INodeDao _nodeDao;

        #endregion

        #region Class Constructor

        public NodeService()
        {
            _nodeDao = new NodeDao();
        }

        #endregion

        #region Public Methods

        public GraphNode FindNode(string id)
        {
            return _nodeDao.FindNode(id);
        }

        public List<GraphNode> FindAllNodes()
        {
            return _nodeDao.FindAllNodes();
        }

        public List<GraphEdge> FindAllEdges()
        {
            return _nodeDao.FindAllEdges();
        }

        #endregion
    }
}
