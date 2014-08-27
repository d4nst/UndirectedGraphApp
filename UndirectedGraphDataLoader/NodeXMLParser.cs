using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndirectedGraphEntity;
using System.Xml.Linq;

namespace UndirectedGraphDataLoader
{
    public class NodeXMLParser : INodeParser
    {
        /// <summary>
        /// Parses an XML file to a GraphNode entity
        /// </summary>
        /// <param name="path">Path to the XML file</param>
        /// <returns>GraphNode entity</returns>
        public GraphNode NodeFiletoNodeEntity(string path)
        {
            XDocument xmlDoc = XDocument.Load(path);

            var node = xmlDoc.Element("node");
            var adjacentNodes = node.Element("adjacentNodes");

            var graphNode = new GraphNode();
            graphNode.ID = node.Element("id").Value;
            graphNode.Label = node.Element("label").Value;
            graphNode.AdjacentNodes = (from adjacentNode in adjacentNodes.Descendants("id")
                                       select new GraphNode 
                                       {
                                           ID = adjacentNode.Value
                                       }).ToList<GraphNode>();

            return graphNode;
        }

    }
}
