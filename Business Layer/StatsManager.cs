using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Layer
{
    public class StatsManager
    {
        private RequestAgent RA;
        private SQLmanager SM;

        public StatsManager() {
            RA = new RequestAgent();
            SM = new SQLmanager();
        }

        public Double[] MaxMinPrices(Boolean max, DateTime start, DateTime end)
        {
            Double[] prices = new Double[10];
            SqlDataReader reader;
            for (int i = 0; i < 10; i++)
            {
                string order;
                if (max)
                {
                    order = @"SELECT MAX(price) FROM history.dbo.items WHERE commodity = " + i+ " AND timestamp>= " + "'" + Convert.ToDateTime(start).ToString("yyyy-MM-dd HH:mm:ss") + "' AND timestamp<= " + "'" + Convert.ToDateTime(end).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                } else {
                    order = @"SELECT MIN(price) FROM history.dbo.items WHERE commodity = " + i + " AND timestamp>= " + "'" + Convert.ToDateTime(start).ToString("yyyy-MM-dd HH:mm:ss") + "' AND timestamp<= " + "'" + Convert.ToDateTime(end).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
                reader = SM.reader(order);
                while (reader.Read())
                {
                    prices[i] = Double.Parse(reader.GetValue(0).ToString().Trim());
                }
                reader.Close();
            }
            return prices;

        }

        public Double[] AvgPrices(DateTime start, DateTime end) {
            Double[] prices = new Double[10];
            SqlDataReader reader;
            DateTime dt = DateTime.Today.AddDays(-7);
            for (int i = 0; i < 10; i++) {
                string order;
                order = @"SELECT * FROM history.dbo.items WHERE commodity = " + i + " AND timestamp>= " + "'" + Convert.ToDateTime(start).ToString("yyyy-MM-dd HH:mm:ss") + "' AND timestamp<= " + "'" + Convert.ToDateTime(end).ToString("yyyy-MM-dd HH:mm:ss") + "'";
                reader = SM.reader(order);
                double sum = 0;
                double count = 0;
                while (reader.Read()) {
                    count++;
                    sum +=Double.Parse(reader.GetValue(3).ToString().Trim());
                }
                prices[i] = sum / count;
                reader.Close();

            }
            return prices;
        }
    }
}


