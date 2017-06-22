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
        SQLmanager myManager;

        public AutonomousMarketAgent()//This function responsible on the timer, to restart him and call the necessary function
        {
            aTimer = new Timer();
            myManager = new SQLmanager();
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

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            int actionCount = 0;
            while (actionCount < 19)
            {
                MarketUserData userInfo = (MarketUserData)market.SendQueryUserRequest();
                actionCount++;
                foreach (KeyValuePair<string, int> entry in userInfo.commodities)
                {
                    int commodityAverage = setAverage(Convert.ToInt32(entry.Key));
                    
                    if (actionCount < 19)
                    {
                        MarketCommodityOffer offer = (MarketCommodityOffer)market.SendQueryMarketRequest(Convert.ToInt32(entry.Key));
                        actionCount++;
                        if (isUpOrDown(Convert.ToInt32(entry.Key)))//check if the price of the last deals is on ascent or on descent
                        {
                            double currAverage = offer.ask / commodityAverage;//we are lokking for the relation between the current ask to the average to decide if we want to buy 
                            if (currAverage < 2.5 && actionCount < 19)
                            {
                                float spendable = userInfo.funds / 10;
                                int count = 1;
                                while ((count + 1) * offer.ask <= spendable)
                                {
                                    if (currAverage < 1.5 && (count + 2) * offer.ask <= spendable)
                                    {
                                        count += 2;
                                        if (currAverage < 0.8 && (count + 2) * offer.ask <= spendable)
                                        {
                                            count += 2;
                                        }
                                    }
                                }
                                if (offer.ask * count <= spendable)
                                {
                                    actionCount++;
                                    market.SendBuyRequest(offer.ask, Convert.ToInt32(entry.Key), count);
                                }
                            }
                        }
                        else
                        {
                            double currAverage = offer.bid / commodityAverage;////we are lokking for the relation between the current bid to the average to decide if we want to sell 
                            int commodityLeft = entry.Value;
                            if (currAverage > 0.5 && commodityLeft > 0 && actionCount < 19)
                            {
                                int count = 1;
                                commodityLeft--;
                                if (currAverage > 1 && (commodityLeft >= count + 1))
                                {
                                    count++;
                                    commodityLeft--;
                                    if (currAverage > 1.5 && (commodityLeft >= count + 1))
                                    {
                                        commodityLeft--;
                                        while (commodityLeft > 0)
                                        {
                                            count++;
                                            commodityLeft--;
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
        }

        public int setAverage(int commodity)//calculate the average of the last 20 deals of each commodity from the last week
        {
            String prices = "";
            String amounts = "";
            Double calculator = 0;
            Double sumAmounts = 0;
            DateTime dateTime = DateTime.Today.AddDays(-7);
            String order = @"SELECT TOP 20 * FROM history.dbo.items WHERE commodity = " + commodity;
            SqlDataReader reader = myManager.reader(order);
            while (reader.Read())
            {
                double price = 0;
                double amount = 0;
                prices = reader.GetValue(3).ToString().Trim();
                price = Double.Parse(prices);
                amounts = reader.GetValue(2).ToString().Trim();
                amount = Double.Parse(amounts);
                sumAmounts += amount;
                calculator += price * amount;
            }
            if (sumAmounts != 0)
                calculator = calculator / sumAmounts;
            reader.Close();
            return (int)calculator;
            
        }

        public Boolean isUpOrDown(int commodity)//the function checks whether in the last 20 deals the stock is on ascent or descent 
        {
            Boolean ans;
            double differenceDown = 0;
            double differenceUp = 0;
            double countDown = 1;
            double countUp = 1;
            DateTime dateTime = DateTime.Today.AddDays(-5);
            String order = @"SELECT TOP 20 * From history.dbo.items WHERE commodity = " +
                commodity + " and timestamp >=" + "'" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY timestamp DESC";
            SqlDataReader reader = myManager.reader(order);
            double first = 0;
            string firstValue;
            if (reader.Read())//get the first price value
            {
                firstValue = reader.GetValue(3).ToString().Trim();
                first = Double.Parse(firstValue);
            }
            string tmp;
            double tmpPrice = 0;
            while (reader.Read())
            {
                tmp = reader.GetValue(3).ToString().Trim();
                tmpPrice = Double.Parse(tmp);
                if (tmpPrice > first)//if the price is on ascent
                {
                    differenceUp = differenceUp + (tmpPrice - first);
                    countUp++;
                }

                else if (tmpPrice < first)// if the price is on descent
                {
                    differenceDown = differenceDown + (first - tmpPrice);
                    countDown++;
                }
                first = tmpPrice;
            }
            if (differenceUp > differenceDown)
                ans = true;
            else
                ans = false;
            reader.Close();
            return ans;
        }
    }
}

