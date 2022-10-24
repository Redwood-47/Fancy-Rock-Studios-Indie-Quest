﻿using System;

namespace Algorithm_Design
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int y = -10; y <= 10; y++)
            {
                for (int x = 1; x <= 80; x++)
                {
                    double r = 0;
                    double i = 0;
                    int k = -1;

                    while (Math.Pow(r, 2) + Math.Pow(i, 2) < 11 & k < 112)
                    {
                        double t = r;
                        r = Math.Pow(t, 2) - Math.Pow(i, 2) - 2.3 + x / 24.5;
                        i = 2 * t * i + y / 8.5;
                        k++;
                    }
                    int c = k % 16;
                    Console.BackgroundColor = (ConsoleColor) c;
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}