using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPGMap
{
    internal class Program
    {
        static char[,] map = new char[,] // dimensions defined by following data:
        {
            {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','~','~','~','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','*','*','*','`','`','`','`','`','`','*','*','`','`','^','^','`','`','~','~','~','`','`','`','`','`','`','`','`','`'},
            {'^','`','`','`','`','`','*','`','`','`','`','*','`','`','*','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','~','`','`','`','*','*','`','`','`','`','^','^','`','`','`','`','*','*','`','`','`','`','*','*','*','`','`'},
            {'`','`','`','~','~','~','~','~','~','`','*','*','*','`','`','`','^','^','`','`','`','`','`','`','`','`','`','`','`','`','*','`','`','`'},
            {'`','`','`','~','~','~','~','~','~','`','`','*','`','`','`','^','^','`','`','`','*','`','^','^','`','`','`','*','`','`','`','`','`','`'},
            {'`','*','`','~','~','~','~','~','~','`','`','`','`','`','`','^','^','`','`','*','`','^','^','^','^','`','`','`','`','`','`','`','*','`'},
            {'`','`','`','`','~','~','~','~','~','`','`','`','`','`','`','^','^','`','*','*','`','`','`','^','^','^','^','`','`','*','`','`','*','`'},
            {'`','`','`','`','`','`','`','~','~','~','`','`','`','`','^','^','`','`','*','`','`','`','~','~','~','`','`','`','`','*','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','~','~','~','`','`','^','^','^','`','`','`','`','`','~','~','~','~','~','`','`','*','`','`','`','`','`'},
            {'`','*','*','`','`','`','`','`','`','~','~','~','^','^','^','`','~','~','~','~','~','~','~','~','~','~','`','`','`','`','`','*','`','`'},
            {'`','`','A','`','`','`','*','`','`','`','~','^','^','^','`','~','~','~','~','~','~','~','`','~','~','`','`','A','A','A','`','`','`','`'},
            {'`','A','A','*','`','`','`','`','`','`','^','^','^','~','~','~','~','~','`','`','`','`','`','`','`','`','`','`','A','`','*','*','`','`'},
            {'`','`','*','`','`','`','`','`','`','`','^','^','^','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','A','`','*','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','*','`','`'},
        };

        static void WriteMapChar(int y, int x)
        {
            if (map[y, x] == '^')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('▲');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (map[y, x] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('♣');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (map[y, x] == '`')
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(',');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (map[y, x] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write('»');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (map[y, x] == 'A')
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('⌂');
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(map[y, x]);
            }
        }

        static void ShowLegend()
        {
            Console.WriteLine("▲ - Mountains");
            Console.WriteLine("» - Rivers");
            Console.WriteLine(", - Grass");
            Console.WriteLine("♣ - Trees");
            Console.WriteLine("⌂ - Towns");
            Console.WriteLine();
        }

        static void DisplayMap(int scale)
        {
            Console.Write('┼');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int z = 0; z < scale; z++)
                {
                    Console.Write('─');
                }
            }
            Console.Write('┼');
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int c = 0; c < scale; c++)
                {
                    Console.Write('│');
                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        for (int z = 0; z < scale; z++)
                        {
                            WriteMapChar(y, x);
                        }
                    }
                    Console.Write('│');
                    Console.WriteLine();
                }
            }
            Console.Write('┼');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int z = 0; z < scale; z++)
                {
                    Console.Write('─');
                }
            }
            Console.Write('┼');

            Console.WriteLine();
            Console.WriteLine();
        }

        static void DisplayMap()
        {
            Console.Write('┼');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write('─');
            }
            Console.Write('┼');
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                Console.Write('│');
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    WriteMapChar(y, x);
                }
                Console.Write('│');
                Console.WriteLine();
            }
            Console.Write('┼');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write('─');
            }
            Console.Write('┼');

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ShowLegend();
            DisplayMap();
            DisplayMap(1);
            DisplayMap(2);
            DisplayMap(3);

            Console.WriteLine("Press any key to exit...");
            Console.WriteLine('»');
            Console.ReadLine();
        }
    }
}
