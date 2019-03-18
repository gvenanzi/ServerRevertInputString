using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameServerSemplice1
{
    public interface ITransportable
    {
        byte[] Recv(int bufferSize, ref EndPoint sender);
        bool Send(byte[] packet, EndPoint endPoint);
    }
}
