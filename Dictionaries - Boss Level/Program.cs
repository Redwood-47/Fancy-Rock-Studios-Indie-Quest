using System;
using System.Collections.Generic;

namespace Dictionaries___Boss_Level
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scoreBoard = new Dictionary<string, int>();
            while (true)
            {
                Console.WriteLine("Who won this round?");

                string name = Console.ReadLine();


                if (scoreBoard.ContainsKey(name))
                {
                    scoreBoard[name] = scoreBoard[name] + 1;
                }
                else
                {
                    scoreBoard.Add(name, 1);
                }

                Console.WriteLine();
                Console.WriteLine("Current Score:");
                foreach (var score in scoreBoard)
                {
                    Console.WriteLine($"{score.Key}, {score.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}
