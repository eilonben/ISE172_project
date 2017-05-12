using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class AllCommodityOffer
    {
        MarketCommodityOffer info;
        int id;

        public override string ToString()
        {
            return ("{info: {ask: " + info.ask + ", bid: " + info.bid + "}, id: " + id + "}");
        }
    }
}
