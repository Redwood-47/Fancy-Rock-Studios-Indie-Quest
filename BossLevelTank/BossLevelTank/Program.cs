using System;

namespace BossLevelTank
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            int tankDistance = random.Next(40, 71);
            int ground = 0;
            int mortar;
            Console.WriteLine("DANGER! A tank is approaching our position. Your mortar unit is our only hope!");
            Console.WriteLine();
            Console.WriteLine("What is your name, Commander?");
            string commanderName = Console.ReadLine();
            do
            {
                Console.WriteLine();
                Console.Write("_/");
                do
                {
                    if (ground == tankDistance)
                    {
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                    ground++;
                } while (ground <81);
                int landmass = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Aim your shot, {commanderName}!");
                Console.Write("Enter distance:");
                mortar = Convert.ToInt32(Console.ReadLine());
                do
                {
                    if (mortar == landmass - 2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    landmass++;
                } while (landmass < 81);
                ground = (ground - 81);
                Console.WriteLine();
                if (mortar == tankDistance)
                {
                    break;
                }
                else if (mortar < tankDistance)
                {
                    Console.WriteLine("Oh no! It appears the enemy is further away!");
                }
                else
                {
                    Console.WriteLine("Bollocks! Your shell flew past them!");
                }
                int tankMovement = random.Next(1, 16);
                tankDistance = tankDistance - tankMovement;
                Console.WriteLine();
                Console.WriteLine("Press enter to see the new battlefield.");
                Console.ReadLine();
                Console.Clear();
            } while (tankDistance > 0);
            if (mortar == tankDistance)
            {
                Console.WriteLine("*BOOM* Fantastic! You've destroyed the tank and saved the entire battalion, Commander!");
            }
            else
            {
                Console.WriteLine("The enemy is upon us Commander, it's been an honor.");
            }
        }
    }
}
