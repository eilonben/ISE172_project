using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
     public class SellRequest
    {
        public const string type = "sell";
        public int commodity;
        public int amount;
        public int price;
    }
}
