using DRG = Skmr.StreamVisuals.Server.DeepRockGalactic;
using BTT = Skmr.StreamVisuals.Server.Brotato;
using Skmr.StreamVisuals.Server.DevKit;

namespace Skmr.StreamVisuals.Server
{
    internal static class MonitorProvider
    {
        private static IMonitor[] monitors;
        public static IMonitor[] GetMonitors()
        {
            if (monitors == null)
            {
                monitors = new IMonitor[]
                {
                    new DRG.Monitor(),
                    new BTT.Monitor(),
                };
            }
            return monitors;
        }
    }
}
