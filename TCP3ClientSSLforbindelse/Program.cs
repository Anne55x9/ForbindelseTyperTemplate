using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP3ClientSSLforbindelse
{
    class Program
    {
        /// <summary>
        /// Private constant port som matcher ServerSSL for SSL forbindelse.  
        /// </summary>
        private const int PORT = 7777;

        static void Main(string[] args)
        {
            ClientSSL client = new ClientSSL(PORT);
            client.StartClient();

            Console.ReadLine();

        }
    }
}
