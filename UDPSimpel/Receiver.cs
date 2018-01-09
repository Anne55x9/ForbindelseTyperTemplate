using ModelLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UDPSimpel
{
    internal class Receiver
    {
        /// <summary>
        /// Receiver skal tændes først i UDP. 
        /// En som er intereesseret i at lytte på port skal være aktiv før forbindelse iprogram.
        /// </summary>
        private int PORT;

        public Receiver(int port)
        {
            this.PORT = port;
        }

        public void StartReceiver()
        {
            using (UdpClient socket = new UdpClient(PORT))
            {
                IPEndPoint AfsenderEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = socket.Receive(ref AfsenderEP);

                Console.WriteLine("Modtager fra " + AfsenderEP.Address + "" + AfsenderEP.Port);

                ////Kode til simpel streng Anne Sofie:        
                //String str = Encoding.ASCII.GetString(data);
                //Console.WriteLine("Modtager \n" + str);

                ////ekko tilbage til adsender:
                //socket.Send(receive, receive.Length, AfsenderEP);

                ////Kode til Plaintext med ModelLib

                //string classNameStr = Encoding.ASCII.GetString(data);

                //Console.WriteLine($"receive: {classNameStr} from: {AfsenderEP}");

                ////Kode til xml med modelLib

                //string XmlStr = Encoding.ASCII.GetString(data);
                //StringReader sr = new StringReader(XmlStr);
                //XmlSerializer serializer = new XmlSerializer(typeof(ClassName));

                //////XMl format deserialiseres til console fremvisning. 
                //ClassName inComingClassName = (ClassName)serializer.Deserialize(sr);

                //Console.WriteLine($"receive: {inComingClassName} from: {AfsenderEP}");

                ////kode til JSON

                string JsonStr = Encoding.ASCII.GetString(data);
                ClassName incomingclassName = JsonConvert.DeserializeObject<ClassName>(JsonStr);

                Console.WriteLine($"receive: {incomingclassName} from: {AfsenderEP}");

            }
        }
    }
}
