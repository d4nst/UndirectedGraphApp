using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using UndirectedGraphRepository;
using UndirectedGraphRepository.Interfaces;
using UndirectedGraphService.FrontEndOriented;
using UndirectedGraphService.FrontEndOriented.Interfaces;
using UndirectedGraphWebServices.FrontEndOriented.Interfaces;

namespace UndirectedGraphWebServices.FrontEndOriented
{
    public class GraphNodeWS : IGraphNodeWS
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;

        private IGraphNodeService _graphNodeService;

        #endregion

        #region Class Constructor

        public GraphNodeWS()
        {
            _unitOfWork = new UnitOfWork();

            _graphNodeService = new GraphNodeService(_unitOfWork);
        }

        #endregion

        #region Public Methods

        public List<GraphNode> FindAllNodes()
        {
           try
           {
               return _unitOfWork.GraphNodeRepository.FindAllNodes();
           }
           catch
           {
               return null;
           }
        }

        #endregion
    }
}
