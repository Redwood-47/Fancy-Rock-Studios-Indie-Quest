using System;
using System.Collections.Generic;

namespace Dictionaries_Mission_1
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            var olympicHosts = new Dictionary<int, string>();
            olympicHosts.Add(2000, "Australia");
            olympicHosts.Add(2004, "Greece");
            olympicHosts.Add(2008, "China");
            olympicHosts.Add(2012, "UK");
            olympicHosts.Add(2016, "Brazil");
            olympicHosts.Add(2020, "Japan");

            while (true)
            {
                int randomYear = 2000 + (random.Next(olympicHosts.Count) * 4);
                Console.WriteLine($"Which country hosted the Summer Olympics during {randomYear}?");
                Console.WriteLine();

                if (olympicHosts[randomYear] == Console.ReadLine())
                {
                    Console.WriteLine("That answer is correct.");
                }
                else
                {
                    Console.WriteLine($"No, that's wrong. The right answer is {olympicHosts[randomYear]}.");
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
