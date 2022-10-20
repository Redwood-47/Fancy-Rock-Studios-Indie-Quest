using System;
using System.Collections.Generic;

namespace KrakenBattle
{
    internal class Program
    {
        static Random random = new Random();
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int result = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll = random.Next(diceSides)+1;
                result += roll;
            }
            result += fixedBonus;
            return result;
        }
        static void SimulateCombat(List<string> characterNames, string monsterName, int monsterHP, int savingThrowDC)
        {
            if (characterNames.Count == 0)
            {
                return;
            }
            Console.WriteLine($"A mighty {monsterName} with {monsterHP} HP heaves itself upon the deck of the ship!");
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (string pirate in characterNames)
                {
                    int boatAxeTotal = DiceRoll(2, 6);
                    monsterHP = monsterHP - boatAxeTotal;
                    if (monsterHP <= 0)
                    {
                        monsterHP = 0;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"{pirate} slashes the {monsterName} tentacles for {boatAxeTotal} damage. The {monsterName} has {monsterHP} HP left.");

                    if (monsterHP == 0)
                    {
                        Console.WriteLine($"The {monsterName} slumps back into the ocean, defeated. Our pirates celebrate with a crate of rum!");
                        break;
                    }
                }
                Console.ForegroundColor= ConsoleColor.Red;
                if (monsterHP > 0)
                {
                    if (characterNames.Count == 0)
                    {
                        Console.WriteLine($"The {monsterName} has defeated our swasbuckling heroes!");
                        break;
                    }
                    int target = random.Next(characterNames.Count);
                    Console.WriteLine();
                    Console.WriteLine($"The {monsterName} attacks {characterNames[target]}!");
                    int dexSavingthrow = DiceRoll(1, 20, 3);
                    Console.Write($"{characterNames[target]} rolls a {dexSavingthrow} Saving Throw,");
                    
                    if (dexSavingthrow < savingThrowDC)
                    {
                        characterNames.RemoveAt(target);
                        Console.Write(" fails the Saving Throw and has met their demise!");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.Write(" succeeds the Saving Throw and manages to keep fighting!");
                        Console.WriteLine();
                    }
                }
            } while (monsterHP > 0);
        }
        static void Main(string[] args)
        {
            var characterNames = new List<string> { "Gregory", "Foul Fritjof", "Rozanna", "Sinclair", };
            Console.WriteLine($"Swashbuckling pirates {String.Join(", ", characterNames)} stand upon the deck.");

            int skeletonHP = DiceRoll(2, 8, 6);
            SimulateCombat(characterNames, "Drowned Skeleton", skeletonHP, 10);
            
            int sahuaginHp = DiceRoll(6, 8, 12);
            SimulateCombat(characterNames, "Sahuagin", sahuaginHp, 18);
            
            int krakenHp = DiceRoll(8, 10, 40);
            SimulateCombat(characterNames, "Kraken", krakenHp, 16);
           
            if (characterNames.Count > 0)
            {
                Console.WriteLine($"After defending their ship from three vicious attackers, the pirates {String.Join(", ", characterNames)} sail away to plunder another day.");
            }
        }
    }
}
