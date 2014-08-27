using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations; 

namespace UndirectedGraphEntity
{
    public class GraphNode
    {
        [Key]
        public string ID { get; set; }
        public string Label { get; set; }

        public virtual List<GraphNode> AdjacentNodes { get; set; }
    }

}
