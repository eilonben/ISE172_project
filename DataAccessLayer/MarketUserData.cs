using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace DataAccessLayer
{
    public class MarketUserData : MarketClient.DataEntries.IMarketUserData
    {
        public Dictionary<string, int> commodities;
        public float funds;
        public List<int> requests;

        public override string ToString()
        {
            string output;
            output = "User Trade Status:" + "\r\n";
            output += "Commodities: { ";
            foreach (KeyValuePair<string, int> kvp in commodities)
            {
                output+= (kvp.Key)+ " ,";
            }
            output = output.Substring(0, output.Length - 1);
            output += " } Remaining funds:" + funds + " requests id's: { ";
            foreach ( int r in requests)
            {
                output += (r) + " ,";
            }
            output = output.Substring(0, output.Length - 1);
            output+= " }";
            return output;
        }
    }
}
