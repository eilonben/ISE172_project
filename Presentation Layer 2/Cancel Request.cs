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
    public partial class Cancel_Request : Form
    {
        RequestAgent rs = new RequestAgent();
        public Cancel_Request()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                Int32.Parse(maskedTextBox1.Text);
            }
            catch(Exception er)
             {
                return; 
            }
            int id = Int32.Parse(maskedTextBox1.Text);
            string msg = rs.cancelRequest(id);
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
