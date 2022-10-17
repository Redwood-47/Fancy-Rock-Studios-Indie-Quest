using System;

namespace RollTillSix
{
    internal class Program
    {
        static Random random = new Random();
        static void RollTillSix()
        {
            int total = 0;
            int dice;
            do
            {
                dice = random.Next(1, 7);
                Console.WriteLine($"The player rolls: {dice}");
                total = total + dice;
            } while (dice < 6);
            {
                Console.WriteLine($"Total score: {total}");
            }
        }
        static void Main(string[] args)
        {
            RollTillSix();
        }
    }
}
