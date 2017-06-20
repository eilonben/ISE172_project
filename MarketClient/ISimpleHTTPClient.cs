using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public interface ISimpleHTTPClient
    {
        T2 SendPostRequest<T1, T2>(string url, string user, int nonce, string privateKey, string token, T1 item) where T2 : class;
        string SendPostRequest<T1>(string url, string user, int nonce, string privateKey, string token, T1 item);
    }
}

