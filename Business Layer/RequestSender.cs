using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Layer
{
   public class RequestSender
    {
        RequestManager rm = new RequestManager();
        public string BuyCommodities(int price, int commodity, int amount) {
            int response = rm.SendBuyRequest(price,commodity,amount);
            if (response == -1)
                return ("Error : The Request was not successful. reason:"+rm.error);
            return ("Your Buy Request was successful. The Request ID is: " + response);
        }
    }
}
