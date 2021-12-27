using System;

namespace Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int aRow = -1;
            int aCol = -1;

            int m1Row = -1;
            int m1Col = -1;
            int m2Row = -1;
            int m2Col = -1;

            int amount = 0;

            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < row.Length; j++)
                {
                    board[i, j] = row[j];
                    if (row[j] == 'A')
                    {
                        aRow = i;
                        aCol = j;
                    }
                    else if (row[j] == 'M')
                    {
                        if (m1Row == -1)
                        {
                            m1Row = i;
                            m1Col = j;
                        }
                        else
                        {
                            m2Row = i;
                            m2Col = j;
                        }
                    }
                }
            }

            while (true)
            {
                board[aRow, aCol] = '-';
                string direction = Console.ReadLine();
                if (direction == "up")
                {
                    int newRow = aRow - 1;
                    int newCol = aCol;
   
                    if(IsOutsideBoards(newRow, newCol, n))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (MoveOfficer(board, newRow, newCol, m1Row, m1Col, m2Row, m2Col, ref amount, ref aRow, ref aCol))
                    {
                        break;
                    }
                }
                else if (direction == "down")
                {
                    int newRow = aRow + 1;
                    int newCol = aCol;

                    if (IsOutsideBoards(newRow, newCol, n))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (MoveOfficer(board, newRow, newCol, m1Row, m1Col, m2Row, m2Col, ref amount, ref aRow, ref aCol))
                    {
                        break;
                    }
                }
                else if (direction == "left")
                {
                    int newRow = aRow;
                    int newCol = aCol - 1;

                    if (IsOutsideBoards(newRow, newCol, n))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (MoveOfficer(board, newRow, newCol, m1Row, m1Col, m2Row, m2Col, ref amount, ref aRow, ref aCol))
                    {
                        break;
                    }
                }
                else if (direction == "right")
                {
                    int newRow = aRow;
                    int newCol = aCol + 1;

                    if (IsOutsideBoards(newRow, newCol, n))
                    {
                        Console.WriteLine("I do not need more swords!");
                        break;
                    }

                    if (MoveOfficer(board, newRow, newCol, m1Row, m1Col, m2Row, m2Col, ref amount, ref aRow, ref aCol))
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"The king paid {amount} gold coins.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsOutsideBoards(int aRow, int aCol, int n)
        {
            if (aRow < 0 || aRow >= n || aCol < 0 || aCol >= n)
            {
                return true;
            }

            return false;
        }

        private static bool MoveOfficer(char[,] board, int newRow, int newCol, int m1Row, int m1Col, int m2Row, int m2Col,
            ref int amount, ref int aRow, ref int aCol)
        {
            char position = board[newRow, newCol];
            if (Char.IsDigit(position))
            {
                amount += position - '0';
                if (amount >= 65)
                {
                    board[newRow, newCol] = 'A';
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    return true;
                }
            }
            else if (position == 'M')
            {
                if (newRow == m1Row)
                {
                    board[m1Row, m1Col] = '-';
                    newRow = m2Row;
                    newCol = m2Col;
                }
                else
                {
                    board[m2Row, m2Col] = '-';
                    newRow = m1Row;
                    newCol = m1Col;
                }
            }

            aRow = newRow;
            aCol = newCol;
            board[aRow, aCol] = 'A';
            return false;
        }
    }
}
