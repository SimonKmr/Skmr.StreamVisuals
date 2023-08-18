using Skmr.StreamVisuals.Server.DevKit;

namespace Skmr.StreamVisuals.Server.Brotato
{
    internal class Packet : IPacket
    {

        public int Currency { get; set; }
        public int Health { get; set; }
        public int Time { get; set; }
        string IPacket.Game => "Brotato";
    }
}
