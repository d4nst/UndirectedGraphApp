using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace UndirectedGraphEntity
{
    [DataContract]
    public class GraphEdge
    {

        [DataMember]
        [Key, Column(Order = 0)]
        public string ID { get; set; }

        [Key, Column(Order = 1)]
        [DataMember]
        public string RelatedID { get; set; }

    }
}
