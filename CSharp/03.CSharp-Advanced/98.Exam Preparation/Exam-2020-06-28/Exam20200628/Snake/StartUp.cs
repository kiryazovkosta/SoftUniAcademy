using System;

namespace Snake
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int snakeRow = 0;
            int snakeCol = 0;

            int burrowRowA = -1;
            int burrowRowB = -1;
            int burrowColA = -1;
            int burrowColB = -1;

            int foodQuantity = 0;

            char[,] board = new char[n, n];
            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int colIndex = 0; colIndex < board.GetLength(1); colIndex++)
                {
                    board[rowIndex, colIndex] = row[colIndex];

                    if (row[colIndex] == 'S')
                    {
                        snakeRow = rowIndex;
                        snakeCol = colIndex;
                    }

                    if (row[colIndex] == 'B')
                    {
                        if (burrowRowA < 0)
                        {
                            burrowRowA = rowIndex;
                            burrowColA = colIndex;
                        }
                        else
                        {
                            burrowRowB = rowIndex;
                            burrowColB = colIndex;
                        }
                    }
                }
            }

            while (foodQuantity < 10)
            {
                board[snakeRow, snakeCol] = '.';

                string command = Console.ReadLine();
                if (command == "up")
                {
                    if (snakeRow - 1 < 0)
                    {
                        break;
                    }

                    snakeRow--;
                }
                else if (command == "down")
                {
                    if (snakeRow + 1 >= board.GetLength(0))
                    {
                        break;
                    }

                    snakeRow++;
                }
                else if (command == "left")
                {
                    if (snakeCol - 1 < 0)
                    {
                        break;
                    }

                    snakeCol--;
                }
                else if (command == "right")
                {
                    if (snakeCol + 1 >= board.GetLength(1))
                    {
                        break;
                    }

                    snakeCol++;
                }

                if (board[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }
                else if (board[snakeRow, snakeCol] == 'B')
                {
                    board[snakeRow, snakeCol] = '.';
                    if (snakeRow == burrowRowA && snakeCol == burrowColA)
                    {
                        snakeRow = burrowRowB;
                        snakeCol = burrowColB;
                    }
                    else
                    {
                        snakeRow = burrowRowA;
                        snakeCol = burrowColA;
                    }
                }

                board[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine(foodQuantity >= 10 ? "You won! You fed the snake." : "Game over!");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            Print(board);
        }

        private static void Print(char[,] board)
        {
            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < board.GetLength(1); colIndex++)
                {
                    Console.Write(board[rowIndex, colIndex]);
                }

                Console.WriteLine();
            }
        }
    }
}
