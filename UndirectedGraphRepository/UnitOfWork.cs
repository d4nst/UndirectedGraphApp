using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository.Interfaces;

namespace UndirectedGraphRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Members

        private GraphContext _context;
        
        private IGraphNodeRepository _graphNodeRepository;

        private IGraphEdgeRepository _graphEdgeRepository;

        #endregion

        #region Properties

        public IGraphNodeRepository GraphNodeRepository
        {
            get
            {

                if (_graphNodeRepository == null)
                {
                    _graphNodeRepository = new GraphNodeRepository(_context);
                }
                return _graphNodeRepository;
            }
        }

        public IGraphEdgeRepository GraphEdgeRepository
        {
            get
            {

                if (_graphEdgeRepository == null)
                {
                    _graphEdgeRepository = new GraphEdgeRepository(_context);
                }   
                return _graphEdgeRepository;
            }
        }

        #endregion


        #region Class Constructor

        public UnitOfWork()
        {
            _context = new GraphContext();
        }

        #endregion


        #region Public Methods

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}
