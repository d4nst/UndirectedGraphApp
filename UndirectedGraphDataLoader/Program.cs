using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UndirectedGraphDataLoader.DataLoaderWS;


namespace UndirectedGraphDataLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataLoaderWS = new DataLoaderWSClient();
            string path;

            Console.WriteLine("Select the path where the folder with the data is located" +
                              " (leave blank to load the \"Input data\" folder under the project root path):");

            path = Console.ReadLine();

            if (String.IsNullOrEmpty(path))
            {
                string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                int index = location.IndexOf("UndirectedGraphDataLoader");
                path = location.Substring(0, index) + "Input Data";
            }

            if (dataLoaderWS.DataLoadXml(path))
            {
                Console.WriteLine("Data loaded successfully");
            }
            else
            {
                Console.WriteLine("Error loading the data");
            }
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();

        }
    }
}
