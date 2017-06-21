using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient
{
    public class ClientUser
    {
        public ISimpleHTTPClient client { get; set; }
        private string url;
        private string username;
        private string privateKey;
        private static int nonce = 0;

        public ClientUser(string username, string privateKey)
        {
            nonce = new Random().Next(Int32.MaxValue);
            client = new SimpleHTTPClient();
            this.username = username;
            this.privateKey = privateKey;
            url = "http://ise172.ise.bgu.ac.il";
        }
    }
}
