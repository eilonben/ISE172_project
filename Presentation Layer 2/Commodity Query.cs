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
    public partial class Commodity_Query : Form
    {
        RequestAgent ra = new RequestAgent();
        public Commodity_Query()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int id = (int)numericUpDown1.Value;
            string msg = ra.CommodityQuery(id);
            MessageBox.Show(msg);
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Commodity_Query_Load(object sender, EventArgs e)
        {

        }
    }
}
