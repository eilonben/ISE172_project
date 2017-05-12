using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class UserRules
    {

        public static RequestManager rManager;
        public static Queue<Rule> requests;
        public static Timer aTimer;


        public UserRules()
        {
            rManager = new RequestManager();
            requests = new Queue<Rule>();
        }


        public static void addRules(string type, int commodity, int price)
        {
            Rule toRequest = new Rule(type, commodity, price);
            requests.Enqueue(toRequest);

            if (toRequest.type.Equals("Buy"))
            {
                SetTimer(toRequest);
            }
            if (toRequest.type.Equals("Sell"))
            {
                SetTimer(toRequest);
            }
        }

        public static void SetTimer(Rule rule)
        {
            Rule tmp =requests.Dequeue();
            string
            rManager.SendQueryBuySellRequest(rManager.SendBuyRequest(rule.price, rule.commodity, 1));
        }
    }
}
