using System;
using System.Linq;

namespace Garden
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[,] garden = new int[size[0], size[1]];
            for (int rowIndex = 0; rowIndex < garden.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < garden.GetLength(1); colIndex++)
                {
                    garden[rowIndex, colIndex] = 0;
                }
            }

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] positions = input.Split(" ").Select(int.Parse).ToArray();
                int rowIndex = positions[0];
                int colIndex = positions[1];

                if (rowIndex < 0 || rowIndex >= garden.GetLength(1) || colIndex < 0 || colIndex >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    garden[rowIndex, colIndex]++;

                    for (int i = 0; i < garden.GetLength(0); i++)
                    {
                        if (i != rowIndex)
                        {
                            garden[i, colIndex]++;
                        }
                    }

                    for (int j = 0; j < garden.GetLength(1); j++)
                    {
                        if (j != colIndex)
                        {
                            garden[rowIndex, j]++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Print(garden);
        }

        private static void Print(int[,] garden)
        {
            for (int rowIndex = 0; rowIndex < garden.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < garden.GetLength(1); colIndex++)
                {
                    Console.Write($"{garden[rowIndex, colIndex]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
