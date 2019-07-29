using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class represents edge in input graph of timetable
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// int representation of start node
        /// </summary>
        public int from { get; set; }

        /// <summary>
        /// int representation of end node
        /// </summary>
        public int to { get; set; }

        /// <summary>
        /// indicate, if edge is transfer
        /// </summary>
        public Boolean isTransfer { get; set; }

        /// <summary>
        /// String representation of duration through edge
        /// </summary>
        public string duration { get; set; }
        /// <summary>
        /// Array of departures per day in the edge
        /// </summary>
        public Departure[] timetable { get; set; }
    }
}
