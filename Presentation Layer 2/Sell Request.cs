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

namespace Presentation_Layer_
{
    public partial class SellRequest : Form
    {
        public SellRequest()
        {
            InitializeComponent();
        }
        RequestAgent ra = new RequestAgent();
        private void SellRequest_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            int amount = (int)numericUpDown2.Value;
            int price = (int)numericUpDown4.Value;
            string response = ra.buyCommodities(price, id, amount);
            MessageBox.Show(response);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
