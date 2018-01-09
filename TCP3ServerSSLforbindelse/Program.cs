using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP3ServerSSLforbindelse
{
    class Program
    {
        /// <summary>
        /// Private constant port nummer til SSL forbindelse.
        /// </summary>
        private const int PORT = 7777;
        static void Main(string[] args)
        {

            ServerSSL server = new ServerSSL(PORT);
            server.StartServer();

            Console.ReadLine();
        }
    }
}
