using System;

namespace Branches_Tutorial
{
    internal class Program
    {
        static Random random = new Random();
        static void DiceRolls()

        {
            int total = 0;
            int dice = 0;
            do
            {
                dice = random.Next(1, 7);
                Console.WriteLine($"The player rolls: {dice}");
                total = total + dice;
            } while (dice < 6);
            
            
            Console.WriteLine($"Total Score: {total}.");
        
        } 

        static void Main(string[] args)
        {
            DiceRolls();
        }

    }
}

