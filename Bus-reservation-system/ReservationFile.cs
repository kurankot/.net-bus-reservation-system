using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class represent json reservation file for line and date
    /// </summary>
    class ReservationFile
    {
        /// <summary>
        /// int representation of line
        /// </summary>
        int line;

        /// <summary>
        /// Array of seats in bus (constant, all busses have 50 seats)
        /// </summary>
        readonly Seats[] seat = new Seats[50];
    }
}
