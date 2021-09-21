namespace JaggedArrayManipulator
{
    using System;
    using System.Linq;

    public class Manipulator
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[rows][];
            for (int row = 0; row < jagged.Length; row++)
            {
                double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jagged[row] = numbers;
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int r = row; r <= row + 1; r++)
                    {
                        for (int c = 0; c < jagged[r].Length; c++)
                        {
                            jagged[r][c] *= 2;
                        }
                    }
                }
                else
                {
                    for (int r = row; r <= row + 1; r++)
                    {
                        for (int c = 0; c < jagged[r].Length; c++)
                        {
                            jagged[r][c] /= 2;
                        }
                    }
                }
            }


            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "End")
                {
                    break;
                }
                else
                {
                    int r = int.Parse(command[1]);
                    int c = int.Parse(command[2]);
                    if (r < 0 || r >= jagged.Length)
                    {
                        continue;
                    }

                    if (c < 0 || c >= jagged[r].Length)
                    {
                        continue;
                    }

                    int value = int.Parse(command[3]);
                    if (command[0] == "Add")
                    {
                        jagged[r][c] += value;
                    }
                    else
                    {
                        jagged[r][c] -= value;
                    }
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
