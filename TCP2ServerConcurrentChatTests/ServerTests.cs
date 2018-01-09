using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCPServerConcurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServerConcurrent.Tests
{
    [TestClass()]
    public class ServerTests
    {
        [TestMethod()]
        public void HandleClientTest()
        {
          
            //Tester om Server håntere clientens forespørgsel korrekt.
              
                //Arrange
                String line = "";

                //Act
                String returnline = Server.HandleClient(line);

                //Assert
                //Først den forventede og derefter den aktuelle.
                Assert.AreEqual("", line);
            }
    }
    
}
