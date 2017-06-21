using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using LiveCharts;
using LiveCharts.WinForms;


namespace Presentation_Layer_
{
    public partial class Statistics_Menu : Form
    {
        public Statistics_Menu()
        {
            InitializeComponent();
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar2.MaxSelectionCount = 1;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Statistics_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = monthCalendar1.SelectionStart;
            DateTime end = monthCalendar2.SelectionStart;

            if (end <= start)
            {
                MessageBox.Show("please choose a valid start and end date ( start > end )");
            }
            else
            {
                if (radioButton3.Checked)
                {
                    MinChart mic = new MinChart(start, end);
                    mic.ShowDialog();
                }
                if (radioButton2.Checked)
                {
                    MaxChart mac = new MaxChart(start, end);
                    mac.ShowDialog();
                }
                if (radioButton4.Checked)
                {
                    AverageChart ac = new AverageChart(start,end);
                    ac.ShowDialog();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
