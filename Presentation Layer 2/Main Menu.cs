using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation_Layer_;
using Business_Layer;
using System.IO;


namespace Presentation_Layer_2
{
    public partial class UserInterface : Form
    {
        RequestAgent ra = new RequestAgent();
        AutonomousMarketAgent AMA = new AutonomousMarketAgent();
        public UserInterface()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            HelpWindow hr = new HelpWindow();
            hr.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Buy_Request br = new Buy_Request();
            br.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cancel_Request cr = new Cancel_Request();
            cr.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SellRequest sr = new SellRequest();
            sr.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Query bsq = new Query();
            bsq.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string msg = ra.UserQuery();
            MessageBox.Show(msg);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Commodity_Query cq = new Commodity_Query();
            cq.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string msg = ra.AllMarketQuery();
            MessageBox.Show(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = ra.UserRequestsQuery();
            MessageBox.Show(msg);
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            History hs = new History();
            hs.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            AMA.start();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            AMA.stop();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Statistics_Menu sm = new Statistics_Menu();
            sm.ShowDialog();
        }
    }
}
