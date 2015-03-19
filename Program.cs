using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSend
{
    class Program
    {
        static void Main(string[] args)
        {
            const string EventLogSource = "TCPSend";

            if (args.Length < 2)
            {
                Console.WriteLine("2 Arguments required");
                Console.WriteLine("1 - IP of target");
                Console.WriteLine("2 - Port number");
                return;
            }

            var host = args[0];
            var port = Convert.ToInt32(args[1]);

            EventLog.WriteEntry(EventLogSource, "Trying to connect to " + host);
            var tcp = new TcpClient();
            try
            {
                tcp.Connect(host, port);
                tcp.Close();
                EventLog.WriteEntry(EventLogSource, "Connected to " + host + " Successfully");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(EventLogSource, "Error\n" + ex.Message + "\n" + ex.StackTrace, EventLogEntryType.Error);
            }
        }
    }
}
