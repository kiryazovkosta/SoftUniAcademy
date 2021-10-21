namespace Survivor
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            int myTokens = 0;
            int opponentTokens = 0;

            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                string line = Console.ReadLine();
                var col = line.Replace(" ", string.Empty).ToCharArray();
                beach[rowIndex] = col;
            }

            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] data = command.Split(" ");
                string action = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                if (action == "Find")
                {
                    if (row >= 0 && row < rows && col >= 0 && col < beach[row].Length)
                    {
                        if (beach[row][col] == 'T')
                        {
                            myTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if (action == "Opponent")
                {
                    string direction = data[3];
                    if (row >= 0 && row < rows && col >= 0 && col < beach[row].Length)
                    {
                        if (beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }

                        if (direction == "up")
                        {
                            for (int rowIndex = row - 1, counter = 0; rowIndex >= 0 && counter < 3; rowIndex--, counter++)
                            {
                                char[] line = beach[rowIndex];
                                if (col < line.Length)
                                {
                                    if (beach[rowIndex][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[rowIndex][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int rowIndex = row + 1, counter = 0; rowIndex < rows && counter < 3; rowIndex++, counter++)
                            {
                                char[] line = beach[rowIndex];
                                if (col < line.Length)
                                {
                                    if (beach[rowIndex][col] == 'T')
                                    {
                                        opponentTokens++;
                                        beach[rowIndex][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int colIndex = col - 1, counter = 0; colIndex >= 0 && counter < 3; colIndex--, counter++)
                            {
                                if (beach[row][colIndex] == 'T')
                                {
                                    opponentTokens++;
                                    beach[row][colIndex] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int colIndex = col + 1, counter = 0; colIndex < beach[row].Length && counter < 3; colIndex++, counter++)
                            {
                                if (beach[row][colIndex] == 'T')
                                {
                                    opponentTokens++;
                                    beach[row][colIndex] = '-';
                                }
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                Console.WriteLine(string.Join(' ', beach[rowIndex]));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
    }
}
