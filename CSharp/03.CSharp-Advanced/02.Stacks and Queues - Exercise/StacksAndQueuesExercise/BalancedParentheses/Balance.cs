using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            Stack<char> first = new Stack<char>();
            Queue<char> second = new Queue<char>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (i < sequence.Length / 2)
                {
                    first.Push(sequence[i]);
                }
                else
                {
                    second.Enqueue(sequence[i]);
                }
            }

            if (first.Count != second.Count)
            {
                Console.WriteLine("NO");
            }
            else
            {
                bool areBalanced = true;
                while (first.Count > 0)
                {
                    char open = first.Pop();
                    char close = second.Dequeue();
                    areBalanced = CheckBalance(open, close);
                    if (areBalanced == false)
                    {
                        break;
                    }
                }

                if (areBalanced)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static bool CheckBalance(char open, char close)
        {
            bool areBalanced = false;
            if (open == '(' && close == ')')
            {
                areBalanced = true;
            }
            else if (open == '[' && close == ']')
            {
                areBalanced = true;
            }
            else if (open == '{' && close == '}')
            {
                areBalanced = true;
            }

            return areBalanced;
        }
    }
}
