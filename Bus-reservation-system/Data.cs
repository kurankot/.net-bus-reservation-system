using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class reresents Data object from json
    /// </summary>
    public class Data
    {
        /// <summary>
        /// First part of json input graph file represents indicies
        /// </summary>
        public NodeIndex[] nodeIndices { get; set; }

        /// <summary>
        /// Second part of json input graph file represents edges 
        /// </summary>
        public Edge[] edges { get; set; }
    }
}
