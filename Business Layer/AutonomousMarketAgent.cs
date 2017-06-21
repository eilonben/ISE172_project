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
        SQLmanager myManager = new SQLmanager();

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

        /*public void OnTimedEvent(Object source, ElapsedEventArgs e)//this function is responsible on the connection with the server,with rules when to buy or sell stocks
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
        }*/

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            int actionCount = 0;

            MarketUserData userInfo = (MarketUserData)market.SendQueryUserRequest();
            actionCount++;
            foreach (KeyValuePair<string, int> entry in userInfo.commodities)
            {
                int commodityAverage = setAverage(entry.Value);

                if (actionCount < 19)
                {
                    MarketCommodityOffer offer = (MarketCommodityOffer)market.SendQueryMarketRequest(Convert.ToInt32(entry.Key));
                    actionCount++;
                    if (isUpOrDown(entry.Value))//check if the average of the last deals is on ascent or on descent
                    {
                        double currAverage = offer.ask / commodityAverage;
                        if (currAverage < 1.5 && actionCount < 19)
                        {
                            float spendable = userInfo.funds / 10;
                            int count = 1;
                            while ((count + 1) * offer.ask <= spendable)
                            {
                                if (currAverage < 0.5 && (count + 3) * offer.ask <= spendable)
                                {
                                    count += 3;
                                    if (currAverage < 0.3 && (count + 3) * offer.ask <= spendable)
                                    {
                                        count += 3;
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
                        double currAverage = offer.bid / commodityAverage;
                        if (currAverage > 0.5 && entry.Value > 0 && actionCount < 19)
                        {
                            int count = 1;
                            if (currAverage > 1 && (count + 3 >= entry.Value))
                            {
                                count += 3;
                                if (currAverage > 1.5 && (count + 1 >= entry.Value))
                                {
                                    while (entry.Value > 0)
                                        count++;
                                }
                            }
                            market.SendSellRequest(offer.bid, Convert.ToInt32(entry.Key), count);
                            actionCount++;
                        }
                    }
                }
            }
        }

        private int setAverage(int commodity)//calculate the average of the last 20 deals of each commodity from the last week
        {
            String prices = "";
            String amounts = "";
            Double calculator = 0;
            Double sumAmounts = 0;
            SqlDataReader reader;
            DateTime dateTime = DateTime.Today.AddDays(-7);
            String order = @"SELECT TOP 20 * FROM history.dbo.items WHERE commodity = " + commodity + " and timestamp >=" + "'" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            reader = myManager.reader(order);
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
            return (int)calculator;
        }

        private double minPriceWeekly(int commodity)
        {
            double minPriceWeekly;
            DateTime dateTime = DateTime.Today.AddDays(-5);
            SqlDataReader reader;
            String order = @"SELECT MIN (price) From history.dbo.items WHERE commodity = " + commodity + " and timestamp >=" + "'" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            reader = myManager.reader(order);
            string min = reader.GetValue(0).ToString().Trim();
            minPriceWeekly = Double.Parse(min);
            return minPriceWeekly;
        }

        private double maxPriceWeekly(int commodity)
        {
            double maxPriceWeekly;
            DateTime dateTime = DateTime.Today.AddDays(-5);
            SqlDataReader reader;
            String order = @"SELECT MAX (price) From history.dbo.items WHERE commodity = " + commodity + " and timestamp >=" + "'" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            reader = myManager.reader(order);
            string max = reader.GetValue(0).ToString().Trim();
            maxPriceWeekly = Double.Parse(max);
            return maxPriceWeekly;
        }



        private Boolean isUpOrDown(int commodity)
        {
            Boolean ans;
            int check = 0;
            double differenceDown = 0;
            double differenceUp = 0;
            double countDown = 1;
            double countUp = 1;
            DateTime dateTime = DateTime.Today.AddDays(-5);
            SqlDataReader reader;
            String order = @"SELECT TOP 100 * FROM history.dbo.items WHERE commodity = " + commodity + " and timestamp >=" + "'" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'" + " order by timestamp DESC";
            reader = myManager.reader(order);
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

                if (tmpPrice > first)
                {
                    check++;
                    differenceUp = differenceUp + (tmpPrice - first);
                    countUp++;
                }

                else if (tmpPrice < first)
                {
                    check--;
                    differenceDown = differenceDown + (first - tmpPrice);
                    countDown++;
                }
                first = tmpPrice;
            }
            if (differenceUp > differenceDown)
                ans = true;
            else
                ans = false;
            return ans;
        }
    }
}

