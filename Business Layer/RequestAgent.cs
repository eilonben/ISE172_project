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
        ILog myLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        

        public string buyCommodities(int price, int commodity, int amount) {
            int response = rm.SendBuyRequest(price, commodity, amount);
            if (response == -1)
            {
                myLogger.Error("You asked to buy "+amount+" commodities of type "+commodity+" in the price of "+price+ ". An error has occured and your Request was incomplete. more info:" + rm.error);
                return ("An error has occured and your Request was incomplete. more info:" + rm.error);
            }
            myLogger.Error("You asked to buy " + amount + " commodities of type " + commodity + " in the price of " + price + ". Your Request has been successful. Request ID:" + response);
            return ("Your Request has been successful. Request ID:" + response);
            
        }

        public string sellCommodities(int price, int commodity, int amount)
        {
            int response = rm.SendSellRequest(price, commodity, amount);
            if (response == -1)
            {
                myLogger.Error("You asked to sell "+amount+" commodities of type "+commodity+" in the price of "+price+". An error has occured and your Request was incomplete.more info: " + rm.error);
                return ("An error has occured and your Request was incomplete. more info:" + rm.error);
            }
            myLogger.Info("You asked to sell "+amount+" commodities of type "+commodity+" in the price of "+price+". Your Request has been successful. Request ID:" + response);
            return ("Your Request has been successful. Request ID:" + response);
        }

        public string cancelRequest(int id)
        {
            bool response = rm.SendCancelBuySellRequest(id);
            if (response)
            {
                myLogger.Info("You asekd to cancel the Request "+id+ ". Request was canceled successfuly");
                return ("Request was canceled successfuly");
            }
            myLogger.Error("You asked to cancel the Request " + id + ". An Error has occured. More info:" + rm.error);    
            return ("An Error has occured. More info:" + rm.error);       
        }

        public string QueryBuySell(int id) 
        {
            var response = rm.SendQueryBuySellRequest(id);
            if (response == null)
            {
                myLogger.Error("You requested Query Buy/Sell " + id + ". An error has occured. More info: " + rm.error);
                return ("An error has occured. More info:" + rm.error);
            }
            myLogger.Info("You requested Query Buy/Sell "+id+". " + response.ToString());
            return response.ToString();
            
        }

        public string CommodityQuery(int id)
        {
            var response = rm.SendQueryMarketRequest(id);
            if (response == null)
            {
                myLogger.Error("You requested Commodity Query "+id+ ". An error has occured. More info:" + rm.error);
                return ("An error has occured. more info:" + rm.error);
            }
            myLogger.Info("You requested Commodity Query " + id + ". "+response.ToString());    
            return response.ToString();
        }

        public string UserQuery()
        {
            var response = rm.SendQueryUserRequest();
            if (response == null)
            {
                myLogger.Error("You requested User Query. An error has occured. More info: "+rm.error);
                return ("An error has occured. More info: " + rm.error);
            }
            myLogger.Info("You requested User Query. "+response.ToString());   
            return response.ToString();
        }
        public string AllMarketQuery()
        {
            var response = rm.SendAllMarketQuery();
            if (response == null)
            {
                myLogger.Error("You requested user All Market Query. An error has occured. More info: " + rm.error);
                return ("An error has occured. more info:" + rm.error);
            }
            myLogger.Info("You requested All Market Query. " + response.ToString());   
            return response.ToString();
        }

        public string UserRequestsQuery()
        {
            var response = rm.SendUserRequestsQuery();
            if (response == null)
            {
                myLogger.Error("You requested User Request Query. An error has occured. More info: " + rm.error);
                return ("An error has occured. more info:" + rm.error);
            }
            myLogger.Info("You requested User Requewst Query. " + response.ToString());
            return response.ToString();
        }
    }
}