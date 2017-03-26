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
            var type = Console.ReadLine();
            if (type == "1")
            {
                Console.WriteLine("Please enter the commodity id, amount and ask price.");
            }
            if (type == "2")
            {
                Console.WriteLine("Please enter the commodity id, amount and ask price.");
            }
            if (type == "3")
            {
                Console.WriteLine();
            }
            if (type == "4")
            {
                Console.WriteLine("What would you like? 1-Query sell/buy, 2-Query user, 3-Query market.");
                var queryChoise = Console.ReadLine();


            }


        }
    }
}
