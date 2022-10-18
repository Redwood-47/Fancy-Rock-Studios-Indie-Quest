using System;
using System.Collections.Generic;

namespace ListCharacterGeneration
{
    internal class Program
    {
        static Random random = new Random();
        static void diceRoll()
        {
            var abilityScores = new List<int>();
            for (int p = 0; p < 6; p++)
            {
                int totalRoll = 0;
                int lowestRoll = 6;
                int roll;
                Console.Write("You roll");
                for (int i = 0; i < 4; i++)
                {
                    roll = random.Next(1, 7);
                    if (roll < lowestRoll)
                    {
                        lowestRoll = roll;
                    }
                    Console.Write($" {roll}");
                    if (i < 3)
                    {
                        Console.Write(",");
                    }
                    totalRoll = totalRoll + roll;
                }
                totalRoll = totalRoll - lowestRoll;
                abilityScores.Add(totalRoll);
                Console.Write($". The ability score is {totalRoll}.");
                Console.WriteLine();
            }
            abilityScores.Sort();
            
            Console.WriteLine($"Your available ability scores are {String.Join(", ",abilityScores)}");


        }
        static void Main(string[] args)
        {
            diceRoll();
        }
    }
}
