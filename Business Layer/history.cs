using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class history
    {
        static string s = "";

        public string historyByDate(DateTime start, DateTime end)
        {
            string[] lines = File.ReadAllLines("../../../history/history.log");
            for (int i=0; i<lines.Length; i++)
            {
                if (lines[i] != "" && lines[i][0].Equals('2'))
                {
                    string[] words = lines[i].Split(' ');
                    string date = words[0];
                    DateTime dt = Convert.ToDateTime(date);
                    if (dt.CompareTo(start) >= 0 && dt.CompareTo(end) <= 0)
                        s += lines[i];
                }
                if (!lines[i][0].Equals('2'))
                {
                    s += lines[i];
                }
                s += "/n";

            }
            return s;
        }
    }
}
