using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    public class Edge
    {
        public int from { get; set; }
        public int to { get; set; }
        public Boolean isTransfer { get; set; }
        public string duration { get; set; }
        public Departure[] timetable { get; set; }
    }
}
