using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace GameServerSemplice1
{
    public class GameServer
    {
        private ITransportable transport;

        public GameServer(ITransportable gameTransport)
        {
            transport = gameTransport;
        }

        public void Run()
        {
            Console.WriteLine("server started");
            while (true)
            {
                SingleStep();
            }
        }

        public void SingleStep()
        {
            EndPoint sender = new IPEndPoint(0, 0);
            //il transport.Recv fa il dequeue della coda dei pacchetti
            byte[] data = transport.Recv(256, ref sender);
            try
            {
                if (data == null)
                    return;
                
            }
            catch 
            {

            }
            
            Send(data, sender);
        }

        public bool Send(byte[] packet, EndPoint endPoint)
        {
            return transport.Send(packet, endPoint);
        }
    }
}
