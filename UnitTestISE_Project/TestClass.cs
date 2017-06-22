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
using System.Data.SqlClient;

namespace UnitTestISE_Project
{
    [TestClass]
    public class TestClass
    {
        
        private static RequestManager market;
        private static RequestAgent rq;
        private int[] testing;
        private static MarketUserData userInfo;
        private SQLmanager sql;
        public AutonomousMarketAgent ama;

        [TestMethod]
        public void initial()
        {
            market = new RequestManager();
            rq = new RequestAgent();
            userInfo = (MarketUserData)market.SendQueryUserRequest();
            sql = new SQLmanager();
            ama = new AutonomousMarketAgent();
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
        public void TestSendQueryUserRequest()
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

        [TestMethod]
        public void testSQL()
        {
            SqlDataReader reader;
            String order = @"SELECT TOP 20 * From history.dbo.items WHERE commodity = " + 0;
            reader = sql.reader(order);
            
            String order2 = @"SELECT TOP 20 * From history.dbo.items WHERE commodity = " + "-7";
            reader = sql.reader(order2);
            Assert.Fail();

        }

        [TestMethod]
        public void testAverageSQL()
        {
            int output = ama.setAverage(1);
            Assert.IsTrue(output > 0);
        }

        [TestMethod]
        public void testHistoryLog()
        {
            string[] output = File.ReadAllLines("../../../history/history.log");
            string s = "";
            for (int i = 0; i < output.Length; i++)
                s += output[i] + "\n";
            Assert.IsTrue(s.Length > 0);
        }



    }
}
