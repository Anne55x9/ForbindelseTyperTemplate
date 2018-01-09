using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    internal class Server
    {
        public Server()
        {

        }

        public void StartServer()
        {
            // TCP er den pålidelige forbindelse. TCP er et socket.

            //Oretter en server som lytter efter clienter med port nummer.
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            //using funktionen sørger for at alt der åbnes lukkes pænt. 


            //Accept af client - del a 3 way hand shake.
            using (TcpClient client = server.AcceptTcpClient())

                ///
            using (NetworkStream ns = client.GetStream())

            //Input fra Client
            using (StreamReader sr = new StreamReader(ns))
            // Output fra Server:
            using (StreamWriter sw = new StreamWriter(ns))
            {
                // denne del adskiller vores ekko server fra en almindelig webserver.

                while (true)
                {
                    //input fra client
                    string inlinje = sr.ReadLine();
                    Console.WriteLine("Server modtaget : " + inlinje);
                    //Output fra Server
                    sw.WriteLine(inlinje.ToUpper());

                    //Tæller antal bogstaver inklusiv mellemrum.

                    int numberOfLetters = inlinje.Length;
                    Console.WriteLine(numberOfLetters);

                    //Tæller antal ord i en sætning.

                    int numberOfNew = inlinje.Split().Length;
                    Console.WriteLine(numberOfNew);


                    // Flush tømmer det serveren har og sender ud til forbindelse. 
                    //Server bliver stateless - kan ikke huske sidste stream.
                    sw.Flush();
                }


            }

        }
    }
}
