using System.Net;

namespace Skmr.StreamVisuals.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            int port = 37019;
            if (args.Length > 0)
                port = int.Parse(args[0]);

            Console.WriteLine($"WebSocket server website: http://localhost:{port}");

            Console.WriteLine();

            var server = new GameServer(IPAddress.Any, port);
            server.Start();
            Console.WriteLine("Server starting...");

            Console.ReadKey();
        }
    }
}