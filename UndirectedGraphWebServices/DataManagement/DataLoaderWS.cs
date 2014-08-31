using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphRepository;
using UndirectedGraphRepository.Interfaces;
using UndirectedGraphService.DataManagement;
using UndirectedGraphService.DataManagement.Interfaces;
using UndirectedGraphWebServices.DataManagement.Interfaces;

namespace UndirectedGraphWebServices.DataManagement
{
    public class DataLoaderWS : IDataLoaderWS
    {

        #region Private Members

        private IDataLoaderService _dataLoaderService;

        private IGraphNodeParser _nodeParser;

        private IUnitOfWork _unitOfWork;

        #endregion

        #region Class Constructor

        public DataLoaderWS()
        {

            _nodeParser = new GraphNodeXMLParser();

            _unitOfWork = new UnitOfWork();

            _dataLoaderService = new DataLoaderService(_nodeParser, _unitOfWork);
        }

        #endregion  

        #region Public Methods

        public bool DataLoadXml(string path, out string error)
        {
            try
            {
                _dataLoaderService.NodeDirectoryToDatabase(path);

                error = String.Empty;
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;

            }

        }

        #endregion

    }
}


 