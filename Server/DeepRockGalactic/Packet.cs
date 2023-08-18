using Skmr.StreamVisuals.Server.DevKit;

namespace Skmr.StreamVisuals.Server.DeepRockGalactic
{
    internal class Packet : IPacket
    {
        public string Game => "DeepRockGalactic";
        public string ID { get; set; } 
        public Player Player { get; set; }

    }

    internal class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
    }

    internal class Weapon
    {
        public string Name { get; set; }
        public int Ammo { get; set; }
        public int Capacity { get; set; }
        public int Heat { get; set; }
    }

    public enum Class
    {
        Driller,
        Engineer,
        Gunner,
        Scout
    }

}
