using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace DataAccessLayer
{
    public class MarketUserData : IMarketUserData
    {
        public Dictionary<string, int> commodities;
        public int funds;
        public List<int> requests;
    }
}
