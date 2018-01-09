using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPSimpelSender
{
    class Program
    {
        private const int MODTAGER_PORT = 22334;
        private const int MIN_PORT = 22335;

        static void Main(string[] args)
        {

            Sender m = new Sender(MODTAGER_PORT);
            m.StartSender();

            Console.ReadLine();
        }
    }
}
