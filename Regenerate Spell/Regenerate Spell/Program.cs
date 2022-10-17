using System;

namespace Regenerate_Spell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regeneration();

            void Regeneration()
            {
                var random = new Random();
                int WarriorHP = random.Next(1, 101);
                
                Console.WriteLine($"Warrior HP: {WarriorHP}");

                if (WarriorHP > 50)
                {

                }
                else
                {
                    Console.WriteLine("The Regenerate spell is cast!");
                }
                do
                {
                    if (WarriorHP < 50)
                    {
                        WarriorHP += 10;

                        Console.WriteLine($"Warrior HP: {WarriorHP}");
                    }
                } while (WarriorHP < 50);
            }
        }
    }
}
