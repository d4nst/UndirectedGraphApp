using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;

namespace UndirectedGraphDAO
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
                return dbContext.GraphNode.Include("AdjacentNodes").ToList();;
            }
        }

        #endregion

    }
}
