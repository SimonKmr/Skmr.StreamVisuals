using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Skmr.StreamVisuals.Server.DevKit
{
    public class MemoryReader
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        public string ProcessName { get; private set; }
        public IntPtr ProcessHandle { get; private set; }
        public int ProcessId { get; private set; }
        public nint Base { get; private set; }
        public string ModuleName { get; private set; }

        public MemoryReader(string processName, string moduleName)
        {
            ProcessName = processName;
            ModuleName = moduleName;
        }

        public bool OpenProcess()
        {
            var processes = Process.GetProcessesByName(ProcessName);
            if (processes.Length == 0)
                return false;
            try
            {
                var process = processes.First();
                ProcessHandle = process.Handle;

                for (int i = 0; i < process.Modules.Count; i++)
                {
                    if (process.Modules[i].ModuleName.Contains(ModuleName))
                    {
                        Base = process.Modules[i].BaseAddress;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return false;
        }

        public int Read(int[] offsets)
        {
            nint basis = Base;

            for (int i = 0; i < offsets.Length; i++)
            {
                var offset = offsets[i];
                basis = basis + offset;

                IntPtr bytesWritten;
                var buffer = new byte[nint.Size];
                ReadProcessMemory(ProcessHandle, basis, buffer, buffer.Length, out bytesWritten);

                //nsize = 4 -> 32bit process
                //nsize = 8 -> 64bit process
                if (buffer.Length == 4)
                {
                    basis = new nint(BitConverter.ToInt32(buffer, 0));
                }
                else if (buffer.Length == 8)
                {
                    basis = new nint(BitConverter.ToInt64(buffer, 0));
                }
            }

            return (int)basis;
        }
    }
}
