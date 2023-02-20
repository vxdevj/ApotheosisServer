using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Apotheosis
{
    public class ApotheosisServer
    {
        int listeningPort = 0;

        public ApotheosisServer(int port)
        {
            listeningPort = port;
            UdpClient socket = new UdpClient(listeningPort);
            socket.BeginReceive(new AsyncCallback(OnUdpData), listeningPort);
        }

        void OnUdpData(IAsyncResult result)
        {
            //this is where we handle incoming data from any connection
            var senderIp = new IPEndPoint(0, 0);
            var socket = result.AsyncState as UdpClient;
            if(socket != null)
            {
                //creating a variable for the raw delicious byte[] we received
                var data = socket.EndReceive(result, ref senderIp);

            }


        }
    }
}
