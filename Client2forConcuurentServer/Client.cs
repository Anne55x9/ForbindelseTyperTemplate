using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client2forConcuurentServer
{
    internal class Client
    {
        /// <summary>
        /// Default konstruktor i klassen Client. 
        /// </summary>
        public Client()
        {

        }

        /// <summary>
        /// Metode som retunerer void og indeholder et nyt objekt af TcpClient (Transmission control protocol). 
        /// IP adressen er localhost og port nr er 7070.
        /// Derudover bruges klassen networkstream til at oprette et flow af information mellem ende systemer.
        /// StreamReader og StreamWriter klasserne er med til at muliggøre at server og client kan læse og skrive tekst.
        /// </summary>
        public void StartClient()
        {
            using (TcpClient client = new TcpClient("localhost", 7070))

            using (NetworkStream ns = client.GetStream())
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                while (true)
                {
                    
                    String SendStr = Console.ReadLine();
                    //Input fra client til server
                    sw.WriteLine(SendStr);
                    //Input flush så forbindelse er stateless. Input huskes ikke.
                    sw.Flush();

                    //Output fra Server til Client
                    String incomingStr = sr.ReadLine();
                    Console.WriteLine("Chat funktion aktiv: " + incomingStr);
                    Console.ReadLine();
                }

            }

        }

    }
}
