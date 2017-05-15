using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    class lodFile
    {
        public void LogFile(string sExceptionName, string sEventName, string sControlName, int nErrorLineNo, string sFormName)

        {

            StreamWriter log;

            if (!File.Exists("logfile.txt"))

            {

                log = new StreamWriter("logfile.txt");

            }

            else

            {

                log = File.AppendText("logfile.txt");

            }

            // Write to the file:

            log.WriteLine("Data Time:" + DateTime.Now);

            log.WriteLine("Exception Name:" + sExceptionName);

            log.WriteLine("Event Name:" + sEventName);

            log.WriteLine("Control Name:" + sControlName);

            log.WriteLine("Error Line No.:" + nErrorLineNo);

            log.WriteLine("Form Name:" + sFormName);

            // Close the stream:

            log.Close();

        }

    }
}

