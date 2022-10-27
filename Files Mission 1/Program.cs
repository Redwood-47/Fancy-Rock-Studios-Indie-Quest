using System;
using System.IO;

namespace Files_Mission_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerNamePath = "player-name.txt";
            if (!File.Exists(playerNamePath))
            {
                Console.WriteLine("Welcome to your biggest adventure yet!");
                Console.WriteLine();
                Console.WriteLine("What is your name, traveller?");
                string playerName = Console.ReadLine();
                File.WriteAllText(playerNamePath, playerName);
            }
            else
            {
                string playerName = File.ReadAllText(playerNamePath);
                Console.WriteLine($"Welcome back, {playerName}!");
                File.Delete(playerNamePath);
            }


        }
    }
}
