using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ModelLibrary;
using Newtonsoft.Json;

namespace TCPSimpelClientFormater
{
    internal class Client
    {

        private readonly int port;

        public Client(int port)
        {
            this.port = port;
        }


        public void StartClient()
        {
            //ClassName clasNamePlane = new ClassName("PlainText", "PlainText",11, "PlainText",11);

            //ClassName classNameXml = new ClassName("XmlText", "XmlText",33, "XmlText",11);

            //ClassName classNameJson = new ClassName("JsonText", "JsonText",33, "JsonText",11);

            using (TcpClient cSocket = new TcpClient("localhost", port))
            using (NetworkStream stream = cSocket.GetStream())
            //output fra server
            using (StreamReader toClient = new StreamReader(stream))
                ////Rækkefølge vigtig for at server kan sende tilbage til client console.
            using (StreamWriter toServer = new StreamWriter(stream))
            {
                ////Kode til plain text
                //toServer.WriteLine(clasNamePlane.ToString());
                //toServer.Flush();

                ////input fra server til client
                //String incomingStr = toClient.ReadLine();
                //Console.WriteLine("Ekko Modtaget:" + incomingStr);


                ////Kode til xml format hvor clienten printer xml format 
                ////som serialiseres xml format af objekt og sender til server som kan desirialiserer til almindelig text. 
                /// 
                //XmlSerializer serializer = new XmlSerializer(typeof(ClassName));

                //StringWriter sw = new StringWriter();
                //serializer.Serialize(sw, classNameXml);
                //Console.WriteLine($"XML size {sw.ToString().Length}\n{sw} ");

                //serializer.Serialize(toServer, classNameXml);
                //sw.Flush();

                ////Xml eksempel hvor objekt i xml format sendes til clienten som deserialiserer xml format til almindelig Text.
                //XmlSerializer serializer = new XmlSerializer(typeof(ClassName));

                //ClassName classCopy = (ClassName)serializer.Deserialize(toClient);
                //Console.WriteLine($"From Server as ClassName object :{classCopy}");


                ////Kode til Json format med clienten med serialiseret data til Json.

                //string jsonStr = JsonConvert.SerializeObject(classNameJson);
                //Console.WriteLine($"Client json string: {jsonStr} and size:: {jsonStr.Length}");

                //toServer.WriteLine(jsonStr);
                //toServer.Flush();

                ////Kode med json format fra serveren og client sidens deserialisering til ormal tekst. 

                string strFromClient = toClient.ReadLine();
                Console.WriteLine($"From Server text : {strFromClient}");

                ClassName clasName = JsonConvert.DeserializeObject<ClassName>(strFromClient);
                Console.WriteLine($"From Server as clasName obj : {clasName}");

            }


        }
    }
}
