using System;
namespace UndirectedGraphDataLoader
{
    interface IDataLoader
    {
        void NodeDirectoryToDatabase(string directoryPath);
        void NodeFileToDataBase(string filePath);
    }
}
