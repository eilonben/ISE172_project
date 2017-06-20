using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Business_Layer;

namespace Presentation_Layer_
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            monthCalendar1.MaxSelectionCount = 1;
            monthCalendar2.MaxSelectionCount = 1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            history h = new history();
            DateTime start = monthCalendar1.SelectionStart;
            DateTime end = monthCalendar2.SelectionStart;
            string output = "";
            output += h.historyByDate(start, end);
            richTextBox1.Text = output;
        



            /*string[] output = File.ReadAllLines("../../../history/history.log");
            string s = "";
            for (int i = 0; i < output.Length; i++)
                s += output[i] + "\n";
            richTextBox1.Text = s;*/
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
