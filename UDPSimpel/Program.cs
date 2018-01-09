using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPSimpel
{
    class Program
    {
        private const int PORT = 22334;
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver(PORT);

            receiver.StartReceiver();

            Console.ReadLine();
        }
    }
}
