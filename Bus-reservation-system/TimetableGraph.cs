using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_reservation_system
{
    class TimetableGraph
    {

        /**
         * Graph representation
         */
        public Timetable[,] data;

        /**
         * indicate, when travel is through 2 days (when reach 00:00 and continuous next)
         */
        bool newDay = false;

        /**
         * <p>Constructor of TimetableGraph class</p>
         * @param data
         */
        public TimetableGraph(Timetable[,] data) {
            this.data = data;
        }

        /**
         * <p>algorithm for searching path in graph</p>
         * @param startNode is int representation of starting node
         * @param indexStartCity is int representation of index of starting city
         * @param endNode is int representation of ending node
         * @param indexFinalCity is int representation of index
         * @param startTime is LocalTime representation of starting time
         * @param nodeIndexes is array of node indexes
         * @return ResultData
         */
        public ResultData findPath(int startNode, int indexStartCity, int endNode, int indexFinalCity, LocalTime startTime, int[] nodeIndexes) {

            //array of closed nodes through algorithm runtime
            bool[] closed = new bool[data.Length];
            //array of distances from starting node to others
            double[] distances = new double[data.Length];
            //auxiliar data structure for algorithm
            HashSet<int> set = new HashSet<int>();
            //array of predecessors for all nodes in graph
            int[] predecessors = new int[data.Length];
            //array of lines between all two nodes after path find
            //int[][] lines = new int[data.length][data.length];

            //array of departures for all pairs of nodes
            LocalTime[,] timeDepartures = new LocalTime[data.Length, data.Length];

            //INITIALIZE SECTION - START
            set.Add(startNode);
            predecessors[startNode] = -1;

            //initialize departure times for all nodes (all nodes have startTime value)
            for (int i = 0; i < data.Length; i++) {
                for (int j = 0; j < data.Length; j++) {
                    timeDepartures[i, j] = startTime;
                }
            }

            //initialize distances to Integer.MAX_VALUE except startNode node
            for (int i = 0; i < data.Length; i++) {
                if (i != startNode) {
                    distances[i] = int.MaxValue;
                }
                else {
                    distances[i] = 0;
                }
            }
            //INITIALIZE SECTION - END

            //ALGORITHM SSECTION - START
            while (set.Count != 0) {
                //find next node with the smallest distance in set
                int actualNode = nextSmallestNodeInSet(set, distances);
                set.Remove(actualNode);
                closed[actualNode] = true;

                //main cycle for all columns in actualNode's row in data
                for (int i = 0; i < data.Length; i++) {
                    if (!data[actualNode,i].isInfDistance) {
                        if (data[actualNode,i].isTransfer) {
                            if (FunctionForTransfer(closed, actualNode, indexFinalCity, i, distances, timeDepartures, nodeIndexes)) {
                                predecessors[i] = actualNode;
                                set.Add(i);
                            }

                        }
                        else {
                            if (FunctionForNonTransfer(closed, actualNode, indexStartCity, i, distances, timeDepartures, nodeIndexes, startTime, startNode)) {
                                predecessors[i] = actualNode;
                                set.Add(i);
                            }
                        }

                    }
                }


            }
            //ALGORITHM SECTION - END

            return compositeData(startNode, endNode, predecessors, timeDepartures);

        }

        /**
         * <p>Get next smallest node in set for searching algorithm</p>
         * @param set is set of actual nodes in algorithm
         * @param distances is array of double numbers of distances from start node to another nodes
         * @return Integer represents next smallest node in set
         */
        private int nextSmallestNodeInSet(HashSet<int> set, double[] distances) {
            //counting next node with the smallest distance
            double minDistance = int.MaxValue;
            int actualNode = -1;
            foreach (int i in set) {
                if (distances[i] < minDistance) {
                    minDistance = distances[i];
                    actualNode = i;
                }
            }
            return actualNode;
        }

        /**
         * <p>Function count next nearest node for transfer edge</p>
         * @param closed is array of closed nodes through algorithm
         * @param actualNode is int representation of actual node
         * @param indexFinalCity is int representation of final city
         * @param i is int representation of cycle from parent calling method
         * @param distances is array of distances from start node to another nodes
         * @param timeDepartures is LocalTime representation of time departures from node
         * @param nodeIndexes is array of ints of node indexes
         * @return indicate, if new node may be added to set and set as predecessor
         */
        private bool FunctionForTransfer(bool[] closed, int actualNode, int indexFinalCity, int i, double[] distances, LocalTime[,] timeDepartures, int[] nodeIndexes) {
            if (!closed[i]) {
                LocalTime nextTime;

                double diff2 = 0;

                //mark all transfer edges neighbours with i
                markMeighbourTransferEdges(i, actualNode, indexFinalCity, timeDepartures, nodeIndexes);

                //return FunctionForNonTransfer(closed, actualNode, i, distances, timeDepartures);

                double duration = data[actualNode,i].duration.Minute + data[actualNode,i].duration.Hour * 60;

                //find shorter path to node i
                if (distances[actualNode] + duration < distances[i]) {
                    distances[i] = distances[actualNode] + duration;

                    //set non-closed nodes's timeDeparture to nextTime
                    for (int l = 0; l < data.Length; l++) {
                        if (!closed[l]) {
                            timeDepartures[i, l] = timeDepartures[actualNode, i].Plus(Period.FromMinutes((long)duration));
                        }
                    }

                    return true;

                }

                return false;

            }
            else {
                return false;
            }
        }

        /**
         * <p>Function count next nearest node for non transfer edge</p>
         * @param closed is array of closed nodes through algorithm
         * @param actualNode is array of closed nodes through algorithm
         * @param indexStartCity is int representation of Start city
         * @param i is int representation of cycle from parent calling method
         * @param distances is array of distances from start node to another nodes
         * @param timeDepartures is LocalTime representation of time departures from node
         * @param nodeIndexes is array of ints of node indexes
         * @param startTime is LocalTime representation of start time
         * @param startNode is int representation of start node
         * @return indicate, if new node may be added to set and set as predecessor
         */
        private bool FunctionForNonTransfer(bool[] closed, int actualNode, int indexStartCity, int i, double[] distances, LocalTime[,] timeDepartures, int[] nodeIndexes, LocalTime startTime, int startNode) {
            if (!closed[i]) {
                //count duration in minute from actualNode to ith node
                double duration = data[actualNode,i].duration.Minute + data[actualNode,i].duration.Hour * 60;

                //find shorter path to node i
                if (distances[actualNode] + duration < distances[i]) {

                    //find and set nearest next time
                    LocalTime nextTime = findImmediateTime(timeDepartures[actualNode, i], actualNode, i, timeDepartures);
                    timeDepartures[actualNode, i] = nextTime;



                    Duration duration2;
                    if (newDay) {
                        LocalTime timeArrive = startTime;
                        Duration toMidnight = betweenAdd(parseTime("23:59"), timeArrive, PeriodUnits.Minutes, 1);

                        duration2 = betweenAdd(nextTime, parseTime("00:00"), PeriodUnits.Minutes, toMidnight.Minutes);
                        newDay = false;
                    }
                    else {

                        duration2 = betweenAdd(nextTime, startTime, PeriodUnits.Minutes, 0);

                    }

                    //wait time in start node when next edge is not transfer
                    double imagDiff = 0;
                    if (nodeIndexes[actualNode] == indexStartCity && actualNode == startNode) {
                        imagDiff = duration2.Minutes;

                    }

                    distances[i] = distances[actualNode] + duration + imagDiff;

                    newDay = false;


                    //set non-closed nodes's timeDeparture to nextTime
                    for (int l = 0; l < data.Length; l++) {
                        if (!closed[l]) {
                            timeDepartures[i, l] = timeDepartures[actualNode, i].Plus(Period.FromMinutes((long)duration));
                        }
                    }
                    return true;
                }
                return false;
            }
            else {
                return false;
            }
        }

        /**
         * <p>find nearest next time</p>
         * @param startTime is LocalTime representation of start time
         * @param actualNode is int representation of actual node
         * @param i  is int representation of cycle from parent calling method
         * @param timeDepartures is array of time departures between all two nodes in graph
         * @return next nearest LocalTime to start time
         */
        private LocalTime findImmediateTime(LocalTime startTime, int actualNode, int i, LocalTime[,] timeDepartures) {
            int k = 0;
            LocalTime nextTime = data[actualNode,i].times[k];

            //find in list of departures in day in actualNode nearest actualTIme
            while (startTime.CompareTo(nextTime) < 0 && !(startTime.Equals(nextTime))) {

                k++;
                //if occured new day, start at begin in list and time departure will set to 00:00
                if (k >= data[actualNode,i].times.Length) {
                    k = 0;
                    //timeDepartures[actualNode][i] = LocalTime.parse("00:00");
                    startTime = parseTime("00:00");
                    newDay = true;

                }
                nextTime = data[actualNode,i].times[k];

            }

            return nextTime;
        }

        /**
         * <p>Marking all neighbour tranfer edges in graph fro actualNode</p>
         * @param actualNode is int representation of actual node
         * @param previousNode is int representation of previous node
         * @param indexFinalCity is int representation of index of final city
         * @param timeDepartures is array of time departures for all two nodes in graph
         * @param nodeIndexes is array of ints of node indexes
         */
        private void markMeighbourTransferEdges(int actualNode, int previousNode, int indexFinalCity, LocalTime[,] timeDepartures, int[] nodeIndexes) {

            //loop for all neighbours
            for (int j = 0; j < data.Length; j++) {
                if (nodeIndexes[actualNode] != indexFinalCity) {
                    if ((!data[actualNode,j].isTransfer) && (actualNode != j) && (!data[actualNode,j].isInfDistance)) {
                        //find next immediate time
                        LocalTime nextImmediateTime = findImmediateTime(timeDepartures[previousNode, actualNode], actualNode, j, timeDepartures);

                        Duration duration;
                        if (newDay) {
                            LocalTime timeArrive = timeDepartures[previousNode, actualNode];
                            Duration toMidnight = betweenAdd(parseTime("23:59"), timeArrive, PeriodUnits.Minutes, 1);

                            duration = betweenAdd(nextImmediateTime, parseTime("00:00"), PeriodUnits.Minutes, toMidnight.Minutes);
                            newDay = false;
                        }
                        else {
                            duration = betweenAdd(nextImmediateTime, timeDepartures[previousNode, actualNode], PeriodUnits.Minutes, 0);
                        }

                        //initialize for next iteration
                        //--

                        String durationString = String.Format(duration.Hours + ":" + (duration.Minutes - duration.Hours * 60));

                        //mark edge
                        data[previousNode,actualNode].duration = parseTime(durationString);
                    }
                }
                else {
                    LocalTime duration = parseTime("00:00");
                    data[previousNode,actualNode].duration = duration;
                }
            }
        }

        /**
         * <p>Composite path from result as path from start node to end node</p>
         * @param startNode is int representation of start node
         * @param endNode is int representation of end node
         * @param predecessors is array of ints of predecessors for all nodes in graph
         * @param timeDepartures is array of time departures of all two nodes in graph
         * @return ResultData
         */
        private ResultData compositeData(int startNode, int endNode, int[] predecessors, LocalTime[,] timeDepartures) {
            List<int> path = new List<int>();

            //compose path from startNode to endNode
            int actualNode = endNode;
            path.Add(actualNode);
            while (startNode != actualNode) {
                path.Add(predecessors[actualNode]);
                actualNode = predecessors[actualNode];
            }

            //remove from begin and end of path transfer edges
            for (int j = 0; j < 3; j++) {
                bool atBegin = true;
                for (int i = 0; i < path.Count() - 1; i++) {
                    if (data[path[i],path[i + 1]].isTransfer && atBegin) {
                        path.Remove(i);
                        i = -1;
                    }
                    else {
                        atBegin = false;
                    }
                }
                path.Reverse();
            }

            //initialize and fill timetable (arrive time and departure time for all node at path)
            LocalTime[] timetable = new LocalTime[path.Count * 2];
            for (int i = 0; i < path.Count - 1; i++) {
                timetable[2 * i + 1] = timeDepartures[path[i], path[i + 1]];
                int duration = data[path[i],path[i + 1]].duration.Hour * 60 + data[path[i],path[i + 1]].duration.Minute;
                timetable[2 * (i + 1)] = timetable[2 * i + 1].PlusMinutes(duration);
            }

            //initialize and find lines for all edges at path
            int[] lines = new int[path.Count - 1];
            for (int i = 0; i < lines.Length; i++) {
                int index = findLine(path[i], path[i + 1], timetable[2 * i + 1]);
                if (index != -1) {
                    lines[i] = data[path[i],path[i + 1]].lines[index];
                }
                else {
                    lines[i] = index;
                }
            }

            ResultData resultData = new ResultData(path.ToArray(), timetable, lines);
            return resultData;
        }

        /**
         * <p>Find line for two neighbour nodes</p>
         * @param firstNode is int representation of firts node
         * @param secondNode is int representation of second node
         * @param time is LocalTime representation of time
         * @return int as index of line
         */
        private int findLine(int firstNode, int secondNode, LocalTime time) {

            if (data[firstNode,secondNode].isTransfer) return -1;

            int index = 0;
            //loop for timetables at concrete edge
            for (int j = 0; j < data[firstNode,secondNode].times.Length; j++) {
                if (time.Equals(data[firstNode,secondNode].times[j])) {
                    index = j;
                }
            }

            return index;
        }

        public LocalTime parseTime(string time) {
            return LocalTimePattern.CreateWithInvariantCulture("HH:mm").Parse(time).Value;
        }

        public Duration betweenAdd(LocalTime first, LocalTime second, PeriodUnits units, int addMinutes) {
            return (Period.Between(second, first, units) + Period.FromMinutes(addMinutes)).ToDuration();
        }
    }



}
