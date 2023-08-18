using Server;

namespace TestTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemoryReader mr = new MemoryReader("Brotato", "Brotato.exe");
            if (mr.OpenProcess())
            {
                Console.WriteLine( mr.Read(new int[] { 0x0278E510, 0x2A8, 0x150, 0x108, 0x38, 0x58, 0x20, 0x1D0 }));
            }
        }
    }
}