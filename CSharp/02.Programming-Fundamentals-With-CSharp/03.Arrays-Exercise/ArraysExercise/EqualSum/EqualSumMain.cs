namespace EqualSum
{
    using System;
    using System.Linq;

    public class EqualSumMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                .ToArray() ?? new int[] { };
            bool found = false;
            int index = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                long leftSideSum = 0;
                long rightSideSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSideSum += numbers[j];
                }

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    rightSideSum += numbers[j];
                }

                if (leftSideSum == rightSideSum)
                {
                    found = true;
                    index = i;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
