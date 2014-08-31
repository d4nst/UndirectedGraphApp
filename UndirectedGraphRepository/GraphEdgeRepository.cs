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
    public class GraphEdgeRepository : IGraphEdgeRepository
    {

        #region Private Members

        private GraphContext _context;

        #endregion

        #region Class Constructor

        public GraphEdgeRepository(GraphContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        public List<GraphEdge> FindAllEdgesByNodeId(string id)
        {
            return _context.GraphEdge.Where(e => e.ID == id || e.RelatedID == id).ToList();
        }

        public GraphEdge FindEdge(string id, string relatedId)
        {
            return _context.GraphEdge.Find(id, relatedId);
        }

        public void AddEdge(GraphEdge edge)
        {
            _context.GraphEdge.Add(edge);
        }

        public void UpdateEdge(GraphEdge edge)
        {
            _context.Entry(edge).State = EntityState.Modified;
        }

        public void DeleteAllEdges()
        {
            _context.GraphEdge.RemoveRange(_context.GraphEdge.ToList());
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion


    }
}
