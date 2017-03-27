using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class BuyRequest
    {
        public const string type = "buy";
        public int commodity;
        public int amount;
        public int price;
    }
}