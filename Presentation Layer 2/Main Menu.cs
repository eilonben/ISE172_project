﻿using System;
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

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Commodity_Query cq = new Commodity_Query();
            cq.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
