namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class Reverse
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? string.Empty;
            Stack<char> text = new Stack<char>();
            foreach (char symbol in input)
            {
                text.Push(symbol);
            }

            while (text.Count > 0)
            {
                Console.Write(text.Pop());
            }
        }
    }
}