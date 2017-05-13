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
    public partial class Query : Form
    {
        RequestAgent ra = new RequestAgent();
        public Query()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)numericUpDown1.Value;
            String msg = ra.QueryBuySell(id);
            MessageBox.Show(msg);
            this.Close();
        }

        private void Query_Load(object sender, EventArgs e)
        {

        }
    }
}
