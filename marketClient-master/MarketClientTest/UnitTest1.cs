using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient;
using MarketClient.Utils;
namespace MarketClientTest
{
    [TestClass]
    public class UnitTest1
    {
        // fill those variable with our own data
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user32";
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


        
        public void TestSimpleHTTPPost()
        {
            // Attantion!, this code is not good practice! this was made for the sole purpose of being an example.
            // A real good code, should use defined classes and and not hardcoded values!
            SimpleHTTPClient client = new SimpleHTTPClient();
            var request = new{
                type = "queryUser",
            };
            string response = client.SendPostRequest(Url,User,SimpleCryptoLibrary.CreateToken(User,PrivateKey), request);
            Trace.Write($"Server response is: {response}");
        }

        
        public void TestObjectBasedHTTPPost()
        {
            // This test query a diffrent site (not the MarketServer)! it's only for demostration.
            // this site doenst accept authentication, it only returns objects.
            string url = "http://ip.jsontest.com/";
            SimpleHTTPClient client = new SimpleHTTPClient();
            IpAddress ip = new IpAddress {Ip = "8.8.8.8"};
            IpAddress response = client.SendPostRequest<IpAddress,IpAddress>(url, null, null, ip);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Ip);
            Trace.Write($"Server response is: {response.Ip}");
        }

        private class IpAddress
        {
            public string Ip { get; set; }
        }
    }
}
