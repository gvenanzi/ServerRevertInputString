using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace GameServerSemplice1
{
    public class Transporter:ITransportable
    {
        private Socket socket;

        public Transporter()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Blocking = false;
        }

        public void Bind(string address, int port)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket.Bind(endPoint);
        }

        public bool Send(byte[] data, EndPoint endPoint)
        {
            bool success = false;
            try
            {
                int rlen = socket.SendTo(data, endPoint);
                if (rlen == data.Length)
                    success = true;
            }
            catch
            {
                success = false;
            }
            return success;
        }

        public byte[] Recv(int bufferSize, ref EndPoint sender)
        {
            int rlen = -1;
            byte[] data = new byte[bufferSize];
            try
            {
                rlen = socket.ReceiveFrom(data, ref sender);
                if (rlen <= 0)
                    return null;
            }
            catch
            {
                return null;
            }

            return RevertData(data, rlen);
        }

        public byte[] RevertData(byte[] data, int rlen)
        {
            Console.WriteLine("arrived a no null packet");
            byte[] trueData = new byte[rlen];
            Buffer.BlockCopy(data, 0, trueData, 0, rlen);

            Console.WriteLine(System.Text.Encoding.UTF8.GetString(trueData));
            string message = Encoding.UTF8.GetString(data, 0, rlen);
            char[] chars = message.ToCharArray();
            Array.Reverse(chars);
            byte[] response = Encoding.UTF8.GetBytes(chars);
            //print the modified data to return
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(response));

            return response;
        }

        public EndPoint CreateEndPoint()
        {
            return new IPEndPoint(0, 0);
        }
    }
}
