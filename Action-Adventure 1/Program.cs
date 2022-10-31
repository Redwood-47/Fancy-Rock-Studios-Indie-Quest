using System;
using System.IO;
using System.Text.RegularExpressions;


namespace Action_Adventure_1
{
    internal class Program
    {
        static Random random = new();
        //Map Variables
        static int width;
        static int height;
        static char[,] map;
        static char treeSprite = '♠';
        static ConsoleColor treeColor = ConsoleColor.DarkGreen;
        static ConsoleColor wallColor = ConsoleColor.DarkBlue;

        //Enemy Variable
        static int minotaurX;
        static int minotaurY;
        static char minotaurSprite = '♂';
        static ConsoleColor minotaurColor = ConsoleColor.Red;


        //Player Variables
        static int playerX;
        static int playerY;
        static char playerSprite = '☻';
        static ConsoleColor playerColor = ConsoleColor.DarkYellow;

        /// <summary>
        /// This method draws the map for the game.
        /// </summary>
        static void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == playerX && y == playerY)
                    {
                        Console.ForegroundColor = playerColor;
                        Console.Write(playerSprite);
                    }
                    else if (x == minotaurX && y == minotaurY)
                    {
                        Console.ForegroundColor = minotaurColor;
                        Console.Write(minotaurSprite);
                    }
                    else if (map[x, y] == treeSprite)
                    {
                        Console.ForegroundColor = treeColor;
                        Console.Write(treeSprite);
                    }
                    else
                    {
                        Console.ForegroundColor = wallColor;
                        Console.Write(map[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] mazeLevelLines = File.ReadAllLines("MazeLevel.txt");

            // Determine Level name
            string levelName = mazeLevelLines[0];

            // Determine level size
            string[] levelSizeParts = mazeLevelLines[1].Split('x');
            string levelHeightText = levelSizeParts[1];
            string levelWidthText = levelSizeParts[0];
            width = Convert.ToInt32(levelWidthText);
            height = Convert.ToInt32(levelHeightText);


            //Setting Up The Map
            map = new char[width, height];
            for (int y = 0; y < height; y++)
            {
                string currentLevelLine = mazeLevelLines[y + 2];
                for (int x = 0; x < width; x++)
                {
                    if (currentLevelLine[x] == 'S')
                    {
                        map[x, y] = ' ';
                        playerX = x;
                        playerY = y;
                    }
                    else if (currentLevelLine[x] == 'M')
                    {
                        map[x, y] = ' ';
                        minotaurX = x;
                        minotaurY = y;
                    }
                    else
                    {
                        map[x, y] = currentLevelLine[x];
                    }
                }
            }

            //Generate Trees
            for (int i = 0; i < 20; i++)
            {
                int treeX = random.Next(width);
                int treeY = random.Next(3);
                map[treeX, treeY] = treeSprite;
            }

            Console.WriteLine($"Get ready to experience: {levelName}");
            Console.WriteLine("Press any key to start:");
            Console.ReadKey();
            Console.Clear();

            //Draw Map For First Time
            DrawMap();

            //LOOP
            while (true)
            {

                if (Console.KeyAvailable)
                {
                    //Move Player

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    ConsoleKey pressedKey = keyInfo.Key;

                    if (pressedKey == ConsoleKey.RightArrow && playerX < width - 1)
                    {
                        if (map[playerX + 1, playerY] == ' ')
                        {
                            playerX++;
                        }
                    }
                    else if (pressedKey == ConsoleKey.LeftArrow && playerX > 0)
                    {
                        if (map[playerX - 1, playerY] == ' ')
                        {
                            playerX--;
                        }
                    }
                    else if (pressedKey == ConsoleKey.UpArrow && playerY > 0)
                    {
                        if (map[playerX, playerY - 1] == ' ')
                        {
                            playerY--;
                        }
                    }
                    else if (pressedKey == ConsoleKey.DownArrow && playerY < height - 1)
                    {
                        if (map[playerX, playerY + 1] == ' ')
                        {
                            playerY++;
                        }
                    }
                    else if (pressedKey == ConsoleKey.Escape)
                    {
                        return;
                    }
                }

                if (playerX == minotaurX && playerY == minotaurY)
                {
                    DrawMap();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Congratulations, you found the lost minotaur baby!");
                    return;
                }

                int minotaurDirection = random.Next(37, 41);
                ConsoleKey minotaurAI = (ConsoleKey)minotaurDirection;
                if (minotaurAI == ConsoleKey.RightArrow && minotaurX < width - 1)
                {
                    if (map[minotaurX + 1, minotaurY] == ' ')
                    {
                        minotaurX++;
                    }
                }
                else if (minotaurAI == ConsoleKey.LeftArrow && minotaurX > 0)
                {
                    if (map[minotaurX - 1, minotaurY] == ' ')
                    {
                        minotaurX--;
                    }
                }
                else if (minotaurAI == ConsoleKey.UpArrow && minotaurY > 0)
                {
                    if (map[minotaurX, minotaurY - 1] == ' ')
                    {
                        minotaurY--;
                    }
                }
                else if (minotaurAI == ConsoleKey.DownArrow && minotaurY < height - 1)
                {
                    if (map[minotaurX, minotaurY + 1] == ' ')
                    {
                        minotaurY++;
                    }
                }
                DrawMap();
            }



        }
    }
}
