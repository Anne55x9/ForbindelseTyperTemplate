using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLibrary;
using Newtonsoft.Json;

namespace TCPSimpleServerFormater
{
    internal class Server
    {
        private readonly int port;

        public Server(int port)
        {
            this.port = port;
        }

        public void StartServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine("Server er tilstluttet");

            while (true)
            {
                TcpClient clientSocket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient socket = clientSocket;
                    DoClient(socket);
                });

            }
        }

        private void DoClient(TcpClient socket)
        {
            //ClassName classNameXml = new ClassName("XmlText", "XmlText", 33, "XmlText", 11);
            ClassName classNameJson = new ClassName("JsonText", "JsonText", 33, "JsonText", 11);



            using (NetworkStream stream = socket.GetStream())

            using (StreamReader sr = new StreamReader(stream))
            using (StreamWriter toServer = new StreamWriter(stream))
            {
                ////Kode til plain
                //string strFromClient = fromClient.ReadLine();
                //Console.WriteLine($"From Client text : {strFromClient}");

                ////output fra server.
                //toClient.WriteLine(strFromClient.ToUpper());


                //// Kode til xml hvor server siden deserialiserer xml til almindelig texk i server consol. 
                //XmlSerializer serializer = new XmlSerializer(typeof(ClassName));

                //ClassName classCopy = (ClassName)serializer.Deserialize(sr);
                //Console.WriteLine($"From Client as ClassName object : {classCopy}");


                ////Kode til xml hvor server serialiserer til xml og clienten deserialiserer til normal text i consol. 
                //XmlSerializer serializer = new XmlSerializer(typeof(ClassName));

                //StringWriter sw = new StringWriter();
                //serializer.Serialize(sw, classNameXml);
                //Console.WriteLine($"XML size {sw.ToString().Length}\n{sw} ");

                //serializer.Serialize(toServer, classNameXml);
                //sw.Flush();

                ////Kode til Json med Server som inkludere clienten Json serialiserings view og Json deserialiseret på server siden.

                //string strFromClient = sr.ReadLine();
                //Console.WriteLine($"From Client text : {strFromClient}");

                //ClassName clasName = JsonConvert.DeserializeObject<ClassName>(strFromClient);
                //Console.WriteLine($"From Client as clasName obj : {clasName}");

                ////Json med serialisering til json format på server siden. 

                string jsonStr = JsonConvert.SerializeObject(classNameJson);
                Console.WriteLine($"Client json string: {jsonStr} and size:: {jsonStr.Length}");

                toServer.WriteLine(jsonStr);
                toServer.Flush();

            }



        }
    }
}
