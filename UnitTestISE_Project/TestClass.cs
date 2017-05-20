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
        private int[] testing;
        private static MarketUserData userInfo;
        ILog history = LogManager.GetLogger("History");
        ILog logger = LogManager.GetLogger("Logger");

        [TestMethod]
        public void initial()
        {
            market = new RequestManager();
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

        public List<string> fileReading(bool file)//the function helps to connect with the history file and log file
        {
            String filePath;
            if (file == true)
                filePath = @"C:\Users\seifa\Desktop\לימודים\סמסטר ב'\ISE-Project-SSE-.git\history\history.log";
            else
                filePath = @"../../../Log/application.log";
            List<string> lines = File.ReadLines(filePath).ToList();
            return lines;
        }

        [TestMethod]
        public void TestSellRequestAndQuerySell()
        {
            testing = new int[2];
            market.SendBuyRequest(1, 1, 1);
            testing[0] = market.SendSellRequest(1, 1, 1);
            List<string> logcheck1 = fileReading(false);
            Assert.AreEqual(true, logcheck1.Last().Contains("sell"));
            List<string> historycheck1 = fileReading(true);
            Assert.AreEqual(true, historycheck1.Last().Contains("Your Request has been successful"));
            testing[1] = market.SendSellRequest(2147483647, 1, 1);
            List<string> historycheck2 = fileReading(true);
            Assert.AreEqual(true, historycheck2.Last().Contains(". An error has occured and your Request was incomplete. more info:"));
            Assert.AreEqual(null, market.SendQueryBuySellRequest(testing[1]).ToString().Contains((testing[1]).ToString()));
            market.SendCancelBuySellRequest(testing[0]);
            market.SendCancelBuySellRequest(testing[1]);
        }

        [TestMethod]
        public void TestBuyRequestAndQueryBuy()
        {
            testing = new int[2];
            testing[0] = market.SendBuyRequest(1, 1, 1);
            //List<string> logcheck1 = fileReading(false);
            //Assert.AreEqual(true, logcheck1.Last().Contains("successful"));
            List <string> historycheck1 = fileReading(true);
            Assert.AreEqual(true, historycheck1.Last().Contains("successful"));
            testing[1] = market.SendBuyRequest(2147483647, 1, 1);
            List<string> historycheck2 = fileReading(true);
            Assert.AreEqual(true, historycheck2.Last().Contains("An error"));
            Assert.AreEqual(true, market.SendQueryBuySellRequest(testing[0]).ToString().Contains((testing[0]).ToString()));
            market.SendCancelBuySellRequest(testing[0]);
            market.SendCancelBuySellRequest(testing[1]);
        }

        [TestMethod]
        public void TestCancelRequest()
        {
            testing = new int[4];
            for(int i = 0; i < testing.Length; i++)
            {
                testing[i] = market.SendBuyRequest(1, 1, 1);
            }
            for(int j = 0; j < testing.Length; j++)
            {
                market.SendCancelBuySellRequest(testing[j]);
                List<string> historycheck1 = fileReading(true);
                Assert.AreEqual(true, historycheck1.Last().Contains("Request was canceled successfuly"));
            }
        }

        [TestMethod]
        public void TestSendQueryUserReques()
        {
            MarketUserData info = (MarketUserData)market.SendQueryUserRequest();
            Assert.IsNotNull(info);
            //List<string> historycheck1 = fileReading(true);
           // Assert.AreEqual(true, historycheck1.Last().Contains("A query user request was sent to the server. The response from the server was: "));
        }

        [TestMethod]
        public void TestSendQueryMarketRequest()
        {
            QueryMarketRequest request = (QueryMarketRequest)market.SendQueryMarketRequest(555);
            Assert.IsNull(request);
        }
    }
}
