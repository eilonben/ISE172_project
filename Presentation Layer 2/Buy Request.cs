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


namespace Presentation_Layer_2
{
    public partial class Buy_Request : Form
    {
        public Buy_Request()
        {
            InitializeComponent();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(this.maskedTextBox1.Text);
                int amount = Int32.Parse(this.maskedTextBox1.Text);
                int price = Int32.Parse(this.maskedTextBox1.Text);
             }
             catch(Exception er) {
             }

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Buy_Request_Load(object sender, EventArgs e)
        {

        }
    }
}
