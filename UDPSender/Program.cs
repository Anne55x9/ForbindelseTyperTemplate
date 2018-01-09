using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPSender
{
    class Program

    {
        //Alle med port 7000 indgang har adgang til UDP forbindelsen. 
        public const int Port = 7000;
        static void Main(string[] args)
        {

            UdpClient socket = new UdpClient();
            socket.EnableBroadcast = true; // IMPORTANT
            //Sender bruger IPAdress.Broadcast så alle med port nummer 7000 kan lytte med. 
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, Port);
            while (true)
            {
                string message = "The time is " + DateTime.Now;
                byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
                socket.Send(sendBuffer, sendBuffer.Length, endPoint);
                Console.WriteLine("Message sent to broadcast address {0} port {1}", endPoint.Address, Port);
                //Timer I UDP forbindelser i stedet for sekvens og acknowledgement numre. 
                Thread.Sleep(5000);
            }
        }
    }
}
