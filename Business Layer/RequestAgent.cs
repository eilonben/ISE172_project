using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using MarketClient;
using MarketClient.DataEntries;
using log4net;

namespace Business_Layer
{
    public class RequestAgent
    {
        RequestManager rm = new RequestManager();
        ILog history = LogManager.GetLogger("History");

        public string buyCommodities(int price, int commodity, int amount)
        {
            int response = rm.SendBuyRequest(price, commodity, amount);
            if (response == -1)
            {
                history.Error("You asked to buy " + amount + " commodities of type " + commodity + " in the price of " + price + ". An error has occured and your Request was incomplete. more info:" + rm.error);
                return ("An error has occured and your Request was incomplete. more info:" + rm.error);
            }
            history.Info("You asked to buy " + amount + " commodities of type " + commodity + " in the price of " + price + ". Your Request has been successful. Request ID:" + response);
            return ("Your Request has been successful. Request ID:" + response);

        }

        public string sellCommodities(int price, int commodity, int amount)
        {
            int response = rm.SendSellRequest(price, commodity, amount);
            if (response == -1)
            {
                history.Error("You asked to sell " + amount + " commodities of type " + commodity + " in the price of " + price + ". An error has occured and your Request was incomplete.more info: " + rm.error);
                return ("An error has occured and your Request was incomplete. more info:" + rm.error);
            }
            history.Info("You asked to sell " + amount + " commodities of type " + commodity + " in the price of " + price + ". Your Request has been successful. Request ID:" + response);
            return ("Your Request has been successful. Request ID:" + response);
        }

        public string cancelRequest(int id)
        {
            bool response = rm.SendCancelBuySellRequest(id);
            if (response)
            {
                history.Info("You asekd to cancel the Request " + id + ". Request was canceled successfuly");
                return ("Request was canceled successfuly");
            }
            history.Error("You asked to cancel the Request " + id + ". An Error has occured. More info:" + rm.error);
            return ("An Error has occured. More info:" + rm.error);
        }

        public string QueryBuySell(int id)
        {
            var response = rm.SendQueryBuySellRequest(id);
            if (response == null)
            {
                history.Error("You requested Query Buy/Sell " + id + ". An error has occured. More info: " + rm.error);
                return ("An error has occured. More info:" + rm.error);
            }
            history.Info("You requested Query Buy/Sell " + id + ". " + response.ToString());
            return response.ToString();

        }

        public string CommodityQuery(int id)
        {
            var response = rm.SendQueryMarketRequest(id);
            if (response == null)
            {
                history.Error("You requested Commodity Query " + id + ". An error has occured. More info:" + rm.error);
                return ("An error has occured. more info:" + rm.error);
            }
            history.Info("You requested Commodity Query " + id + ". " + response.ToString());
            return response.ToString();
        }

        public string UserQuery()
        {
            var response = rm.SendQueryUserRequest();
            if (response == null)
            {
                history.Error("You requested User Query. An error has occured. More info: " + rm.error);
                return ("An error has occured. More info: " + rm.error);
            }
            history.Info("You requested User Query. " + response.ToString());
            return response.ToString();
        }
        public string AllMarketQuery()
        {
            var response = rm.SendAllMarketQuery();
            if (response == null)
            {
                history.Error("An error has occured. more info:" + rm.error);
                return ("An error has occured. more info:" + rm.error);
            }
                
            string output = "Status of all commodities: \n";
            foreach (AllCommodityOffer e in response)
            {
                output += e.ToString();
                output += "\n";
            }
            history.Info("An AllMarketQuery was applied. result: \n");
            history.Info(output);
            return output;
        }

        public string UserRequestsQuery()
        {
            List<MarketUserRequests> response = rm.SendUserRequestsQuery();
            if (response == null)
            {
                history.Error("An error has occured. more info:" + rm.error);
                return ("An error has occured. more info:" + rm.error);
            }
                
            string output = "";
            if (response.Count == 0)
            {
                history.Error("User Request Query has been applied. You had no active requests.");
                return "You have no active requests.";
            }
                
            foreach (MarketUserRequests e in response) {
                output += "All The requests of user32: \n";
                output += e.ToString();
                output += "\n";
            }
            history.Info("A UserRequestQuery was applied. result: \n");
            history.Info(output);
            return output;
        }

    }
}