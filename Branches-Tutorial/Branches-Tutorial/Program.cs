using System;

namespace FirstGameWorksheet
{
    internal class Program
    {
        static void BowlingFrameRevised()
        {
            var random = new Random();
            int bowltoss1 = random.Next(0, 11);
            int total = 0;

            if (bowltoss1 == 10)
            {
                Console.WriteLine("First roll: X");
                total = 10;
            }
            else
            {
                if (bowltoss1 == 0)
                {
                    Console.WriteLine("First roll: -");
                }
                else
                {
                    Console.WriteLine($"First roll: {bowltoss1}");
                }

                int bowltoss2 = random.Next(0, 11 - bowltoss1);

                if (bowltoss2 == 10 - bowltoss1)
                {
                    Console.WriteLine("Second roll: /");
                }
                else if (bowltoss2 == 0)
                {
                    Console.WriteLine("Second roll: -");
                }
                else
                {
                    Console.WriteLine($"Second roll: {bowltoss2}");
                }

                total = bowltoss1 + bowltoss2;

            }
            Console.WriteLine($"Knocked Pins: {total}");

            /*
           int bowltoss2 = random.Next(0, 11 - bowltoss1);
           int total = bowltoss1 + bowltoss2;
            if (bowltoss1 == 0)
            {
                Console.WriteLine("First roll: -");
            }
            else if (bowltoss1 == 10)
            {
                Console.WriteLine("First roll: X");
            }
            else
            {
                Console.WriteLine($"First roll: {bowltoss1}");
            }
            if (bowltoss2 == 10 - bowltoss1)
            {
                Console.WriteLine("Second roll: /");
            }
            else if (bowltoss2 == 0)
            {
                Console.WriteLine("Second roll: -");
            }
            else
            {
                Console.WriteLine($"Second roll: {bowltoss2}");
            }
                Console.WriteLine($"Knocked Pins: {total}");*/
        }

        static void Main(string[] args) 
        {
            BowlingFrameRevised();
        }
    }
}
