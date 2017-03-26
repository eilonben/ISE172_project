using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace DataAccessLayer
{
    public class MarketItemQuery : IMarketItemQuery
    {
        public int price;
        public int amount;
        public string type;
        public int commodity;

        public string toString()
        {
            string output;
            output = "Request status:"+ "\r\n";
            output += "Price: " + price + ", " + "Amount: " + amount + ", " + "Type: " + type + ", " + "Commodity: " + commodity + ".";
            return output;
        }
    }
}
