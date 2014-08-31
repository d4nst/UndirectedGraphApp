using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository.Interfaces;

namespace UndirectedGraphRepository
{
    public class GraphNodeRepository : IGraphNodeRepository
    {

        #region Private Members

        private GraphContext _context;

        #endregion

        #region Class Constructor

        public GraphNodeRepository(GraphContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public List<GraphNode> FindAllNodes()
        {
            return _context.GraphNode.Include("GraphEdges").ToList();
        }

        public GraphNode FindNode(string id)
        {
            return _context.GraphNode.Find(id);
        }

        public void AddNode(GraphNode node)
        {
            _context.GraphNode.Add(node);
        }

        public void UpdateNode(GraphNode node)
        {
            _context.Entry(node).State = EntityState.Modified;
        }

        public void DeleteAllNodes()
        {
            _context.GraphNode.RemoveRange(_context.GraphNode.ToList());
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
