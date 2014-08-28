using System;
namespace UndirectedGraphDataLoader
{
    public interface IDataLoader
    {
        void NodeDirectoryToDatabase(string directoryPath);
        void NodeFileToDataBase(string filePath);
    }
}
