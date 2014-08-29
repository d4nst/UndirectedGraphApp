using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphDataLoader;

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
                // If the path parameter equals "default", the default directory for input data is loaded
                if (path.Equals("default"))
                {
                    path = @"C:\Users\Daniel\Documents\Visual Studio 2013\Projects\UndirectedGraphApp\Input data";
                }

                // Insert all the files under the path to the database
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
