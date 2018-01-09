using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP3ClientSSLforbindelse
{
    internal class ClientSSL
    {
        private int PORT;

        public ClientSSL(int port)
        {
            this.PORT = port;
        }

        public void StartClient()
        {
            bool leaveInnerStreamOpen = false;

            using (TcpClient connectionSocket = new TcpClient(IPAddress.Loopback.ToString(), PORT))

            using (Stream unsecureStream = connectionSocket.GetStream())
            using (SslStream secureStream = new SslStream(unsecureStream, leaveInnerStreamOpen))
            {
                //Variable er target host. Navn oprettet i certificate oprettelse. 
                //SSL forbindelse.Client SSLHello, authenticateASClient til at authenticate server.
                secureStream.AuthenticateAsClient("FakeServerNameFinal");

                using (StreamReader sr = new StreamReader(secureStream))
                using (StreamWriter sw = new StreamWriter(secureStream))
                {
                    Console.WriteLine("Clienten er tilsluttet");
                    sw.AutoFlush = true;

                   

                    ////Input fra client3 en linje 99 gange før luk client forespørgsel håndteret.
                    //Client3(sr, sw);

                    ////Input fra client2 en linje 4 gange før luk client forespørgsel håndteret.
                    //Client2(sr,sw);

                    ////Input fra Client1 en linje en gang og client forespørgsel er håndteret.
                    Client1(sr,sw);

                    Console.WriteLine("Clientens forespørsel er klar.");

                }


            }


        }

        private void Client3(StreamReader sr, StreamWriter sw)
        {
            for (int i = 0; i < 100; i++)
            {
                string message = "All work and no play makes Jack a dullboy." + i;
                //Client forespørgsels, input til Server.
                sw.WriteLine(message);
                //Server output til Client.
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
            
        }

        private void Client2(StreamReader sr, StreamWriter sw)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Type a line");
                string message = Console.ReadLine();
                //Client forespørgsels, input til Server.
                sw.WriteLine(message);
                //Server output til Client.
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Server: " + serverAnswer);
            }
        }

        private void Client1(StreamReader sr, StreamWriter sw)
        {
            //Sender. Client forespørgsel til server.  
            Console.WriteLine("Type a line");
            string message = Console.ReadLine();
            sw.WriteLine(message);

            //Modtager: Server output til CLient
            string serverAnswer = sr.ReadLine();
            Console.WriteLine("Server" + serverAnswer);

        }

    }
}
