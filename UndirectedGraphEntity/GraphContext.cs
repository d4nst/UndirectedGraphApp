using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace UndirectedGraphEntity
{
    public class GraphContext : DbContext
    {
        public DbSet<GraphNode> GraphNode { get; set; }
        public DbSet<GraphEdge> GraphEdge { get; set; }

    }
}
