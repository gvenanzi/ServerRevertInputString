using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameServerSemplice1.Test
{
    public class TestClass
    {
        private FakeTransporter transport;
        GameServer server;

        [SetUp]
        public void SetupTests()
        {
            transport = new FakeTransporter();
            server = new GameServer(transport);
        }

        [Test]
        public void TestReverseMessage()
        {
            //create the data in byte, the reverse data too
            string message = "cane";
            char[] chars = message.ToCharArray();
            byte[] bytes = Encoding.Default.GetBytes(chars);
            message = Encoding.UTF8.GetString(bytes);
            chars = message.ToCharArray();
            Array.Reverse(chars);
            byte[] response = Encoding.UTF8.GetBytes(chars);

            transport.DataEnqueue(bytes);
            byte[] transportOutput = transport.Recv(256);

            Assert.That(transportOutput, Is.EqualTo(response));
        }
    }
}
