using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class represents attributes of node
    /// </summary>
    public class NodeIndex
    {
        /// <summary>
        /// int representation of index
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// String representatio nof node, forexample "BA1"
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// String full name of node, forexample "Bratislava". Can be same for multiple nodes
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// int representation of index of city, not equals to index
        /// </summary>
        public int indexCity { get; set; }
    }
}
