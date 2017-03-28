using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace DataAccessLayer
{
    public class MarketCommodityOffer : MarketClient.DataEntries.IMarketCommodityOffer
    {
        public int ask;
        public int bid;

        public string toString()
        {
            string output;
            output = "Commodity Status:" + "\r\n";
            output += "Best ask price: " + ask + " Best bid price: " + bid;
            return output;
        }
    }
}
