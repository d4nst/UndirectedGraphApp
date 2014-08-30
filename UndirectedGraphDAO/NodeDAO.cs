using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UndirectedGraphEntity;

namespace UndirectedGraphRepository
{
    public class NodeDao : INodeDao
    {
        #region Private Members

        #endregion

        #region Class Constructor

        #endregion

        #region Public Methods

        public GraphNode FindNode(string id)
        {
            using (var dbContext = new GraphContext())
            {
                return dbContext.GraphNode.Find(id);
            }
        }

        public List<GraphNode> FindAllNodes()
        {
            using (var dbContext = new GraphContext())
            {
                return dbContext.GraphNode.Include("GraphEdges").ToList();
            }
        }

        public List<GraphEdge> FindAllNodeEdges(string id)
        {
            using (var dbContext = new GraphContext())
            {
                return dbContext.GraphEdge.Where(e => e.ID == id  || e.RelatedID == id).ToList();
            }
        }

        public List<GraphEdge> FindAllEdges()
        {
            using (var dbContext = new GraphContext())
            {
                return dbContext.GraphEdge.ToList();
            }
        }

        #endregion

    }
}
