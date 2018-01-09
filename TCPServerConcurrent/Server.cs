using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using Newtonsoft.Json;

namespace TCPServerConcurrent
{
    public class Server
    {
        public Server()
        {

        }

        /// <summary>
        /// Metode som starter en TcpListener. 
        /// </summary>

        public void StartServer()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7070);

            server.Start();

            //Informere i server consol at server kører.
            Console.WriteLine("Server er tilsluttet");

            //while loop sikre at flere clienter kan connecte til server. Server er derfor concurrent.
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient LokalSocket = client;
                    DoClient(LokalSocket);
                    
                });

            }
        }

        public static void DoClient(TcpClient client)
        {
            using (NetworkStream ns = client.GetStream())

            using (StreamReader sr = new StreamReader(ns))

            using (StreamWriter sw = new StreamWriter(ns))
            {
                //Input fra Client
                String inline = sr.ReadLine();
                String outline = HandleClient(inline);

                //Output fra server til client
                sw.WriteLine(outline);
                sw.Flush();
            }

        }

        public static String HandleClient(String line)
        {
            Console.WriteLine("Server modtaget" + line);
            return line;
        }

    }
    
}
