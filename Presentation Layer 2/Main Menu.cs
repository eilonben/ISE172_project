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
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Buy_Request br = new Buy_Request();
            br.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Presentation_Layer_.HelpWindow hr = new Presentation_Layer_.HelpWindow();
            hr.Show();
        }
    }
}
