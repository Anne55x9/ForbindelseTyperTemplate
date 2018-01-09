using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ModelLibrary;
using Newtonsoft.Json;

namespace UDPSimpelSender
{
    internal class Sender
    {
        private readonly int PORT;
        public Sender(int port)
        {
            this.PORT = port;
        }

        public void StartSender()
        {
            ////Instanser af Modelklassen:

            ////PlainText
            //ClassName classNamePlain = new ClassName("PlainText","PlainText",33,"PlainText",44);

            ////XmlText
            //ClassName classNameXml = new ClassName("XmlText", "XmlText", 44, "XmlText", 55);

            ////JsonText 
            ClassName classNameJson = new ClassName("JsonText", "JsonText", 44, "JsonText", 50);


            using (UdpClient socket = new UdpClient())
            {
                ////Kode til simpel string
                //string str = "Anne Sofie";
                //byte[] buffer = Encoding.ASCII.GetBytes(str);
                //IPEndPoint ReceiverEP = new IPEndPoint(IPAddress.Loopback, PORT);
                //socket.Send(buffer, buffer.Length, ReceiverEP);

                ////Kode til PlainTekst med modelLib
                //string classNameStr = classNamePlain.ToString();
                //byte[] buffer = Encoding.ASCII.GetBytes(classNameStr);
                //IPEndPoint ReceiverEP = new IPEndPoint(IPAddress.Loopback, PORT);
                //socket.Send(buffer, buffer.Length, ReceiverEP);
                //Console.WriteLine($"sent: {classNameStr} to: {ReceiverEP}");


                ////Kode til XmlText med modelLib
                //XmlSerializer serializer = new XmlSerializer(typeof(ClassName));
                //StringWriter sw = new StringWriter();

                ////Serialiserer instanser fra modellib klassen til xml.
                //serializer.Serialize(sw, classNameXml);
                //string ObjektToXml = sw.ToString();

                //byte[] buffer = Encoding.ASCII.GetBytes(ObjektToXml);

                //IPEndPoint ReceiverEP = new IPEndPoint(IPAddress.Loopback, PORT);

                //socket.Send(buffer, buffer.Length, ReceiverEP);

                //Console.WriteLine($"sent: {ObjektToXml} to: {ReceiverEP}");


                ////Kode til Json med ModelLib

                string Json = JsonConvert.SerializeObject(classNameJson);

                Byte[] data = Encoding.ASCII.GetBytes(Json);

                IPEndPoint receiverEP = new IPEndPoint(IPAddress.Loopback, PORT);

                socket.Send(data, data.Length, receiverEP);

                Console.WriteLine($"sent: {Json} to: {receiverEP}");

            }
        }
    }
}
