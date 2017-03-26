using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.Utils;


namespace DataAccessLayer
{
    public class RequestManager:IMarketClient
     {
        private const string url="http://ise172.ise.bgu.ac.il";
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

           public int SendBuyRequest(int price, int commodity, int amount) 
           {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            BuyRequest request = new BuyRequest();
            request.price = price;
            request.commodity = commodity;
            request.amount = amount;
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            string response = HTTPClient.SendPostRequest(url, user, token, request);
            return Convert.ToInt32(response);
               
           }
        public int SendSellRequest(int price, int commodity, int amount)
        {
            SimpleHTTPClient HTTPClient = new SimpleHTTPClient();
            SellRequest request = new SellRequest();
            request.price = price;
            request.commodity = commodity;
            request.amount = amount;
            string token = SimpleCryptoLibrary.CreateToken(user, PrivateKey);
            string response = HTTPClient.SendPostRequest(url, user, token, request);
            return Convert.ToInt32(response);
        }
    }
}
