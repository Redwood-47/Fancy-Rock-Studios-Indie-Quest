using System;
using System.Collections.Generic;

namespace Algorith_Design_Unit_2_Mission_1
{
    internal class Program
    {
        static Random random = new Random();
        static void ShuffleList(List<string> items)
        {
            for (int i = 0; i <= items.Count-2; i++)
            {
                int j = random.Next(i, items.Count);
                string temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
            {
                int factorialTotal = n * Factorial (n-1);
                return factorialTotal;
            }
        }
    
        static void Main(string[] args)
        {
            var participantList = new List<string> { "Patrik", "Anton", "Matej", "Bozo", "Tintin" };
            Console.WriteLine($"Learning office homies: {String.Join(", ",participantList)}");
            Console.WriteLine("Swapping desks...");
            while (true)
            {

                ShuffleList(participantList);

                int patrikIndex = participantList.IndexOf("Patrik");
                int antonIndex = participantList.IndexOf("Anton");
                int distance = Math.Abs (patrikIndex - antonIndex);

                if (distance == 1)
                {
                    break;
                }
            }

            Console.WriteLine($"Shuffled learning office homies: {String.Join(", ",participantList)}");

            for (int i = 0; i < 21; i++)
            {
                Console.WriteLine($"{i}! = {Factorial(i)}"); 
            }
            

        }
    }
}
