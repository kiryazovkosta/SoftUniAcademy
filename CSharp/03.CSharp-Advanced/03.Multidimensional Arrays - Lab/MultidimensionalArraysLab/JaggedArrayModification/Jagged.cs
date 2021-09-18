namespace JaggedArrayModification
{
    using System;
    using System.Linq;

    public class Jagged
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];
            for (int row = 0; row < jagged.Length; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jagged[row] = numbers;
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] operation = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                int row = int.Parse(operation[1]);
                int col = int.Parse(operation[2]);
                int value = int.Parse(operation[3]);

                if (row < 0 || row >= jagged.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }

                if (col < 0 || col >= jagged[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine();
                    continue;
                }

                if (command == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jagged[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
