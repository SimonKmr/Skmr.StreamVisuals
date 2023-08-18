using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Skmr.StreamVisuals.Server.DevKit
{
    public interface IMonitor
    {
        public void Start();
        public void Stop();
        public bool IsRunning { get; }
        public string Game { get; }

        public event UpdateHandler OnUpdate;
        public delegate void UpdateHandler(string message);
    }
}
