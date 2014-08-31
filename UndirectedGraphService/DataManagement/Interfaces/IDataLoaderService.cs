using System;

namespace UndirectedGraphService.DataManagement.Interfaces
{
    public interface IDataLoaderService
    {
        void NodeDirectoryToDatabase(string directoryPath);

        void NodeFileToDatabase(string filePath);
    }
}
