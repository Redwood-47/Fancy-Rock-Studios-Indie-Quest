using System;
using System.Collections.Generic;

namespace Algorithm_Design___Unit_5_Anton
{
    internal class Program
    {
        static Random random = new Random();

        public int width = 75;
        public int height = 25;

        static int[] GenerateCurve(int mapHeight, int startX, int curveChance) 
        {
            int[] curveValues = new int[mapHeight];
            int curveX = startX;
            for (int i = 0; i < mapHeight; i++)
            {
                curveValues[i] = curveX;

                int curveRandom = random.Next(curveChance);
                if (curveRandom == 0)
                {
                    curveX++;
                }
                else if (curveRandom == 1)
                {
                    curveX--;
                }
            }
            return curveValues;
        }

        static bool DrawCurve(int[] curve, int positionY, int positionX, int minOffset, int maxOffset, ConsoleColor color)
        {
            int curveMin = curve[positionY] + minOffset;
            int curveMax = curve[positionY] + maxOffset;
            if (positionX >= curveMin && positionX <= curveMax)
            {
                int currentCurveX = curve[positionY];
                int previousCurveX = curve[positionY - 1];
                int curveXDelta = currentCurveX - previousCurveX;

                Console.ForegroundColor = color;

                if (curveXDelta < 0)
                {
                    Console.Write('/');
                }
                else if (curveXDelta > 0)
                {
                    Console.Write(@"\");
                }
                else
                {
                    Console.Write('|');
                }
                return true;
            }
            return false;
        }

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

            int[] verticalRiver = GenerateCurve(height, width * 3 / 4, 3);

            int[] wall = GenerateCurve(height, width * 1 / 4, 20);

            int bridgeMin = 0;
            int bridgeMax = 0;
            int bridgeY = 0;

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
                    else if (DrawCurve(verticalRiver, y, x, -1, 1, ConsoleColor.DarkBlue))
                    {
                        continue;
                    }
                    else if (x == verticalRiver[y] - 8 && y > horizontalRoad[x])
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write('#');
                        continue;
                    }
                    else if (DrawCurve(wall, y, x, 0, 1, ConsoleColor.DarkGray))
                    {
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
            //Console.SetWindowSize(width, height);
            //Console.SetBufferSize(width, height);
            int width = 75;
            int height = 25;
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
