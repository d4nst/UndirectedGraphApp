using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphService.DataManagement.Interfaces;
using UndirectedGraphEntity;
using System.Xml.Linq;

namespace UndirectedGraphService.DataManagement
{
    public class GraphNodeXMLParser : IGraphNodeParser
    {

        #region Private Members

        #endregion


        #region Class Constructor

        #endregion


        #region Public Methods

        public GraphNode NodeFileToNodeEntity(string path)
        {
            XDocument xmlDoc = XDocument.Load(path);

            var node = xmlDoc.Element("node");
            var adjacentNodes = node.Element("adjacentNodes");

            var graphNode = new GraphNode();
            graphNode.ID = node.Element("id").Value;
            graphNode.Label = node.Element("label").Value;
            graphNode.GraphEdges = (from adjacentNode in adjacentNodes.Descendants("id")
                                    select new GraphEdge
                                    {
                                        ID = node.Element("id").Value,
                                        RelatedID = adjacentNode.Value
                                    }).ToList<GraphEdge>();

            return graphNode;
        }

        #endregion

    }
}
