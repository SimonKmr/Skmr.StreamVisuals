using NetCoreServer;
using System.Net.Sockets;

namespace Skmr.StreamVisuals.Server
{
    internal class GameSession : WsSession
    {
        public GameSession(WsServer server) : base(server) 
        { 
            foreach(var m in MonitorProvider.GetMonitors())
            {
                m.OnUpdate += RepeatMonitor;
                m.Start();
            }
        }

        private void RepeatMonitor(string message)
        {
            SendText(message);
            Thread.Sleep(100);
        }

        public override void OnWsConnected(HttpRequest request)
        {
            Console.WriteLine($"Chat WebSocket session with Id {Id} connected!");
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat WebSocket session caught an error with code {error}");
        }

        public override void OnWsConnecting(HttpRequest request)
        {
            Console.WriteLine("test");
            base.OnWsConnecting(request);
        }


    }
}
