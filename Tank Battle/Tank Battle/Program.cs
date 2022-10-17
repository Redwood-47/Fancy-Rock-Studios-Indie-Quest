using System;

namespace Tank_Battle
{
    internal class Program
    { 
        static Random random = new Random();
    
        static void Main(string[] args)
        {
            int tankDistance = random.Next(40, 71);
            int ground = 2;
            int mortar;
            Console.WriteLine("Varning!! En pansarvagn från fienden är på väg mot oss! Du är vårt enda hopp!");
            Console.WriteLine();
            Console.WriteLine("Vad heter du?");
            string CommanderName = Console.ReadLine();
            do
            {
                Console.WriteLine();
                Console.Write($"_/");
                do
                {
                    if (ground == tankDistance)
                    {
                        Console.Write("P");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                    ground++;
                } while (ground < 81);
                int landLength = 0;
                Console.WriteLine();
                Console.WriteLine($"Sikta, {CommanderName}!");
                Console.WriteLine();
                Console.Write("Skriv in distansen:");
                mortar = Convert.ToInt32(Console.ReadLine());
                do
                {
                  if (mortar == landLength -2)
                    {
                      Console.Write("*");
                    }
                  else
                    {
                      Console.Write(" ");
                    }
                  landLength++;
                } while (landLength < 81);
                ground = (ground - 81);
                Console.WriteLine();
                if (mortar == tankDistance)
                {
                    break;
                }
                else if (mortar > tankDistance)
                {
                    Console.WriteLine("Attans, du sköt för högt!");
                }
                else if (mortar < tankDistance)
                {
                    Console.WriteLine("Du sköt för lågt!");
                }
                int movementTank = random.Next(1, 16);
                tankDistance = tankDistance - movementTank;
                Console.WriteLine();
                Console.WriteLine("Tryck på ENTER knappen för att uppdatera skärmen.");
                Console.ReadLine();
                Console.Clear();
            } while (tankDistance > 0);
            if (mortar == tankDistance)
            {
                Console.WriteLine("Grattis! Du träffade den! Jag bjuder på champagne när vi kommer hem!");
            }
            else
            {
                Console.WriteLine("Vi har förlorat striden. Adjö, det var en ära att strida med di- **KA-BOOM**");
            }
        } 
    }
}
