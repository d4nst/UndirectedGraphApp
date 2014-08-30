using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphRepository;

namespace UndirectedGraphService
{
    public class DataLoaderXmlService : IDataLoaderXmlService
    {
         #region Private Members

        private IDataLoader _dataLoader;

        private INodeParser _nodeParser;

        #endregion

        #region Class Constructor

        public DataLoaderXmlService()
        {
            _nodeParser = new NodeXMLParser();

            _dataLoader = new DataLoader(_nodeParser);
        }

        #endregion  

        #region Public Methods

        public bool DataLoadXml(string path)
        {

            try
            {
                _dataLoader.NodeDirectoryToDatabase(path);

                return true;
            }
            catch
            {
                return false;
            }

        }
        
        #endregion

    }
}
