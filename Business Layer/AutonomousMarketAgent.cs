using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MarketClient;
using MarketClient.DataEntries;
using System.Timers;
using System.Data.SqlClient;

namespace Business_Layer
{
    public class AutonomousMarketAgent
    {
        private static RequestManager market = new RequestManager();
        private static Timer aTimer;

        public AutonomousMarketAgent()//This function responsible on the timer, to restart him and call the necessary function
        {
            aTimer = new Timer();
            aTimer.Interval = 10000;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.AutoReset = true;
        }

        public void start()
        {
            aTimer.Enabled = true;
        }

        public void stop()
        {
            aTimer.Enabled = false;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)//this function is responsible on the connection with the server,with rules when to buy or sell stocks
        {

            int actionCount = 0;
            while (actionCount < 19)
            {

                MarketUserData userInfo = (MarketUserData)market.SendQueryUserRequest();
                actionCount++;
                foreach (KeyValuePair<string, int> entry in userInfo.commodities)//the loop run on all the commodities we have to sell/buy any of them
                {
                    if (actionCount < 19)
                    {
                        MarketCommodityOffer offer = (MarketCommodityOffer)market.SendQueryMarketRequest(Convert.ToInt32(entry.Key));
                        actionCount++;
                        if (offer.ask < 12 && actionCount < 19)
                        {
                            float spendable = userInfo.funds / 10;
                            int count = 1;
                            while ((count + 1) * offer.ask < spendable)
                            {
                                count++;
                            }
                            if (offer.ask * count <= spendable)
                            {
                                actionCount++;
                                market.SendBuyRequest(offer.ask, Convert.ToInt32(entry.Key), count);
                            }
                        }
                        if (offer.bid > 7 && entry.Value > 0 && actionCount < 19)
                        {
                            int count = 1;
                            if ((offer.bid > 14) && (count + 1 >= entry.Value))
                            {
                                count++;
                                if (offer.bid > 18 && (count + 1 >= entry.Value))
                                {
                                    count++;
                                    if (offer.bid > 22 && (count + 1 >= entry.Value))
                                    {
                                        count++;
                                        while (entry.Value > 0)
                                            count++;
                                    }
                                }
                            }
                            market.SendSellRequest(offer.bid, Convert.ToInt32(entry.Key), count);
                            actionCount++;
                        }
                    }
                }
            }
        }

        public int setAverage()
        {
            SQLmanager myManager = new SQLmanager();
            String prices = "";
            String amounts = "";
            Double calculator = 0;
            Double sumAmounts = 0;
            SqlDataReader reader;
            for (int i = 0;i< 9; i++){
                String order = @"SELECT TOP 20 * From history.dbo.items WHERE commodity = " + i;
                reader = myManager.reader(order);
                while (reader.Read())
                {
                    Double price = 0;
                    Double amount = 0;
                    prices = reader.GetValue(3).ToString().Trim();
                    price = Double.Parse(prices);
                    amounts = reader.GetValue(2).ToString().Trim();
                    amount = Double.Parse(amounts);
                    sumAmounts += amount;
                    calculator += price * amount;
                }
                if (sumAmounts != 0)
                    calculator = calculator / sumAmounts;
                
            }
            
        }
    }
}
