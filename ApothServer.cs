using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apotheosis
{
    public class ApothServer
    {
        int listeningPort = 0;
        UdpClient client;

        public ApothServer(int port)
        {
            listeningPort = port;
            client = new UdpClient(listeningPort);
        }

        public async Task Start()
        {
            while (true)
            {
                var data = await client.ReceiveAsync();
                OnUdpData(data);
            }
        }

        void OnUdpData(UdpReceiveResult result)
        {
            //this is where we handle incoming data from any connection
            if (result.Buffer != null)
            {
                Console.WriteLine($"|{DateTime.Now.ToShortTimeString()}|{result.RemoteEndPoint}:{Encoding.UTF8.GetString(result.Buffer)}");

            }
            else
            {
                //data was null
            }


        }
    }
}
