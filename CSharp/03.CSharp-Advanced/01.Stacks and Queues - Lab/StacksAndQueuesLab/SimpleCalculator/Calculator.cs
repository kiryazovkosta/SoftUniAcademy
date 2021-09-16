namespace SimpleCalculator
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class Calculator
    {
        private static void Main(string[] args)
        {
            bool isPositive = true;
            Stack<int> numbers = new Stack<int>();
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in data)
            {
                if (element == "+")
                {
                    isPositive = true;
                } else if (element == "-")
                {
                    isPositive = false;
                }
                else
                {
                    int number = int.Parse(element);
                    if (isPositive == false)
                    {
                        number *= -1;
                    }

                    numbers.Push(number);
                }
            }

            long result = 0;
            while (numbers.Count > 0)
            {
                result += numbers.Pop();
            }

            Console.WriteLine(result);
        }
    }
}