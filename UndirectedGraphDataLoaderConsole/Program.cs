using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphDataLoaderConsole.DataLoaderWS;


namespace UndirectedGraphDataLoaderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataLoaderWS = new DataLoaderWSClient();
            dataLoaderWS.DataLoadXml("default");

        }
    }
}
