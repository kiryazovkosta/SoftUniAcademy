namespace MatchingBrackets
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class Brackets
    {
        private static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> openBracketsIndexes = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openBracketsIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = openBracketsIndexes.Pop();
                    int endIndex = i + 1;
                    Console.WriteLine(expression.Substring(startIndex, endIndex - startIndex));
                }
            }
        }
    }
}