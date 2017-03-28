using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Presentation_Layer
{
     class Main1
    {
        public static void Main()
        {
            RequestManager rManager = new RequestManager();//creates an instance of the RequestManager class 
            bool quit = false;
            Console.WriteLine("Hello, please enter your request type number: 1-Buy, 2-Sell, 3-Cancel, 4-Query, 0-Quit program.");
            while (!quit)
            {
                
                String type = Console.ReadLine();
                while (!type.Equals("1") & !type.Equals("2") & !type.Equals("3") & !type.Equals("4") & !type.Equals("0"))//checking if input is valid
                {
                    Console.WriteLine("It seems like your input is invalid, please enter an integer between 0 to 4");
                    type = Console.ReadLine();
                }
                int typeInt = Convert.ToInt32(type);
                quit = (typeInt == 0);
                if (typeInt==1) //buy request
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
                        Console.WriteLine("An error has occurred:" + rManager.error);
                    else
                        Console.WriteLine("Congratulations! Your request was successful! Your request ID is:" + output);
                    Console.WriteLine("What would you like to do next? Please type the relevant number: 1-Back to main menu, 0-Quit program");
                    String quitBuy = Console.ReadLine();
                    while (!quitBuy.Equals("1") & !quitBuy.Equals("0"))//checking if input is valid
                    {
                        Console.WriteLine("It seems like your input is invalid. Type 1 to go back to main menu, or 0 to quit");
                        quitBuy = Console.ReadLine();
                    }
                    quit = (Convert.ToInt32(quitBuy) == 0);


                }
                if (typeInt==2) //sell request
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
                        Console.WriteLine("An error has occurred:" + rManager.error);
                    else
                        Console.WriteLine("Congratulations! Your request was successful! Your request ID is:" + output);
                    Console.WriteLine("What would you like to do next? Please type the relevant number: 1-Back to main menu, 0-Quit program");
                    String quitSell = Console.ReadLine();
                    while (!quitSell.Equals("1") & !quitSell.Equals("0"))//checking if input is valid
                    {
                        Console.WriteLine("It seems like your input is invalid. Type 1 to go back to main menu, or 0 to quit");
                        quitSell = Console.ReadLine();
                    }
                    quit = (Convert.ToInt32(quitSell) == 0);

                }
                if (typeInt==3) //cancellation request
                {
                    Console.WriteLine("Please enter the Buy or the Sell Rrequest ID of the request you want to cancel.");
                    String requestID = Console.ReadLine();
                    while (!isDigitsOnly(requestID)) //checking if input is valid
                    {
                        Console.WriteLine("The Request ID must be a number! Please enter a valid Rrequest ID");
                        requestID = Console.ReadLine();
                    }
                    int requestNums = Convert.ToInt32(requestID); //casting the String to int
                    bool ans = rManager.SendCancelBuySellRequest(requestNums);
                    if (ans)
                        Console.WriteLine("Congratulations! Your cancellation request was successful.");
                    else
                        Console.WriteLine("Our apologies, your cancellation request did not complete. If the request was yet to be canceled, please make sure that the Buy or the Sell Rrequest ID that you enterd was typed correctly, and try again.");
                    Console.WriteLine("What would you like to do next? Please type the relevant number: 1-Back to main menu, 0-Quit program");
                    String quitCancel = Console.ReadLine();
                    while (!quitCancel.Equals("1") & !quitCancel.Equals("0"))//checking if input is valid
                    {
                        Console.WriteLine("It seems like your input is invalid. Type 1 to go back to main menu, or 0 to quit");
                        quitCancel = Console.ReadLine();
                    }
                    quit = (Convert.ToInt32(quitCancel) == 0);

                }
                if (typeInt==4) //query request
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
                            Console.WriteLine("The Request ID must be a number! Please enter a valid Request ID");
                            requestID = Console.ReadLine();
                        }
                        int requestNums = Convert.ToInt32(requestID); //casting the String to int
                        var querySB = rManager.SendQueryBuySellRequest(requestNums);
                        if (querySB == null)
                            Console.WriteLine("An error has occurred:" + rManager.error);
                        else
                            Console.WriteLine(querySB);
                    }
                    if (queryType.Equals("2")) //query user
                    {
                        var queryU = rManager.SendQueryUserRequest();
                        if (queryU == null)
                            Console.WriteLine("An error has occurred:" + rManager.error);
                        else
                            Console.WriteLine(queryU);
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
                        var queryM = rManager.SendQueryMarketRequest(commodityNums);
                        if (queryM == null)
                            Console.WriteLine("An error has occurred:" + rManager.error);
                        else
                            Console.WriteLine(queryM);
                    }
                    Console.WriteLine("What would you like to do next? Please type the relevant number: 1-Back to main menu, 0-Quit program");
                    String quitQuery = Console.ReadLine();
                    while (!quitQuery.Equals("1") & !quitQuery.Equals("0"))//checking if input is valid
                    {
                        Console.WriteLine("It seems like your input is invalid. Type 1 to go back to main menu, or 0 to quit");
                        quitQuery = Console.ReadLine();
                    }
                    quit = (Convert.ToInt32(quitQuery) == 0);
                    
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
