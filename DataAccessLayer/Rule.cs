using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class Rule
    {
        public String type;
        public int commodity;
        public int price;
        public int requestID;

        public Rule(String type, int commodity, int price)
        {
            this.type = type;
            this.commodity = commodity;
            this.price = price;
            requestID = 0;
        }

    }
}
