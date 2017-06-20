using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MarketClient;
using MarketClient.DataEntries;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Business_Layer
{
    public class SQLmanager
    {
        private static string connect = @"Data Source=ise172.ise.bgu.ac.il;Initial Catalog=history;User ID=labuser;Password=wonsawheightfly";
        private SqlConnection myConnection;
        private int amountOfValues;
        

        public SQLmanager()
        {
            myConnection = new SqlConnection(connect);
            try
            {
                myConnection.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public SqlDataReader reader(String order)
        {
            SqlCommand myOrder = new SqlCommand(order, myConnection);
            SqlDataReader reader = myOrder.ExecuteReader();
            return reader;
        }
    }
}
