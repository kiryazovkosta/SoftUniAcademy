using System;

namespace EqualArrays
{
    using System.Linq;

    public class EqualArrayMain
    {
        public static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };

            int[] secondArray = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };

            int differenceIndex = int.MinValue;
            long sum = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    differenceIndex = i;
                    break;
                }

                sum += firstArray[i];
            }

            Console.WriteLine(differenceIndex < 0
                ? $"Arrays are identical. Sum: {sum}"
                : $"Arrays are not identical. Found difference at {differenceIndex} index");
        }
    }
}
