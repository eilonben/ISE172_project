﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace DataAccessLayer
{
    public class IMarketUserData : MarketClient.DataEntries.IMarketUserData
    {
        public Dictionary<string, int> commodities;
        public float funds;
        public List<int> requests;

        public string toString() {
            string output;
            output = "User Trade Status:" + "\r\n";
            output += "Commodities: {" + commodities + "} Remaining funds:" + funds + " requests id's: {" + requests + "}";
            return output;
        }
    }
}
