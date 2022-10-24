using System;

namespace Ordinal_Numbers
{
    internal class Program
    {
        static string OrdinalNumber(int number)
        {
            int lastDigit = number % 10;
            int secondToLastDigit = number / 10 % 10;

            if (secondToLastDigit == 1)
            {
                return number + "th";
            }
            else if (lastDigit == 1)
            {
                return number + "st";
            }
            else if (lastDigit == 2)
            {
                return number + "nd";
            }
            else if (lastDigit == 3)
            {
                return number + "rd";
            }
            else
            {
                return number + "th";
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 251; i++)
            {
                Console.WriteLine(OrdinalNumber(i));
            }
        }
    }
}
