using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository;
using UndirectedGraphRepository.Interfaces;
using UndirectedGraphService.FrontEndOriented.Interfaces;

namespace UndirectedGraphService.FrontEndOriented
{
    public class GraphNodeService : IGraphNodeService
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;

        #endregion

        #region Class Constructor

        public GraphNodeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods


        public List<GraphNode> FindAllNodes()
        {
            return _unitOfWork.GraphNodeRepository.FindAllNodes();
        }


        #endregion
    }
}
