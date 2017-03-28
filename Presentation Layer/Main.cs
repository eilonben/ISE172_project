﻿using System;
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
            RequestManager rManager = new RequestManager();//creates an instance of the RequestManager class 
            Console.WriteLine("Hello, please enter your request type number: 1-Buy, 2-Sell, 3-Cancel, 4-Query.");
            String type = Console.ReadLine();
            while (!type.Equals("1") & !type.Equals("2") & !type.Equals("3") & !type.Equals("4"))//checking if input is valid
            {
                Console.WriteLine("It seems like your input is invalid, please enter an integer between 1 to 4");
                type = Console.ReadLine();
            }
            if (type.Equals("1")) //buy request
            {
                Console.WriteLine("You chose to buy commodities. To proceed, please enter the Commodity ID number.");
                String commodityID = Console.ReadLine();
                while (!isDigitsOnly(commodityID)) //checking if input is valid
                {
                    Console.WriteLine("The Commodity ID must be a number! Please enter a valid Commodity ID");
                    commodityID = Console.ReadLine();
                }
                int commodityNums = Convert.ToInt32(commodityID); //casting the String to int
                Console.WriteLine("Now enter the amount of commodities you would like to purchase.");
                String ammount = Console.ReadLine();
                while (!isDigitsOnly(ammount)) //checking if input is valid
                {
                    Console.WriteLine("The ammount must be a number! Please enter a valid amount");
                    ammount = Console.ReadLine();
                }
                int ammountNums = Convert.ToInt32(ammount); //casting the String to int
                Console.WriteLine("What is the price you want to pay?");
                String price = Console.ReadLine();
                while (!isDigitsOnly(price)) //checking if input is valid
                {
                    Console.WriteLine("The price must be a number! Please enter a valid price");
                    price = Console.ReadLine();
                }
                int priceNums = Convert.ToInt32(price); //casting the String to int
                int output = rManager.SendBuyRequest(priceNums, commodityNums, ammountNums);
                if (output == -1)
                    Console.WriteLine(rManager.error);
                else
                    Console.WriteLine("Congratulations! Your request was successful! Your request ID is:" + output);
            }
            if (type.Equals("2")) //sell request
            {
                Console.WriteLine("You chose to sell commodities. Please enter the Commodity ID.");
                String commodityID = Console.ReadLine();
                while (!isDigitsOnly(commodityID)) //checking if input is valid
                {
                    Console.WriteLine("The Commodity ID must be a number! Please enter a valid Commodity ID");
                    commodityID = Console.ReadLine();
                }
                int commodityNums = Convert.ToInt32(commodityID); //casting the String to int
                Console.WriteLine("Now enter the amount of commodities you would like to sell.");
                String ammount = Console.ReadLine();
                while (!isDigitsOnly(ammount)) //checking if input is valid
                {
                    Console.WriteLine("The ammount must be a number! Please enter a valid amount");
                    ammount = Console.ReadLine();
                }
                int ammountNums = Convert.ToInt32(ammount); //casting the String to int
                Console.WriteLine("What is the price you would like to receive?");
                String price = Console.ReadLine();
                while (!isDigitsOnly(price)) //checking if input is valid
                {
                    Console.WriteLine("The price must be a number! Please enter a valid price");
                    price = Console.ReadLine();
                }
                int priceNums = Convert.ToInt32(price); //casting the String to int
                int output = rManager.SendSellRequest(priceNums, commodityNums, ammountNums);
                if (output == -1)
                    Console.WriteLine(rManager.error);
                else
                    Console.WriteLine("Congratulations! Your request was successful! Your request ID is:" + output);
            }
            if (type.Equals("3")) //cancellation request
            {
                Console.WriteLine("Please enter the Buy or the Sell Rrequest ID of the request you want to cancel.");
                String requestID = Console.ReadLine();
                while (!isDigitsOnly(requestID)) //checking if input is valid
                {
                    Console.WriteLine("The Rrequest ID must be a number! Please enter a valid Rrequest ID");
                    requestID = Console.ReadLine();
                }
                int requestNums = Convert.ToInt32(requestID); //casting the String to int
                bool ans = rManager.SendCancelBuySellRequest(requestNums);
                if (ans)
                    Console.WriteLine("Congratulations! Your cancellation request was successful.");
                else
                    Console.WriteLine("Our apologies, your cancellation request did not complete. If the request was yet to be canceled, please make sure that the Buy or the Sell Rrequest ID that you enterd was typed correctly, and try again.");
            }
            if (type.Equals("4")) //query request
            {
                Console.WriteLine("What kind of query would you like? Please type the relevant number: 1-Query sell/buy, 2-Query user, 3-Query market.");
                String queryType = Console.ReadLine();
                while (!queryType.Equals("1") & !queryType.Equals("2") & !queryType.Equals("3") & !queryType.Equals("4"))//checking if input is valid
                {
                    Console.WriteLine("It seems like your input is invalid, please enter an integer between 1 to 3");
                    queryType = Console.ReadLine();
                }
                if (queryType.Equals("1")) //query sell/buy
                {
                    Console.WriteLine("Please enter the Buy or the Sell Request ID.");
                    String requestID = Console.ReadLine();
                    while (!isDigitsOnly(requestID)) //checking if input is valid
                    {
                        Console.WriteLine("The Rrequest ID must be a number! Please enter a valid Rrequest ID");
                        requestID = Console.ReadLine();
                    }
                    int requestNums = Convert.ToInt32(requestID); //casting the String to int
                    Console.WriteLine(rManager.SendQueryBuySellRequest(requestNums));
                }
                if (queryType.Equals("2")) //query user
                {
                    Console.WriteLine(rManager.SendQueryUserRequest());
                }
                if (queryType.Equals("3")) //query market
                {
                    Console.WriteLine("Please enter the Commodity ID.");
                    String commodityID = Console.ReadLine();
                    while (!isDigitsOnly(commodityID)) //checking if input is valid
                    {
                        Console.WriteLine("The Commodity ID must be a number! Please enter a valid Commodity ID");
                        commodityID = Console.ReadLine();
                    }
                    int commodityNums = Convert.ToInt32(commodityID); //casting the String to int
                    Console.WriteLine(rManager.SendQueryMarketRequest(commodityNums));
                }
            }
        }

        private static bool isDigitsOnly(string str)//a private function that checks if a given string is made only of numbers.
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
