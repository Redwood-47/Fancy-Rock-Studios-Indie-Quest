using System;
using System.Collections.Generic;

namespace Algorithm_Design___Unit_4
{
    internal class Program
    {
        static Random random = new Random();

        static void Map(int width, int height)
        {
            var trees = new List<string>();
            trees.Add("%");
            trees.Add("Y");
            trees.Add("A");
            trees.Add("O");
            trees.Add("@");
            trees.Add("8");

            int[] horizontalRoad = new int[width];
            int roadY = height / 2;
            
            int[] verticalRiver = new int[height];
            int riverX = width * 3 / 4;

            int bridgeMin = 0;
            int bridgeMax = 0;
            int bridgeY = 0;


            for (int i = 0; i < height; i++)
            {
                verticalRiver[i] = riverX;
                int randomCurve = random.Next(3);
                if (randomCurve == 1)
                {
                   riverX++;
                }
                else if (randomCurve == 2)
                {
                   riverX--;
                }
                
            }

            for (int x = 0; x < width; x++)
            {
                

                horizontalRoad[x] = roadY;
                int riverCenterX = verticalRiver[roadY];
                int potentialBridgeMin = riverCenterX - 5;
                int potentialBridgeMax = riverCenterX + 5;
                bool onBridge = x >= potentialBridgeMin && x <= potentialBridgeMax;


                if (onBridge)
                {
                    bridgeMin = potentialBridgeMin;
                    bridgeMax = potentialBridgeMax;
                    bridgeY = roadY;
                }
                else
                {
                    int randomCurve = random.Next(3);

                    if (randomCurve == 1 && roadY < height - 2)
                    {
                        roadY++;
                    }
                    else if (randomCurve == 2 && roadY > 1)
                    {
                        roadY--;
                    }
                }
            }

            string title = "ADVENTURE MAP";
            int spacings = width - title.Length;
            int spacing = spacings / 2;


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
                    int riverOffsetMin = -1;
                    int riverOffsetMax = 1;

                    if (isCorner)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('+');
                        continue;
                    }
                    else if (isFlatBorder)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('-');
                        continue;
                    }
                    else if (isThinBorder && x <= width)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write('|');
                        continue;
                    }
                    else if (x == spacing && y == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(title);
                        x = x + title.Length - 1;
                        continue;
                    }
                    else if (horizontalRoad[x] == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write('#');
                        continue;
                    }
                    else if (x >= bridgeMin && x <= bridgeMax && (y == bridgeY - 1 || y == bridgeY + 1))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write('=');
                        continue;
                    }
                    else if (verticalRiver[y] >= x + riverOffsetMin && verticalRiver[y] <= x + riverOffsetMax)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        if (verticalRiver[y -1] > verticalRiver[y])
                        {
                            Console.Write('/');
                        }
                        else if (verticalRiver[y -1] < verticalRiver[y])
                        {
                            Console.Write('\\');
                        }
                        else
                        {
                            Console.Write('|');
                        }
                        continue;
                    }
                    else if (x == verticalRiver[y] - 8 && y > horizontalRoad[x])
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write('#');
                        continue;
                    }
                    else if (isForest && x < width / 10 && shouldAddForest == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(trees[random.Next(6)]);
                        continue;
                    }
                    else if (x <= width - 1)
                    {
                        Console.Write(' ');
                        continue;
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int width = 75;
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
