using NodaTime;
using NodaTime.Text;
using System;

namespace Bus_reservation_system
{
    /// <summary>
    /// Class represents Converter of data from json file to metrix
    /// </summary>
    class DataConverter
    {
        /// <summary>
        /// Convert input data from json file to metrix of length VxV, where V is number of vertices in graph
        /// </summary>
        /// <param name="load">load is Data representation from json file</param>
        /// <returns></returns>
        public static Timetable[,] convert(Data load) {
            Timetable[,] finalData = new Timetable[load.nodeIndices.Length, load.nodeIndices.Length];
            foreach (Edge edge in load.edges) {
                if (edge.isTransfer) { //is transfer --> within town
                    finalData[edge.from, edge.to] = new Timetable(true, LocalTimePattern.CreateWithInvariantCulture("HH:mm").Parse("00:00").Value);
                }
                else {  //is not transfer --> must be edge between 2 towns
                    //LocalTime duration = LocalTime.Parse(edge.duration);
                    LocalTime duration = LocalTimePattern.CreateWithInvariantCulture("HH:mm").Parse(edge.duration).Value;
                    int[] lines = new int[edge.timetable.Length];
                    LocalTime[] times = new LocalTime[edge.timetable.Length];

                    for (int i = 0; i < edge.timetable.Length; i++) {
                        int.TryParse(edge.timetable[i].line, out lines[i]);
                        times[i] = LocalTimePattern.CreateWithInvariantCulture("HH:mm").Parse(edge.timetable[i].departure).Value;
                    }

                    finalData[edge.from, edge.to] = new Timetable(duration, lines, times);
                }
            }

            for (int i = 0; i < load.nodeIndices.Length; i++) {
                for (int j = 0; j < load.nodeIndices.Length; j++) {
                    if (i == j) { //edge from town into that one town --> edge nullDistance set to true
                        finalData[i, j] = new Timetable(true);
                    }
                    else if (finalData[i, j] == null) {
                        finalData[i, j] = new Timetable(false);
                    }
                }
            }

            return finalData;

        }

    }
}
