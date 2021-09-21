namespace BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Balance
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> parenthesis = new Stack<char>();
            Dictionary<char, char> brackets = new Dictionary<char, char>()
            {
                {'{', '}'},
                {'(', ')'},
                {'[', ']'}
            };

            bool isBalances = true;

            for (int i = 0; i < sequence.Length; i++)
            {
                char symbol = sequence[i];
                if (brackets.ContainsKey(symbol))
                {
                    parenthesis.Push(symbol);
                }
                else
                {
                    if (parenthesis.Count == 0)
                    {
                        isBalances = false;
                    }
                    else
                    {
                        char key = brackets.First(v => v.Value == symbol).Key;
                        char bracket = parenthesis.Pop();
                        if (key != bracket)
                        {
                            isBalances = false;
                        }
                    }
                }

                if (isBalances == false)
                {
                    break;
                }
            }

            Console.WriteLine(isBalances ? "YES" : "NO");
        }
    }
}