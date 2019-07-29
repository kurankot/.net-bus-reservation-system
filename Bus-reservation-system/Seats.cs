using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    /// <summary>
    /// CLass represents seat in bus
    /// </summary>
    class Seats
    {
        /// <summary>
        /// Boolean, if seat is available
        /// </summary>
        Boolean[] availability;

        /// <summary>
        /// Constructor of class Seats
        /// </summary>
        /// <param name="length">length is number of cities on line path</param>
        public Seats(int length) {
            availability = new Boolean[length];
        }
    }
}
