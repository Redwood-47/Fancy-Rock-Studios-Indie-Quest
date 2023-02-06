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

    public enum WeightCategory
    {
        Light,
        Medium,
        Heavy
    }

    public class MonsterType
    {
        public string name;
        public string description;
        public string alignment;
        public int hitPointsDefault;
        public string hitPointsRoll;
        public int armorClass;
        public ArmorTypeID armorTypeID;
        public string speed;
        public string challengeRating;
        public string xp;
    }

    public class ArmorType
    {
        public string DisplayName;
        public WeightCategory Category;
        public int Weight;
    }

    internal class Program
    {
        static SortedList<string, MonsterType> monsters = new SortedList<string, MonsterType>();
        static Dictionary<ArmorTypeID, ArmorType> armorTypes = new Dictionary<ArmorTypeID, ArmorType>();

        static void Display(MonsterType monsterType)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {monsterType.name}");
            Console.WriteLine($"Description: {monsterType.description}");
            Console.WriteLine($"Alignment: {monsterType.alignment}");
            Console.WriteLine($"Hit Points Roll: {monsterType.hitPointsRoll}");
            Console.WriteLine($"Armor Class: {monsterType.armorClass}");
            if (armorTypes.ContainsKey(monsterType.armorTypeID))
            {
                ArmorType currentArmor = armorTypes[monsterType.armorTypeID];
                Console.WriteLine($"Armor Type: {currentArmor.DisplayName}");
                Console.WriteLine($"Armor Category: {currentArmor.Category}");
                Console.WriteLine($"Armor Weight: {currentArmor.Weight} lbs.");
            }
            else
            {
                Console.WriteLine($"Armor Type: {monsterType.armorTypeID}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            string[] manualLines = File.ReadAllLines("Descriptions/MonsterManual.txt");
            string[] armorLines = File.ReadAllLines("Descriptions/ArmorTypes.txt");


            List<MonsterType> monsterTypeResults = new List<MonsterType>();
            List<ArmorType> armorTypeResults = new List<ArmorType>();

            MonsterType currentMonster = null;
            ArmorType currentArmor = null;

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

                    int openParenthesisIndex = armorLineData.IndexOf("(");
                    int closedParenthesisIndex = armorLineData.IndexOf(")");

                    if (openParenthesisIndex >= 0)
                    {
                        string armorTypeText = armorLineData.Substring(openParenthesisIndex + 1, closedParenthesisIndex - openParenthesisIndex - 1);

                        if (armorTypeText.Contains("Natural"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.Natural;
                        }
                        else if (armorTypeText.Contains("Studded Leather"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.StuddedLeather;
                        }
                        else if (armorTypeText.Contains("Leather"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.Leather;
                        }
                        else if (armorTypeText.Contains("Hide"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.Hide;
                        }
                        else if (armorTypeText.Contains("Chain Shirt"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.ChainShirt;
                        }
                        else if (armorTypeText.Contains("Chain Mail"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.ChainMail;
                        }
                        else if (armorTypeText.Contains("Scale Mail"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.ScaleMail;
                        }
                        else if (armorTypeText.Contains("Plate"))
                        {
                            currentMonster.armorTypeID = ArmorTypeID.Plate;
                        }
                        else
                        {
                            currentMonster.armorTypeID = ArmorTypeID.Other;
                        }
                    }
                    else
                    {
                        currentMonster.armorTypeID = ArmorTypeID.Unspecified;
                    }
                }
            }

            for (int i = 0; i < armorLines.Length; i++)
            {
                currentArmor = new ArmorType();
                string[] splitComma = armorLines[i].Split(",");
                ArmorTypeID armorTypeID = Enum.Parse<ArmorTypeID>(splitComma[0]);
                currentArmor.DisplayName = splitComma[1];
                currentArmor.Category = Enum.Parse<WeightCategory>(splitComma[2]);
                currentArmor.Weight = Convert.ToInt32(splitComma[3]);
                armorTypes.Add(armorTypeID, currentArmor);
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
                    Console.WriteLine("Here's the monster you wanted to see.");
                    Display(monsterTypeResults[0]);
                }
                else if (foundMonster && monsterTypeResults.Count != 1 && searchInput == "n")
                {
                    Console.WriteLine("We found some monsters for you. Which one would you like to look at?");
                    string userInputNumber = Console.ReadLine();
                    int result = Convert.ToInt32(userInputNumber);
                    Display(monsterTypeResults[result - 1]);
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

                    if (monster.armorTypeID == armorResult)
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
                    currentMonster = monsterTypeResults[inputResult - 1];

                    Display(currentMonster);
                    break;
                }
            }
        }
    }
}