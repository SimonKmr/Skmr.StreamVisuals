using Dev = Skmr.StreamVisuals.Server.DevKit;

namespace Skmr.StreamVisuals.Server.DeepRockGalactic
{
    internal class Monitor : Dev.Monitor
    {
        public Monitor() : base("DeepRockGalactic") { }

        private Dev.MemoryReader m = new Dev.MemoryReader("FSD-Win64-Shipping.exe", "Brotato.exe");

        public override object? Scan()
        {
            var processOpen = m.OpenProcess();

            if (!processOpen)
            {
                return null;
            }

            return new Packet()
            {
                Player = new Player()
                {
                    Health = 0,
                    Level = 0,
                    Name = "Player"
                }
            };
        }
    }
}
