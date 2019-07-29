using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Text;

namespace Bus_reservation_system
{
    public partial class Form1 : Form
    {
        private Timetable[,] data;
        private Data load; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string string_from = this.input_from.Text;
            string string_to = this.input_to.Text;
            string string_time = this.input_time.Text;
            string string_date = this.input_date.Text;
            //MessageBox.Show(string_from + " " + string_to + " " + string_time + " " + string_date);
            load = LoadJson();

            data = DataConverter.convert(load);

            int indexFrom = 0;
            int indexTo = 0;
            for (int i = 0; i < load.nodeIndices.Length; i++) {
                if (load.nodeIndices[i].city.ToLower().Equals(string_from.ToLower())) {
                    indexFrom = load.nodeIndices[i].index;
                }
                else if (load.nodeIndices[i].city.ToLower().Equals(string_to.ToLower())) {
                    indexTo = load.nodeIndices[i].index;
                }
            }

            ResultData result = findResult(indexFrom, indexTo, string_time);
            int a = 0;
        }

        public ResultData findResult(int from, int dest, String timeString) {

            LocalTime time = parseTime(timeString);
            TimetableGraph ttg = new TimetableGraph(data);
            int indexFinalCity = load.nodeIndices[dest].indexCity;
            int indexStartCity = load.nodeIndices[from].indexCity;
            int[] cityIndexes = new int[load.nodeIndices.Length];
            for (int i = 0; i < load.nodeIndices.Length; i++) {
                cityIndexes[i] = load.nodeIndices[i].indexCity;
            }
            return ttg.findPath(from, indexStartCity, dest, indexFinalCity, time, cityIndexes);

        }

        /// <summary>
        /// Auxiliar method for time parsing
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public LocalTime parseTime(string time) {
            return LocalTimePattern.CreateWithInvariantCulture("HH:mm").Parse(time).Value;
        }


        public Data LoadJson()
        {
            using (StreamReader r = new StreamReader("../../InputData/data01.json"))
            {
                string json = r.ReadToEnd();
                Data items = JsonConvert.DeserializeObject<Data>(json);
                return items;
            }
        }
    }
}
