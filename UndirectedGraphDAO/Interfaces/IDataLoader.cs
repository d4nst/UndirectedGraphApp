using System;
namespace UndirectedGraphRepository
{
    public interface IDataLoader
    {
        void NodeDirectoryToDatabase(string directoryPath);
        void NodeFileToDataBase(string filePath);
    }
}
