using System;
using System.IO;
namespace Files_Mission_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Figuring out the players name
            string playerNamePath = "player-name.txt";
            string playerName;
            

            if (!File.Exists(playerNamePath))
            {
                Console.WriteLine("Welcome to the ASCII-sea, Pirate!");
                Console.WriteLine("What be yer name?");
                playerName = Console.ReadLine();
                File.WriteAllText(playerNamePath, playerName);
                Console.WriteLine($"Welcome aboard, Captain {playerName}!");
            }
            else
            {
                playerName = File.ReadAllText(playerNamePath);
                Console.WriteLine($"Our Captain {playerName} has returned!");
                
            }
            
            //Figuring out if player is a backer
            string[] backers = File.ReadAllLines("backers.txt");
            bool isABacker = false;
            foreach (string backer in backers)
            {
                if (backer == playerName)
                {
                    isABacker = true;
                }
            }

            //Telling the player if they are on the list
            if (!isABacker)
            {
                Console.WriteLine("Unfortunately you are not permitted to enter the Captain's cabin.");
            }
            else
            {
                Console.WriteLine("You succesfully enter the Captain's cabin and take your seat as our rightful Captain!");
                Console.WriteLine("The crew hails you with a warm welcome for backing the game's kickstarter!");
            }

            // Goodbye
            Console.WriteLine("Have a nice day!");
        }
    }
}
