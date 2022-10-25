using System;

namespace Arrays_Mission_1
{
    internal class Program
    {
        static string CreateDayDescription(int day, int season, int year)
        {
            string[] seasonArray = { "Spring", "Summer", "Fall", "Winter"};
            return $"{OrdinalNumber(day)} day of {seasonArray[season]} in the year {year}.";
        }
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
            Console.WriteLine(CreateDayDescription(29, 3, 753));
        }
    }
}
