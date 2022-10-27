using System;
using System.IO;
namespace Files_Mission_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerNamePath = "player-name.txt";

            if (!File.Exists(playerNamePath))
            {
                Console.WriteLine("Welcome to the ASCII-sea, Pirate!");
                Console.WriteLine("What be yer name?");
                string playerName = Console.ReadLine();
                File.WriteAllText(playerNamePath, playerName);
                Console.WriteLine($"Welcome aboard, Captain {playerName}!");
            }
            else
            {
                string playerName = File.ReadAllText(playerNamePath);
                Console.WriteLine($"Our Captain {playerName} has returned!");
                string backers = File.ReadAllText("backers.txt");
                string[] backersArray = {backers};
                if (backers.Contains(playerName))
                {
                    Console.WriteLine("You succesfully enter the Captain's cabin and take your seat as our rightful Captain!");
                    Console.WriteLine("The crew hails you with a warm welcome for backing the game's kickstarter!");
                }
                else
                {
                    Console.WriteLine("Unfortunately you are not permitted to enter the Captain's cabin.");
                }
            }
        }
    }
}
