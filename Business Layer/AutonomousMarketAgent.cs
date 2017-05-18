using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MarketClient;
using MarketClient.DataEntries;
using System.Timers;


namespace Business_Layer
{
    public class AutonomousMarketAgent
    {
        private static RequestManager market = new RequestManager();
        private static Timer aTimer;

        public AutonomousMarketAgent()
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

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            int actionCount = 0;
            while (actionCount < 20)
            {

                MarketUserData userInfo = (MarketUserData)market.SendQueryUserRequest();
                actionCount++;
                foreach (KeyValuePair<string, int> entry in userInfo.commodities)
                {
                    if (actionCount < 20)
                    {
                        MarketCommodityOffer offer = (MarketCommodityOffer)market.SendQueryMarketRequest(Convert.ToInt32(entry.Key));
                        actionCount++;
                        if (offer.ask < 12 && actionCount < 20)
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
                        if (offer.bid > 7 && entry.Value > 0 && actionCount < 20)
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
    }
}
