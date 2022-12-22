using System;
using System.Collections.Generic;

namespace Algorithm_Design_Unit_3_Anton
{
    internal class Program
    {
        static Random random = new Random();

        static void Map (int width, int height)
        {
            var trees = new List<string>();
            trees.Add("%");
            trees.Add("Y");
            trees.Add("A");
            trees.Add("O");
            trees.Add("@");
            trees.Add("8");

            for (int y = 0; y < height; y++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int x = 0; x < width; x++)
                {
                    bool isFlatBorder = (y == 0 || y == height - 1);
                    bool isThinBorder = (x == 0 || x == width - 1);
                    bool isCorner = isThinBorder && isFlatBorder;
                    bool isForest = !isThinBorder && !isFlatBorder && !isCorner;
                    int shouldAddForest = random.Next(2);

                    
                    if (isCorner)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('+');
                    }
                    else if (isFlatBorder)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('-');
                    }
                    else if (isThinBorder && x <= width)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('|');
                    }
                    else if (isForest && x < width / 4 && shouldAddForest == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(trees[random.Next(6)]);
                    }
                    else if (x <= width -1)
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int width = 50;
            int height = 25;

            //Console.SetWindowSize(width, height);
            //Console.SetBufferSize(width, height);
            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Map(width, height);
                Console.ReadKey(true);
            }
        }
    }
}
