using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MarketClient;
using MarketClient.DataEntries;

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

        public string QueryBuySell(int id) 
        {
            var response = rm.SendQueryBuySellRequest(id);
            if (response == null)
                return ("An error has occured. more info:" + rm.error);
            return response.ToString();
        }

        public string CommodityQuery(int id)
        {
            var response = rm.SendQueryMarketRequest(id);
            if (response == null)
                return ("An error has occured. more info:" + rm.error);
            return response.ToString();
        }

        public string UserQuery()
        {
            var response = rm.SendQueryUserRequest();
            if (response == null)
                return ("An error has occured. more info:" + rm.error);
            return response.ToString();
        }
        public string AllMarketQuery()
        {
            var response = rm.SendAllMarketQuery();
            if (response == null)
                return ("An error has occured. more info:" + rm.error);
            string output = "Status of all commodities: \n";
            foreach (AllCommodityOffer e in response)
            {
                output += e.ToString();
                output += "\n";
            }
            return output;
        }

        public string UserRequestsQuery()
        {
            List<MarketUserRequests> response = rm.SendUserRequestsQuery();
            if (response == null)
                return ("An error has occured. more info:" + rm.error);
            string output = "";
            if (response.Count == 0)
                return "You have no active requests.";
            foreach (MarketUserRequests e in response) {
                output += "All The requests of user32: \n";
                output += e.ToString();
                output += "\n";
            }
            return output;
        }
    }
}