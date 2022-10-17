using System;

namespace Bowling_Pins
{
    internal class Program
    {
        static void BowlingFrameRevised()

        {
            var random = new Random();
            int bowlingToss1 = random.Next(0, 11);
            if (bowlingToss1 == 10)
            {
                Console.WriteLine("First roll: X");
            }
            else if (bowlingToss1 == 0)
                Console.WriteLine("First roll: -");
            else
                Console.WriteLine($"First roll: {bowlingToss1}");
            {
                int bowlingToss2 = random.Next(0, 11 - bowlingToss1);
                if (bowlingToss2 + bowlingToss1 == 10)
                    Console.WriteLine("Second roll: /");
                else if (bowlingToss2 == 0)
                    Console.WriteLine("Second roll: -");
                else
                    Console.WriteLine($"Second roll: {bowlingToss2}");

                int sum = { bowlingToss1 + bowlingToss2 };
                Console.WriteLine($"Total Score: {Sum}");
            }
            static void Main(string[] args)
            {
                BowlingFrameRevised();

           
            }
        }
    }
}
