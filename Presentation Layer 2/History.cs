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

namespace Presentation_Layer_
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] output = File.ReadAllLines("../../../history/history.log");
            string s = "";
            for (int i = 0; i < output.Length; i++)
                s += output[i] + "\n";
            richTextBox1.Text = s;
        }
    }
}
