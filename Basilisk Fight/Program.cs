using System;
using System.Collections.Generic;

namespace Basilisk_Fight
{
    internal class Program
    {
        static Random random = new Random();
        static void krakenRoll()
        {
            var pirates = new List<string> { "Sinclair", "Foul Fritjof", "Gregory", "Hector" };
            {
                Console.WriteLine($"The mighty swashbuckling pirates, {String.Join(", ", pirates)}, stand bravely upon their ship.");
            }
            int krakenHP = 0;
            for (int i = 0; i < 8; i++)
            {
                int kraken = random.Next(1, 9);
                krakenHP = krakenHP + kraken;
            }
            krakenHP = krakenHP + 16;
            Console.WriteLine();
            Console.WriteLine($"Yargh! The terrifying Kraken slams its tentacles upon our ship with {krakenHP} HP! Smite the beast!!");
            Console.WriteLine();
            do
            {
                
                foreach (var pirate in pirates)
                {
                    int dagger = random.Next(1, 5);
                    krakenHP = krakenHP - dagger;
                    if (krakenHP <= 0)
                    {
                        krakenHP = 0;
                    }
                    Console.WriteLine($"Our mighty pirate {pirate} stabs the beast's slimy tentacle with his dagger, dealing {dagger} damage! The beast has {krakenHP} HP remaining.");
                    if (krakenHP == 0)
                    {
                        Console.WriteLine("Huzzah! The beast has been slain! Bring out the rum, laddies!");
                        break;
                    }
                    Console.WriteLine();
                }
                int dexterityThrow = random.Next(1, 21);
                dexterityThrow = dexterityThrow + 3;
                if(krakenHP <= 0)
                {
                    break;
                }
                int target = random.Next(pirates.Count); 
                if (pirates.Count <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The Kraken has sunk the ship. Our mighty pirate's souls now belong to Davy Jones...");
                    break;
                }
                Console.WriteLine($"The kraken attempts to grab {pirates[target]} and squeeze them to death!");
                Console.WriteLine();
                if (dexterityThrow >= 12)
                {
                    Console.Write($"{pirates[target]} rolled a/an {dexterityThrow} for their Dexterity Saving Throw. ");
                    Console.WriteLine($"{pirates[target]} manages to dodge the attack!");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write($"{pirates[target]} rolled a/an {dexterityThrow} for their Dexterity Saving Throw. ");
                    Console.WriteLine($"Damn! The Kraken has crushed {pirates[target]}. They'll be sleeping with the fishes tonight.");
                    pirates.Remove(pirates[target]);
                    Console.WriteLine();
                }
            } while (krakenHP > 0);
        }
        static void Main(string[] args)
        {
            krakenRoll();
        }
    }
}
