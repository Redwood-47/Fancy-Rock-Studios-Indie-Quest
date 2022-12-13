using System;

namespace Switch_Mission_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Set the price:");

                string priceInput = Console.ReadLine();

                string[] equationStrings = priceInput.Split(' ');

                float x = int.Parse(equationStrings[0]);

                float sumOfPrice = 0;
                if (equationStrings.Length > 1)
                {
                    float y = int.Parse(equationStrings[2]);

                    switch (equationStrings[1])
                    {
                        case "*":
                            sumOfPrice = x * y;
                            break;

                        case "+":
                            sumOfPrice = x + y;
                            break;

                        case "/":
                            sumOfPrice = x / y;
                            break;

                        case "-":
                            sumOfPrice = x - y;
                            break;
                    }
                }
                else
                {
                    sumOfPrice = x;
                }



                Console.WriteLine($"The price was set to {sumOfPrice}");
                Console.WriteLine();
            }

        }
    }
}
