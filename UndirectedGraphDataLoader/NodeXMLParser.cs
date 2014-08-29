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
        public GraphNode NodeFiletoNodeEntity(string path)
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
    }
}
