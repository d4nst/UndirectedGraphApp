using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;

namespace UndirectedGraphDataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
           
            {
                // Create xml parser
                var nodeXMLParser = new NodeXMLParser();

                // Create dataLoader instance
                var dataLoader = new DataLoader(nodeXMLParser);

                // Insert all the files under the default path to the database
                var defaultPath = @".\..\..\..\Input data";
                dataLoader.NodeDirectoryToDatabase(defaultPath);
            }

        }
    }
}
