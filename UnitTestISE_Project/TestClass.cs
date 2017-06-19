using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using MarketClient;
using MarketClient.DataEntries;
using Business_Layer;
using log4net;
using System.IO;

namespace UnitTestISE_Project
{
    [TestClass]
    public class TestClass
    {
        private static RequestManager market;
        private static RequestAgent rq;
        private int[] testing;
        private static MarketUserData userInfo;

        [TestMethod]
        public void initial()
        {
            market = new RequestManager();
            rq = new RequestAgent();
            userInfo = (MarketUserData)market.SendQueryUserRequest();
        }

        [TestMethod]
        public void TestBuyRequest()
        {
            int ans = market.SendBuyRequest(1, 1, 1);
            Assert.IsTrue(ans > 0);
            market.SendCancelBuySellRequest(ans);
            int currFunds = (int)userInfo.funds;
            try
            {
                int ans1 = market.SendBuyRequest(currFunds * 3, 1, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void TestSellRequest()
        {
            market.SendBuyRequest(10, 2, 1);
            int ans= market.SendSellRequest(1, 2, 1);
            Assert.IsTrue(ans > 0);
            market.SendCancelBuySellRequest(ans);
        }

        [TestMethod]
        public void TestSendQueryBuySellRequest()
        {
            testing = new int[3];
            testing[1] = market.SendBuyRequest(10, 2147483647, 2147483647);//try to buy wrong id of commodity,should fail
            Assert.AreEqual(true,testing[1]==-1);
            market.SendCancelBuySellRequest(testing[1]);
            testing[2] = market.SendSellRequest(1, 2147483647, 2147483647);//try to sell wrong id of commodity,should fail
            Assert.AreEqual(true, testing[2]==-1);
            market.SendCancelBuySellRequest(testing[2]);
        }

        [TestMethod]
        public void TestBuySellRequest()
        {
            testing = new int[3];
            testing[0] = market.SendBuyRequest(1, 1, 1);
            testing[1] = market.SendSellRequest(1, 1, 0);
            Assert.AreEqual(true, testing[1] == -1);
            testing[2] = market.SendSellRequest(10, 1, 1);
            Assert.AreEqual(true, testing[2] == -1);
            market.SendCancelBuySellRequest(testing[0]);
            market.SendCancelBuySellRequest(testing[1]);
            market.SendCancelBuySellRequest(testing[2]);
        }
 
        [TestMethod]
        public void TestCancelRequest()
        {
            int ans = market.SendBuyRequest(1, 1, 1);
            market.SendCancelBuySellRequest(ans);
            Assert.IsTrue(ans > 0);   
        }

        [TestMethod]
        public void TestSendQueryUserReques()
        {
            MarketUserData info = (MarketUserData)market.SendQueryUserRequest();
            Assert.IsNotNull(info);
        }

        [TestMethod]
        public void TestSendQueryMarketRequest()
        {
            QueryMarketRequest request = (QueryMarketRequest)market.SendQueryMarketRequest(555);
            Assert.IsNull(request);
        }
    }
}
