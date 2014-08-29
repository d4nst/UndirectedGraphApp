using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations; 

namespace UndirectedGraphEntity
{
    [DataContract]
    public class GraphNode
    {
        [DataMember]
        [Key]
        public string ID { get; set; }

        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public List<GraphNode> AdjacentNodes { get; set; }

        [DataMember]
        public List<GraphEdge> GraphEdges { get; set; }
    }

}
