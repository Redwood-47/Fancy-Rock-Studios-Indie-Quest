using System;
using System.Runtime.InteropServices;

namespace Test
{
    internal class Program
    {
        public static System.Runtime.InteropServices.Architecture OSArchitecture { get; }
        public static bool IsOSPlatform(System.Runtime.InteropServices.OSPlatform osPlatform)
        {
            if (osPlatform == System.Runtime.InteropServices.OSPlatform.OSX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            if (System.Environment.OSVersion.VersionString.Contains("Windows"))
            {
                Console.WriteLine("You are running the game on Windows: True");
            }
            else if (!System.Environment.OSVersion.VersionString.Contains("Windows"))
            {
                Console.WriteLine("You are running the game on Windows: False");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Console.WriteLine("Windows");
            }

        }
    }
}
