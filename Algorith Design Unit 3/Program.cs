using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Algorith_Design_Unit_3
{
    internal class Program
    {
        static Random random = new Random();

        static void DrawMapBorder(char symbol)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(symbol);
        }
        static void DrawTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(title);
        }
        static void DrawRoad()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('#');
        }
        static void DrawTrees()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int randomTree = random.Next(4);
            if (randomTree == 0)
            {
                Console.Write('T');
            }
            else if (randomTree == 1)
            {
                Console.Write('Å');
            }
            else if (randomTree == 2)
            {
                Console.Write('$');
            }
            else
            {
                Console.Write('!');
            }
        }
        static void DrawBridge()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write('=');
        }
        static void DrawTurret()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("[]");
        }
        static int[] GenerateCurve(int mapHeight, int mapWidth, int curveChance)
        {
            int[] curveValues = new int[mapHeight];
            int curveX = mapWidth;
            for (int y = 0; y < mapHeight; y++)
            {
                curveValues[y] = curveX;
                int curveTurn = random.Next(curveChance);
                if (curveTurn == 0)
                {
                    curveX++;
                }
                else if (curveTurn == 1)
                {
                    curveX--;
                }
            }
            return curveValues;
        }

        static bool TryDrawCurve(int[] curve, int positionY, int positionX, int minOffset, int maxOffset, ConsoleColor color)
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
                    Console.Write('\\');
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
            
            //Title Equation
            string title = "Helden's Crossing";
            int spacings = width - title.Length;
            int spacing = spacings / 2;
            int titleStart = spacing;

            //Prepare River
            int[] river = GenerateCurve(height, width * 3 / 4, 4);

            //Prepare Wall
            int[] wall = GenerateCurve(height, width / 4, 6);


            //Prepare Road And Bridge
            int bridgeMin = 0;
            int bridgeMax = 0;
            int bridgeY = 0;

            int gateY = 0;

            int[] horizontalRoad = new int[width];
            int roadY = height / 2;
            for (int x = 0; x < width; x++)
            {
                //BridgeRoad preparing
                horizontalRoad[x] = roadY;
                int riverCenterX = river[roadY];
                int potentialBridgeMin = riverCenterX - 5;
                int potentialBridgeMax = riverCenterX + 5;
                bool onBridge = x >= potentialBridgeMin && x <= potentialBridgeMax;

                //TurretRoad preparing
                int wallLeft = wall[roadY];
                int gateMin = wallLeft - 2;
                int gateMax = wallLeft + 2;
                bool onGate = x >= gateMin && x <= gateMax;

                if (onBridge)
                {
                    bridgeMin = potentialBridgeMin;
                    bridgeMax = potentialBridgeMax;
                    bridgeY = roadY;
                }
                else if (onGate)
                {
                    gateY = roadY;
                }
                else
                {
                    int roadTurn = random.Next(4);
                    if (roadTurn == 0 && roadY < height - 2)
                    {
                        roadY++;
                    }
                    else if (roadTurn == 1 && roadY > 1)
                    {
                        roadY--;
                    }
                }
            }
            //Drawing The Map
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //Determine Border
                    bool isFlatBorder = y == 0 || y == height - 1;
                    bool isStraightBorder = x == 0 || x == width - 1;

                    //Draw Border
                    if (isFlatBorder && isStraightBorder)
                    {
                        DrawMapBorder('+');
                        continue;
                    }
                    else if (isFlatBorder)
                    {
                        DrawMapBorder('-');
                        continue;
                    }
                    else if (isStraightBorder)
                    {
                        DrawMapBorder('|');
                        continue;
                    }

                    //Draw Title
                    if (x == titleStart && y == 1)
                    {
                        DrawTitle(title);
                        x += title.Length - 1;
                        continue;
                    }

                    //Draw Road
                    if (horizontalRoad[x] == y)
                    {
                        DrawRoad();
                        continue;
                    }

                    //Draw Bridge
                    if (x >= bridgeMin && x <= bridgeMax && (y == bridgeY -1 || y == bridgeY + 1))
                    {
                        DrawBridge();
                        continue;
                    }

                    //Draw Turret
                    if (x == wall[y] && (y == gateY -1 || y == gateY + 1))
                    {
                        DrawTurret();
                        x++;
                        continue;
                    }
                    //Draw River
                    if (TryDrawCurve(river, y, x, -1, 4, ConsoleColor.Blue))
                    {
                        continue;
                    }

                    //Draw Wall
                    if (TryDrawCurve(wall, y, x, 0, 1, ConsoleColor.Gray))
                    {
                        continue;
                    }

                    //Draw SideRoad
                    if (x == river[y] - 8 && y > horizontalRoad[x])
                    {
                        DrawRoad();
                        continue;
                    }

                    //Draw Trees
                    if (random.Next(x, width) < width / 3 && x < wall[y])
                    {
                        DrawTrees();
                        continue;
                    }
                    //Otherwise, blank space
                    Console.Write(' ');
                }

                //New Line
                if (y < height - 1)
                {
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            int width = 150;
            int height = 50;

            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            while (true)
            {
                Console.SetCursorPosition(0,0);
                Map(width, height);
                Console.ReadKey(true);
            }
        }
    }
}
