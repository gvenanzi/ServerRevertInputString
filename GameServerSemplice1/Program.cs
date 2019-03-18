using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServerSemplice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Transporter transport = new Transporter();
            transport.Bind("192.168.12.1", 9999);

            GameServer server = new GameServer(transport);
            server.Run();
        }
    }
}
