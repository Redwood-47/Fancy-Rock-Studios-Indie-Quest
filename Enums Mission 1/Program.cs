using System;
using System.IO;

namespace Enums_Mission_1
{
    internal class Program
    {
        enum Suit
        {
            Heart,
            Spade,
            Diamond,
            Club
        }
        static char GetSuitSymbol(Suit suit)
        {
            //Determine Which Suit
            char symbol;
            if (suit == Suit.Heart)
            {
                symbol = '♥';
            }
            else if (suit == Suit.Spade)
            {
                symbol = '♠';
            }
            else if (suit == Suit.Diamond)
            {
                symbol = '♦';
            }
            else
            {
                symbol = '♣';
            }
            return symbol;
        }
        static void DrawCard(Suit suit, int rank)
        {
            string[] allCardLines = File.ReadAllLines("Card.txt");
            int startIndex = (rank - 1) * 10;
            int endIndex = startIndex + 8;

            string[] cardLines = allCardLines[startIndex..(endIndex + 1)];
            string cardText = string.Join("\n", cardLines);
            Console.WriteLine(cardText.Replace('♠', GetSuitSymbol(suit)));
        }
        static void DrawAce3(Suit suit)
        {
            Console.WriteLine(File.ReadAllText("Ace.txt").Replace('♠', GetSuitSymbol(suit)));
        }
        static void DrawAce2(Suit suit)
        {
            char symbol = GetSuitSymbol(suit);
            Console.WriteLine($"╭───────╮");
            Console.WriteLine($"│A      │");
            Console.WriteLine($"│{symbol}      │");
            Console.WriteLine($"│   {symbol}   │");
            Console.WriteLine($"│      {symbol}│");
            Console.WriteLine($"│      A│");
            Console.WriteLine($"╰───────╯");

        }
        static void DrawAce1(Suit suit)
        {
            char symbol = GetSuitSymbol(suit);
            int cardHeight = 7;
            int cardWidth = 9;
            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    //Determine cardborders
                    bool isFlatSide = y == 0 || y == cardHeight - 1;
                    bool isStraightSide = x == 0 || x == cardWidth - 1;

                    //Determine suit placement
                    bool isSuitPlacement = (y == 2 && x == 1) || (y == cardHeight - 3 && x == cardWidth - 2) || (y == cardHeight / 2 && x == cardWidth / 2);

                    //Determine ace placement
                    bool isAce = (y == 1 && x == 1) || (y == cardHeight - 2 && x == cardWidth - 2);
                    //Draw Cardborders
                    if (isFlatSide && isStraightSide)
                    {
                        Console.Write('+');
                        continue;
                    }
                    else if (isStraightSide)
                    {
                        Console.Write('|');
                        continue;
                    }
                    else if (isFlatSide)
                    {
                        Console.Write('-');
                        continue;
                    }

                    //Draw Ace
                    if (isAce)
                    {
                        Console.Write('A');
                        continue;
                    }

                    //Draw suit
                    if (isSuitPlacement)
                    {
                        Console.Write(symbol);
                        continue;
                    }

                    //If blank space, write blank
                    Console.Write(' ');
                    continue;
                }
                //New Line
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DrawAce1(Suit.Diamond);
            DrawAce2(Suit.Spade);
            DrawAce3(Suit.Heart);

            Suit[] suits = Enum.GetValues<Suit>();
            foreach (Suit suit in suits)
            {
                for (int rank = 1; rank < 14; rank++)
                {
                    DrawCard(suit, rank);
                }
            }

        }
    }
}
