using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameServerSemplice1.Test
{
    class FakeTransporter:ITransportable
    {
        private Queue<byte[]> recvQueue;
        private Queue<byte[]> sendQueue;

        public FakeTransporter()
        {
            recvQueue = new Queue<byte[]>();
            sendQueue = new Queue<byte[]>();
        }

        public void DataEnqueue(byte[] data)
        {
            recvQueue.Enqueue(data);
        }

        public byte[] Recv(int bufferSize, ref EndPoint sender)
        {
            //devo fare il dequeue del dato 
            byte[] dequeueData = recvQueue.Dequeue();
            

            return RevertData(dequeueData, dequeueData.Length);
        }

        public byte[] Recv(int bufferSize)
        {
            //devo fare il dequeue del dato 
            byte[] dequeueData = recvQueue.Dequeue();

            return RevertData(dequeueData, dequeueData.Length);
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

        public bool Send(byte[] packet, EndPoint endPoint)
        {
            return false;
        }
    }
}
