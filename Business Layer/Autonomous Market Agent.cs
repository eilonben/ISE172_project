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
    public class Autonomous_Market_Agent
    {
        private RequestManager market = new RequestManager();
                
        public void Start()
        {
            MarketUserData userInfo = (MarketUserData)market.SendQueryUserRequest();
            foreach(KeyValuePair<string,int> entry in userInfo.commodities)
            {
                MarketCommodityOffer offer = (MarketCommodityOffer)market.SendQueryMarketRequest(Convert.ToInt32(entry.Key));
                if (offer.ask < 12)
                {
                    float spendable = userInfo.funds / 10;
                    int count = 1;
                    while ((count+1) * offer.ask < spendable)
                    {
                        count++;
                    }
                    if (offer.ask * count <= spendable)
                    {
                        market.SendBuyRequest(offer.ask, Convert.ToInt32(entry.Key), count);
                    }
                }
                if (offer.bid > 7 && entry.Value>0)
                {
                    int count = 1;
                    if((offer.bid>14)&&(count + 1 >= entry.Value))
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
                }
            }
        }
    }
}
