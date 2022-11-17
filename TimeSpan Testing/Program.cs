using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace TimeSpan_Testing
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            TimeSpan startingTime = TimeSpan.FromSeconds(3);
            TimeSpan timer = startingTime;

            Stopwatch stopwatch = new Stopwatch();

            while (true)
            {

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{timer.Minutes:D2}:{timer.Seconds:D2}.{timer.Milliseconds:D3}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey pressedKey = keyInfo.Key;

                    if (pressedKey == ConsoleKey.Enter && !stopwatch.IsRunning)
                    {
                        stopwatch.Start();
                    }
                }

                if (stopwatch.IsRunning)
                {
                    long elapsedTicks = stopwatch.ElapsedTicks;
                    TimeSpan elapsed = new TimeSpan(elapsedTicks);
                    timer -= elapsed;
                    stopwatch.Restart();

                    if (timer <= TimeSpan.Zero)
                    {
                        stopwatch.Reset();
                        timer = startingTime;
                    }
                }
            }
        }
    }
}