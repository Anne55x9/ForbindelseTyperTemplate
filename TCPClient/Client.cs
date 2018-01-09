using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    internal class Client
    {
        public void StartClient()
        {
            //String sendStr = "Anne Sofie";

            using (TcpClient client = new TcpClient("localhost", 7))
            using (NetworkStream ns = client.GetStream())
            //output fra server
            using (StreamReader sr = new StreamReader(ns))
                //input fra Client
            using (StreamWriter sw = new StreamWriter(ns))
            {
                while (true)
                {
                    //
                    string sendStr = Console.ReadLine();
                    sw.WriteLine(sendStr);
                    sw.Flush();

                    //input fra server
                    String incomingStr = sr.ReadLine();
                    Console.WriteLine("Ekko Modtaget:" + incomingStr);

                }

                
            }
        }
    }
}
