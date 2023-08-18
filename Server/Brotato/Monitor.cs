using Dev = Skmr.StreamVisuals.Server.DevKit;

namespace Skmr.StreamVisuals.Server.Brotato
{
    internal class Monitor : Dev.Monitor
    {
        public Monitor() : base("Brotato") { }

        private Dev.MemoryReader m = new Dev.MemoryReader("brotato", "Brotato.exe");

        public override object? Scan()
        {
            var processOpen = m.OpenProcess();
            
            if (!processOpen)
            {
                return null;
            }

            var currency = m.Read(new int[] { 0x0278E510, 0x2A8, 0x150, 0x108, 0x38, 0x58, 0x20, 0x1D0 });
            return new Packet()
            {
                Currency = currency,
                Health = 0,
            };
        }
    }
}
