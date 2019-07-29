using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Bus_reservation_system
{
    public partial class Form1 : Form
    {
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
            List<Data> inputGraph = LoadJson();

        }

        public List<Data> LoadJson()
        {
            using (StreamReader r = new StreamReader("../../InputData/data01.json"))
            {
                string json = r.ReadToEnd();
                List<Data> items = JsonConvert.DeserializeObject<List<Data>>(json);
                return items;
            }
        }
    }
}
