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

        private void SellRequest_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(this.maskedTextBox1.Text);
                int amount = Int32.Parse(this.maskedTextBox1.Text);
                int price = Int32.Parse(this.maskedTextBox1.Text);
            }
            catch (Exception er)
            {
            }
        }
    }
}
