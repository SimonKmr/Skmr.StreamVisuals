using NetCoreServer;
using Skmr.StreamVisuals;
using System.Net;

namespace Skmr.StreamVisuals.Server
{
    internal class GameServer : WsServer
    {
        public GameServer(IPAddress address, int port) : base(address, port){ }
        protected override TcpSession CreateSession() 
        { 
            return new GameSession(this); 
        }
    }
}
