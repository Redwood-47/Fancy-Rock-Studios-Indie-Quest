using System;
using System.Collections.Generic;

namespace Algorithm_Design_2
{
    internal class Program
    {

        static string JoinWithAnd(List<string> items, bool useSerialComma = true)
        {
            if (items.Count == 0)
            {
                return "";
            }
            else if (items.Count == 1)
            {
                return items[0];
            }
            else if (items.Count == 2)
            {
                return ($"{items[0]} and {items[1]}");
            }
            else
            {
                var itemsCopy = new List<string>(items);
                if (useSerialComma)
                {
                    itemsCopy[itemsCopy.Count - 1] = $"and {itemsCopy[itemsCopy.Count - 1]}";
                }
                else
                {
                    int lastItemIndex = itemsCopy.Count - 1;
                    string lastItem = itemsCopy[lastItemIndex];

                    int secondToLastItemIndex = itemsCopy.Count - 2;
                    string secondToLastItem = itemsCopy[secondToLastItemIndex];

                    itemsCopy[secondToLastItemIndex] = $"{secondToLastItem} and {lastItem}";
                    itemsCopy.RemoveAt(lastItemIndex);
                }
                return ($" {String.Join(", ", itemsCopy)}");
            }
        }
        static void Main(string[] args)
        {
            var items = new List<string> {"Jazlyn", "Theron", "Dayana", "Rolando"};

            Console.WriteLine($"The heroes in the party are:{JoinWithAnd(items, true)}.");
        }
    }
}
