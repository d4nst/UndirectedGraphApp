using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UndirectedGraphDataLoader;

namespace UndirectedGraphWebServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DataLoaderWS : IDataLoaderWS
    {

        public bool DataLoadXml(string path)
        {
            // Create xml parser
            var nodeXMLParser = new NodeXMLParser();

            // Create dataLoader instance
            var dataLoader = new DataLoader(nodeXMLParser);

            try
            {
                // If the path parameter equals "default", the default directory for input data is loaded
                if (path.Equals("default"))
                {
                    path = @"C:\Users\Daniel\Documents\Visual Studio 2013\Projects\UndirectedGraphApp\Input data";
                }

                // Insert all the files under the path to the database
                dataLoader.NodeDirectoryToDatabase(path);

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
