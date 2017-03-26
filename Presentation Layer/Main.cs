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
            Console.WriteLine("Hello, please enter your request type number: 1-Buy, 2-Sell, 3-Cancle, 4-Query.");
            int type = Convert.ToInt32(Console.ReadLine());
            if (type == 1)
            {
                Console.WriteLine("Please enter the Commodity ID.");
                int commodityID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the amount.");
                int ammount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the price.");
                int price = Convert.ToInt32(Console.ReadLine());
            }
            if (type == 2)
            {
                Console.WriteLine("Please enter the Commodity ID.");
                int commodityID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the amount.");
                int ammount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the price.");
                int price = Convert.ToInt32(Console.ReadLine());
            }
            if (type == 3)
            {
                Console.WriteLine();
            }
            if (type == 4)
            {
                Console.WriteLine("What would you like? 1-Query sell/buy, 2-Query user, 3-Query market.");
                int queryType = Convert.ToInt32(Console.ReadLine());
                if (queryType == 1)
                {
                    Console.WriteLine("Please enter the Buy or the Sell Rrequest ID.");
                    int requestID = Convert.ToInt32(Console.ReadLine());
                }
                if (queryType == 2)
                {

                }
                if (queryType == 3)
                {
                    Console.WriteLine("Please enter the Commodity ID.");
                    int commodityID = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}
