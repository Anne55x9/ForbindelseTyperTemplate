using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TCP3ServerSSLforbindelse
{
    internal class ServerSSL
    {

        //Private instance felt til port nummer. Del af sikre forbindelser. 
        private int PORT;

        public ServerSSL(int port)
        {
            this.PORT = port;
        }

        //Server ikke concurrent da forbindelse er sikret via forbindelse certifikater
        //for uvedkomne andre clienter.
        public void StartServer()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, PORT);
            serverSocket.Start();

            //Informere i server consol at server kører.
            Console.WriteLine("Server er tilsluttet");

            //vaiable som indeholder certiicate directory og filen ServerSSL.pfx
            string serverCertificateASW = "C:/CertificatesFinal/ServerSSL.pfx";

            //Initerering at nyt certificate med tilhørende kodeord til nøgle. 
            X509Certificate serverCertificate = new X509Certificate2(serverCertificateASW, "mysecret");
            bool leaveInnerStreamOpen = false;

            
            using (TcpClient connectionSocket = serverSocket.AcceptTcpClient())
            using (Stream unsecureStream = connectionSocket.GetStream())
            using (SslStream secureStream = new SslStream(unsecureStream, leaveInnerStreamOpen))
            {
                //SSL hello fra client til server derefter ok fra server som sender offentlig nøgle til client.
                //AuthenticateAsServer er bruges til at authentikere client 
                //og er en del af SSL forbindelse med paremeter som er certificater med offenlige nøgle til Client.
                //Clientens offentlige nøgle bruges til afkodning med private nøgle på Server siden.SSL forbindelse etableret. 
                secureStream.AuthenticateAsServer(serverCertificate);

                using (StreamReader sr = new StreamReader(secureStream))
                using (StreamWriter sw = new StreamWriter(secureStream))
                {
                    Console.WriteLine("Server er tilgængelig");

                    //Stateless connection
                    sw.AutoFlush = true;


                    string message = sr.ReadLine();
                    string answer = "";

                    //String skal ikkevære null. 
                    while (!string.IsNullOrEmpty(message))
                    {
                        
                        Console.WriteLine("Client: " + message);
                        answer = message.ToUpper();
                        
                        //Output fra Server til Cient.
                        sw.WriteLine(answer);

                        //Input fra Client til server.
                        message = sr.ReadLine();
                    }
                }

            }
        }
    }
}
    
