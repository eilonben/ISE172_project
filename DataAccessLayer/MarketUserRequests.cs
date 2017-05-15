using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MarketUserRequests
    {
        public MarketItemQuery request;
        public int id;

        public override string ToString()
        {
            string output = "{request: {price: " + request.price + ", amount: " + request.amount + ", type: " + request.type + ", user: user32, commodity: " + request.commodity + "}, id:" + id + "}";
            return output;
        }
    }
}
