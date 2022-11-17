using System;
using System.IO;

namespace Algorith_Design_Unit_3
{
    internal class Program
    {
        static Random random = new Random();
        /// <summary>
        /// Draw a piece of the border.
        /// </summary>
        /// <param name="symbol">Draw the specific symbol.</param>
        static void DrawMapBorder(char symbol)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(symbol);
        }

        static void DrawCrabSymbol(char symbol)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(symbol);
        }
        static void DrawTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(title);
        }
        /// <summary>
        /// Draws a piece of the road.
        /// </summary>
        static void DrawRoad()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write('#');
        }

        /// <summary>
        /// Draws a random green tree.
        /// </summary>
        static void DrawTree()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //Randomizing what tree will be drawn
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
        /// <summary>
        /// Draws the bridge.
        /// </summary>
        static void DrawBridge()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write('=');
        }
        /// <summary>
        /// Draws a turret.
        /// </summary>
        static void DrawTurret()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("[]");
        }

        static int[] GenerateCurve(int mapHeight, int startX, int curveChance)
        {
            //Generate curve coordinates
            int[] curveValues = new int[mapHeight];
            int curveX = startX;
            for (int y = 0; y < mapHeight; y++)
            {
                curveValues[y] = curveX;

                //Determine if curve should change direction
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
            //Check if on the curve
            int curveMin = curve[positionY] + minOffset;
            int curveMax = curve[positionY] + maxOffset;
            if (positionX >= curveMin && positionX <= curveMax)
            {
                //Determine curve direction
                int currentCurveX = curve[positionY];
                int previousCurveX = curve[positionY - 1];
                int curveXDelta = currentCurveX - previousCurveX;

                //Draw the corresponding symbol
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

            //Calculate Title
            string title = "Sinclair's Despair";
            int spacing = (width - title.Length) / 2;
            int titleStart = spacing;

            //Prepare River
            int[] river = GenerateCurve(height, width * 3 / 4, 2);

            //Prepare Wall
            int[] wall = GenerateCurve(height, width / 4, 6);


            //Prepare Road And Bridge
            int bridgeMin = 0;
            int bridgeMax = 0;
            int bridgeY = 0;
            int gateY = 0;

            int[] horizontalRoad = new int[width];
            int roadY = height / 5;
            for (int x = 0; x < width; x++)
            {
                //Straighten the road at bridge
                horizontalRoad[x] = roadY;
                int riverCenterX = river[roadY];
                int potentialBridgeMin = riverCenterX - 5;
                int potentialBridgeMax = riverCenterX + 5;
                bool onBridge = x >= potentialBridgeMin && x <= potentialBridgeMax;

                //Straighten the road between turrets
                int wallLeft = wall[roadY];
                int gateMin = wallLeft - 2;
                int gateMax = wallLeft + 2;
                bool onGate = x >= gateMin && x <= gateMax;

                //Place Road
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
                    int roadTurn = random.Next(10) + 1;
                    if (roadTurn < 5 && roadY < height - 3)
                    {
                        roadY++;
                    }
                    else if (roadTurn == 10 && roadY > 1)
                    {
                        roadY--;
                    }
                }
            }


            //Prepare CRAB
            string[] crabLines = File.ReadAllLines("TextFile1.txt");
            int crabHeight = 4;
            int crabWidth = 14;
            char[,] crabSprite = new char[crabWidth, crabHeight];


            for (int crabY = 0; crabY < crabHeight; crabY++)
            {
                for (int crabX = 0; crabX < crabWidth; crabX++)
                {
                    crabSprite[crabX, crabY] = crabLines[crabY][crabX];
                }
            }

            int crabPositionX = width - crabWidth - 3;
            int crabPositionY = horizontalRoad[crabPositionX] - crabHeight;

            //Draw The Map
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

                    //Draw Crab in top right corner
                    int crabY = y - crabPositionY;
                    int crabX = x - crabPositionX;
                    if (y < crabPositionY + crabHeight && y >= crabPositionY && x >= crabPositionX && x < crabPositionX + crabWidth && crabSprite[crabX, crabY] != ' ')
                    {
                        DrawCrabSymbol(crabSprite[crabX, crabY]);
                        continue;
                    }

                    //Draw Road
                    if (horizontalRoad[x] == y)
                    {
                        DrawRoad();
                        continue;
                    }

                    //Draw Bridge where the road crosses the river
                    if (x >= bridgeMin && x <= bridgeMax && (y == bridgeY - 1 || y == bridgeY + 1))
                    {
                        DrawBridge();
                        continue;
                    }

                    //Draw Turrets where the road and walls meet
                    if (x == wall[y] && (y == gateY - 1 || y == gateY + 1))
                    {
                        DrawTurret();
                        x++;
                        continue;
                    }

                    //Draw River
                    if (TryDrawCurve(river, y, x, -2, 3, ConsoleColor.DarkBlue))
                    {
                        continue;
                    }

                    //Draw Wall
                    if (TryDrawCurve(wall, y, x, 0, 1, ConsoleColor.Black))
                    {
                        continue;
                    }

                    //Draw SideRoad below main road, 8 characters to the left
                    if (x == river[y] - 8 && y < horizontalRoad[x])
                    {
                        DrawRoad();
                        continue;
                    }

                    //Draw Trees on the left third of the map
                    if (random.Next(x, width) < width / 3 && x < wall[y])
                    {
                        DrawTree();
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
            //Set Map Parameters
            int width = 150;
            int height = 50;

            //Prepare the console
            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);


            //Generate map on keypress
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0, 0);
                Map(width, height);
                Console.ReadKey(true);
            }
        }
    }
}
