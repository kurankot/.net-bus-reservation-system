using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class represents Result data
    /// </summary>
    public class ResultData
    {
        /// <summary>
        /// Array of Objects represents nodes in path
        /// </summary>
        int[] path;

        /// <summary>
        /// Array of LocalTimes represents time departures for all nodes in path
        /// </summary>
        LocalTime[] timeDepartures;

        /// <summary>
        /// Array of lines in int representation
        /// </summary>
        int[] lines;

        /// <summary>
        /// Constructor of ResultData class
        /// </summary>
        /// <param name="path">path is Array of Objects represents nodes in path</param>
        /// <param name="timeDepartures">timeDepartures is Array of LocalTimes represents time departures for all nodes in path</param>
        /// <param name="lines">lines is Array of lines in int representation</param>
        public ResultData(int[] path, LocalTime[] timeDepartures, int[] lines) {
            this.path = path;
            this.timeDepartures = timeDepartures;
            this.lines = lines;
        }
    }
}
