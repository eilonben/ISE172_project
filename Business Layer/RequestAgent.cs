using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Business_Layer
{
    public class RequestAgent
    {
        RequestManager rm = new RequestManager();

        public string buyCommodities(int price, int commodity, int amount) {
            int response = rm.SendBuyRequest(price, commodity, amount);
            if (response == -1)
                return ("An error has occured and your Request was incomplete. more info:" + rm.error);
            return ("Your Request has been successful. Request ID:" + response);
        }

        public string sellCommodities(int price, int commodity, int amount)
        {
            int response = rm.SendSellRequest(price, commodity, amount);
            if (response == -1)
                return ("An error has occured and your Request was incomplete. more info:" + rm.error);
            return ("Your Request has been successful. Request ID:" + response);
        }

        public string cancelRequest(int id)
        {
            bool response = rm.SendCancelBuySellRequest(id);
            if (response)
                return ("Request was canceled successfuly");
            return ("An Error has occured. more info:" + rm.error);       
        }
        //

    }
}