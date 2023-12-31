﻿using System;
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("▲ - Mountains");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("» - Rivers");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(", - Grass");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("♣ - Trees");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("⌂ - Towns");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void DisplayMap(int scale)
        {
            ShowLegend();
            Console.Write('┌');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int z = 0; z < scale; z++)
                {
                    Console.Write('─');
                }
            }
            Console.Write('┐');
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
            Console.Write('└');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                for (int z = 0; z < scale; z++)
                {
                    Console.Write('─');
                }
            }
            Console.Write('┘');

            Console.WriteLine();
            Console.WriteLine();
        }

        static void DisplayMap()
        {
            ShowLegend();
            Console.Write('┌');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write('─');
            }
            Console.Write('┐');
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
            Console.Write('└');
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write('─');
            }
            Console.Write('┘');

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            DisplayMap();
            DisplayMap(1);
            DisplayMap(2);
            DisplayMap(3);

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
