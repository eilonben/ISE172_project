using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data Access Layer;

namespace Presentation_Layer
{
    class Main
    {
        public static void main(String[] args)
        {
            Console.WriteLine("Hello, please enter your request type number: 1-Buy, 2-Sell, 3-Cancle, 4-Query.");
            string type = Console.ReadLine();
            if (type == "1")
                Console.WriteLine("Please enter your bid price, commodity and ammount.");
            if (type=="2")
                Console.WriteLine("Please enter your sell price, commodity and ammount.");

        }
    }
}
