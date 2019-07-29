using NodaTime;
using System;

namespace Bus_reservation_system
{
    class Timetable
    {
        /// <summary>
        /// duration between cities where is edge in input graph
        /// </summary>
        public LocalTime duration;

        /// <summary>
        /// array of lines
        /// </summary>
        public int[] lines;

        /// <summary>
        /// array of times departure per day
        /// </summary>
        public LocalTime[] times;

        /// <summary>
        /// indicate, if there is edge between same node (diagonal in metrix representation of input data)
        /// </summary>
        public bool isNullDistance = false;

        /// <summary>
        /// indicate, if there is not edge between two nodes (in metrix representation of input data)
        /// </summary>
        public bool isInfDistance = false;

        /// <summary>
        /// indicate, if there is a transfer edge between two nodes (in metrix representation of input data)
        /// </summary>
        public bool isTransfer = false;

        /// <summary>
        /// Constructor of Timetable class for two nodes, where is non transfer edge
        /// </summary>
        /// <param name="duration">duration</param>
        /// <param name="lines">lines</param>
        /// <param name="times">times</param>
        public Timetable(LocalTime duration, int[] lines, LocalTime[] times) {
            this.duration = duration;
            this.lines = lines;
            this.times = times;
        }

        //if in not null distance, must be inf distance, because in other cause will be use another constructor

        /// <summary>
        /// Constructor of Timetable class for same node or two nodes, where non exists edge
        /// </summary>
        /// <param name="isNullDistance">isNullDistance</param>
        public Timetable(bool isNullDistance) {
            if (isNullDistance) {
                this.isNullDistance = true;
            }
            else {
                isInfDistance = true;
            }
        }

        /// <summary>
        /// Constructor of Timetable class for two nodes, where is transfer edge
        /// </summary>
        /// <param name="isTransfer">isTransfer</param>
        /// <param name="duration">duration</param>
        public Timetable(bool isTransfer, LocalTime duration) {
            this.isTransfer = isTransfer;
            this.duration = duration;
        }
    }
}
