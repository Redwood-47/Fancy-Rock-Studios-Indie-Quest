using System;
using System.Collections.Generic;
using System.IO;

namespace Monster_Manual_Unit_1
{
    public enum ArmorTypeID
    {
        Unspecified = 1,
        Natural = 2,
        Leather = 3,
        StuddedLeather = 4,
        Hide = 5,
        ChainShirt = 6,
        ChainMail = 7,
        ScaleMail = 8,
        Plate = 9,
        Other = 10
    }

    public class MonsterType
    {
        public string name;
        public string description;
        public string alignment;
        public int hitPointsDefault;
        public string hitPointsRoll;
        public int armorClass;
        public ArmorTypeID armorType;
        public string speed;
        public string challengeRating;
        public string xp;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] manualLines = File.ReadAllLines("Descriptions/MonsterManual.txt");
            string[] armorLines = File.ReadAllLines("Descriptions/ArmorTypes.txt");
            var monsters = new SortedList<string, MonsterType>();

            List<MonsterType> monsterTypeResults = new List<MonsterType>();

            MonsterType currentMonster = null;

            for (int i = 0; i < manualLines.Length; i++)
            {
                if (i % 7 == 0)
                {
                    //Line = Name of Monster
                    currentMonster = new MonsterType();
                    currentMonster.name = manualLines[i].ToLowerInvariant();
                    monsters.Add(currentMonster.name, currentMonster);
                }
                else if (i % 7 == 1)
                {
                    //Line = Description & Alignment
                    string[] splitDescription = manualLines[i].Split(", ");
                    currentMonster.description = splitDescription[0];
                    currentMonster.alignment = splitDescription[1];
                }
                else if (i % 7 == 2)
                {
                    string[] splitHitPoints = manualLines[i].Substring("Hit Points: ".Length).Split(' ');
                    currentMonster.hitPointsRoll = splitHitPoints[1];
                }
                else if (i % 7 == 3)
                {
                    string armorLineData = manualLines[i].Substring("Armor Class: ".Length);
                    string[] splitArmor = armorLineData.Split(' ');

                    currentMonster.armorClass = int.Parse(splitArmor[0]);
                    //Enum.Parse<ArmorTypeID>(splitArmor[1]); Save for later(?)

                    int openParenthesisIndex = armorLineData.IndexOf("(");
                    int closedParenthesisIndex = armorLineData.IndexOf(")");

                    if (openParenthesisIndex >= 0)
                    {
                        string armorTypeText = armorLineData.Substring(openParenthesisIndex + 1, closedParenthesisIndex - openParenthesisIndex - 1);

                        if (armorTypeText.Contains("Natural"))
                        {
                            currentMonster.armorType = ArmorTypeID.Natural;
                        }
                        else if (armorTypeText.Contains("Leather"))
                        {
                            currentMonster.armorType = ArmorTypeID.Leather;
                        }
                        else if (armorTypeText.Contains("Studded Leather"))
                        {
                            currentMonster.armorType = ArmorTypeID.StuddedLeather;
                        }
                        else if (armorTypeText.Contains("Hide"))
                        {
                            currentMonster.armorType = ArmorTypeID.Hide;
                        }
                        else if (armorTypeText.Contains("Chain Shirt"))
                        {
                            currentMonster.armorType = ArmorTypeID.ChainShirt;
                        }
                        else if (armorTypeText.Contains("Chain Mail"))
                        {
                            currentMonster.armorType = ArmorTypeID.ChainMail;
                        }
                        else if (armorTypeText.Contains("Scale Mail"))
                        {
                            currentMonster.armorType = ArmorTypeID.ScaleMail;
                        }
                        else if (armorTypeText.Contains("Plate"))
                        {
                            currentMonster.armorType = ArmorTypeID.Plate;
                        }
                        else
                        {
                            currentMonster.armorType = ArmorTypeID.Other;
                        }
                    }
                    else
                    {
                        currentMonster.armorType = ArmorTypeID.Unspecified;
                    }
                }
            }

            Console.WriteLine("MONSTER MANUAL");
            Console.WriteLine("Would you like to search by Armor (a) or by Name (n)?");
            string searchInput = Console.ReadLine();
            Console.WriteLine();

            while (searchInput != "n" || searchInput != "a")
            {
                if (searchInput == "n")
                {
                    Console.WriteLine("Enter a query to search for monsters by name:");
                }
                else if (searchInput == "a")
                {
                    Console.WriteLine("Which armor type would you like to search for?");
                }
                else
                {
                    Console.WriteLine("Sorry, you have to insert the letter (n) or (a), in order to search.");
                }

                if (searchInput != null)
                {
                    break;
                }
            }

            while (searchInput == "n")
            {
                string userInput = Console.ReadLine();
                Console.WriteLine();

                bool foundMonster = false;
                int numberCounter = 1;
                for (int i = 0; i < monsters.Count; i++)
                {
                    if (monsters.Keys[i].Contains(userInput.ToLowerInvariant()))
                    {
                        string monsterName = monsters.Keys[i];
                        MonsterType monster = monsters[monsterName];

                        Console.WriteLine($"{numberCounter}. {monster.name}");
                        foundMonster = true;
                        numberCounter++;

                        monsterTypeResults.Add(monster);
                    }
                }
                Console.WriteLine();
                if (!foundMonster)
                {
                    Console.WriteLine("Error: Could not find. Try again.");
                    continue;
                }
                else if (foundMonster && monsterTypeResults.Count == 1 && searchInput == "n")
                {
                    string monsterName = monsterTypeResults[0].name;
                    MonsterType monster = monsters[monsterName];


                    Console.WriteLine("Here's the monster you wanted to see.");
                    Console.WriteLine();
                    Console.WriteLine($"Name: {monsterName}");
                    Console.WriteLine($"Description: {monsterTypeResults[0].description}");
                    Console.WriteLine($"Alignment: {monsterTypeResults[0].alignment}");
                    Console.WriteLine($"Hit Points Roll: {monsterTypeResults[0].hitPointsRoll}");
                    Console.WriteLine($"Armor Class: {monsterTypeResults[0].armorClass}");
                    Console.WriteLine($"Armor Type: {monsterTypeResults[0].armorType}");
                }
                else if (foundMonster && monsterTypeResults.Count != 1 && searchInput == "n")
                {
                    Console.WriteLine("We found some monsters for you. Which one would you like to look at?");
                    string userInputNumber = Console.ReadLine();
                    int result = Convert.ToInt32(userInputNumber);
                    Console.WriteLine();
                    Console.WriteLine($"Name: {monsterTypeResults[result - 1].name}");
                    Console.WriteLine($"Description: {monsterTypeResults[result - 1].description}");
                    Console.WriteLine($"Alignment: {monsterTypeResults[result - 1].alignment}");
                    Console.WriteLine($"Hit Points Roll: {monsterTypeResults[result - 1].hitPointsRoll}");
                    Console.WriteLine($"Armor Class: {monsterTypeResults[result - 1].armorClass}");
                    Console.WriteLine($"Armor Type: {monsterTypeResults[result - 1].armorType}");

                    break;
                }
            }

            while (searchInput == "a")
            {
                Console.WriteLine();

                bool foundMonster = false;
                int numberCounter = 1;
                foreach (string i in Enum.GetNames(typeof(ArmorTypeID)))
                {
                    Console.WriteLine($"{numberCounter}. {i}");
                    numberCounter++;
                }

                Console.WriteLine();
                Console.WriteLine("Enter number:");
                Console.WriteLine();
                numberCounter = 1;
                string userInput = Console.ReadLine();
                int result = Convert.ToInt32(userInput);
                Console.WriteLine();
                for (int i = 0; i < monsters.Count; i++)
                {
                    string monsterName = monsters.Keys[i];
                    MonsterType monster = monsters[monsterName];

                    ArmorTypeID armorResult = (ArmorTypeID)result;

                    if (monster.armorType == armorResult)
                    {
                        Console.WriteLine($"{numberCounter}. {monster.name}");
                        foundMonster = true;
                        numberCounter++;

                        monsterTypeResults.Add(monster);
                    }
                }

                if (foundMonster && monsterTypeResults.Count != 1 && searchInput == "a")
                {
                    Console.WriteLine("We found some monsters for you. Which one would you like to look at?");
                    Console.WriteLine();
                    string userInputNumber = Console.ReadLine();
                    int inputResult = Convert.ToInt32(userInputNumber);
                    Console.WriteLine();
                    Console.WriteLine($"Name: {monsterTypeResults[inputResult - 1].name}");
                    Console.WriteLine($"Description: {monsterTypeResults[inputResult - 1].description}");
                    Console.WriteLine($"Alignment: {monsterTypeResults[inputResult - 1].alignment}");
                    Console.WriteLine($"Hit Points Roll: {monsterTypeResults[inputResult - 1].hitPointsRoll}");
                    Console.WriteLine($"Armor Class: {monsterTypeResults[inputResult - 1].armorClass}");
                    Console.WriteLine($"Armor Type: {monsterTypeResults[inputResult - 1].armorType}");
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
}