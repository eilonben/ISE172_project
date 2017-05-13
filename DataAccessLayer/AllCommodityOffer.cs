using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AllCommodityOffer
    {
        public MarketCommodityOffer info;
        public int id;

        public override string ToString()
        {
            return ("{info: {ask: " + info.ask + ", bid: " + info.bid + "}, id: " + id + "}");
        }
    }
}
