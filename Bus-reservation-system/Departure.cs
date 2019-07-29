using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class represents timetable item in json input data file
    /// </summary>
    public class Departure
    {
        /// <summary>
        /// String representation of departure time
        /// </summary>
        public string departure { get; set; }

        /// <summary>
        /// String representation of line for appropriate departure
        /// </summary>
        public string line { get; set; }
    }
}
