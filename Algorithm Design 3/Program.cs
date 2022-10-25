using System;

namespace Algorithm_Design_3
{
    internal class Program
    {
        static string OrdinalNumber(int number)
        { 
            if (number > 10)
            {
                int secondToLastDigit = number / 10 % 10;

                if (secondToLastDigit == 1)
                {
                    return $"{number}th";
                }
            }

            int lastDigit = number % 10;

            if (lastDigit == 1)
            {
                return $"{number}st";
            }
            else if (lastDigit == 2)
            {
                return $"{number}nd";
            }
            else if (lastDigit == 3)
            {
                return $"{number}rd";
            }
            else
            {
                return $"{number}th";
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 250; i++)
            {
                Console.WriteLine(OrdinalNumber(i));
            }
            
        }
    }
}
