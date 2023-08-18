using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Skmr.StreamVisuals.Server.DevKit
{
    public abstract class Monitor : IMonitor
    {
        public event IMonitor.UpdateHandler OnUpdate = delegate { };

        public string Game { get; }
        public bool IsRunning { get; private set; }

        public Monitor(string gameName)
        {
            Game = gameName;
        }

        public void Start()
        {
            IsRunning = true;
            Thread thread = new Thread(RunMonitor);
            thread.Start();
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void RunMonitor()
        {
            while (IsRunning)
            {
                var packet = Scan();

                if (packet != null)
                {
                    var json = JsonConvert.SerializeObject(packet);
                    OnUpdate(json);
                }
            }
        }

        public abstract object? Scan();
    }
}
