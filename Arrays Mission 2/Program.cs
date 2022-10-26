using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Arrays_Mission_2
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            int[] monsterAmounts = new int[100];
            for (int i = 0; i < monsterAmounts.Length; i++)
            {
                int monsterAmount = random.Next(50)+1;
                monsterAmounts[i] = monsterAmount;
            }

            Array.Sort(monsterAmounts);
            Console.Write("Number of monsters in levels: ");
            Console.Write($"{String.Join(",", monsterAmounts)}.");
        }
    }
}
