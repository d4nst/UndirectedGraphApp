using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;

namespace UndirectedGraphDataLoader
{
    public class DataLoader : IDataLoader
    {
        #region Private Members

        private INodeParser _nodeParser;

        #endregion

        #region Class Constructor

        public DataLoader(INodeParser nodeParser)
        {
            _nodeParser = nodeParser;
        }

        #endregion  

        #region Public Methods

        /// <summary>
        /// Adds the file in the given file path to the database
        /// </summary>
        /// <param name="filePath"></param>
        public void NodeFileToDataBase(string filePath)
        {
            using (var dbContext = new GraphContext())
            {

                // parse graph node from file
                var graphNode = _nodeParser.NodeFiletoNodeEntity(filePath);

                var existingNode = dbContext.GraphNode.Find(graphNode.ID);

                if (existingNode != null)
                {
                    dbContext.Entry(existingNode).State = EntityState.Modified;
                    existingNode.Label = graphNode.Label;

                    CreateGraphEdges(dbContext, graphNode);

                    dbContext.SaveChanges();

                }
                else
                {
                    dbContext.GraphNode.Add(new GraphNode
                    {
                        ID = graphNode.ID,
                        Label = graphNode.Label
                    });

                    CreateGraphEdges(dbContext, graphNode);

                    dbContext.SaveChanges();

                }


            }
        }


        /// <summary>
        /// Clears all the data in the database and
        /// adds all the files under the given directory path to the database
        /// </summary>
        /// <param name="directoryPath">Directory path</param>
        public void NodeDirectoryToDatabase(string directoryPath)
        {

            ClearDatabase();

            string[] files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                this.NodeFileToDataBase(file);
            }

        }

        #endregion


        #region Private Methods

        /// <summary>
        ///  Clear all the data in the database
        /// </summary>
        private static void ClearDatabase()
        {
            using (var dbContext = new GraphContext())
            {
                string[] tableNames = new string[] { "GraphEdges", "GraphNodes" };

                foreach (var tableName in tableNames)
                {
                    dbContext.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tableName));
                }

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Creates an adjacent node
        /// </summary>
        /// <param name="dbContext">dbContext</param>
        /// <param name="graphNode">Current graph node</param>
        /// <param name="adjacentNode">Current adjacent node</param>
        private static void CreateAdjacentNode(GraphContext dbContext, GraphNode graphNode, GraphNode adjacentNode)
        {
            // TODO: implement with Entity Framework API instead of stored procedure
            dbContext.Database.ExecuteSqlCommand(
                "EXEC createAdjacentNode @ID, @RelatedID",
                new SqlParameter("ID", graphNode.ID),
                new SqlParameter("RelatedID", adjacentNode.ID)
                );
        }

        /// <summary>
        /// Creates all the edges for the given node.
        /// If a related node doesn't exists, it creates a new node
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="graphNode"></param>
        private static void CreateGraphEdges(GraphContext dbContext, GraphNode graphNode)
        {
            foreach (var graphEdge in graphNode.GraphEdges)
            {
                var existingRelatedNode = dbContext.GraphNode.Find(graphEdge.RelatedID);

                if (existingRelatedNode == null)
                {
                    dbContext.GraphNode.Add(new GraphNode
                    {
                        ID = graphEdge.RelatedID,
                    });
                }

                var existingEdge = dbContext.GraphEdge.Find(graphEdge.ID, graphEdge.RelatedID);

                if (existingEdge != null)
                {
                    dbContext.Entry(existingEdge).State = EntityState.Modified;
                    existingEdge.RelatedID = graphEdge.RelatedID;
                }
                else
                {
                    dbContext.GraphEdge.Add(new GraphEdge
                    {
                        ID = graphEdge.ID,
                        RelatedID = graphEdge.RelatedID
                    });
                }

            }
        }

        #endregion

    }
}
