using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.DataEntries;
using MarketClient.Utils;
using log4net;


namespace DataAccessLayer
{
    public class RequestManager : IMarketClient
    {
        private const string url = "http://ise172.ise.bgu.ac.il";
        private const string user = "user32";
        private const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
        MIICXQIBAAKBgQDkV2AG1vqzPnMv2jjfD9Z3tTwXYRp4Vwdo01IeoHohwU5J2bD1
        /VXiPxd7SkwGsEPK+K+rwQcL/rtCf1VSbxu26yW1pUI6BW9iAyewJfuk6RRGwnwq
        6HPlvScCXnHx3S91LMHG+WPmLT/Y7VYA+rgr0lC9NhJAu8W7DkDkrxPEOQIDAQAB
        AoGBAMhLOIlnZAt8uS99fSt1SgxBZo+fdseel3pE+6Cv5dHcLZ8sHET6zq4h56gX
        OO8ZCK5vTDEdpd/It1wSM7aWjbhTCNmKiNxG8K0qV0bcMD0usulC8cKkP0sB5qzg
        jT9hWlC46lBkvVhEWDfsHUerBZyuoCY4hS2iYRRhpR4THfaBAkEA78yeiF5MAB+r
        XtQ4w7xwdITAk8QRA7O4KdqTb3guDfQCYVvW+bp45UKGTQi7NoMd/Jgv3rcmL8rg
        RKvkwy5HMQJBAPPElmaesCdSDitJX+Hcew5q6QfHyqLEqUeIl6OWUjp75iKlDjV1
        GPdQRV4ZlwJIiJg5JbVSFvtVPMownOZFm4kCQQCyGBTxkJ7/RIYA8rqJ3IzkbKed
        1vMP/czcAMKY+feyUzPlXNEHPY+GLWcTFVX9QVnm/Jwo23sX6aOwPL20m80xAkA0
        hwYJsuQudOYMudDpcIMrxinUvV6S2GHJwks6uueZJp2elYaMSmFI2Yk5D7aUjWCx
        vI69laTSH7nrr7H/hLxRAkA7YOf9KdlHgHI/fUc0oVGsjFYle7XQMRSdLgQc0nW2
        RBqA5j2CGRy/yTVv6RIDB/aueJc+NaopqxJ4lHCvkxv3
        -----END RSA PRIVATE KEY-----";
        public string error;
        private int nonce = 0;
        ILog logger = LogManager.GetLogger("Logger");


        public bool SendCancelBuySellRequest(int id) // The cancel request function using the CancelRequest class
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            CancelRequest request = new CancelRequest();
            request.type = "cancelBuySell";
            request.id = id;
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            string response = HTTPClient.SendPostRequest(url, user, token, myNonce, PrivateKey, request);
            if (response.Equals("Ok"))
            {
                logger.Info("A cancel request was sent to the server for ID "+id+ ". Successfully canceled.");
                return true;
            }
                
            else
            {
                error = response;
                logger.Error("A cancel request was sent to the server for ID " + id + ". An error occurred: "+error);
                return false;
            }
        }

        public int SendBuyRequest(int price, int commodity, int amount)// The buy request function using the BuyRequest class
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            BuyRequest request = new BuyRequest();
            request.type = "buy";
            request.price = price;
            request.commodity = commodity;
            request.amount = amount;
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            bool eflag=false;
            string response = "";
            try
            {
               response = HTTPClient.SendPostRequest(url, user, token, myNonce, PrivateKey, request);
               Convert.ToInt32(response);
            }
            catch (Exception e)
            {
                error = response;
                eflag = true;
            }
            if (!eflag)
            {
                int output = Convert.ToInt32(response);
                logger.Info("A buy request was sent to the server for commodity id " + commodity + ", amount " + amount + ", in the price of " + price + ". The buy was succesful, the request ID was " + output);
                return output;
            }
                
            else
            {
                logger.Error("A buy request was sent to the server for commodity id " + commodity + ", amount " + amount + ", in the price of " + price + ". An error occurred: " + error);
                return -1;
            }

        }
        public int SendSellRequest(int price, int commodity, int amount)// The sell request function using the SellRequest class
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            SellRequest request = new SellRequest();
            request.type = "sell";
            request.price = price;
            request.commodity = commodity;
            request.amount = amount;
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            bool eflag = false;
            string response = "";
            try
            {
                response = HTTPClient.SendPostRequest(url, user, token, myNonce, PrivateKey, request);
                Convert.ToInt32(response);
            }
            catch (Exception e)// catching the exception, and sending back the response
            {
                error = response;
                eflag = true;
            }
            if (!eflag)
            {
                int output = Convert.ToInt32(response);
                logger.Info("A sell request was sent to the server for commodity ID " + commodity + ", amount " + amount + ", in the price of" + price + ". The sell was succesful, the sell ID was " + output);
                return output;
            }
                
            else
            {
                logger.Error("A sell request was sent to the server for commodity ID " + commodity + ", amount " + amount + ", in the price of" + price + ". An error occurred.");
                return -1;
            }
        }

        public IMarketItemQuery SendQueryBuySellRequest(int id) // The query buy/sell request function using the QuerySellBuyRequest class and returning a IMarketItemQuery object
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            QuerySellBuyRequest request = new QuerySellBuyRequest();
            request.type = "queryBuySell";
            request.id = id;
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            bool eflag = false;
            MarketItemQuery response = null;
            try
            {
               response = HTTPClient.SendPostRequest<QuerySellBuyRequest, MarketItemQuery>(url, user, token, myNonce,PrivateKey, request);
                
            }
            catch(Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
            {
                logger.Error("A query buy/sell request was sent to the server for commodity ID " + id + ". An error occurred: "+error);
                return null;
            }
                
            else
            {
                logger.Info("A query buy/sell request was sent to the server for commodity ID " + id + ". The response from the server was: "+response);
                return response;
            }
        }
        public IMarketUserData SendQueryUserRequest() //The query user request function using the QueryUserRequest class and returning a IMarketUserData object
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            QueryUserRequest request = new QueryUserRequest();
            request.type = "queryUser";
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            MarketUserData response = null;
            bool eflag = false;
            try
            {
                response = HTTPClient.SendPostRequest<QueryUserRequest, MarketUserData>(url, user, token, myNonce, PrivateKey, request);
            }
            catch (Exception e)
            { 
                error = e.Message;
                eflag = true;
            }
            if (eflag)
            {
                logger.Error("A query user request was sent to the server. An error occurred: " + error);
                return null;
            }
                
            else
            {
                logger.Info("A query user request was sent to the server. The response from the server was: " + response);
                return response;
            }
        }

        public IMarketCommodityOffer SendQueryMarketRequest(int commodity) //The query market request function using the QueryMarketRequest class and returning a IMarketCommodityOffer object
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            QueryMarketRequest request = new QueryMarketRequest();
            request.type = "queryMarket";
            request.commodity = commodity;
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            MarketCommodityOffer response = null;
            bool eflag = false;
            
            try
            {
                response = HTTPClient.SendPostRequest<QueryMarketRequest, MarketCommodityOffer>(url, user, token, myNonce, PrivateKey, request);
            }
            catch (Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
            {
                logger.Error("A query market request was sent to the server for commodity ID " + commodity + ". An error occurred: " + error);
                return null;
            }
                
            else
            {
                logger.Info("A query market request was sent to the server for commodity ID " + commodity + ". The response from the server was: " + response);
                return response;
            }

        }

        public List<AllCommodityOffer> SendAllMarketQuery()
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            AllMarketRequest request = new AllMarketRequest();
            request.type = "queryAllMarket";
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            List<AllCommodityOffer> response = new List<AllCommodityOffer>();
            bool eflag = false;
            
            try
            {
                response = HTTPClient.SendPostRequest<AllMarketRequest, List<AllCommodityOffer>>(url, user, token, myNonce, PrivateKey, request);
            }
            catch (Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
            {
                logger.Error("The server received a SendAllMarketQuery request. An error occurred: "+error);
                return null;
            }
                
            else
            {
                logger.Info("The server received a SendAllMarketQuery request.");
                return response;
            }

        }

        public List<MarketUserRequests> SendUserRequestsQuery()
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            UserRequestsQuery request = new UserRequestsQuery();
            request.type = "queryUserRequests";
            int uniqeNonce = (nonce * 2) + 1;//uniqe way to represent the specific nonce
            String myNonce = "" + uniqeNonce;
            nonce++;
            string token = SimpleCryptoLibrary.CreateToken(user + "_" + myNonce, PrivateKey);
            List<MarketUserRequests> response = new List<MarketUserRequests>();
            bool eflag = false;

            try
            {
                response = HTTPClient.SendPostRequest<UserRequestsQuery, List<MarketUserRequests>>(url, user, token, myNonce, PrivateKey, request);
            }
            catch (Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
            {
                logger.Error("The server received a SendUserRequestsQuery request. An error occurred: " + error);
                return null;
            }
                
            else
            {
                logger.Info("The server received a SendUserRequestsQuery request.");
                return response;
            }
        }
    }
}
