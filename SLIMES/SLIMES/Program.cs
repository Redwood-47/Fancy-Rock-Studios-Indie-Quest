using System;

namespace SLIMES
{
    internal class Program
    {
        static Random random = new Random();
        static void Slimy()
        {
            int totstrength = 0;
            for (int index = 0; index < 3; index++)
            {
                int strength = random.Next(1, 7);
                totstrength = totstrength + strength;
            }
            Console.WriteLine($"A character with strength {totstrength} was created.");
           
            int cubehp = 0;
            for (int index = 0; index < 8; index++)
            {
                int cube = random.Next(1, 11);
                cubehp = cubehp + cube;
            }
            cubehp = cubehp + 40;
            Console.WriteLine($"A gelatinous cube with {cubehp} HP appears!");

            int armyhp = 0;
            for (int index = 0; index < 100; index++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int army = random.Next(1, 11);
                    armyhp = armyhp + army;
                }
                armyhp = armyhp + 40;
            }
            Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {armyhp} HP. We are doomed!");
        }
        static void Main(string[] args)
        {
            Slimy();
        }
    }
}
