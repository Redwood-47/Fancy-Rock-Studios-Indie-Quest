using System;
using System.Collections.Generic;

namespace Dictionaries___Mission_2
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            var countryCapitals = new SortedList<string, string>();

            countryCapitals.Add("Sweden", "Stockholm");
            countryCapitals.Add("Norway", "Oslo");
            countryCapitals.Add("Finland", "Helsinki");
            countryCapitals.Add("Denmark", "Copenhagen");
            countryCapitals.Add("Iceland", "Reykjavik");
            countryCapitals.Add("Russia", "Moscow");
            countryCapitals.Add("Belarus", "Minsk");
            countryCapitals.Add("Ukraine", "Kyiv");
            countryCapitals.Add("Germany", "Berlin");
            countryCapitals.Add("France", "Paris");
            countryCapitals.Add("Slovenia", "Ljubljana");
            countryCapitals.Add("USA", "Washington");
            countryCapitals.Add("Japan", "Tokyo");
            countryCapitals.Add("UK", "London");
            countryCapitals.Add("Jamaica", "Kingston");

            var countries = new List<string>(countryCapitals.Keys);
            
            while (true)
            {
                int randomCountryIndex = random.Next(countries.Count);
                string randomCountry = countries[randomCountryIndex];

                Console.WriteLine($"What is the capital of {randomCountry}?");
                Console.WriteLine();

                if (countryCapitals[randomCountry] == Console.ReadLine())
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"No, that's wrong. The capital is {countryCapitals[randomCountry]}.");
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
