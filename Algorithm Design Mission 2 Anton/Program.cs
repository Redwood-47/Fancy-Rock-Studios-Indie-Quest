using System;
using System.Collections.Generic;

namespace Algorithm_Design_Mission_2_Anton
{
    internal class Program
    {
        static Random random = new Random(); 

        static void Main(string[] args)
        {
            var listOfPeople = new List<string>();

            listOfPeople.Add("Anton");
            listOfPeople.Add("Patrik");
            listOfPeople.Add("Remi");
            listOfPeople.Add("Matej");
            listOfPeople.Add("Tintin");
            listOfPeople.Add("James");

            for (int i = 0; i < listOfPeople.Count; i++)
            {
                Console.WriteLine(listOfPeople[i]);
            }

            for (int i = 0; i < listOfPeople.Count -2; i++)
            {
                int j = random.Next(i, listOfPeople.Count);
                string tempList = listOfPeople[j];
                listOfPeople[j] = listOfPeople[i];
                listOfPeople[i] = tempList;
            }
            Console.WriteLine();
            for (int i = 0; i < listOfPeople.Count; i++)
            {
                Console.WriteLine(listOfPeople[i]);
            }
        }
    }
}
