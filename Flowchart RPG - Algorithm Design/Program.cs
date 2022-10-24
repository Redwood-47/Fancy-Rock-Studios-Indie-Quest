using System;
using System.Collections.Generic;

namespace Flowchart_RPG___Algorithm_Design
{
    internal class Program
    {
        static string JoinWithAnd(List<string> items, bool useSerialComma = false)
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
                return $"{items[0]} and {items[1]}";   
            }
            else
            {
                var itemsCopy = new List<string>(items);
                if (useSerialComma)
                {
                    itemsCopy[itemsCopy.Count-1] = $"and {itemsCopy[itemsCopy.Count-1]}";
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
                return String.Join(", ", itemsCopy);
            }
        }
        static void Main(string[] args)
        {
            var items = new List<string> { "Sinclair", "Hector", "Foul Fritjoff", "Aubrek", };
            Console.WriteLine($"On a pirate ship, we can see the crew of {JoinWithAnd(items)} standing proudly on the ship.");
        }
    }
}
