using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Noahv.Game.Fccg.fccgConnectionServer
{
    /// <summary>
    /// This is a Tcp version of the connection server
    /// </summary>
    public class TcpServer
    {
        public void Run(int port)
        {
            Thread serverSocketThraed = new Thread(() =>
            {
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, port));
                server.Listen(10);
                //server.BeginAccept(new AsyncCallback(Accept), server);                
            });

            serverSocketThraed.Start();
            Console.WriteLine("Server is ready");
            //Broadcast();
        }
    }
}