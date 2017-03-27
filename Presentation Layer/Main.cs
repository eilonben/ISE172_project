using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Presentation_Layer
{
    public class Main
    {
        public static void main(String[] args)
        {
            RequestManager rManager = new RequestManager();
            Console.WriteLine("Hello, please enter your request type number: 1-Buy, 2-Sell, 3-Cancle, 4-Query.");
            int type = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Thank you!");
            if (type == 1) //buy request
            {
                Console.WriteLine("You chose to buy commodities. To proceed, please enter the Commodity ID.");
                int commodityID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Now enter the amount of commodities you would like to purchase.");
                int ammount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What is the price you want to pay?");
                int price = Convert.ToInt32(Console.ReadLine());
                int output = rManager.SendBuyRequest(price, commodityID, ammount);
                if (output == -1)
                    Console.WriteLine(rManager.error);
                else
                    Console.WriteLine("Congratulations! Your request was successful! Your request ID is:" + output);
            }
            if (type == 2) //sell request
            {
                Console.WriteLine("You chose to sell commodities. Please enter the Commodity ID.");
                int commodityID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Now enter the amount of commodities you would like to sell.");
                int ammount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What is the price you would like to receive?");
                int price = Convert.ToInt32(Console.ReadLine());
                int output = rManager.SendSellRequest(price, commodityID, ammount);
                if (output == -1)
                    Console.WriteLine(rManager.error);
                else
                    Console.WriteLine("Congratulations! Your request was successful! Your request ID is:" + output);
            }
            if (type == 3) //cancellation request
            {
                Console.WriteLine("Please enter the Buy or the Sell Rrequest ID of the request you want to cancel.");
                int requestID = Convert.ToInt32(Console.ReadLine());
                bool ans = rManager.SendCancelBuySellRequest(requestID);
                if (ans)
                    Console.WriteLine("Congratulations! Your cancellation request was successful.");
                else
                    Console.WriteLine("Our apologies, your cancellation request did not complete. If the request was yet to be canceled, please make sure that the Buy or the Sell Rrequest ID that you enterd was typed correctly, and try again.");
            }
            if (type == 4) //query request
            {
                Console.WriteLine("What kind of query would you like? Please type the relevant number: 1-Query sell/buy, 2-Query user, 3-Query market.");
                int queryType = Convert.ToInt32(Console.ReadLine());
                if (queryType == 1) //query sell/buy
                {
                    Console.WriteLine("Please enter the Buy or the Sell Rrequest ID.");
                    int requestID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(rManager.SendQueryBuySellRequest(requestID));
                }
                if (queryType == 2) //query user
                {
                    Console.WriteLine(rManager.SendQueryUserRequest());
                }
                if (queryType == 3) //query market
                {
                    Console.WriteLine("Please enter the Commodity ID.");
                    int commodityID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(rManager.SendQueryMarketRequest(commodityID));
                }
            }
        }
    }
}
