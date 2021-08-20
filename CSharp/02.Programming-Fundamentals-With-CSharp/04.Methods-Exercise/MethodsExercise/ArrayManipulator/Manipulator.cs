// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace ArrayManipulator
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Manipulator
    {
        private static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray()
                ?? new int[] { };

            string input = Console.ReadLine() ?? throw new ArgumentException(nameof(input));
            while (input != "end")
            {
                string[] commandParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];
                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(commandParts[1]);
                        ExchangeArray(numbers, index);
                        break;

                    case "max":
                        string parity = commandParts[1];
                        int maxIndex = GetMaxIndex(numbers, parity);
                        Console.WriteLine(maxIndex >= 0 ? maxIndex.ToString() : "No matches");
                        break;

                    case "min":
                        parity = commandParts[1];
                        int minIndex = GetMinIndex(numbers, parity);
                        Console.WriteLine(minIndex >= 0 ? minIndex.ToString() : "No matches");
                        break;

                    case "first":
                        int count = int.Parse(commandParts[1]);
                        parity = commandParts[2];
                        GetFirstElements(numbers, count, parity);
                        break;

                    case "last":
                        count = int.Parse(commandParts[1]);
                        parity = commandParts[2];
                        GetLastElements(numbers, count, parity);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine() ?? throw new ArgumentException(nameof(input));
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void GetLastElements(int[] numbers, int count, string parity)
        {
            if (numbers.Length < count)
            {
                Console.WriteLine("Invalid count");
            }

            int[] elements = new int[numbers.Length];
            int realLength = 0;

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = -1;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (parity == "even")
                {
                    if (number % 2 == 0)
                    {
                        elements[realLength] = number;
                        realLength++;
                    }
                }

                if (parity == "odd")
                {
                    if (number % 2 != 0)
                    {
                        elements[realLength] = number;
                        realLength++;
                    }
                }
            }

            if (realLength > count)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.Write($"{elements[i]} ");
                }
            }
            else if (realLength <= count)
            {
                for (int i = 0; i < realLength; i++)
                {
                    Console.Write($"{elements[i]} ");
                }
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private static void GetFirstElements(int[] numbers, int count, string parity)
        {
            if (numbers.Length < count)
            {
                Console.WriteLine("Invalid count");
            }

            Console.Write("[");
            int foundNumbers = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (parity == "even")
                {
                    if (number % 2 == 0)
                    {
                        Console.Write($"{number} ");
                        foundNumbers++;
                        if (foundNumbers == count)
                        {
                            break;
                        }
                    }
                }
                
                if (parity == "odd")
                {
                    if (number % 2 != 0)
                    {
                        Console.Write($"{number} ");
                        foundNumbers++;
                        if (foundNumbers == count)
                        {
                            break;
                        }
                    }
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }

        private static int GetMinIndex(int[] numbers, string parity)
        {
            int minNumber = int.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (parity == "even")
                {
                    if (number % 2 == 0 && number <= minNumber)
                    {
                        minNumber = number;
                        minIndex = i;
                    }
                }
                else if (parity == "odd")
                {
                    if (number % 2 != 0 && number <= minNumber)
                    {
                        minNumber = number;
                        minIndex = i;
                    }
                }
            }

            return minIndex;
        }

        private static int GetMaxIndex(int[] numbers, string parity)
        {
            int maxIndex = -1;
            if (parity == "even")
            {
                maxIndex = GetMaxEvenIndex(numbers);
            }
            else
            {
                maxIndex = GetMaxOddIndex(numbers);
            }

            return maxIndex;
        }

        private static int GetMaxOddIndex(int[] numbers)
        {
            int maxOddIndex = -1;
            int maxOddValue = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0 && numbers[i] >= maxOddValue)
                {
                    maxOddValue = numbers[i];
                    maxOddIndex = i;
                }
            }

            return maxOddIndex;
        }

        private static int GetMaxEvenIndex(int[] numbers)
        {
            int maxNumber = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                {
                    if (number % 2 == 0 && number >= maxNumber)
                    {
                        maxNumber = number;
                        maxIndex = i;
                    }
                }
            }

            return maxIndex;
        }

        private static void ExchangeArray(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= index; i++)
            {
                int temp = numbers[0];
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }

                numbers[^1] = temp;
            }
        }
    }
}