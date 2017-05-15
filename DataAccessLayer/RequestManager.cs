using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.DataEntries;
using MarketClient.Utils;


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
        
        public bool SendCancelBuySellRequest(int id) // The cancel request function using the CancelRequest class
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            CancelRequest request = new CancelRequest();
            request.type = "cancelBuySell";
            request.id = id;
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            string response = HTTPClient.SendPostRequest(url, user, token, request);
            if (response.Equals("Ok"))
                return true;
            else
            {
                error = response;
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
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            bool eflag=false;
            string response = "";
            try
            {
               response = HTTPClient.SendPostRequest(url, user, token, request);
               Convert.ToInt32(response);
            }
            catch (Exception e)
            {
                error = response;
                eflag = true;
            }
            if (!eflag)
                return Convert.ToInt32(response);
            else
            {
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
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            bool eflag = false;
            string response = "";
            try
            {
                response = HTTPClient.SendPostRequest(url, user, token, request);
                Convert.ToInt32(response);
            }
            catch (Exception e)// catching the exception, and sending back the response
            {
                error = response;
                eflag = true;
            }
            if (!eflag)
                return Convert.ToInt32(response);
            else
            {
                return -1;
            }
        }

        public IMarketItemQuery SendQueryBuySellRequest(int id) // The query buy\sell request function using the QuerySellBuyRequest class and returning a IMarketItemQuery object
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            QuerySellBuyRequest request = new QuerySellBuyRequest();
            request.type = "queryBuySell";
            request.id = id;
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            bool eflag = false;
            MarketItemQuery response = null;
            try
            {
               response = HTTPClient.SendPostRequest<QuerySellBuyRequest, MarketItemQuery>(url, user, token, request);
                
            }
            catch(Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
                return null;
            else
            {
                return response;
            }
        }
        public IMarketUserData SendQueryUserRequest() //The query user request function using the QueryUserRequest class and returning a IMarketUserData object
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            QueryUserRequest request = new QueryUserRequest();
            request.type = "queryUser";
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            MarketUserData response = null;
            bool eflag = false; 
            try
            {
                response = HTTPClient.SendPostRequest<QueryUserRequest, MarketUserData>(url, user, token, request);
            }
            catch (Exception e)
            { 
                error = e.Message;
                eflag = true;
            }
            if (eflag)
                return null;
            else
            {
                return response;
            }
        }

        public IMarketCommodityOffer SendQueryMarketRequest(int commodity) //The query market request function using the QueryMarketRequest class and returning a IMarketCommodityOffer object
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            QueryMarketRequest request = new QueryMarketRequest();
            request.type = "queryMarket";
            request.commodity = commodity;
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            MarketCommodityOffer response = null;
            bool eflag = false;
            try
            {
                response = HTTPClient.SendPostRequest<QueryMarketRequest, MarketCommodityOffer>(url, user, token, request);
            }
            catch (Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
                return null;
            else
            {
                return response;
            }

        }
        public List<AllCommodityOffer> SendAllMarketQuery()
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            AllMarketRequest request = new AllMarketRequest();
            request.type = "queryAllMarket";
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            List<AllCommodityOffer> response = new List<AllCommodityOffer>();
            bool eflag = false;
            try
            {
                response = HTTPClient.SendPostRequest<AllMarketRequest, List<AllCommodityOffer>>(url, user, token, request);
            }
            catch (Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
                return null;
            else
            {
                return response;
            }

        }
        public List<MarketUserRequests> SendUserRequestsQuery()
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            UserRequestsQuery request = new UserRequestsQuery();
            request.type = "queryAllMarket";
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            List<MarketUserRequests> response = new List<MarketUserRequests>();
            bool eflag = false;
            try
            {
                response = HTTPClient.SendPostRequest<UserRequestsQuery, List<MarketUserRequests>>(url, user, token, request);
            }
            catch (Exception e)
            {
                error = e.Message;
                eflag = true;
            }
            if (eflag)
                return null;
            else
            {
                return response;
            }

        }
    }
}
